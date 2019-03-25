using System;
using ProjectEuler.Solutions;

namespace ProjectEuler
{
	public static class Program
	{
        static int _problemnumber;
        
        static void Main(string[] args)
		{
			Problems Problemset = new Problems();
            Console.WriteLine("Enter the problem number you wish to solve");

            while (!int.TryParse(Console.ReadLine(), out _problemnumber))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid problem number");
                continue;
            }
            do
            {
                string result = Problemset.ProblemSelector(_problemnumber);
                Console.WriteLine("\nEnter a number if you wish to solve another problem or any letter to quit");
            }
            while (int.TryParse(Console.ReadLine(), out _problemnumber));
        }
	}

}
