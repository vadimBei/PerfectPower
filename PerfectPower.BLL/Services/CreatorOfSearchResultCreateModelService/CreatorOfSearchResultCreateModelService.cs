using System;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.BLL.Services.TypeOfPowerService;
using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService
{
	public class CreatorOfSearchResultCreateModelService : ICreatorOfSearchResultCreateModelService
	{
		private readonly ISearchResultService _searchResultService;
		private readonly ITypeOfPowerService _typeOfPowerService;

		public CreatorOfSearchResultCreateModelService(
			ISearchResultService searchResultService,
			ITypeOfPowerService typeOfPowerService)
		{
			_searchResultService = searchResultService;
			_typeOfPowerService = typeOfPowerService;
		}

		public SearchResultCreateModel CreateSearchResultModel(int[] array)
		{
			var searchResultCreateModel = new SearchResultCreateModel()
			{
				InputParameter = array[0],
				Number = array[1],
				Power = array[2],
				DateCreation = DateTime.Now,
				ModifiedDate = DateTime.Now,
				TypeOfPower = _typeOfPowerService.GetTypeOfPower(array[2])
			};

			var searchResultModelId = _searchResultService.Create(searchResultCreateModel);

			var searchResultModel = _searchResultService.Get(searchResultModelId);

			return searchResultModel;
		}

		public SearchResultCreateModel CreateSearchResultModel(int number)
		{
			var searchResultCreateModel = new SearchResultCreateModel()
			{
				InputParameter = number,
				DateCreation = DateTime.Now,
				ModifiedDate = DateTime.Now,
				TypeOfPower = TypeOfPower.IsNotPerfectPower
			};

			var searchResultModelId = _searchResultService.Create(searchResultCreateModel);

			var searchResultModel = _searchResultService.Get(searchResultModelId);

			return searchResultModel;
		}
	}
}
