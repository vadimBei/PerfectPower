using System.Collections.Generic;
using System.Linq;
using PerfectPower.BLL.Models.SearchResultModel;

namespace PerfectPower.BLL.Services.LastElementsService
{
	public class LastElementsService : ILastElementsService
	{
		public List<SearchResultModel> LastFiveElements(List<SearchResultModel> searchResultModels)
		{
			searchResultModels = searchResultModels.OrderByDescending(r => r.DateCreation).ToList();

			if (searchResultModels.Count <= 5)
				return searchResultModels;
			else
				// Get the last five elements 
				searchResultModels = searchResultModels.GetRange(0, 5);

			return searchResultModels;
		}
	}
}
