namespace WordsGame.Test;

public class WordsGameTest
{
    [Fact]
    public void TestStartReturnsScrambledWord()
    {
        String original = "abcdefghijkl";

        String scrambled = new WordsGame(new FakeScrambler()).Start(original);

        Assert.Equal("lkjihgfedcba", scrambled);
    }

    private class FakeScrambler : IScrambler
    {
        public string Scramble(string word)
        {
            return new string(word.Reverse().ToArray());
        }
    }
}