using System.Windows;

namespace PerfectPower.WPF.ViewModels
{
	public class CheckingIntegerWindowViewModel : BaseViewModel
	{
		private int? _newInteger;

		public CheckingIntegerWindowViewModel()
		{
			CloseCheckingIntegerWindowCommand = new RelayCommand<Window>(OnCloseCheckingIntegerWindowCommand);
		}

		public int? NewInteger
		{
			get { return _newInteger; }
			set
			{
				_newInteger = value;
				OnPropertyChanged(nameof(NewInteger));
			}
		}

		public RelayCommand<Window> CloseCheckingIntegerWindowCommand { get; set; }

		private void OnCloseCheckingIntegerWindowCommand(Window window)
		{
			if (window != null)
			{
				window.DialogResult = true;
				window.Close();

			}
		}
	}
}
