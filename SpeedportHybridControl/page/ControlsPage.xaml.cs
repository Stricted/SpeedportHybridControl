using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for ControlsPage.xaml
	/// </summary>
	public partial class ControlsPage : Page {
		public ControlsPage() {
			InitializeComponent();
		}

		private void button_click (object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(button7)) {
				MessageBoxResult result = MessageBox.Show("Willst du den Router wirklich neustarten?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
				if (result.Equals(MessageBoxResult.Yes)) {
					SpeedportHybridAPI.getInstance().reboot();
				}
			}
			else if (sender.Equals(button8)) {
				new Thread(() => {
					bool reconnectLte = SpeedportHybridAPI.getInstance().reconnectLte();
					if (reconnectLte.Equals(false)) {
						new Thread(() => { MessageBox.Show("Could not reconnect LTE.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
						LogManager.WriteToLog("Could not reconnect LTE.");
					}
					else {
						new Thread(() => { MessageBox.Show("LTE reconnected", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
					}
				}).Start();
			}
			else if (sender.Equals(button9)) {
				new Thread(() => {
					bool reconnectDSL = SpeedportHybridAPI.getInstance().reconnectDSL();
					if (reconnectDSL.Equals(false)) {
						new Thread(() => { MessageBox.Show("Could not reconnect DSL.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
						LogManager.WriteToLog("Could not reconnect DSL.");
					}
					else {
						new Thread(() => { MessageBox.Show("DSL reconnected", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
					}
				}).Start();
			}
			else if (sender.Equals(button10)) {
				SpeedportHybridAPI.getInstance().checkFirmware();
			}
			else if (sender.Equals(button17)) {
				MessageBoxResult result = MessageBox.Show("Beim Zurücksetzen auf die Werkseinstellungen gehen alle Ihre Einstellungen verloren.\nSind Sie sicher, dass Sie den Router zurücksetzen möchten ? ", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
				if (result.Equals(MessageBoxResult.Yes)) {
					bool reconnectDSL = SpeedportHybridAPI.getInstance().resetToFactoryDefault();
					if (reconnectDSL.Equals(false)) {
						new Thread(() => { MessageBox.Show("Could not reset the router.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
						LogManager.WriteToLog("Could not reset the router.");
					}
				}
			}
			else if (sender.Equals(btnflushdns)) {
				new Thread(() => { SpeedportHybridAPI.getInstance().flushDNS(); }).Start();
			}
			else if (sender.Equals(btnSpeedtest)) {
				Process.Start("http://www.speedtest.net/");
			}
			else if (sender.Equals(btnSpeedtest2)) {
				Process.Start("http://speedtest.t-online.de/");
			}
			else if (sender.Equals(btnDSLconnect)) {
				bool status = SpeedportHybridAPI.getInstance().changeDSLStatus("online");
				if (status.Equals(false)) {
					new Thread(() => { MessageBox.Show("DSL Verbinden Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("Could not connect DSL.");
				}
				else {
					new Thread(() => { MessageBox.Show("DSL Verbinden erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
				}
			}
			else if (sender.Equals(btnDSLdisconnect)) {
				bool status = SpeedportHybridAPI.getInstance().changeDSLStatus("offline");
				if (status.Equals(false)) {
					new Thread(() => { MessageBox.Show("DSL Trennen Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("Could not disconnect DSL.");
				}
				else {
					new Thread(() => { MessageBox.Show("DSL Trennen erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
				}
			}
			else if (sender.Equals(btnLTEconnect)) {
				bool status = SpeedportHybridAPI.getInstance().changeLTEStatus("online");
				if (status.Equals(false)) {
					new Thread(() => { MessageBox.Show("LTE Verbinden Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("Could not connect LTE.");
				}
				else {
					new Thread(() => { MessageBox.Show("LTE Verbinden erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
				}
			}
			else if (sender.Equals(btnLTEdisconnect)) {
				bool status = SpeedportHybridAPI.getInstance().changeLTEStatus("offline");
				if (status.Equals(false)) {
					new Thread(() => { MessageBox.Show("LTE Trennen Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("Could not disconnect LTE.");
				}
				else {
					new Thread(() => { MessageBox.Show("LTE Trennen erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
				}
			}
			*/
		}
	}
}
