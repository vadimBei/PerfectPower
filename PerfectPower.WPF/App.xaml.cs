using System;
using System.Configuration;
using System.Windows;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerfectPower.BLL.Services.CreatorOfSearchResultCreateModelService;
using PerfectPower.BLL.Services.LastElementsService;
using PerfectPower.BLL.Services.PerfectPowerService;
using PerfectPower.BLL.Services.SearchResultService;
using PerfectPower.BLL.Services.TypeOfPowerService;
using PerfectPower.DAL.Common;

namespace PerfectPower.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static ServiceProvider ServiceProvider { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var services = new ServiceCollection();

			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDbContext<ApplicationDbContext>(optionsAction =>
			optionsAction.UseSqlServer(connection));

			services.AddScoped<ISearchResultService, SearchResultService>();
			services.AddScoped<ILastElementsService, LastElementsService>();
			services.AddScoped<ITypeOfPowerService, TypeOfPowerService>();
			services.AddScoped<IPerfectPowerService, PerfectPowerService>();
			services.AddScoped<ICreatorOfSearchResultCreateModelService, CreatorOfSearchResultCreateModelService>();
			services.AddScoped<MainWindow>();

			ServiceProvider = services.BuildServiceProvider();
			var mainWindow = ServiceProvider.GetService<MainWindow>();

			MainWindow.Show();
		}
	}
}
