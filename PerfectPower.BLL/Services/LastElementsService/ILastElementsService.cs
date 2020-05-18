using System.Collections.Generic;
using PerfectPower.BLL.Models.SearchResultModel;

namespace PerfectPower.BLL.Services.LastElementsService
{
	public interface ILastElementsService
	{
		// If table SearchResults has more then five elements, this method returns the last five elements
		List<SearchResultModel> LastFiveElements(ref List<SearchResultModel> searchResults);
	}
}
