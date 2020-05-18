using System;
using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.BLL.Services.TypeOfPowerService;

namespace PerfectPower.BLL.Services.PerfectPowerService
{
	public class PerfectPowerService : IPerfectPowerService
	{
		private readonly ISearchResultService _searchResultService;
		private readonly ITypeOfPowerService _typeOfPowerService;
		private readonly IMapper _mapper;

		public PerfectPowerService(
			ISearchResultService searchResultService,
			ITypeOfPowerService typeOfPowerService,
			IMapper mapper)
		{
			_searchResultService = searchResultService;
			_typeOfPowerService = typeOfPowerService;
			_mapper = mapper;
		}

		public SearchResultModel SearchingPerfectPower(int n)
		{
			if (n > 0)
			{
				for (double i = 2; i <= Math.Sqrt(n); i++)
				{
					double power = 2;
					double number = Math.Pow(i, power);

					while (number < n && number > 0)
					{
						power++;
						number = Math.Pow(i, power);
					}

					if (number == n)
					{
						var searchResult = _mapper.Map<SearchResultCreateModel>(new SearchResultCreateModel
						{
							InputParameter = n,
							Number = (int)i,
							Power = (int)power,
							DateCreation = DateTime.Now,
							ModifiedDate = DateTime.Now,
							TypeOfPower = _typeOfPowerService.GetTypeOfPower((int)power)
						});

						var searchResultId = _searchResultService.Create(searchResult);

						var result = _searchResultService.Get(searchResultId);

						return result;
					}
				}
			}

			return null;
		}
	}
}
