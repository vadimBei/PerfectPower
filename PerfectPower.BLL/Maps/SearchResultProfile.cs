using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.DAL.Entities;

namespace PerfectPower.BLL.Maps
{
	public class SearchResultProfile : Profile
	{
		public SearchResultProfile()
		{
			CreateMap<SearchResultCreateModel, SearchResult>()
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			CreateMap<SearchResultUpdateModel, SearchResult>()
				.IncludeBase<SearchResultCreateModel, SearchResult>();

			CreateMap<SearchResult, SearchResultModel>()
				.ReverseMap();
		}
	}
}
