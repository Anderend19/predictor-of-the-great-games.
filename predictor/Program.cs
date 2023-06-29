using predictor;
using System.CodeDom.Compiler;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Match> mMatches = new List<Match>();

        using (var streamReader = File.OpenText("..\\..\\.\\..\\..\\results.csv"))
        {
            string data = streamReader.ReadToEnd();

            string[] lines = data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //Step 1 create match list
            for (int i = 1; i < lines.Length; i++)
            {
                mMatches.Add(new Match(lines[i]));
            }
        }

        int maxScore = 0;
        int maxIndex = 0;
        //Step 2 use match list to find biggest home score
        for (int i = 1; i < mMatches.Count; i++)
        {
            if (maxScore < mMatches[i].HomeScore)
            {
                maxScore = mMatches[i].HomeScore;
                maxIndex = i;
            }
        }

        string text = (string.Format("{0} {1}", 1 + maxIndex, mMatches[maxIndex].Raw));
        Console.WriteLine(text);

    }
}
