namespace WordsGame
{
    public class Scrambler : IScrambler
    {
        public string Scramble(string original)
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
    }
}
