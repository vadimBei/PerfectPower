using PerfectPower.Entities;
using System;

namespace PerfectPower.Service.PerfectPowerService
{
	public static class PerfectPowerService
	{
		// This method check if input argument is perfect power
		public static SearchResult SearchingPerfectPower(int n)
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
						using (ApplicationDBContext appContext = new ApplicationDBContext())
						{
							SearchResult searchResult = new SearchResult()
							{
								InputParameter = n,
								Number = (int)i,
								Power = (int)power
							};

							appContext.SearchResults.Add(searchResult);
							appContext.SaveChanges();

							return searchResult;
						}
					}
				}
			}

			return null;
		}
	}
}
