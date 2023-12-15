namespace WordsGame.Test;

public class ScramblerTest
{
    [Fact]
    public void TestScrambleEmptyIsEmpty()
    {
        String original = "";

        String scrambled = new Scrambler().Scramble(original);

        Assert.Equal("", scrambled);
    }

    [Fact]
    public void TestScrambleSingleLetterIsSame()
    {
        String original = ((char)new Random().Next('a', 'z')).ToString();

        String scrambled = new Scrambler().Scramble(original);

        Assert.Equal(original, scrambled);
    }

    [Fact]
    public void TestScrambleTwoLettersIsOtherWayRound()
    {
        String original = "ab";

        String scrambled = new Scrambler().Scramble(original);

        Assert.Equal("ba", scrambled);
    }

    [Fact]
    public void TestScrambleThreeLettersOrderIsDifferent()
    {
        String original = "abc";

        String scrambled = new Scrambler().Scramble(original);

        Assert.NotEqual(original, scrambled);
        assertContainsExactlySameChars(original, scrambled);
        Assert.Equal(3, scrambled.Length);
    }

    [Fact]
    public void TestScrambleLargeStringTwiceResultsAreDifferent()
    {
        String original = "xTVPohZjHvw4ax7vAYK4FVAN1D6d23jgVWSfUrvlQcQkXoL4xcEgp5TE0llkqST9Tf8LXiNZ2x25yQax8fGQ18IxvhsmMLixRrBr";

        String firstResult = new Scrambler().Scramble(original);
        String secondResult = new Scrambler().Scramble(original);

        Assert.NotEqual(original, firstResult);
        Assert.NotEqual(original, secondResult);
        Assert.NotEqual(firstResult, secondResult);
        assertContainsExactlySameChars(original, firstResult);
        assertContainsExactlySameChars(original, secondResult);
        Assert.Equal(100, firstResult.Length);
        Assert.Equal(100, secondResult.Length);
    }

    private static void assertContainsExactlySameChars(string original, string scrambled)
    {
        Assert.True(
                    original.All(scrambled.Contains) && scrambled.All(original.Contains),
                    $"Scrambled string \"{scrambled}\" should exactly contain characters from original string \"{original}\""
                );
    }
}