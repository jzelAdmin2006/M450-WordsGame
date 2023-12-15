namespace WordsGame;

public class Utils
{
    public static string Scramble(string original)
    {
        return original.Length <= 1 ? original : ScrambleForceChange(original);
    }

    private static string ScrambleForceChange(string original)
    {
        string result;
        do
        {
            result = OrderRandomly(original);
        }
        while (result == original);
        return result;
    }

    private static string OrderRandomly(string original)
    {
        return new string(original.ToCharArray().OrderBy(s => Guid.NewGuid()).ToArray());
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