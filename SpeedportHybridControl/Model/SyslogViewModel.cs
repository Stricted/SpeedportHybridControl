using System.Collections.Generic;

namespace SpeedportHybridControl.Model {
	public class SyslogData : SuperViewModel {
		private List<SyslogList> _syslogList;
		private string _datetime;

		public List<SyslogList> syslogList {
			get { return _syslogList; }
			set { SetProperty(ref _syslogList, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		public SyslogData() {
		}
	}

	public class SyslogList : SuperViewModel {
		private string _message;
		private string _timestamp;

		public string message {
			get { return _message; }
			set { SetProperty(ref _message, value); }
		}

		public string timestamp {
			get { return _timestamp; }
			set { SetProperty(ref _timestamp, value); }
		}

		public override string ToString () {
			return string.Concat(timestamp, ": ", message);
		}

		public SyslogList() {
		}
	}
}
