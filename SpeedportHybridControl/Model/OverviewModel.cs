namespace SpeedportHybridControl.Model {
	public class OverviewModel : SuperViewModel {
		private string _onlinestatus;
		private string _dsl_link_status;
		private string _lte_image = "../assets/lte0.png";
		private string _number_status;
		private string _use_dect;
		private string _dect_devices;
		private string _devices;
		private string _use_wlan;
		private string _use_wlan_5ghz;
		private string _wlan_enc;
		private string _wlan_power;
		private string _external_devices; 
		private string _nas_sync_active;
		private string _nas_backup_active;
		private string _mc_state;
		private string _days_online;
		private string _datetime;

		public string onlinestatus {
			get { return _onlinestatus; }
			set { SetProperty(ref _onlinestatus, value); }
		}

		public string dsl_link_status {
			get { return _dsl_link_status; }
			set { SetProperty(ref _dsl_link_status, value); }
		}

		public string lte_image {
			get { return _lte_image; }
			set { SetProperty(ref _lte_image, value); }
		}

		public string number_status {
			get { return _number_status; }
			set { SetProperty(ref _number_status, value); }
		}

		public string use_dect {
			get { return _use_dect; }
			set { SetProperty(ref _use_dect, value); }
		}

		public string dect_devices {
			get { return _dect_devices; }
			set { SetProperty(ref _dect_devices, value); }
		}

		public string devices {
			get { return _devices; }
			set { SetProperty(ref _devices, value); }
		}

		public string use_wlan {
			get { return _use_wlan; }
			set { SetProperty(ref _use_wlan, value); }
		}

		public string use_wlan_5ghz {
			get { return _use_wlan_5ghz; }
			set { SetProperty(ref _use_wlan_5ghz, value); }
		}

		public string wlan_enc {
			get { return _wlan_enc; }
			set { SetProperty(ref _wlan_enc, value); }
		}

		public string wlan_power {
			get { return _wlan_power; }
			set { SetProperty(ref _wlan_power, value); }
		}

		public string external_devices {
			get { return _external_devices; }
			set { SetProperty(ref _external_devices, value); }
		}

		public string nas_sync_active {
			get { return _nas_sync_active; }
			set { SetProperty(ref _nas_sync_active, value); }
		}

		public string nas_backup_active {
			get { return _nas_backup_active; }
			set { SetProperty(ref _nas_backup_active, value); }
		}

		public string mc_state {
			get { return _mc_state; }
			set { SetProperty(ref _mc_state, value); }
		}

		public string days_online {
			get { return _days_online; }
			set { SetProperty(ref _days_online, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		public OverviewModel () {

		}
	}
}
