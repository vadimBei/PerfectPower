using System.Windows;
using PerfectPower.WPF.ViewModels;

namespace PerfectPower.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainWindowViewModel();
		}
	}
}
