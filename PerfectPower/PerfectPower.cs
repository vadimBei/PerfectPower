using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPower
{
	public static class PerfectPower
	{
		public static int[] SearchingPerfectPower(int n)
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
