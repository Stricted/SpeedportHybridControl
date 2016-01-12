using SpeedportHybridControl.Data;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.Model;
using System;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SpeedportHybridControl.PageModel {
	class LteInfoModel : SuperViewModel {
		private DelegateCommand _reloadCommand;
		private DelegateCommand _autoReloadCommand;
		private DelegateCommand _saveCommand;
		private DelegateCommand _popupCommand;
		private System.Timers.Timer _timer;
		private bool _autoReload;
		private ltepopup _ltepopup;
		private ComboBoxItem _selectedItem;


		private string _imei;
		private string _imsi;
		private string _device_status;
		private string _card_status;
		private string _antenna_mode;
		private string _antenna_mode2;
		private string _phycellid;
		private string _cellid;
		private string _rsrp;
		private Brush _rsrp_bg = Brushes.Transparent;
		private string _rsrq;
		private Brush _rsrq_bg = Brushes.Transparent;
		private string _service_status;
		private string _tac;
		private string _datetime;
		private string _frequenz;

		public DelegateCommand ReloadCommand {
			get { return _reloadCommand; }
			set { SetProperty(ref _reloadCommand, value); }
		}

		public DelegateCommand AutoReloadCommand {
			get { return _autoReloadCommand; }
			set { SetProperty(ref _autoReloadCommand, value); }
		}

		public DelegateCommand SaveCommand {
			get { return _saveCommand; }
			set { SetProperty(ref _saveCommand, value); }
		}

		public DelegateCommand PopupCommand {
			get { return _popupCommand; }
			set { SetProperty(ref _popupCommand, value); }
		}

		public ComboBoxItem SelectedItem {
			get { return _selectedItem; }
			set { SetProperty(ref _selectedItem, value); }
		}

		private void OnReloadCommandExecute () {
			new Thread(() => { SpeedportHybrid.initLTE(); }).Start();
		}

		private void OnAutoReloadCommandExecute () {
			if (AutoReload.Equals(true)) {
				StartTimer();
			}
			else {
				StopTimer();
			}
		}

		private void OnSaveCommandExecute () {
			SpeedportHybridAPI.getInstance().setAntennaMode(SelectedItem.Name);
			OnReloadCommandExecute();
        }

		private void OnPopupCommandExecute () {
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

			ltepopupModel lm = Application.Current.FindResource("ltepopupModel") as ltepopupModel;
			lm.StartTimer();
		}

		public bool AutoReload {
			get { return _autoReload; }
			set { SetProperty(ref _autoReload, value); }
		}

		public void StopTimer () {
			if (Object.Equals(_timer, null).Equals(false)) {
				_timer.Stop();
			}

			if (AutoReload.Equals(true)) {
				AutoReload = false;
			}
		}

		private void StartTimer () {
			_timer = new System.Timers.Timer {
				Interval = 1000, // every second
			};

			_timer.Elapsed += timer_Elapsed;
			_timer.Start();
		}

		private void timer_Elapsed (object sender, ElapsedEventArgs e) {
			OnReloadCommandExecute();
		}

		public string imei {
			get { return _imei; }
			set { SetProperty(ref _imei, value); }
		}

		public string imsi {
			get { return _imsi; }
			set { SetProperty(ref _imsi, value); }
		}

		public string device_status {
			get { return _device_status; }
			set { SetProperty(ref _device_status, value); }
		}

		public string card_status {
			get { return _card_status; }
			set { SetProperty(ref _card_status, value); }
		}

		public string antenna_mode {
			get { return _antenna_mode; }
			set { SetProperty(ref _antenna_mode, value); }
		}

		public string antenna_mode2 {
			get { return _antenna_mode2; }
			set { SetProperty(ref _antenna_mode2, value); }
		}

		public string phycellid {
			get { return _phycellid; }
			set { SetProperty(ref _phycellid, value); }
		}

		public string cellid {
			get { return _cellid; }
			set { SetProperty(ref _cellid, value); }
		}

		public string rsrp {
			get { return _rsrp; }
			set { SetProperty(ref _rsrp, value); }
		}

		public Brush rsrp_bg {
			get { return _rsrp_bg; }
			set { SetProperty(ref _rsrp_bg, value); }
		}

		public string rsrq {
			get { return _rsrq; }
			set { SetProperty(ref _rsrq, value); }
		}

		public Brush rsrq_bg {
			get { return _rsrq_bg; }
			set { SetProperty(ref _rsrq_bg, value); }
		}

		public string service_status {
			get { return _service_status; }
			set { SetProperty(ref _service_status, value); }
		}

		public string tac {
			get { return _tac; }
			set { SetProperty(ref _tac, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		public string frequenz {
			get { return _frequenz; }
			set { SetProperty(ref _frequenz, value); }
		}

		public LteInfoModel () {
			ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
			AutoReloadCommand = new DelegateCommand(new Action(OnAutoReloadCommandExecute));
			SaveCommand = new DelegateCommand(new Action(OnSaveCommandExecute));
			PopupCommand = new DelegateCommand(new Action(OnPopupCommandExecute));
		}
	}
}
