namespace WordsGame;

public class Utils
{
    private static readonly Dictionary<char, int> ScrabbleScores = new Dictionary<char, int>
    {
        {'A', 1}, {'E', 1}, {'I', 1}, {'L', 1}, {'N', 1}, {'O', 1}, {'R', 1}, {'S', 1}, {'T', 1}, {'U', 1},
        {'D', 2}, {'G', 2},
        {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
        {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
        {'K', 5},
        {'J', 8}, {'X', 8},
        {'Q', 10}, {'Z', 10}
    };

    public static int CalculateScrabbleScore(string word)
    {
        return word.ToUpper().Sum(c => ScrabbleScores.ContainsKey(c) ? ScrabbleScores[c] : 0);
    }

    public static List<string> SlurpLines(string filePath)
    {
        List<string> words = new();
        foreach (string line in File.ReadLines(filePath))
        {
            words.Add(line.Trim());
        }
        return words;
    }

    public static string PickRandom(List<string> entries)
    {
        var i = new Random().NextInt64() % entries.Count;
        return entries[(int)i];
    }

    public static int CalculateTimeWeightedScore(int score, double timeTaken, double maxTime)
    {
        double weightedScore = score * (maxTime - timeTaken) / maxTime;
        return (int)Math.Round(weightedScore);
    }
}