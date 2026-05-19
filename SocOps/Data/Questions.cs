using System.Collections.Generic;

namespace SocOps.Data;

public static class Questions
{
    public const string FREE_SPACE = "FREE SPACE";
    
    public static readonly string[] All = new[]
    {
        "Show your favorite keyboard shortcut.",
        "Name the IDE or editor you use most.",
        "Share your most-used extension or plugin.",
        "Choose dark mode or light mode and why.",
        "Show the tab you always keep open while working.",
        "Tell us your go-to snack or drink for coding sessions.",
        "Name a language you enjoy using.",
        "Share one habit that helps you focus.",
        "Show your favorite terminal command.",
        "Describe your ideal desk setup in one sentence.",
        "Name a developer tool you would recommend to anyone.",
        "Share the first app, game, or project you ever built.",
        "Tell us your favorite debug trick.",
        "Pick tabs or spaces and defend it lightly.",
        "Name a coding playlist or background sound you like.",
        "Show a sticker, mug, or desk item from your tech life.",
        "Give a 5-second pep talk to your future self before a deadline.",
        "Rock-paper-scissors challenge someone nearby.",
        "Teach a tiny productivity trick in 5 seconds.",
        "Share one thing you always do before pushing code.",
        "Name a library or framework you like working with.",
        "Tell us about a shortcut or feature you recently discovered.",
        "Share a project you are proud of from this year.",
        "Name a tool you wish every team used.",
        "Describe your happiest code review experience.",
        "Show your most organized folder, repo, or workspace habit.",
        "Share a developer meme format you never get tired of.",
        "Name a bug that taught you something useful.",
        "Say the phrase you repeat most during standups or pair programming.",
        "Share one rule you have for keeping code readable.",
        "Name a culture practice that makes a team better.",
        "Tell us what your perfect hack day looks like.",
        "Show your commit message style in one example.",
        "Share a time you changed your mind about a tool or workflow.",
        "Name a conference talk, blog, or podcast you would recommend.",
        "Describe the ideal onboarding experience for a new developer.",
        "Share a coding superstition or ritual you secretly keep.",
        "Name a feature you wish more IDEs had by default.",
        "Tell us the best piece of advice you got from another developer.",
        "Share your favorite way to learn a new technology.",
        "Name one thing that instantly improves your workday."
    };

    public static readonly IReadOnlyList<string> TechLifeBingo = All;

    public static IReadOnlyList<string> Bingo => All;

    public static IEnumerable<string> GetAll() => All;

    public static readonly List<string> QuestionsList = new(All);
}
