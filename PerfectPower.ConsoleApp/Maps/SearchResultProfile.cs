﻿using AutoMapper;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.ConsoleApp.ViewModels;

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
