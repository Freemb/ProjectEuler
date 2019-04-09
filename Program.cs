using System;
using ProjectEuler.Solutions;

namespace ProjectEuler
{
	public static class Program
	{
        private static int _problemNumber;
        
        static void Main(string[] args)
		{
			Problems Problemset = new Problems();
            Console.WriteLine("Enter the problem number you wish to solve");

            while (!int.TryParse(Console.ReadLine(), out _problemNumber))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid problem number");
                continue;
            }
            do
            {
                string result = Problemset.ProblemSelector(_problemNumber);
                Console.WriteLine(result);
                Console.WriteLine("\nEnter a number if you wish to solve another problem or enter any letter to quit");
            }
            while (int.TryParse(Console.ReadLine(), out _problemNumber));
        }
	}

}
