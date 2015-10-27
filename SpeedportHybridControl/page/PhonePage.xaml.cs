using System.Windows;
using System.Windows.Controls;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for PhonePage.xaml
	/// </summary>
	public partial class PhonePage : Page {
		public PhonePage() {
			InitializeComponent();
		}

		private void CommandBinding_Executed(object sender, RoutedEventArgs e) {
			string text = string.Empty;

			if (e.Source.Equals(listView1)) {
				text = listView1.SelectedItem.ToString();
			}
			else if (e.Source.Equals(listView2)) {
				text = listView2.SelectedItem.ToString();
			}
			else if (e.Source.Equals(listView3)) {
				text = listView3.SelectedItem.ToString();
			}
			Clipboard.SetText(text);
			text = null;
		}

		private void button_click(object sender, RoutedEventArgs e) {
			if (sender.Equals(reload)) {
				//util.init("Phone");
			}
		}
	}
}
