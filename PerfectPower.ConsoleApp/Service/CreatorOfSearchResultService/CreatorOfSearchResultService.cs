using System;
using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.SearchResultService;

namespace PerfectPower.ConsoleApp.Service.CreatorOfSearchResultService
{
	public class CreatorOfSearchResultService : ICreatorOfSearchResultService
	{
		private readonly ISearchResultService _searchResultService;
		private readonly IMapper _mapper;

		public CreatorOfSearchResultService(
			ISearchResultService searchResultService,
			IMapper mapper)
		{
			_searchResultService = searchResultService;
			_mapper = mapper;
		}

		public Guid CreateSearchResultElement(int number)
		{
			Guid searchResultId = Guid.Empty;

			if (number > 0)
			{
				var newSearchResult = _mapper.Map<SearchResultCreateModel>(new SearchResultCreateModel
				{
					InputParameter = number,
					Number = null,
					Power = null,
					DateCreation = DateTime.Now,
					ModifiedDate = DateTime.Now,
					TypeOfPower = null
				});
				searchResultId = _searchResultService.Create(newSearchResult);
			}

			return searchResultId;
		}
	}
}
