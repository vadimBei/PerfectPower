using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.WEB.ViewModels.SearchResult;

namespace PerfectPower.WEB.Maps
{
	public class SearchResultProfile : Profile
	{
		public SearchResultProfile()
		{
			CreateMap<SearchResultViewModel, SearchResultCreateModel>().ReverseMap();
		}
	}
}
