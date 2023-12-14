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

    [Fact]
    public void TestScrambleSingleLetterIsSame()
    {
        String original = new Random().Next('a', 'z').ToString();

        String scrambled = Utils.Scramble(original);

        Assert.Equal(original, scrambled);
    }
}