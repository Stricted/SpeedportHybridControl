namespace SpeedportHybridControl.Model {
	public class TR181 : SuperViewModel {
		private string _enable1;
		private string _status1;
		private string _mode;
		private string _servername;
		private string _severip;
		private string _bw;
		private string _errorinfo;
		private string _hellostatus;

		private string _lte_tunnel;
		private string _dsl_tunnel;
		private string _bonding;
		private string _QueueSkbTimeOut;

		private string _datetime;

		private string _bypass_up_bw;
		private string _bypass_dw_bw;
		private string _bypass_up_rb;
		private string _bypass_dw_rb;
		private string _bypass_check;

		public string enable1 {
			get { return _enable1; }
			set { SetProperty(ref _enable1, value); }
		}
		
		public string status1 {
			get { return _status1; }
			set { SetProperty(ref _status1, value); }
		}
		
		public string mode {
			get { return _mode; }
			set { SetProperty(ref _mode, value); }
		}
		
		public string servername {
			get { return _servername; }
			set { SetProperty(ref _servername, value); }
		}
		
		public string severip {
			get { return _severip; }
			set { SetProperty(ref _severip, value); }
		}
		
		public string bw {
			get { return _bw; }
			set { SetProperty(ref _bw, value); }
		}
		
		public string errorinfo {
			get { return _errorinfo; }
			set { SetProperty(ref _errorinfo, value); }
		}
		
		public string hellostatus {
			get { return _hellostatus; }
			set { SetProperty(ref _hellostatus, value); }
		}
		
		public string lte_tunnel {
			get { return _lte_tunnel; }
			set { SetProperty(ref _lte_tunnel, value); }
		}

		public string dsl_tunnel {
			get { return _dsl_tunnel; }
			set { SetProperty(ref _dsl_tunnel, value); }
		}

		public string bonding {
			get { return _bonding; }
			set { SetProperty(ref _bonding, value); }
		}
		
		public string QueueSkbTimeOut {
			get { return _QueueSkbTimeOut; }
			set { SetProperty(ref _QueueSkbTimeOut, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		public string bypass_up_bw {
			get { return _bypass_up_bw; }
			set { SetProperty(ref _bypass_up_bw, value); }
		}

		public string bypass_dw_bw {
			get { return _bypass_dw_bw; }
			set { SetProperty(ref _bypass_dw_bw, value); }
		}

		public string bypass_up_rb {
			get { return _bypass_up_rb; }
			set { SetProperty(ref _bypass_up_rb, value); }
		}

		public string bypass_dw_rb {
			get { return _bypass_dw_rb; }
			set { SetProperty(ref _bypass_dw_rb, value); }
		}

		public string bypass_check {
			get { return _bypass_check; }
			set { SetProperty(ref _bypass_check, value); }
		}

		public TR181() {
		}
	}
}
