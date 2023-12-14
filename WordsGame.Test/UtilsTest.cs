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
        String original = ((char)new Random().Next('a', 'z')).ToString();

        String scrambled = Utils.Scramble(original);

        Assert.Equal(original, scrambled);
    }

    [Fact]
    public void TestScrambleTwoLettersIsOtherWayRound()
    {
        String original = "ab";

        String scrambled = Utils.Scramble(original);

        Assert.Equal("ba", scrambled);
    }

    [Fact]
    public void TestScrambleThreeLettersOrderIsDifferent()
    {
        String original = "abc";

        String scrambled = Utils.Scramble(original);

        Assert.NotEqual(original, scrambled);
        Assert.True(
            original.All(scrambled.Contains) && scrambled.All(original.Contains), 
            $"Scrambled string \"{scrambled}\" should exactly contain characters from original string \"{original}\""
        );
        Assert.Equal(3, scrambled.Length);
    }
}