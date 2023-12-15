namespace WordsGame.Test
{
    public class UtilsTest
    {
        [Theory]
        [InlineData("WORD", 8)] 
        [InlineData("QUIZ", 22)]
        [InlineData("JAZZ", 29)]
        [InlineData("", 0)]
        public void TestCalculateScrabbleScoreShouldCalculateCorrectly(string word, int expectedScore)
        {
            int score = Utils.CalculateScrabbleScore(word);
            Assert.Equal(expectedScore, score);
        }

        [Fact]
        public void TestCalculateScrabbleScoreShouldBeCaseInsensitive()
        {
            int scoreLower = Utils.CalculateScrabbleScore("word");
            int scoreUpper = Utils.CalculateScrabbleScore("WORD");
            Assert.Equal(scoreLower, scoreUpper);
        }

        [Theory]
        [InlineData(10, 25.3, 30.0, 2)]
        [InlineData(7, 22.1, 60.0, 4)]
        [InlineData(5, 0, 30.0, 5)]
        [InlineData(5, 30.0, 30.0, 0)]
        [InlineData(0, 15.0, 30.0, 0)]
        public void TestCalculateTimeWeightedScore(int baseScore, double timeTaken, double maxTime, int expectedScore)
        {
            int score = Utils.CalculateTimeWeightedScore(baseScore, timeTaken, maxTime);
            Assert.Equal(expectedScore, score);
        }
    }
}
