namespace WordsGame;

public class WordsGame : IWordsGame
{
    private readonly IScrambler scrambler;
    private string? originalWord;

    public WordsGame(IScrambler scrambler) {
        this.scrambler = scrambler;
    }

    public string Start(string word)
    {
        originalWord = word;
        return scrambler.Scramble(word);
    }

    public int Grade(string solution)
    {
        return solution == originalWord ? CorrectScore(solution) : 0;
    }

    protected virtual int CorrectScore(string solution)
    {
        return solution.Length;
    }
}
