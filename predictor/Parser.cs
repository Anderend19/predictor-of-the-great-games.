
using Microsoft.VisualBasic;
using System;
using System.Numerics;
using System.Reflection;

class Expo
{
    static void Main()
    {
        string equation;
        Console.Write("binary : ");
        equation = Console.ReadLine();
        Int64 equat = int.Parse(equation);
        string binary = Convert.ToString(equat, 10);
        Console.Write(binary);
    }
}
