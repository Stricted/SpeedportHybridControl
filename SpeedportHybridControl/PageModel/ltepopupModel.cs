using System;
using SpeedportHybridControl.Data;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.Charts;
using System.Timers;
using System.Windows.Media;
using System.IO;
using System.Windows;
using System.Threading;

namespace SpeedportHybridControl.PageModel
{
    class ltepopupModel : SuperViewModel
    {
        private System.Timers.Timer _timer;
        private DelegateCommand _pinCommand;
        private DelegateCommand _closeWindowCommand;
        private bool _pinActive;
        private bool _logActive;

        private bool _topmost = false;
        private LTECollection _lteCollection;
        private LTECollection _lteCollection2;
        private EnumerableDataSource<LTEData> _rsrqGraph;
        private EnumerableDataSource<LTEData> _rsrpGraph;
        private HorizontalDateTimeAxis _dateTimeAxis1;
        private HorizontalDateTimeAxis _dateTimeAxis2;

        private string _phycellid;
        private string _cellid;
        private string _rsrp;
        private Brush _rsrp_bg = Brushes.Transparent;
        private string _rsrq;
        private Brush _rsrq_bg = Brushes.Transparent;
        private string _datetime;

        public DelegateCommand PinCommand
        {
            get { return _pinCommand; }
            set { SetProperty(ref _pinCommand, value); }
        }

        public DelegateCommand CloseWindowCommand
        {
            get { return _closeWindowCommand; }
            set { SetProperty(ref _closeWindowCommand, value); }
        }

        public bool PinActive
        {
            get { return _pinActive; }
            set { SetProperty(ref _pinActive, value); }
        }

        public bool LogActive
        {
            get { return _logActive; }
            set { SetProperty(ref _logActive, value); }
        }

        public bool Topmost
        {
            get { return _topmost; }
            set { SetProperty(ref _topmost, value); }
        }

        public LTECollection LTECollection
        {
            get { return _lteCollection; }
            set { SetProperty(ref _lteCollection, value); }
        }

        public LTECollection LTECollection2
        {
            get { return _lteCollection2; }
            set { SetProperty(ref _lteCollection2, value); }
        }

        public EnumerableDataSource<LTEData> RsrqGraph
        {
            get { return _rsrqGraph; }
            set { SetProperty(ref _rsrqGraph, value); }
        }

        public EnumerableDataSource<LTEData> RsrpGraph
        {
            get { return _rsrpGraph; }
            set { SetProperty(ref _rsrpGraph, value); }
        }

        public HorizontalDateTimeAxis DateTimeAxis1
        {
            get { return _dateTimeAxis1; }
            set { SetProperty(ref _dateTimeAxis1, value); }
        }

        public HorizontalDateTimeAxis DateTimeAxis2
        {
            get { return _dateTimeAxis2; }
            set { SetProperty(ref _dateTimeAxis2, value); }
        }

        public string phycellid
        {
            get { return _phycellid; }
            set { SetProperty(ref _phycellid, value); }
        }

        public string cellid
        {
            get { return _cellid; }
            set { SetProperty(ref _cellid, value); }
        }

        public string rsrp
        {
            get { return _rsrp; }
            set { SetProperty(ref _rsrp, value); }
        }

        public Brush rsrp_bg
        {
            get { return _rsrp_bg; }
            set { SetProperty(ref _rsrp_bg, value); }
        }

        public string rsrq
        {
            get { return _rsrq; }
            set { SetProperty(ref _rsrq, value); }
        }

        public Brush rsrq_bg
        {
            get { return _rsrq_bg; }
            set { SetProperty(ref _rsrq_bg, value); }
        }

        public string datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        public void StopTimer()
        {
            if (Object.Equals(_timer, null).Equals(false))
            {
                _timer.Stop();
            }
        }

        public void StartTimer()
        {
            StopTimer();

            _timer = new System.Timers.Timer
            {
                Interval = 1000, // every second
            };

            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            new Thread(() => {
                SpeedportHybrid.initLtePopup();
                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    LTECollection.Add(new LTEData() { Date = DateTime.Now, Data = rsrq.ToInt() });
                    LTECollection2.Add(new LTEData() { Date = DateTime.Now, Data = rsrp.ToInt() });

                    if (LogActive.Equals(true))
                    {
                        // log
                        log(string.Concat("Pysical Cell ID: ", phycellid, ", Cell ID: ", cellid, ", RSRP: ", rsrp, ", RSRQ: ", rsrq));
                    }
                }));
            }).Start();
        }

        private void log(string value)
        {
            DateTime time = DateTime.Now;

            if (Directory.Exists("log/").Equals(false))
                Directory.CreateDirectory("log/");

            if (Directory.Exists("log/lte/").Equals(false))
                Directory.CreateDirectory("log/lte/");

            StreamWriter file = new StreamWriter(string.Concat("log/lte/", time.ToString("dd.MM.yyyy"), ".txt"), true);
            file.WriteLine(string.Concat("[", time.ToString("dd.MM.yyyy HH:mm:ss"), "]: ", value));
            file.Close();
        }

        private void OnPinCommandExecute()
        {
            if (PinActive.Equals(true))
            {
                Topmost = true;
            }
            else {
                Topmost = false;
            }
        }

        private void OnCloseWindowCommandExecute()
        {
            StopTimer();
        }

        public ltepopupModel()
        {
            PinCommand = new DelegateCommand(new Action(OnPinCommandExecute));
            CloseWindowCommand = new DelegateCommand(new Action(OnCloseWindowCommandExecute));

            LTECollection = new LTECollection();
            LTECollection2 = new LTECollection();
            DateTimeAxis1 = new HorizontalDateTimeAxis();
            DateTimeAxis2 = new HorizontalDateTimeAxis();

            var ds = new EnumerableDataSource<LTEData>(LTECollection);
            ds.SetXMapping(x => DateTimeAxis1.ConvertToDouble(x.Date));
            ds.SetYMapping(y => y.Data);

            RsrqGraph = ds;

            var ds2 = new EnumerableDataSource<LTEData>(LTECollection2);
            ds2.SetXMapping(x => DateTimeAxis1.ConvertToDouble(x.Date));
            ds2.SetYMapping(y => y.Data);

            RsrpGraph = ds2;
        }
    }
}
