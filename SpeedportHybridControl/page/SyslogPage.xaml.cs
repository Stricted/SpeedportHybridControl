using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System;
using SpeedportHybridControl.Model;
using System.Threading.Tasks;

namespace SpeedportHybridControl.page {
	/// <summary>
	/// Interaction logic for SyslogPage.xaml
	/// </summary>
	public partial class SyslogPage : Page {
		public SyslogPage() {
			InitializeComponent();
		}
		
		public void init () {
			tbSearch.Text = string.Empty;
		}

		private bool SyslogFilter (object item) {
			//if (tbSearch.Text.IsNullOrEmpty().Equals(false)) {
			//	return ((item as SyslogList).message.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
			//}

			return true;
		}
		
		private void button_click(object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(btnReload)) {
				SpeedportHybrid.initSyslog();
				TextChanged(null, null);
			}
			else if (sender.Equals(btnClear)) {
				MessageBoxResult result = MessageBox.Show("Sollen die System-Informationen wirklich gelöscht werden?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
				if (result.Equals(MessageBoxResult.Yes)) {
					SpeedportHybridAPI.getInstance().clearSyslog();
					util.init("Syslog");
					tbSearch.Text = string.Empty;
                }
			}
			*/
		}
		
		public void TextChanged (object sender, TextChangedEventArgs e) {
			/*
			SyslogData syslog = Application.Current.FindResource("SyslogData") as SyslogData;
			CollectionView collectionView = CollectionViewSource.GetDefaultView(syslog.syslogList) as CollectionView;
			collectionView.Filter = SyslogFilter;

			CollectionViewSource.GetDefaultView(syslog.syslogList).Refresh();
			*/			
		}

		private void CommandBinding_Executed(object sender, RoutedEventArgs e) {
			string text = string.Empty;

			if (e.Source.Equals(listView)) {
				text = listView.SelectedItem.ToString();
			}

			Clipboard.SetText(text);
			text = null;
		}
	}
}
