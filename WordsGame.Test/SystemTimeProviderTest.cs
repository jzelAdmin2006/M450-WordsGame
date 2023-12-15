namespace WordsGame.Test;

public class SystemTimeProviderTest
{
    [Fact]
    public void Now_ShouldReturnCurrentDateTime()
    {
        var systemTimeProvider = new SystemTimeProvider();
        var beforeCall = DateTime.Now;

        var result = systemTimeProvider.Now;

        var afterCall = DateTime.Now;

        Assert.True(result > beforeCall && result < afterCall,
            "The returned time should be within the time frame of the test execution.");
    }
}
