namespace SpeedportHybridControl.Model
{
    public class PhoneCallList : SuperViewModel
    {
        private int _id;
        private string _date;
        private string _time;
        private string _who;
        private string _duration;

        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public string time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        public string who
        {
            get { return _who; }
            set { SetProperty(ref _who, value); }
        }

        public string duration
        {
            get { return _duration; }
            set { SetProperty(ref _duration, value); }
        }

        public override string ToString()
        {
            return string.Concat(date, " ", time, " ", who, " ", duration);
        }

        public PhoneCallList()
        {
        }
    }
}
