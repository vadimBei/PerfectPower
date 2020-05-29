using System;
using System.Collections.Generic;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.ConsoleApp.ViewModels;

namespace PerfectPower.ConsoleApp.Service.OutputValueService
{
	public class OutputValueService : IOutputValueService
	{
		public static void PrintToConsole(SearchResultViewModel viewModel)
		{
			if (viewModel.Number == null || viewModel.Power == null)
				Console.WriteLine($"You entered: {viewModel.InputParameter}, this value isn't perfect power.");
			else if (viewModel.Power == 2)
				Console.WriteLine($"You entered: {viewModel.InputParameter}, it's perfect square and has natural number " +
					$"{viewModel.Number}, and power {viewModel.Power}");
			else if (viewModel.Power == 3)
				Console.WriteLine($"You entered: {viewModel.InputParameter}, it's perfect cube and has natural number" +
					$" {viewModel.Number}, and power {viewModel.Power}");
			else
				Console.WriteLine($"You entered: {viewModel.InputParameter}, it's perfect power and has natural number" +
					$" {viewModel.Number}, and power {viewModel.Power}");
		}

		public void OutputElementOfSearchResultToConsole(SearchResultViewModel searchResultModel)
		{
			PrintToConsole(searchResultModel);
		}

		public void OutputListOfSearchResultToConsole(List<SearchResultViewModel> searchResults)
		{
			foreach (var temp in searchResults)
			{
				PrintToConsole(temp);
			}
		}
	}
}
