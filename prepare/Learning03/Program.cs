using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction01 = new Fraction();
        Fraction fraction02 = new Fraction(5);
        Fraction fraction03 = new Fraction(3, 4);
        Fraction fraction04 = new Fraction(1, 3);

        Console.WriteLine("Get Decimal Values:\n" +
                          $"Fraction01: {fraction01.GetDecimalValue()}\n" +
                          $"Fraction02: {fraction02.GetDecimalValue()}\n" +
                          $"Fraction03: {fraction03.GetDecimalValue()}\n" +
                          $"Fraction04: {fraction04.GetDecimalValue()}\n"
                          );
        Console.WriteLine("Get Fractional String:\n" +
                          $"Fraction01: {fraction01.GetFractionalString()}\n" +
                          $"Fraction02: {fraction02.GetFractionalString()}\n" +
                          $"Fraction03: {fraction03.GetFractionalString()}\n" +
                          $"Fraction04: {fraction04.GetFractionalString()}\n"
                          );
    }
}