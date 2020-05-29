using System.Collections.Generic;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.ConsoleApp.ViewModels;

namespace PerfectPower.ConsoleApp.Service.OutputValueService
{
	public interface IOutputValueService
	{
		void OutputListOfSearchResultToConsole(List<SearchResultViewModel> searchResultModels);

		void OutputElementOfSearchResultToConsole(SearchResultViewModel searchResultModel);
	}
}
