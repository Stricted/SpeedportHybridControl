using System.Windows;
using System.Windows.Controls;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for TR181Page.xaml
	/// </summary>
	public partial class TR181Page : Page {
		public TR181Page() {
			InitializeComponent();
		}

		private void button_click(object sender, RoutedEventArgs e) {
			if (sender.Equals(reload)) {
				//util.init("TR181");
			}
			else if (sender.Equals(btnSave)) {
				//SpeedportHybridAPI.getInstance().setQueueSkbTimeOut(tbQueue.Text);
			}
		}
	}
}
