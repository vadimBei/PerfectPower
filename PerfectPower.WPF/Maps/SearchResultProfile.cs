using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.WPF.ViewModels.SearchResult;

namespace PerfectPower.WPF.Maps
{
	public class SearchResultProfile : Profile
	{
		public SearchResultProfile()
		{
			CreateMap<SearchResultViewModel, SearchResultCreateModel>().ReverseMap();
		}
	}
}
