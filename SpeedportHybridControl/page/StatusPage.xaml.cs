using SpeedportHybridControl.Model;
using System.Windows;
using System.Windows.Controls;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for StatusPage.xaml
	/// </summary>
	public partial class StatusPage : Page {
		public StatusPage() {
			InitializeComponent();
		}

		private void button_click(object sender, RoutedEventArgs e) {
			if (sender.Equals(reload)) {
				//util.init("Status");
			}
		}
    }
}
