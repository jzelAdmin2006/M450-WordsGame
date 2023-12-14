namespace WordsGame.Test;

public class UtilsTest
{
    [Fact]
    public void TestScrambleEmptyIsEmpty()
    {
        String original = "";

        String scrambled = Utils.Scramble(original);

        Assert.Equal("", scrambled);
    }
}