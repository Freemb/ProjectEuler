using System;
using ProjectEuler.Solutions;

namespace ProjectEuler
{
	class Program
	{
		private static int number;
		static void Main(string[] args)
		{
			Problems Problemset = new Problems();
			Console.WriteLine("Enter the problem number you wish to solve");
			while (!int.TryParse(Console.ReadLine(), out number))
			{
				Console.Clear();
				Console.WriteLine("Please enter a valid problem number");
				continue;
			}


			switch (number)
			{
				case 1:
					Problemset.Problem1();
					break;
				case 2:
					Problemset.Problem2();
					break;
				case 3:
					Problemset.Problem3();
					break;
				case 4:
					Problemset.Problem4();
					break;
				case 5:
					Problemset.Problem5();
					break;
				case 6:
					Problemset.Problem6();
					break;
				case 7:
					Problemset.Problem7();
					break;
				case 8:
					Problemset.Problem8();
					break;
				case 9:
					Problemset.Problem9();
					break;
				case 10:
					Problemset.Problem10();
					break;
				default:
					Console.WriteLine("This problem has not been solved yet");
					Console.ReadLine();
					break;
			}
		}
	}
}
