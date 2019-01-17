using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Solutions
{
	class Problems
	{
		private int number;
		public Problems()
		{
			Console.WriteLine("What is the problem number?");
			int.TryParse(Console.ReadLine(), out number);

			switch (number)
			{
				case 1:
					Problem1();
					break;
				case 2:
					Problem2();
					break;
				case 3:
					Problem3();
					break;
				default:
					Console.WriteLine("This problem has not been solved yet");
					break;
			}
		}

		/// <summary>
		/// Find the sum of all the multiples of 3 or 5 below 1000.
		/// </summary>
		private void Problem1()
		{
			List<int> Results = new List<int>(); // list for all the multiples
			for (int i = 0; i < 1000; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
				{
					Results.Add(i);
				}
			}
			Console.WriteLine("The answer is " + Results.Sum());
			Console.ReadLine();
		}

		/// <summary>
		/// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
		/// </summary>
		private void Problem2()
		{
			List<int> Resultset = new List<int>(); // list to store even fibonacci numbers
			int[] Fibonacci = new int[3]{1,2,0}; // array that holds 3 consecutive values of the fibonacci sequence
			Resultset.Add(2);

			do
			{
				Fibonacci[2] = Fibonacci[0] + Fibonacci[1];
				if (Fibonacci[2] % 2 == 0)
				{
					Resultset.Add(Fibonacci[2]);
				}
				Fibonacci[0] = Fibonacci[1];
				Fibonacci[1] = Fibonacci[2];
			} while (Fibonacci[2] <= 4000000);
			Console.WriteLine(Resultset.Sum());
			Console.ReadLine();

		}
		
		//The prime factors of 13195 are 5, 7, 13 and 29.
		/// <summary>
		/// What is the largest prime factor of the number 600851475143 ?
		/// </summary>
		private void Problem3()
		{
			int i = 2;
			long number = 600851475143;
			while (i !=number)
			{
				if (number % i == 0) // test for prime factors i of number
				{
					number = number / i; // result divide by prime factor is still a multiple of other prime factors, smaller number reduces iterations
				}
				i++;
			}
			Console.WriteLine("The result is " + number);
			Console.ReadLine();
		}






	}
}
