using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedportHybridControl.Model {
	public class SyslogList : SuperViewModel {
		private string _message;
		private string _timestamp;
		private bool _isSelected;

		public string message {
			get { return _message; }
			set { SetProperty(ref _message, value); }
		}

		public string timestamp {
			get { return _timestamp; }
			set { SetProperty(ref _timestamp, value); }
		}

		public bool IsSelected
		{
			get { return _isSelected; }
			set { SetProperty(ref _isSelected, value); }
		}

		public override string ToString () {
			return string.Concat(timestamp, ": ", message);
		}

		public SyslogList () {
		}
	}
}
