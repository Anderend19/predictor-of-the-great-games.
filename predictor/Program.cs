
internal class Program
{
    private static void Main(string[] args)
    {
        using (var streamReader = File.OpenText("..\\..\\.\\..\\..\\results.csv"))
        {
            string data = streamReader.ReadToEnd();
            Console.WriteLine(data);
            //string lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //foreach (var line in lines) ;
            // Process line
        }
    }
}
