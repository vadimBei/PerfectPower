using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPower
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the number in digits and press Enter: ");
			int num = int.Parse(Console.ReadLine());

			var sqrtResult = Math.Sqrt(num);

			if (sqrtResult % 1 != 0 && num < 0)
				Console.WriteLine("null");
			else
			{
				int[] res = PerfectPower(num);

				Console.WriteLine($"Your number is {res[0]}, power is {res[1]}");
			}

			Console.ReadLine();
		}

		static int[] PerfectPower(int n)
		{
			if (n > 0)
			{
				for (double i = 2; i <= Math.Sqrt(n); i++)
				{
					double power = 2;
					double number = Math.Pow(i, power);

					while (number < n && number > 0)
					{
						power++;
						number = Math.Pow(i, power);
					}

					if (number == n)
					{
						return new int[]
						{
						(int)i, (int)power
						};
					}
				}

			}

			return null;
		}
	}
}
