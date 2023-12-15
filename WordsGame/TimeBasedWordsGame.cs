namespace WordsGame;

public class TimeBasedWordsGame : WordsGame
{
    private DateTime? startTime;
    private readonly double maxTimeInSeconds;
    private readonly ITimeProvider timeProvider;

    public TimeBasedWordsGame(IScrambler scrambler, double maxTimeInSeconds, ITimeProvider timeProvider)
        : base(scrambler)
    {
        this.maxTimeInSeconds = maxTimeInSeconds;
        this.timeProvider = timeProvider;
    }

    public override string Start(string word)
    {
        string scrambledWord = base.Start(word);
        startTime = timeProvider.Now;
        return scrambledWord;
    }

    public override int Grade(string solution)
    {
        if (originalWord == null || !startTime.HasValue)
            return 0;

        double timeTaken = (timeProvider.Now - startTime.Value).TotalSeconds;
        if (timeTaken > maxTimeInSeconds)
            return 0;

        return Utils.CalculateTimeWeightedScore(base.Grade(solution), timeTaken, maxTimeInSeconds);
    }
}
