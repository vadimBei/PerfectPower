using System;

namespace PerfectPower
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number in digits and press Enter: ");
			int num = int.Parse(Console.ReadLine());

			int[] result = PerfectPower.SearchingPerfectPower(num);

			if (result == null)
			{
				Console.WriteLine("This number hasn't perfect power");
			}
			else
			{
				Console.WriteLine($"Your number is {result[0]}, power is {result[1]}");
			}

			Console.ReadLine();
		}


	}
}
