using System;
using System.Collections.Generic;
using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.WEB.ViewModels.SearchResult;

namespace PerfectPower.ConsoleApp.Service.OutputValueService
{
	public class OutputValueService : IOutputValueService
	{
		private readonly ISearchResultService _searchResultService;
		private readonly IMapper _mapper;

		public OutputValueService(
			ISearchResultService searchResultService,
			IMapper mapper)
		{
			_searchResultService = searchResultService;
			_mapper = mapper;
		}

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

		public void OutputElementOfSearchResultToConsole(SearchResultModel searchResultModel)
		{
			var elemToView = _mapper.Map<SearchResultViewModel>(searchResultModel);

			PrintToConsole(elemToView);
		}

		public void OutputElementOfSearchResultToConsoleById(Guid id)
		{
			var searchResultModel = _searchResultService.Get(id);

			var elemToView = _mapper.Map<SearchResultViewModel>(searchResultModel);

			PrintToConsole(elemToView);
		}

		public void OutputListOfSearchResultToConsole(List<SearchResultModel> searchResults)
		{
			var elemToView = _mapper.Map<List<SearchResultViewModel>>(searchResults);

			foreach (var temp in elemToView)
			{
				PrintToConsole(temp);
			}
		}
	}
}
