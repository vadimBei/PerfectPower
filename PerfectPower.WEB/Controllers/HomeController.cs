using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PerfectPower.BLL.Models.SearchResultModel;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.WEB.Models;
using PerfectPower.WEB.ViewModels.SearchResult;

namespace PerfectPower.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ISearchResultService _searchResultService;
		private readonly IPerfectPowerService _perfectPowerService;
		private readonly ILastElementsService _lastElementsService;

		public HomeController(
			ISearchResultService searchResultService,
			IPerfectPowerService perfectPowerService,
			ILastElementsService lastElementsService,
			IMapper mapper)
		{
			_searchResultService = searchResultService;
			_perfectPowerService = perfectPowerService;
			_lastElementsService = lastElementsService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var searchResults = _searchResultService.GetAll().ToList();

			_lastElementsService.LastFiveElements(ref searchResults);

			List<SearchResultViewModel> resultsToView = new List<SearchResultViewModel>();

			foreach (var tempElem in searchResults)
			{
				var temp = _mapper.Map<SearchResultViewModel>(new SearchResultViewModel
				{
					InputParameter = tempElem.InputParameter,
					Number = tempElem.Number,
					Power = tempElem.Power,
					TypeOfPower = tempElem.TypeOfPower
				});

				resultsToView.Add(temp);
			}

			return View(resultsToView);
		}

		[HttpPost]
		public IActionResult CheckNumber(int number)
		{
			if(number < 0)
			{
				return Content("Integer must be positive!");
			}

			var checkedNumber = _perfectPowerService.SearchingPerfectPower(number);

			if (checkedNumber == null)
			{
				var newSearchResult = _mapper.Map<SearchResultCreateModel>(new SearchResultCreateModel
				{
					InputParameter = number,
					DateCreation = DateTime.Now,
					ModifiedDate = DateTime.Now,
					TypeOfPower = null
				});

				_searchResultService.Create(newSearchResult);
			}

			return RedirectToAction("Index", "Home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
