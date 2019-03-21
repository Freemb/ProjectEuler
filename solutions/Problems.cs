using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace ProjectEuler.Solutions
{
	public class Problems
	{
		private readonly int _problemnumber;
        MethodInfo problem;

        public MethodInfo this[int problemnumber]
        {
            get
            {
                //Assembly current = Assembly.GetExecutingAssembly();
                //Type problemtype = current.GetType("ProjectEuler.Solutions.Problems");
                problem = typeof(Problems).GetMethod("Problem" + problemnumber.ToString());
                return problem;
            }
            
        }

		public Problems()
		{
            Console.WriteLine("Enter the problem number you wish to solve");
            
            while (!int.TryParse(Console.ReadLine(), out _problemnumber))
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid problem number");
                continue;
            }
            do
            {
                problem = this[_problemnumber];
                Console.WriteLine(problem.Invoke(null, null));
                Console.WriteLine("\nEnter a number if you wish to solve another problem or any letter to quit");
            }
            while (int.TryParse(Console.ReadLine(), out _problemnumber));
            
            
           
        }
        /// <summary>
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        public static string Problem1()
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
			//Console.WriteLine("The answer is {0}", Results.Sum());
			return $"The answer is {Results.Sum()}";
		}

		/// <summary>
		/// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
		/// </summary>
		public static string Problem2()
		{
			Console.WriteLine("Problem 2: By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.");

			List<int> Resultset = new List<int>(); // list to store even fibonacci numbers
			int[] Fibonacci = new int[3] { 1, 2, 0 }; // array that holds 3 consecutive values of the fibonacci sequence
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
			return $"The solution is {Resultset.Sum()}";
		}

		//The prime factors of 13195 are 5, 7, 13 and 29.
		/// <summary>
		/// What is the largest prime factor of the number 600851475143 ?
		/// </summary>
		public static string Problem3()
		{
			Console.WriteLine("Problem 3: What is the largest prime factor of the number 600851475143 ?");
			int i = 2;
			long number = 600851475143L;
			while (i != number)
			{
				if (number % i == 0) // test for prime factors i of number
				{
					number = number / i; // result divide by prime factor is still a multiple of other prime factors, smaller number reduces iterations
				}
				i++;
			}
			return $"The result is {number}";
		}

		//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
		/// <summary>
		///Find the largest palindrome made from the product of two 3-digit numbers.
		/// </summary>
		public static string Problem4()
		{
			Console.WriteLine("Problem 4: Find the largest palindrome made from the product of two 3-digit numbers.");

			char[] ToReverse;
			int product;
			StringBuilder Reversed = new StringBuilder(); //use stringbuilder instead of string to save memory
			List<int> palindromes = new List<int>();

			for (int i = 999; i > 0; i--)  //will iterate backwards from 999 and find product
			{
				for (int j = 999; j > 0; j--)
				{
					product = i * j;
					ToReverse = product.ToString().ToCharArray();
					//Reversed = new string(Array.Reverse(ToReverse); //could use this to simplify
					for (int z = ToReverse.Length - 1; z > -1; z--) //adds each character in array from last to first
					{
						Reversed.Append(ToReverse[z]);
					}
					if (int.Parse(Reversed.ToString()) == product) { palindromes.Add(product); }
					Reversed.Clear(); // needed to reset the string for new reversal
				}
			}
			return $"The largest palindrome is {palindromes.Max()}";
		}
		/// <summary>
		/// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
		/// </summary>

		public static string Problem5()
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
						Results += 20; //increment results and break to try new number
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
			return $"The smallest multiple of all the numbers is {Results}";
		}

		/// <summary>
		/// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
		/// </summary>
		public static string Problem6()
		{
			Console.WriteLine("Problem 6:Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum. ");
			int sum = 0;
			long sumsquare = 0L;
			for (int i = 1; i < 101; i++)
			{
				sumsquare += (i * i);
				sum += i;

			}
			long result = (sum * sum) - sumsquare;
			return $"The result is {result}";
		}
		/// <summary>
		/// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
		///What is the 10 001st prime number?
		/// </summary>
		public static string Problem7()
		{
			Console.WriteLine("Problem 7: By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13." +
								"What is the 10 001st prime number?");
			bool flag; //true when number prime
			int[] result = new int[10001];
			result[0] = 2; //initialise array with 2
			int number = 3; // starting with the 1st odd number after 2
			int counter = 1; //prime number 2 already counted as it is the only even prime

			while (counter < 10001)
			{
				flag = true;
				for (int i = 0; i < counter; i++)
				{
					if (number % result[i] == 0) { flag = false; break; } // Number is prime if indivisible by any primes preceding it
				}

				if (flag){	result[counter++] = number;	}

				number += 2;
			}
			return $"The result is {result[10000]}";
		}
		/// <summary>
		/// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
		/// </summary>
		public static string Problem8()
		{
			int adjacent = 13;
			int result = 0;
			StringBuilder Result = new StringBuilder();
			StringBuilder productstring = new StringBuilder();
			string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843" +
							"8586156078911294949545950173795833195285320880551112540698747158523863050715693290963295227443043557" +
							"6689664895044524452316173185640309871112172238311362229893423380308135336276614282806444486645238749" +
							"3035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776" +
							"6572733300105336788122023542180975125454059475224352584907711670556013604839586446706324415722155397" +
							"5369781797784617406495514929086256932197846862248283972241375657056057490261407972968652414535100474" +
							"8216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586" +
							"1786645835912456652947654568284891288314260769004224219022671055626321111109370544217506941658960408" +
							"0719840385096245544436298123098787992724428490918884580156166097919133875499200524063689912560717606" +
							"0588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

			Console.WriteLine("Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?" + $"\n{number}\n");

			for (int i = 0; i + adjacent <= number.Length; i++)
			{
				int product = 1;
				productstring.Clear();
				for (int j = i; j < i + adjacent; j++)
				{
					if (int.Parse(number[i].ToString()) * int.Parse(number[j].ToString()) == 0)
					{
						product = 0;
						break;
					}
					else
					{
						product *= int.Parse(number[j].ToString());
						productstring.Append(number[j]);
					}

				}
				if (product > result)
				{
					result = product;
					Result.Clear();
					Result.Append(productstring.ToString());
				}
			}

			return $"The result string is {Result.ToString()} and the value of the product is {result}";
		}
		/// <summary>
		/// A Pythagorean triplet is a set of three natural numbers, a less than b less than c, for which a2 + b2 = c2.
		///For example, 32 + 42 = 9 + 16 = 25 = 52.There exists exactly one Pythagorean triplet for which a + b + c = 1000.
		///Find the product abc.
		/// </summary>
		public static string Problem9()
		{
			Console.WriteLine(" A Pythagorean triplet is a set of three natural numbers, a less than b less than c, for which a2 + b2 = c2.\n" +
								"For example, 32 + 42 = 9 + 16 = 25 = 52.There exists exactly one Pythagorean triplet for which a + b + c = 1000.\n" +
								"Find the product abc.");
			long product;
			int sum = 1000;

				for (int a = 1; a < sum; a++)
				{
					// since a<b<c then b must be less than c which is sum-a-b since a+b+c = sum
					for (int b = a + 1; b < sum - a - b; b++)
					{
						int c = sum - a - b;
						if (c * c == a * a + b * b)
						{
							product = a * b * c;
							return $"The Pythagorean triplets are {a}, {b}, {c}. The Product is {product}";
						}
					}
				}
			return $"No Pythagorean triplets found that sum to {sum}";
		}
		/// <summary>
		/// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17. Find the sum of all the primes below two million.
		/// </summary>
		public static string Problem10()
		{
			int limit = 2000000;
			bool flag; //true when number prime
			List<int> result = new List<int>() { 2 }; // initialise list with number 2;
			int number = 3; // starting with the 1st odd number after 2
			long sum = 0; // doing list.sum() at end costs double the time
			Stopwatch timer = new Stopwatch();
			timer.Start();
				
			while (number < limit)
			{
				flag = true;
				foreach (int prime in result)
				{
					if (number % prime == 0) { flag = false; break; } // Number is prime if indivisible by any primes preceding it
				}
				
				if (flag) { result.Add(number); sum += number; }
				number += 2;
			}
			timer.Stop();
			return $"The sum of the primes below {limit} is {sum}, completed in {timer.ElapsedMilliseconds} ms";
		}
		/// <summary>
		/// What is the largest product of 4 adjacent numbers in a 2 dimensional grid?
		/// </summary>
		public static string Problem11()
		{
			char[] separators = new char[] { ' ', '\n' };
			string maxsequence ="";
			long maxProduct = 1;
			int[,] intgrid = new int[20, 20];
			string gridvalues = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\n" +
								"49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\n" +
								"81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\n" +
								"52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\n" +
								"22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\n" +
								"24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\n" +
								"32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\n" +
								"67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\n" +
								"24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\n" +
								"21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\n" +
								"78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\n" +
								"16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\n" +
								"86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\n" +
								"19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\n" +
								"04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\n" +
								"88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\n" +
								"04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\n" +
								"20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\n" +
								"20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\n" +
								"01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

			Console.WriteLine(gridvalues + "\n");
			string[] stringgrid = gridvalues.Split(separators);
			
			for (int i = 0; i < stringgrid.Length; i++) // splits input 1-D string array into integer 2-D array
			{
				intgrid[i / 20, i % 20] = int.Parse(stringgrid[i]); //remainder gives column number
			}
			//only 1 direction for each needs to be considered as there will be an equivalent in the other direction
			for (int i = 0; i < 20; i++) 
			{
				for (int j = 0; j < 20; j++)
				{
					long horizproduct = 1;
					long vertproduct = 1;
					long downRightproduct = 1;
					long downLeftproduct = 1;
					int[] horizsequence = new int[4];
					int[] vertsequence = new int[4];
					int[] downLeftsequence = new int[4];
					int[] downRightsequence = new int[4]; 

					for (int k = 0; k < 4; k++)
					{
						if (j < 17) // check horizontally stopping at 17th column so not out of bounds
						{
							horizsequence[k] = intgrid[i, j + k];
							horizproduct *= horizsequence[k];
						}
						if (i < 17) //check vertically stopping at 17th row so not out of bounds
						{
							vertsequence[k] = intgrid[i + k, j];
							vertproduct *= vertsequence[k];
						}
						if (i < 17 && j < 17) //check diagonally down right stopping at 17th row and column so not out of bounds
						{
							downRightsequence[k] = intgrid[i + k, j + k];
							downRightproduct *= downRightsequence[k];
							
						}
						if (j > 2 && i < 17) //check diagonally down left starting at 4th column and stopping at 17th row so not out of bounds
						{
							downLeftsequence[k] = intgrid[i + k, j - k];
							downLeftproduct *= downLeftsequence[k];
						}
					}
					if (horizproduct > maxProduct) { maxProduct = horizproduct; maxsequence = "Horizontal: " + string.Join(" X ",horizsequence); }
					if (vertproduct > maxProduct) { maxProduct = vertproduct; maxsequence = "Vertical: " + string.Join(" X ", vertsequence); }
					if (downRightproduct > maxProduct) { maxProduct = downRightproduct; maxsequence = "Down Right: " + string.Join(" X ",downRightsequence); }
					if (downLeftproduct > maxProduct) { maxProduct = downLeftproduct; maxsequence = "Down Left: " + string.Join(" X ",downLeftsequence); }
				}
				
			}
			return $"The largest sequence is {maxsequence}, its product is {maxProduct}";
        }

        /// <summary>
        /// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. 

        /// The first ten terms would be: 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, .. What is the value of the first triangle number to have over five hundred divisors?
        /// </summary>
        public static string Problem12()	 
		{
            int divisorcount = 2; // initialised at 2 since we don't test for factor 1 and the number itself.
            int nth = 1;
            int Tnumber = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (divisorcount <= 501)
            {
                //reset variables, need to include the number itself as a factor since only testing up to sqrt num
                divisorcount = 2;
                if (nth == 1){divisorcount = 1;}
                Tnumber += nth; // 1st number is 0+1, 2nd number is 0+1+2,nth number is  0+1+....+nth

                for (int i = 2; i <= Math.Sqrt(Tnumber); i++) // each prime factor has a complementary unique factor, no prime factor of num is > sqrt(num)
                {
                    if (Tnumber % i == 0)
                    {
                        divisorcount += 2; // add the divisor and its complement (num/divisor)
                    }
                }
                nth++;
            }
            timer.Stop();
			return $"The first triangle number with over {divisorcount} divisors is {Tnumber} the {nth} th Triangle Number" + $"Elapsed time {timer.ElapsedMilliseconds}" ;
		}


	}

}
