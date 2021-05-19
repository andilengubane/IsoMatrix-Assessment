using System;

namespace IsoMatrix.AssessmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.Write("Provide input: ");

            string input = Console.ReadLine();

            StringCalculator.Add(input);

            Console.WriteLine($"Your input: {input}");

            Console.WriteLine("Press [enter] to continue...");
            Console.ReadLine();
        }
    }
}
