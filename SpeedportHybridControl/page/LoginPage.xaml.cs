using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page {
		public bool savePW;

		public LoginPage() {
			InitializeComponent();
		}

		void loaded (object sender, RoutedEventArgs e) {
			/*
			SettingsModel settings = Settings.load();
			if (settings.ip.IsNullOrEmpty().Equals(false)) {
				SpeedportHybridAPI.getInstance().ip = settings.ip;
			}

			if (settings.password.IsNullOrEmpty().Equals(false)) {
				savePW = true;
				cbSave.IsChecked = true;
				PasswordBox.Password = settings.password;
			}

			PasswordBox.Focus();

			tbip.Text = SpeedportHybridAPI.getInstance().ip;
			*/
		}

		private void button_click(object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(button1)) {
				if (button1.Content.Equals("Login")) {
					if (SpeedportHybridAPI.getInstance().ip.Equals(tbip.Text).Equals(false)) {
						SpeedportHybridAPI.getInstance().ip = tbip.Text;
					}

					if (PasswordCheckBox.IsChecked.Equals(true)) {
						PasswordBox.Password = PasswordTextBox.Text;
						PasswordCheckBox.IsChecked = false;
					}

					if (SpeedportHybridAPI.getInstance().login(PasswordBox.Password).Equals(true)) {
						util.login();
						SettingsModel SettingsModel = null;

						if (savePW.Equals(true)) {
							SettingsModel = new SettingsModel {
								password = PasswordBox.Password,
								ip = SpeedportHybridAPI.getInstance().ip
							};
						}
						else {
							SettingsModel = new SettingsModel {
								password = string.Empty,
								ip = SpeedportHybridAPI.getInstance().ip
							};
						}

						Settings.save(SettingsModel);
					}
					else {
						new Thread(() => { MessageBox.Show("Login fehlgeschlagen. Sie haben ein falsches Gerätepasswort eingegeben. Bitte versuchen Sie es erneut und achten Sie auf die korrekte Schreibweise.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
						LogManager.WriteToLog("Login Failed, wrong password");
						PasswordBox.Focus();
					}
				}
				else if (button1.Content.Equals("Logout")) {
					if (SpeedportHybridAPI.getInstance().logout().Equals(true)) {
						util.logout();
					}
				}
			}
			*/
		}

		private void CheckBox(object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(PasswordCheckBox)) {
				if (PasswordCheckBox.IsChecked.Equals(true)) {
					PasswordTextBox.Text = PasswordBox.Password;
					PasswordBox.Visibility = Visibility.Hidden;
					PasswordTextBox.Visibility = Visibility.Visible;
					PasswordTextBox.Focus();
				}
				else {
					PasswordBox.Password = PasswordTextBox.Text;
					PasswordBox.Visibility = Visibility.Visible;
					PasswordTextBox.Visibility = Visibility.Hidden;
					PasswordBox.Focus();
				}
			}
			else if (sender.Equals(cbSave)) {
				if (cbSave.IsChecked.Equals(true)) {
					savePW = true;
				}
				else {
					savePW = false;
				}
			}
			*/
		}
	}
}
