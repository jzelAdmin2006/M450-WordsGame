namespace WordsGame;

public class WordsGame : IWordsGame
{
    private readonly IScrambler scrambler;

    public WordsGame(IScrambler scrambler) {
        this.scrambler = scrambler;
    }

    public string Start(string word)
    {
        return scrambler.Scramble(word);
    }

    public int Grade(string solution)
    {
        // TODO: award one point per letter if the solution is the original word
        return 0;
    }
}
