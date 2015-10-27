using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System;
using SpeedportHybridControl.Model;
using System.IO;

namespace SpeedportHybridControl.page {
	public partial class DslPage : Page {
		public Timer _timer;

		public int lastdFEC;
		public int lastuFEC;
		public int lastdHEC;
		public int lastuHEC;
		public int lastdCRC;
		public int lastuCRC;
		public DateTime lastReload;

		public DslPage () {
			InitializeComponent();
		}

		public void StopTimer () {
			if (Object.Equals(_timer, null).Equals(false)) {
				_timer.Stop();
			}

			if (autoreload.IsChecked.Equals(true)) {
				autoreload.IsChecked = false;
			}

			if (btnLog.IsChecked.Equals(true)) {
				btnLog.IsChecked = false;
			}

			btnLog.IsEnabled = false;
		}

		private void StartTimer () {
			_timer = new Timer {
				Interval = 1000, // every second
			};

			_timer.Elapsed += timer_Elapsed;
			_timer.Start();
		}

		void timer_Elapsed (object sender, ElapsedEventArgs e) {
			/*
			util.init("DSL");
			DSLViewModel dsl = Application.Current.FindResource("DSL") as DSLViewModel;

			Application.Current.Dispatcher.BeginInvoke(new Action(() => {
				if (btnLog.IsChecked.Equals(true)) {
					//log
					string prepare = "State: {0}, Actual Data Rate: up: {1} down: {2}, Attainable Data Rate: up: {3} down: {4}, SNR Margin up: {5} down: {6}, CRC error count: up: {7} down: {8}, HEC error count: up: {9} down: {10}, FEC error count: up: {11} down: {12}";
					log(string.Format(prepare, dsl.Connection.state, dsl.Line.uactual, dsl.Line.dactual, dsl.Line.uattainable, dsl.Line.dattainable, dsl.Line.uSNR, dsl.Line.dSNR, dsl.Line.uCRC, dsl.Line.dCRC, dsl.Line.uHEC, dsl.Line.dHEC, dsl.Line.uFEC, dsl.Line.dFEC));
					log(string.Format("CRC/min up: {0} down: {1}, HEC/min up: {2} down: {3}, FEC/min up: {4} down: {5}", dsl.Line.uCRCsec, dsl.Line.dCRCsec, dsl.Line.uHECsec, dsl.Line.dHECsec, dsl.Line.uFECsec, dsl.Line.dFECsec));
				}
			}));
			*/
		}

		private void log (string value) {
			DateTime time = DateTime.Now;

			if (Directory.Exists("log/").Equals(false))
				Directory.CreateDirectory("log/");

			if (Directory.Exists("log/dsl/").Equals(false))
				Directory.CreateDirectory("log/dsl/");

			StreamWriter file = new StreamWriter(string.Concat("log/dsl/", time.ToString("dd.MM.yyyy"), ".txt"), true);
			file.WriteLine(string.Concat("[", time.ToString("dd.MM.yyyy HH:mm:ss"), "]: ", value));
			file.Close();
		}

		private void button_click (object sender, RoutedEventArgs e) {
			/*
			if (sender.Equals(reload)) {
				SpeedportHybrid.initDSL();
				
				DSLViewModel dsl = Application.Current.FindResource("DSL") as DSLViewModel;
				
				if (lastReload.Equals(DateTime.MinValue).Equals(false)) {
					DateTime now = DateTime.Now;
					double difference = Math.Ceiling(Math.Ceiling((DateTime.Now - lastReload).TotalSeconds) / 60);

					double diffdCRC = Math.Ceiling((dsl.Line.dCRC - lastdCRC) / difference);
					double diffuCRC = Math.Ceiling((dsl.Line.uCRC - lastuCRC) / difference);
					dsl.lastCRC = string.Format("CRC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuCRC, diffdCRC);

					double diffdHEC = Math.Ceiling((dsl.Line.dHEC - lastdHEC) / difference);
					double diffuHEC = Math.Ceiling((dsl.Line.uHEC - lastuHEC) / difference);
					dsl.lastHEC = string.Format("HEC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuHEC, diffdHEC);

					double diffdFEC = Math.Ceiling((dsl.Line.dFEC - lastdFEC) / difference);
					double diffuFEC = Math.Ceiling((dsl.Line.uFEC - lastuFEC) / difference);
					dsl.lastFEC = string.Format("FEC/min (last {0} min) Upstream: {1} Downstream: {2}", difference, diffuFEC, diffdFEC);
				}
				
				lastReload = DateTime.Now;
				lastdCRC = dsl.Line.dCRC;
				lastuCRC = dsl.Line.uCRC;

				lastdHEC = dsl.Line.dHEC;
				lastuHEC = dsl.Line.uHEC;

				lastdFEC = dsl.Line.dFEC;
				lastuFEC = dsl.Line.uFEC;

				// TODO: calculate CRC/HEC/FEC difference betewen 2 refreshes
				
			}
			else if (sender.Equals(autoreload)) {
				if (autoreload.IsChecked.Equals(true)) {
					btnLog.IsEnabled = true;
					StartTimer();
				}
				else {
					if (btnLog.IsChecked.Equals(true)) {
						btnLog.IsChecked = false;
					}

					btnLog.IsEnabled = false;
					StopTimer();
				}
			}
			*/
		}
	}
}
