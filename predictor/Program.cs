
    using System;
using System.Reflection;

class Expo
{
    static void Main()
    {
        int m, n, a;
        Console.Write("Enter the Number : ");
        m = int.Parse(Console.ReadLine());
        Console.Write("Give the Exponent : ");
        n = int.Parse(Console.ReadLine());
        Console.Write("Give the Exponent : ");
        a = int.Parse(Console.ReadLine());
        int value1 = doublesuperfunction(m, n, a);
        Console.WriteLine("Result : {0}", value1);
        Console.ReadLine();
    }
    static int doublesuperfunction(int num, int exp, int and)
    {
        int answer = power(num, exp);
        return power(answer, and);

    }
    static int superpower(int num, int exp)
    {
        
        return power(num, exp) + power(exp, num);
    }
    static int power(int num, int exp)
    {
        int result = 1;

        for (int i = 0; i < exp; i++)
        {
            result = result * num;
        }

        return result;
    }
}
  