using System.Windows;
using System.Windows.Input;

namespace PerfectPower.WPF.Views
{
	/// <summary>
	/// Interaction logic for CheckingIntegerWindow.xaml
	/// </summary>
	public partial class CheckingIntegerWindow : Window
	{
		public CheckingIntegerWindow()
		{
			InitializeComponent();
		}

		private void TxtBox_TextInput(object sender, TextCompositionEventArgs e)
		{
			int value;

			if (!int.TryParse(e.Text, out value))
			{
				e.Handled = true;
			}
		}

		private void TxtBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				e.Handled = true;
		}
	}
}
