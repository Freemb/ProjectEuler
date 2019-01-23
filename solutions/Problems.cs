using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Solutions
{
	struct Problems
	{
		/// <summary>
		/// Find the sum of all the multiples of 3 or 5 below 1000.
		/// </summary>
		public void Problem1()
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
		public void Problem2()
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
		public void Problem3()
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
		public void Problem4()
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

		public void Problem5()
		{
			Console.WriteLine("What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?");
			long Results = 20; // inititialised to smallest number that is a multiple of the largest number in the set of numbers
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

		/// <summary>
		/// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
		/// </summary>
		public void Problem6()
		{
			int sum = 0;
			long sumsquare = 0L;
			for (int i = 1; i < 101; i++)
			{
				sumsquare += (i * i);
				sum += i;
				
			}
			long result = (sum * sum) - sumsquare;
			Console.WriteLine("The result is {0}", result);
			Console.ReadLine();
		}

		public void Problem7()
		{
			bool flag = false;
			int number = 5;
			int counter = 3;
			int result = 0;
			while(counter < 10002)
			{
				flag = false;
				for (int i = 3; i < number; i+=2)
				{
					if (number % i == 0||number % 2 == 0) { flag = true;continue; }
				}

				if (flag == false)
				{
					result = number;
					counter++;
				}

				number += 2;
			}
			Console.WriteLine("The result is {0}", result);
			Console.ReadLine();
		}
	}
}
