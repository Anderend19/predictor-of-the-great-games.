

using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var streamReader = File.OpenText("..\\..\\.\\..\\..\\results.csv"))
        {
            string data = streamReader.ReadToEnd();

            string[] lines = data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int maxScore = 0;
            int maxIndex = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] small = lines[i].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int homescore = int.Parse(small[3]);
                if(maxScore < homescore)
                {
                    maxScore = homescore;
                    maxIndex = i;
                }
            }
            
            string text = (string.Format("{0} {1}", 1 + maxIndex, lines[maxIndex]));
            Console.WriteLine(text); 
        }
    }
}
