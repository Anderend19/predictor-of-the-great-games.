
using Microsoft.VisualBasic;
using System;
using System.Reflection;

class Expo
{
    static void Main()
    {
        string equation;
        Console.Write("equation : ");
        equation = Console.ReadLine();
        string[] lines = equation.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int number = int.Parse(lines[0]);
        int numberr = int.Parse(lines[2]);
        int numbers = 0;
        
        if (lines[1] == "+")
        {
            numbers = number + numberr;
        }
        if (lines[1] == "-")
        {
            numbers = number - numberr;
        }
        if (lines[1] == "*")
        {
            numbers = number * numberr;
        }
        if (lines[1] == "/")
        {
            numbers = number / numberr;
        }
        if (lines[1] == "^")
        {
           for(int i = 0; i < numberr; i++)
            {
                if(i == 0)
                {
                    numbers = number;
                }
                if(i > 0)
                {
                    numbers = numbers * numberr;
                }
            }
        }
        Console.Write(numbers);
    }
}
