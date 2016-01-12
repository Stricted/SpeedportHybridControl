using SpeedportHybridControl.Data;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.Model;
using System;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows;

namespace SpeedportHybridControl.PageModel
{
    class DslPageModel : SuperViewModel
    {
        private DelegateCommand _reloadCommand;
        private DelegateCommand _autoReloadCommand;
        private bool _autoReload;
        private bool _log;
        private bool _logEnabled;
        private System.Timers.Timer _timer;

        private Connection _Connection;
        private Line _Line;
        private string _datetime;

        private string _lastCRC;
        private string _lastHEC;
        private string _lastFEC;

        private int lastdFEC;
        private int lastuFEC;
        private int lastdHEC;
        private int lastuHEC;
        private int lastdCRC;
        private int lastuCRC;
        private DateTime lastReload;

        public Connection Connection
        {
            get { return _Connection; }
            set { SetProperty(ref _Connection, value); }
        }

        public Line Line
        {
            get { return _Line; }
            set { SetProperty(ref _Line, value); }
        }

        public string datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        public string lastCRC
        {
            get { return _lastCRC; }
            set { SetProperty(ref _lastCRC, value); }
        }

        public string lastFEC
        {
            get { return _lastFEC; }
            set { SetProperty(ref _lastFEC, value); }
        }

        public string lastHEC
        {
            get { return _lastHEC; }
            set { SetProperty(ref _lastHEC, value); }
        }


        public DelegateCommand ReloadCommand
        {
            get { return _reloadCommand; }
            set { SetProperty(ref _reloadCommand, value); }
        }

        public DelegateCommand AutoReloadCommand
        {
            get { return _autoReloadCommand; }
            set { SetProperty(ref _autoReloadCommand, value); }
        }

        public bool AutoReload
        {
            get { return _autoReload; }
            set { SetProperty(ref _autoReload, value); }
        }

        public bool Log
        {
            get { return _log; }
            set { SetProperty(ref _log, value); }
        }

        public bool LogEnabled
        {
            get { return _logEnabled; }
            set { SetProperty(ref _logEnabled, value); }
        }

        private void OnReloadCommandExecute()
        {
            new Thread(() => {
                SpeedportHybrid.initDSL();

                if (lastReload.Equals(DateTime.MinValue).Equals(false))
                {
                    DateTime now = DateTime.Now;
                    double difference = Math.Ceiling(Math.Ceiling((DateTime.Now - lastReload).TotalSeconds) / 60);

                    double diffdCRC = Math.Ceiling((Line.dCRC - lastdCRC) / difference);
                    double diffuCRC = Math.Ceiling((Line.uCRC - lastuCRC) / difference);
                    lastCRC = string.Format("CRC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuCRC, diffdCRC);

                    double diffdHEC = Math.Ceiling((Line.dHEC - lastdHEC) / difference);
                    double diffuHEC = Math.Ceiling((Line.uHEC - lastuHEC) / difference);
                    lastHEC = string.Format("HEC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuHEC, diffdHEC);

                    double diffdFEC = Math.Ceiling((Line.dFEC - lastdFEC) / difference);
                    double diffuFEC = Math.Ceiling((Line.uFEC - lastuFEC) / difference);
                    lastFEC = string.Format("FEC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuFEC, diffdFEC);
                }

                lastReload = DateTime.Now;
                lastdCRC = Line.dCRC;
                lastuCRC = Line.uCRC;

                lastdHEC = Line.dHEC;
                lastuHEC = Line.uHEC;

                lastdFEC = Line.dFEC;
                lastuFEC = Line.uFEC;
            }).Start();
        }

        private void OnAutoReloadCommandExecute()
        {
            if (AutoReload.Equals(true))
            {
                StartTimer();
                LogEnabled = true;
            }
            else {
                StopTimer();
            }
        }

        public void StopTimer()
        {
            if (Object.Equals(_timer, null).Equals(false))
            {
                _timer.Stop();
            }

            if (AutoReload.Equals(true))
            {
                AutoReload = false;
            }

            if (Log.Equals(true))
            {
                Log = false;
            }

            LogEnabled = false;
        }

        private void StartTimer()
        {
            _timer = new System.Timers.Timer
            {
                Interval = 1000, // every second
            };

            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SpeedportHybrid.initDSL();

            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                if (Log.Equals(true))
                {
                    //log
                    string prepare = "State: {0}, Actual Data Rate: up: {1} down: {2}, Attainable Data Rate: up: {3} down: {4}, SNR Margin up: {5} down: {6}, CRC error count: up: {7} down: {8}, HEC error count: up: {9} down: {10}, FEC error count: up: {11} down: {12}";
                    log(string.Format(prepare, Connection.state, Line.uactual, Line.dactual, Line.uattainable, Line.dattainable, Line.uSNR, Line.dSNR, Line.uCRC, Line.dCRC, Line.uHEC, Line.dHEC, Line.uFEC, Line.dFEC));
                    log(string.Format("CRC/min up: {0} down: {1}, HEC/min up: {2} down: {3}, FEC/min up: {4} down: {5}", Line.uCRCsec, Line.dCRCsec, Line.uHECsec, Line.dHECsec, Line.uFECsec, Line.dFECsec));
                }
            }));
        }

        private void log(string value)
        {
            DateTime time = DateTime.Now;

            if (Directory.Exists("log/").Equals(false))
                Directory.CreateDirectory("log/");

            if (Directory.Exists("log/dsl/").Equals(false))
                Directory.CreateDirectory("log/dsl/");

            StreamWriter file = new StreamWriter(string.Concat("log/dsl/", time.ToString("dd.MM.yyyy"), ".txt"), true);
            file.WriteLine(string.Concat("[", time.ToString("dd.MM.yyyy HH:mm:ss"), "]: ", value));
            file.Close();
        }

        public DslPageModel()
        {
            ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
            AutoReloadCommand = new DelegateCommand(new Action(OnAutoReloadCommandExecute));
        }
    }
}
