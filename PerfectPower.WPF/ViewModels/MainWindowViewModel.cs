using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.WPF.ViewModels.SearchResult;
using PerfectPower.WPF.Views;

namespace PerfectPower.WPF.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel()
		{
			LoadSearchResult();
			ShowCheckingIntegerWindowCommand = new RelayCommand(ShowCkeckingIntegerWindow);
		}

		private List<SearchResultViewModel> searchResultViewModels;

		public List<SearchResultViewModel> SearchResultViewModels
		{
			get { return this.searchResultViewModels; }
			set
			{
				this.searchResultViewModels = value;
				OnPropertyChanged(nameof(SearchResultViewModels));
			}
		}

		public RelayCommand ShowCheckingIntegerWindowCommand
		{
			get;
			private set;
		}

		private void ShowCkeckingIntegerWindow()
		{
			CheckingIntegerWindowViewModel viewModel = new CheckingIntegerWindowViewModel();

			CheckingIntegerWindow checkingIntegerWindow = new CheckingIntegerWindow()
			{
				DataContext = viewModel
			};

			bool? showResult = checkingIntegerWindow.ShowDialog();

			if (showResult==true && viewModel.NewInteger.HasValue)
			{
				int newInteger = viewModel.NewInteger.Value;

				CheckNewInteger(newInteger);
			}
		}

		private void CheckNewInteger(int param)
		{
			if (param >= 0)
			{
				var searchREsultModel = App.ServiceProvider.GetService<IPerfectPowerService>()
				.SearchingPerfectPower(param);

				if (searchREsultModel == null)
				{
					App.ServiceProvider.GetService<ICreatorOfSearchResultCreateModelService>()
						.CreateSearchResultModel(param);
				}
				else if (searchREsultModel is int[])
				{
					App.ServiceProvider.GetService<ICreatorOfSearchResultCreateModelService>()
						.CreateSearchResultModel(searchREsultModel);
				}
			}
			else
				MessageBox.Show("Integer must be positive!");

			LoadSearchResult();
		}

		private void LoadSearchResult()
		{
			var allSearchResaltElements = App.ServiceProvider.GetService<ISearchResultService>()
				.GetAll().ToList();

			var fiveElemets = App.ServiceProvider.GetService<ILastElementsService>()
				.LastFiveElements(allSearchResaltElements);

			var fiveElemetsViewModels = App.ServiceProvider.GetService<IMapper>()
				.Map<List<SearchResultViewModel>>(fiveElemets);

			SearchResultViewModels = fiveElemetsViewModels;
		}
	}
}
