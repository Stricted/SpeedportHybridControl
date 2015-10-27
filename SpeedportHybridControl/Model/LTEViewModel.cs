using System.Windows.Media;

namespace SpeedportHybridControl.Model {
	public class LTE : SuperViewModel {
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

		public LTE() {
		}
	}
}
