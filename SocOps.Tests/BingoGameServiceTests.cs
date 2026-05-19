using System.Reflection;
using SocOps.Services;
using Xunit;

namespace SocOps.Tests;

public class BingoGameServiceTests
{
    [Fact]
    public void BingoGameService_ShouldExposeSelectedGameMode()
    {
        var serviceType = typeof(BingoGameService);

        var currentGameMode = serviceType.GetProperty("CurrentGameMode", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(currentGameMode);
        Assert.Equal("GameMode", currentGameMode!.PropertyType.Name);

        var startGame = serviceType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .SingleOrDefault(method => method.Name == "StartGame" && method.GetParameters().Length == 1);
        Assert.NotNull(startGame);
        Assert.Equal("GameMode", startGame!.GetParameters()[0].ParameterType.Name);
    }

    [Fact]
    public void BingoGameService_StoredState_ShouldPersistGameMode()
    {
        var storedGameData = typeof(BingoGameService).GetNestedType("StoredGameData", BindingFlags.NonPublic);

        Assert.NotNull(storedGameData);
        Assert.NotNull(storedGameData!.GetProperty("GameMode", BindingFlags.Public | BindingFlags.Instance));
    }
}
