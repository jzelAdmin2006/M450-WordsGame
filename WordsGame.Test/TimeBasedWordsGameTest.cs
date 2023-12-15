namespace WordsGame.Test;

using Moq;

public class TimeBasedWordsGameTest
{
    private Mock<IScrambler> scramblerMock;
    private Mock<ITimeProvider> timeProviderMock;
    private WordsGame game;

    public TimeBasedWordsGameTest()
    {
        scramblerMock = new Mock<IScrambler>();
        timeProviderMock = new Mock<ITimeProvider>();
        game = new TimeBasedWordsGame(scramblerMock.Object, 30.0, timeProviderMock.Object);
    }

    [Fact]
    public void StartShouldSetStartTimeCorrectly()
    {
        var testStartTime = DateTime.Now;
        timeProviderMock.Setup(tp => tp.Now).Returns(testStartTime);

        game.Start("test");

        timeProviderMock.Setup(tp => tp.Now).Returns(testStartTime.AddSeconds(1));
        var score = game.Grade("test");
        var expectedScore = Utils.CalculateTimeWeightedScore(4, 1, 30.0);
        Assert.Equal(expectedScore, score);
    }

    [Theory]
    [InlineData("test", "test", 25, 1)]
    [InlineData("asdfqwert", "asdfqwert", 1, 9)]
    [InlineData("test", "wrong", 25, 0)]
    [InlineData("test", "test", 31, 0)]
    public void GradeShouldCalculateCorrectScore(string word, string solution, int timeTaken, int expectedScore)
    {
        scramblerMock.Setup(s => s.Scramble(It.IsAny<string>())).Returns(word);
        var startTime = new DateTime(2020, 1, 1, 0, 0, 0);
        timeProviderMock.Setup(tp => tp.Now).Returns(startTime);

        game.Start(word);

        var gradeTime = startTime.AddSeconds(timeTaken);
        timeProviderMock.Setup(tp => tp.Now).Returns(gradeTime);

        int score = game.Grade(solution);

        Assert.Equal(expectedScore, score);
    }
}
