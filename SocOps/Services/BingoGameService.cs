using SocOps.Models;
using System.Text.Json;
using Microsoft.JSInterop;
using SocOps.Data;

namespace SocOps.Services;

public class BingoGameService
{
    private const string STORAGE_KEY = "bingo-game-state";
    private const int STORAGE_VERSION = 3;

    private readonly IJSRuntime _jsRuntime;

    public GameState CurrentGameState { get; private set; } = GameState.Start;
    public GameMode CurrentGameMode { get; private set; } = GameMode.Bingo;
    public List<BingoSquareData> Board { get; private set; } = new();
    public List<ScavengerItemData> ScavengerItems { get; private set; } = new();
    public BingoLine? WinningLine { get; private set; }
    public HashSet<int> WinningSquareIds => BingoLogicService.GetWinningSquareIds(WinningLine);
    public int ScavengerCompletedCount => ScavengerItems.Count(item => item.IsCompleted);
    public int ScavengerTotalCount => ScavengerItems.Count;
    public double ScavengerProgressPercentage => ScavengerTotalCount == 0
        ? 0
        : ScavengerCompletedCount * 100.0 / ScavengerTotalCount;
    public bool ScavengerIsComplete => ScavengerTotalCount > 0 && ScavengerCompletedCount == ScavengerTotalCount;
    public bool ShowBingoModal { get; private set; }

    public event Action? OnStateChanged;

    public BingoGameService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        await LoadGameStateAsync();
    }

    public void StartGame(GameMode mode = GameMode.Bingo)
    {
        CurrentGameMode = mode;
        ShowBingoModal = false;

        if (mode == GameMode.Bingo)
        {
            Board = BingoLogicService.GenerateBoard();
            ScavengerItems = new();
            WinningLine = null;
            CurrentGameState = GameState.Playing;
        }
        else
        {
            Board = new();
            ScavengerItems = Questions.QuestionsList
                .Select((text, index) => new ScavengerItemData
                {
                    Id = index,
                    Text = text,
                    IsCompleted = false
                })
                .ToList();
            WinningLine = null;
            CurrentGameState = GameState.ScavengerHunt;
        }

        ShowBingoModal = false;
        _ = SaveGameStateAsync();
        NotifyStateChanged();
    }

    public void HandleSquareClick(int squareId)
    {
        Board = BingoLogicService.ToggleSquare(Board, squareId);

        // Check for bingo after toggling
        if (WinningLine == null)
        {
            var bingo = BingoLogicService.CheckBingo(Board);
            if (bingo != null)
            {
                WinningLine = bingo;
                CurrentGameState = GameState.Bingo;
                ShowBingoModal = true;
            }
        }

        _ = SaveGameStateAsync();
        NotifyStateChanged();
    }

    public void ToggleScavengerItem(int itemId)
    {
        var item = ScavengerItems.FirstOrDefault(item => item.Id == itemId);
        if (item == null)
        {
            return;
        }

        item.IsCompleted = !item.IsCompleted;

        _ = SaveGameStateAsync();
        NotifyStateChanged();
    }

    public void ResetGame()
    {
        CurrentGameState = GameState.Start;
        CurrentGameMode = GameMode.Bingo;
        Board = new();
        ScavengerItems = new();
        WinningLine = null;
        ShowBingoModal = false;
        _ = SaveGameStateAsync();
        NotifyStateChanged();
    }

    public void DismissModal()
    {
        ShowBingoModal = false;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnStateChanged?.Invoke();

    private async Task LoadGameStateAsync()
    {
        try
        {
            var saved = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", STORAGE_KEY);
            if (!string.IsNullOrEmpty(saved))
            {
                var data = JsonSerializer.Deserialize<StoredGameData>(saved);
                if (data != null && data.Version == STORAGE_VERSION)
                {
                    CurrentGameState = data.GameState;
                    CurrentGameMode = data.GameMode;
                    Board = data.Board;
                    ScavengerItems = data.ScavengerItems;
                    WinningLine = data.WinningLine;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load game state: {ex.Message}");
        }
    }

    private async Task SaveGameStateAsync()
    {
        try
        {
            var data = new StoredGameData
            {
                Version = STORAGE_VERSION,
                GameState = CurrentGameState,
                GameMode = CurrentGameMode,
                Board = Board,
                ScavengerItems = ScavengerItems,
                WinningLine = WinningLine
            };
            var json = JsonSerializer.Serialize(data);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", STORAGE_KEY, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save game state: {ex.Message}");
        }
    }

    private class StoredGameData
    {
        public int Version { get; set; }
        public GameState GameState { get; set; }
        public GameMode GameMode { get; set; }
        public List<BingoSquareData> Board { get; set; } = new();
        public List<ScavengerItemData> ScavengerItems { get; set; } = new();
        public BingoLine? WinningLine { get; set; }
    }
}
