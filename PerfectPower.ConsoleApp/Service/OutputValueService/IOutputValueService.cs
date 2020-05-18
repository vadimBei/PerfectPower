using System;
using System.Collections.Generic;
using PerfectPower.BLL.Models.SearchResultModel;

namespace PerfectPower.ConsoleApp.Service.OutputValueService
{
	public interface IOutputValueService
	{
		void OutputListOfSearchResultToConsole(List<SearchResultModel> searchResultModels);

		void OutputElementOfSearchResultToConsoleById(Guid id);
		
		void OutputElementOfSearchResultToConsole(SearchResultModel searchResultModel);
	}
}
