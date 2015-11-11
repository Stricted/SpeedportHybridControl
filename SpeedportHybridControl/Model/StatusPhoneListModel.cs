namespace SpeedportHybridControl.Model {
	class StatusPhoneListModel : SuperViewModel {
		private string _number;
		private string _status;

		public string number {
			get { return _number; }
			set { SetProperty(ref _number, value); }
		}

		public string status {
			get { return _status; }
			set { SetProperty(ref _status, value); }
		}

		public StatusPhoneListModel () {

		}
	}
}
