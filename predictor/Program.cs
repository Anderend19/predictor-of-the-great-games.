// See https://aka.ms/new-console-template for more information
Console.WriteLine("enter number:");
string numbere = Console.ReadLine();

Double num = Double.Parse(numbere);
Double result = num << 1;
Console.WriteLine("The number multiplied by two is: {0}", result);