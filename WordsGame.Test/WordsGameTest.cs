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

    [Fact]
    public void TestGradeIsZeroForWrongSolution()
    {
        String original = "Apfel";
        WordsGame game = new(new FakeScrambler());
        game.Start(original);

        int grade = game.Grade("Afpel");

        Assert.Equal(0, grade);
    }

    private class FakeScrambler : IScrambler
    {
        public string Scramble(string word)
        {
            return new string(word.Reverse().ToArray());
        }
    }
}