using Xunit;

namespace SocOps.Tests;

public class ScavengerHuntTests
{
    [Fact]
    public void ScavengerHuntComponent_ShouldExistWithChecklistProgressUi()
    {
        var source = SourceFileHelper.ReadRelativeSource("SocOps/Components/ScavengerHunt.razor");

        Assert.Contains("CompletedCount", source);
        Assert.Contains("ProgressPercentage", source);
        Assert.Contains("ToggleItem", source);
        Assert.Contains("IsComplete", source);
        Assert.Contains("Questions.QuestionsList", source);
    }
}
