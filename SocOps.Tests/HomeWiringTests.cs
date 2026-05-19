using Xunit;

namespace SocOps.Tests;

public class HomeWiringTests
{
    [Fact]
    public void HomePage_ShouldRouteToScavengerHuntMode()
    {
        var source = SourceFileHelper.ReadRelativeSource("SocOps/Pages/Home.razor");

        Assert.Contains("ScavengerHunt", source);
        Assert.Contains("GameMode.ScavengerHunt", source);
        Assert.Contains("OnModeSelected", source);
    }
}
