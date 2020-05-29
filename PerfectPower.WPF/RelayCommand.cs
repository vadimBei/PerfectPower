using System;
using System.Windows.Input;

namespace PerfectPower.WPF
{
	public class RelayCommand : ICommand
	{
		private Action execute;
		private Func<bool> canExecute;

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return this.canExecute == null || this.canExecute();
		}

		public void Execute(object parameter)
		{
			this.execute();
		}
	}

	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> execute = null;
		private readonly Predicate<T> canExecute = null;

		public RelayCommand(Action<T> execute) : this(execute, null)
		{
		}

		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException(nameof(execute));
			}

			this.execute = execute;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null ? true : canExecute((T)parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			execute((T)parameter);
		}
	}
}
