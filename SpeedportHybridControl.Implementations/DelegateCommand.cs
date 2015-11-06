﻿using System;
using System.Windows.Input;

namespace SpeedportHybridControl.Implementations {
	public class DelegateCommand : ICommand {
		private Action _executeMethod;

		public DelegateCommand (Action executeMethod) {
			_executeMethod = executeMethod;
		}

		public bool CanExecute (object parameter = null) {
			return true;
		}

		public event EventHandler CanExecuteChanged;

		public void Execute (object parameter = null) {
			_executeMethod.Invoke();
		}
	}
}
