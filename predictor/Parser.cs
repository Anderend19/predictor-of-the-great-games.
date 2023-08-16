
using Microsoft.VisualBasic;
using System;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Numerics;
using System.Reflection;

class Expo
{
    static void Main()
    {
        string equation;
        Console.Write("binary : ");
        equation = Console.ReadLine();
        int binary = Convert.ToInt32(equation, 2);
        Console.Write(binary);
    }
}
