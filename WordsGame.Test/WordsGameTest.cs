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

    [Theory]
    [InlineData("nein", 4)]
    [InlineData("Bier", 4)]
    [InlineData("blau", 4)]
    [InlineData("Frickelbude", 11)]
    [InlineData("https://youtu.be/dQw4w9WgXcQ", 28)]
    public void TestGradeIsNumberOfLettersForCorrectSolution(string word, int expectedPoints)
    {
        WordsGame game = new(new FakeScrambler());
        game.Start(word);

        int grade = game.Grade(word);

        Assert.Equal(expectedPoints, grade);
    }

    private class FakeScrambler : IScrambler
    {
        public string Scramble(string word)
        {
            return new string(word.Reverse().ToArray());
        }
    }
}