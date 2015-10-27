using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System;

namespace SpeedportHybridControl.page {


	/// <summary>
	/// Interaction logic for LteInfoPage.xaml
	/// </summary>
	public partial class LteInfoPage : Page {
		public Timer _timer;
		//public ltepopup _ltepopup;
		public LteInfoPage() {
			InitializeComponent();
		}

		public void StopTimer () {
			if (Object.Equals(_timer, null).Equals(false)) {
				_timer.Stop();
			}

			if (autoreload.IsChecked.Equals(true)) {
				autoreload.IsChecked = false;
			}
		}

		private void StartTimer () {
			_timer = new Timer {
				Interval = 1000, // every second
			};

			_timer.Elapsed += timer_Elapsed;
			_timer.Start();
		}

		void timer_Elapsed (object sender, ElapsedEventArgs e) {
			//util.init("LTE");
		}

		private void button_click(object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(reload)) {
				util.init("LTE");
			}
			else if (sender.Equals(autoreload)) {
				if (autoreload.IsChecked.Equals(true)) {
					StartTimer();
				}
				else {
					StopTimer();
				}
			}
			else if (sender.Equals(btnSave)) {
				ComboBoxItem item = cbAntenna.SelectedItem as ComboBoxItem;
				SpeedportHybridAPI.getInstance().setAntennaMode(item.Name);
				util.init("LTE");
			}
			else if (sender.Equals(btnPopup)) {
				if (Object.Equals(_ltepopup, null)) {
					_ltepopup = new ltepopup();
				}
				else if (Object.Equals(_ltepopup, null).Equals(false) && _ltepopup.IsLoaded.Equals(false)) {
					_ltepopup = null;
					_ltepopup = new ltepopup();
				}

				if (_ltepopup.Visibility.Equals(Visibility.Visible).Equals(false)) {
					_ltepopup.Show();
					StopTimer();
				}
			}
			*/
		}
	}
}
