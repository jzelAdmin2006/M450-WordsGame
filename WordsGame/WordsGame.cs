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
        return solution == originalWord ? solution.Length : 0;
    }
}
