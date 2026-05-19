using Microsoft.AspNetCore.Components;
using SocOps.Components;
using Xunit;

namespace SocOps.Tests;

public class StartScreenTests
{
    [Fact]
    public void StartScreen_ShouldAdvertiseScavengerHuntMode()
    {
        var source = SourceFileHelper.ReadRelativeSource("SocOps/Components/StartScreen.razor");

        Assert.Contains("OnModeSelected", source);
        Assert.Contains("Bingo Mode", source, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Scavenger Hunt", source, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void StartScreen_ShouldExposeModeSelectionCallback()
    {
        var parameterNames = typeof(StartScreen)
            .GetProperties()
            .Where(property => Attribute.IsDefined(property, typeof(ParameterAttribute)))
            .Select(property => property.Name)
            .ToHashSet(StringComparer.Ordinal);

        Assert.Contains("OnModeSelected", parameterNames);
        Assert.DoesNotContain("OnStart", parameterNames);
    }
}
