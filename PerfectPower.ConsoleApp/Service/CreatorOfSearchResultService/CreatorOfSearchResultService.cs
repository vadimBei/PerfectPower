using System;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.DAL.Entities;

namespace PerfectPower.ConsoleApp.Service.CreatorOfSearchResultService
{
	public class CreatorOfSearchResultService : ICreatorOfSearchResultService
	{
		private readonly ISearchResultService _searchResultService;

		public CreatorOfSearchResultService(
			ISearchResultService searchResultService)
		{
			_searchResultService = searchResultService;
		}

		public Guid CreateSearchResultElement(int number)
		{
			Guid searchResultId = Guid.Empty;

			if (number > 0)
			{
				var searchResultCreateModel = new SearchResultCreateModel()
				{
					InputParameter = number,
					Number = null,
					Power = null,
					DateCreation = DateTime.Now,
					ModifiedDate = DateTime.Now,
					TypeOfPower = TypeOfPower.IsNotPerfectPower
				};

				searchResultId = _searchResultService.Create(searchResultCreateModel);
			}

			return searchResultId;
		}
	}
}
