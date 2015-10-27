using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for AboutPage.xaml
	/// </summary>
	public partial class AboutPage : Page {
		public AboutPage () {
			InitializeComponent();
			//tbVersion.Text = MainWindow.VERSION;
        }

		private void button_click (object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(btnDonate)) {
				Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E7EBAC5NP928J");
			}
			else if (sender.Equals(btnBugtracker)) {
				Process.Start("https://stricted.net/bugtracker/index.php/ProductList/");
			}
			else if (sender.Equals(btnUpdate)) {
				if (util.checkUpdate().Equals(true)) {
					new Thread(() => { MessageBox.Show("Ein Update ist verfügbar.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning); }).Start();
				}
				else {
					new Thread(() => { MessageBox.Show("SpeedportHybridControl ist auf dem neuesten Stand.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
				}
            }
			*/
		}
	}
}
