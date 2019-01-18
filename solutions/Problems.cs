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
		/// <summary>
		/// Constructor initiates console to select problem number to be solved
		/// </summary>
		public Problems()
		{
			Console.WriteLine("Enter the problem number you wish to solve");
			int.TryParse(Console.ReadLine(), out number);
			Console.Clear();

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
				case 4:
					Problem4();
					break;
				case 5:
					Problem5();
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
			Console.WriteLine("Problem 1: Find the sum of all the multiples of 3 or 5 below 1000.");
			
			List<int> Results = new List<int>(); // list for all the multiples
			for (int i = 0; i < 1000; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
				{
					Results.Add(i);
				}
			}
			Console.WriteLine("The answer is {0}",Results.Sum());
			Console.ReadLine();
		}

		/// <summary>
		/// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
		/// </summary>
		private void Problem2()
		{
			Console.WriteLine("Problem 2: By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.");
		
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
			Console.WriteLine("The solution is {0}",Resultset.Sum());
			Console.ReadLine();

		}
		
		//The prime factors of 13195 are 5, 7, 13 and 29.
		/// <summary>
		/// What is the largest prime factor of the number 600851475143 ?
		/// </summary>
		private void Problem3()
		{
			Console.WriteLine("Problem 3: What is the largest prime factor of the number 600851475143 ?");
			int i = 2;
			long number = 600851475143L;
			while (i !=number)
			{
				if (number % i == 0) // test for prime factors i of number
				{
					number = number / i; // result divide by prime factor is still a multiple of other prime factors, smaller number reduces iterations
				}
				i++;
			}
			Console.WriteLine("The result is {0}",number);
			Console.ReadLine();
		}

		//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
		/// <summary>
		///Find the largest palindrome made from the product of two 3-digit numbers.
		/// </summary>
		private void Problem4()
		{
			Console.WriteLine("Problem 4: Find the largest palindrome made from the product of two 3-digit numbers.");

			char[] ToReverse;
			int product;
			string Reversed = string.Empty; 
			List<int> palindromes = new List<int>();

			for (int i = 999; i > 0; i--)  //will iterate backwards from 999 and find product
			{
				for (int j = 999; j > 0; j--)
				{
					product = i * j;
					ToReverse = product.ToString().ToCharArray();
					//Reversed = (new string(Array.Reverse(ToReverse)); //could use this to simplify
					for (int z = ToReverse.Length - 1; z >-1; z--) //adds each character in array from last to first
					{
						Reversed += ToReverse[z];
					}
					if (int.Parse(Reversed) == product){ palindromes.Add(product);}
					Reversed = string.Empty; // needed to reset the string for new reversal
				}
			}
			Console.WriteLine("The largest palindrome is {0}, the smallest is {1} ",palindromes.Max(),palindromes.Min());
			Console.ReadLine();
		}
		/// <summary>
		/// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
		/// </summary>

		private void Problem5()
		{
			Console.WriteLine("What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?");
			long Results = 20; // minimum number that is a multiple of the largest number in the set of numbers
			bool found = false;

			while (!found)
			{
					for (int i = 20; i > 1; i--)
					{
						if (Results % i != 0) // is not a multiple of number
						{
							Results+=20; //increment results and break to try new number
							break;
						}
						else
						{
							if (i == 2) //if reached this point then all numbers from 20 to 2 were factors.
							{
								found = true;
								break;
							}

						}
					}
				
			}
			Console.WriteLine("The smallest multiple of all the numbers is {0}", Results);
			Console.ReadLine();
		}


	}
}
