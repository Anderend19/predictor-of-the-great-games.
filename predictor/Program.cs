
using System.Data.Common;
using System.Reflection.Metadata;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var streamReader = File.OpenText("..\\..\\.\\..\\..\\results.csv"))
        {
            string data = streamReader.ReadToEnd();

            string[] lines = data.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

           

            for (int i = 0; i < lines.Length; i++)
            {
                string text = string.Format("{0}.{1}", 201242, lines[i]);
                Console.WriteLine(text);
                //Console.WriteLine(lines[i]);

            }
          
            // foreach (var line in lines) ;
            // Process line
        }
    }
}
