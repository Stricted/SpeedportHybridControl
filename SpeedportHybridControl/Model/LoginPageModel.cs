using System;
using SpeedportHybridControl.Implementations;
using System.Windows;
using System.Threading;

namespace SpeedportHybridControl.Model {
	class LoginPageModel : SuperViewModel {
		private string _ip = "speedport.ip";
		private string _password;
		private string _loginButtonText = "Login";
		private bool _showPassword;
		private bool _savePassword;
		private Visibility _passwordBoxVisibility = Visibility.Visible;
		private Visibility _passwordTextBoxVisibility = Visibility.Hidden;

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

		public string LoginButtonText {
			get { return _loginButtonText; }
			set { SetProperty(ref _loginButtonText, value); }
		}

		public bool ShowPassword {
			get { return _showPassword; }
			set { SetProperty(ref _showPassword, value); }
		}

		public bool SavePassword {
			get { return _savePassword; }
			set { SetProperty(ref _savePassword, value); }
		}

		public Visibility PasswordBoxVisibility {
			get { return _passwordBoxVisibility; }
			set { SetProperty(ref _passwordBoxVisibility, value); }
		}

		public Visibility PasswordTextBoxVisibility {
			get { return _passwordTextBoxVisibility; }
			set { SetProperty(ref _passwordTextBoxVisibility, value); }
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
			if (ShowPassword.Equals(true)) {
				PasswordBoxVisibility = Visibility.Hidden;
				PasswordTextBoxVisibility = Visibility.Visible;
            }
			else {
				PasswordBoxVisibility = Visibility.Visible;
				PasswordTextBoxVisibility = Visibility.Hidden;
			}
		}

		private void OnSavePasswordCommandExecute () {
			Console.WriteLine(SavePassword);
		}

		private void OnLoginCommandExecute () {
			MainWindowModel mwm = Application.Current.FindResource("MainWindowModel") as MainWindowModel;

			if (LoginButtonText.Equals("Login")) {
				if (SpeedportHybridAPI.getInstance().ip.Equals(ip).Equals(false)) {
					SpeedportHybridAPI.getInstance().ip = ip;
				}

				bool login = SpeedportHybridAPI.getInstance().login(password);
				if (login.Equals(true)) {
					if (SavePassword.Equals(true)) {
						/*
						SettingsModel SettingsModel = new SettingsModel {
							password = password,
							ip = SpeedportHybridAPI.getInstance().ip
						};

						Settings.save(SettingsModel);
						*/
					}
					else {
						/*
						SettingsModel SettingsModel = new SettingsModel {
							password = string.Empty,
							ip = SpeedportHybridAPI.getInstance().ip
						};

						Settings.save(SettingsModel);
						*/
					}

					LoginButtonText = "Logout";
					mwm.LoginButtonContent = "Logout";
				}
				else {
					new Thread(() => { MessageBox.Show("Login fehlgeschlagen. Sie haben ein falsches Gerätepasswort eingegeben. Bitte versuchen Sie es erneut und achten Sie auf die korrekte Schreibweise.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("Login Failed, wrong password");
				}
			}
			else {
				if (SpeedportHybridAPI.getInstance().logout().Equals(true)) {
					// TODO: util.logout();
					LoginButtonText = "Login";
					mwm.LoginButtonContent = "Login";
				}
			}
		}

		public LoginPageModel () {
			// TODO: ip = Settings....
			// TODO: SpeedportHybridAPI.getInstance().ip = ip;
			ShowPasswordCommand = new DelegateCommand(new Action(OnShowPasswordCommandExecute));
			SavePasswordCommand = new DelegateCommand(new Action(OnSavePasswordCommandExecute));
			LoginCommand = new DelegateCommand(new Action(OnLoginCommandExecute));
		}
	}
}
