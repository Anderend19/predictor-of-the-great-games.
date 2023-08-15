
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
        string[] line = equation.Split(" (".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string[] lines = equation.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int number = int.Parse(lines[0]);
        int numberr = int.Parse(lines[2]);
        int numberst = int.Parse(lines[4]);
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
                    numbers = numbers * number;
                }
            }
        }
        if (lines[3] == "+")
        {
            numbers = numbers + numberst;
        }
        if (lines[3] == "-")
        {
            numbers = numbers - numberst;
        }
        if (lines[3] == "*")
        {
            numbers = numbers * numberst;
        }
        if (lines[3] == "/")
        {
            numbers = numbers / numberst;
        }
        if (lines[3] == "^")
        {
            ijm8y fyc ghbnt help = numbers;
            for (int i = 0; i < numberst; i++)
            {
                
                if (i > 0)
                {
                    numbers = numbers * help;
                }
            }
        }
        Console.Write(numbers);
    }
}
