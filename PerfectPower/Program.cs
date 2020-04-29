using PerfectPower.Entities;
using PerfectPower.Service.LastElementsService;
using PerfectPower.Service.OutputValueService;
using PerfectPower.Service.PerfectPowerService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectPower
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ApplicationDBContext appContext = new ApplicationDBContext())
			{
				Console.WriteLine("Please wait...!!!");

				List<SearchResult> searchResults = appContext.SearchResults.ToList();

				// Get the last five element from database
				LastElementsService.LastFiveElements(ref searchResults);

				// Output to console the last five element from database
				OutputValueService.OutputListOfSearchResult(searchResults);

				Console.WriteLine("Please enter the a positive integer and press Enter: ");

				int number = int.Parse(Console.ReadLine());

				if (number < 0)
				{
					Console.WriteLine("Input element must be positive!!!!");
				}

				SearchResult result = PerfectPowerService.SearchingPerfectPower(number);

				if (result == null)
				{
					SearchResult searchResult = new SearchResult()
					{
						InputParameter = number
					};

					appContext.SearchResults.Add(searchResult);
					appContext.SaveChanges();

					Console.WriteLine("This value isn't perfect power");
				}
				else
				{
					// Output to console result
					OutputValueService.OutputElementOfSearchResult(result);
				}
			}

			Console.ReadLine();
		}
	}
}
