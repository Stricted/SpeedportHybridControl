using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedportHybridControl.Implementations;

namespace SpeedportHybridControl.Model {
	class LoginPageModel : SuperViewModel {
		private string _ip = "speedport.ip";
		private string _password;
		private bool _showPassword;
		private bool _savePassword;

		private DelegateCommand _showPasswordCommand;
		private DelegateCommand _savePasswordCommand;
		private DelegateCommand _loginCommand;

		public string ip {
			get { return _ip; }
			set { SetProperty(ref _ip, value); }
		}

		public string password {
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		public bool ShowPassword {
			get { return _showPassword; }
			set { SetProperty(ref _showPassword, value); }
		}

		public bool SavePassword {
			get { return _savePassword; }
			set { SetProperty(ref _savePassword, value); }
		}

		public DelegateCommand ShowPasswordCommand {
			get { return _showPasswordCommand; }
			set { SetProperty(ref _showPasswordCommand, value); }
		}

		public DelegateCommand SavePasswordCommand {
			get { return _savePasswordCommand; }
			set { SetProperty(ref _savePasswordCommand, value); }
		}

		public DelegateCommand LoginCommand {
			get { return _loginCommand; }
			set { SetProperty(ref _loginCommand, value); }
		}

		private void OnShowPasswordCommandExecute () {
			Console.WriteLine(ShowPassword);
		}

		private void OnSavePasswordCommandExecute () {
			Console.WriteLine(SavePassword);
		}

		private void OnLoginCommandExecute () {
			Console.WriteLine(password);
		}

		public LoginPageModel () {
			ShowPasswordCommand = new DelegateCommand(new Action(OnShowPasswordCommandExecute));
			SavePasswordCommand = new DelegateCommand(new Action(OnSavePasswordCommandExecute));
			LoginCommand = new DelegateCommand(new Action(OnLoginCommandExecute));
		}
	}
}
