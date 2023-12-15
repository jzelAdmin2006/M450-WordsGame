namespace WordsGame;

public class WordsGame : IWordsGame
{
    private readonly IScrambler scrambler;
    protected string? originalWord;

    public WordsGame(IScrambler scrambler) {
        this.scrambler = scrambler;
    }

    public virtual string Start(string word)
    {
        originalWord = word;
        return scrambler.Scramble(word);
    }

    public virtual int Grade(string solution)
    {
        return solution == originalWord ? CorrectScore(solution) : 0;
    }

    protected virtual int CorrectScore(string solution)
    {
        return solution.Length;
    }
}
