using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.WEB.ViewModels.SearchResult;

namespace PerfectPower.ConsoleApp.Maps
{
	public class SearchResultProfile : Profile
	{
		public SearchResultProfile()
		{
			CreateMap<SearchResultViewModel, SearchResultCreateModel>().ReverseMap();
		}
	}
}
