using PerfectPower.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PerfectPower.Service.LastElementsService
{
	public static class LastElementsService
	{
		// If table SearchResult has more then five elements, this method returns the last five elements
		public static List<SearchResult> LastFiveElements(ref List<SearchResult> searchResults)
		{
			searchResults = searchResults.OrderByDescending(r => r.CreationDate).ToList();

			//List<SearchResult> result = new List<SearchResult>();

			if (searchResults.Count <= 5)
				return searchResults;
			else
				// Get the last five elements 
				searchResults = searchResults.GetRange(0, 5);

			return searchResults;
		}
	}
}
