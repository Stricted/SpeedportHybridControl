namespace SpeedportHybridControl.Model {
	public class DeviceList : SuperViewModel {
		private int _id;
		private string _name;
		private string _mac;
		private int _type;
		private int _connected;
		private string _ipv4;
		private string _ipv6;
		private int _static;

		public int id {
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		public string name {
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		public string mac {
			get { return _mac; }
			set { SetProperty(ref _mac, value); }
		}

		public int type {
			get { return _type; }
			set { SetProperty(ref _type, value); }
		}

		public int connected {
			get { return _connected; }
			set { SetProperty(ref _connected, value); }
		}

		public string ipv4 {
			get { return _ipv4; }
			set { SetProperty(ref _ipv4, value); }
		}

		public string ipv6 {
			get { return _ipv6; }
			set { SetProperty(ref _ipv6, value); }
		}

		public int mstatic {
			get { return _static; }
			set { SetProperty(ref _static, value); }
		}

		public DeviceList() {
		}
	}
}
