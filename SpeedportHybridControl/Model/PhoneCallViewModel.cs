using System.Collections.Generic;

namespace SpeedportHybridControl.Model {
	public class PhoneCallData : SuperViewModel {
		private List<PhoneCallList> _missedCalls;
		private List<PhoneCallList> _takenCalls;
		private List<PhoneCallList> _dialedCalls;
		private string _datetime;

		public List<PhoneCallList> missedCalls {
			get { return _missedCalls; }
			set { SetProperty(ref _missedCalls, value); }
		}

		public List<PhoneCallList> takenCalls {
			get { return _takenCalls; }
			set { SetProperty(ref _takenCalls, value); }
		}

		public List<PhoneCallList> dialedCalls {
			get { return _dialedCalls; }
			set { SetProperty(ref _dialedCalls, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		public PhoneCallData () {
		}
	}

	public class PhoneCallList : SuperViewModel {
		private int _id;
		private string _date;
		private string _time;
		private string _who;
		private string _duration;

		public int id {
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		public string date {
			get { return _date; }
			set { SetProperty(ref _date, value); }
		}

		public string time {
			get { return _time; }
			set { SetProperty(ref _time, value); }
		}

		public string who {
			get { return _who; }
			set { SetProperty(ref _who, value); }
		}

		public string duration {
			get { return _duration; }
			set { SetProperty(ref _duration, value); }
		}

		public override string ToString() {
			return string.Concat(date, " ", time, " ", who, " ", duration);
		}

		public PhoneCallList () {
		}
	}
}
