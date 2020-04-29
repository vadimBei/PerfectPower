using PerfectPower.Entities;
using System;
using System.Collections.Generic;

namespace PerfectPower.Service.OutputValueService
{
	public static class OutputValueService
	{
		public static void OutputListOfSearchResult (List<SearchResult> searchResults)
		{
			foreach (var temp in searchResults)
			{
				if (temp.Number == null || temp.Power == null)
					Console.WriteLine($"You entered: {temp.InputParameter}, this value isn't perfect power.");
				else if (temp.Power == 2)
					Console.WriteLine($"You entered: {temp.InputParameter}, it's perfect square and has natural number {temp.Number}, " +
						$" and power {temp.Power}");
				else if (temp.Power == 3)
					Console.WriteLine($"You entered: {temp.InputParameter}, it's perfect cube and has natural number {temp.Number}, " +
						$" and power {temp.Power}");
				else
					Console.WriteLine($"You entered: {temp.InputParameter}, it's perfect power and has natural number {temp.Number}, " +
						$" and power {temp.Power}");
			}
		}

		public static void OutputElementOfSearchResult (SearchResult searchResult)
		{
			if (searchResult.Power == 2)
				Console.WriteLine($"You entered: {searchResult.InputParameter}, it's perfect square and has natural number {searchResult.Number}, " +
					$" and power {searchResult.Power}");
			else if (searchResult.Power == 3)
				Console.WriteLine($"You entered: {searchResult.InputParameter}, it's perfect cube and has natural number {searchResult.Number}, " +
					$" and power {searchResult.Power}");
			else
				Console.WriteLine($"You entered: {searchResult.InputParameter}, it's perfect power and has natural number {searchResult.Number}, " +
					$" and power {searchResult.Power}");
		}
	}
}
