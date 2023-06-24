

using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var streamReader = File.OpenText("..\\..\\.\\..\\..\\results.csv"))
        {
            string data = streamReader.ReadToEnd();

            string[] lines = data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


           
            //Console.WriteLine(string.Format("{0} {1} - {2} {3}"Home_Team, Home_Score, Away_Team, Away_Score));

            for (int i = 1; i < lines.Length; i++)
            {
                
               // string text = string.Format("{0}.{1}", 1+i, lines[i]);
                //Console.WriteLine(text);
                string[] small = lines[i].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(string.Format("{0} {1} - {2} {3}", small[1], small[3], small[2], small[4]));

                //int a= 66;
                //int b;
                //string foo = "and";
                //string bar = "rew";

                //string blah =string.Format("hello {1} world {2} {0}", a, foo, bar);
                //Console.WriteLine(lines[i]);

            }

            // foreach (var line in lines) ;
            // Process line
        }
    }
}
