namespace WordsGame;

public class Utils
{
    public static string Scramble(string original)
    {
        return new string(original.Reverse().ToArray());
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
}