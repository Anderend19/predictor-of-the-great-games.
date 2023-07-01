using predictor;
using soccer_predictor;
using System.CodeDom.Compiler;

internal class Program
{
    private static void Main(string[] args)
    {
        Parser parser = new Parser();
        parser.Parse();
    }
}
