using System;
using System.Windows;
using System.Windows.Media;
using System.Timers;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.Common;
using System.ComponentModel;
using System.IO;
using SpeedportHybridControl.Data;
using SpeedportHybridControl.Model;

namespace SpeedportHybridControl {
	public class LTECollection : RingArray<LTEData> {
		private const int TOTAL_POINTS = 200;

		public LTECollection () : base(TOTAL_POINTS) {
		}
	}

	public class LTEData {
		public DateTime Date { get; set; }

		public int Data { get; set; }
	}

	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class ltepopup : Window {
		public Timer _timer;
		public LTECollection lteCollection;
		public LTECollection lteCollection2;

		public ltepopup () {
			InitializeComponent();
			/*
			util.init("LTE2");

			lteCollection = new LTECollection();
			lteCollection2 = new LTECollection();

			var ds = new EnumerableDataSource<LTEData>(lteCollection);
			ds.SetXMapping(x => dateAxis.ConvertToDouble(x.Date));
			ds.SetYMapping(y => y.Data);
			plotter.AddLineGraph(ds, Colors.Green, 1, "rsrq");

			var ds2 = new EnumerableDataSource<LTEData>(lteCollection2);
			ds2.SetXMapping(x => dateAxis.ConvertToDouble(x.Date));
			ds2.SetYMapping(y => y.Data);
			plotter2.AddLineGraph(ds2, Colors.Green, 1, "rsrp");

			StartTimer();
			*/
		}

		void Window_Closing (object sender, CancelEventArgs e) {
			//StopTimer();
		}
		/*
		public void StopTimer () {
			if (Object.Equals(_timer, null).Equals(false)) {
				_timer.Stop();
			}
		}

		private void StartTimer () {
			_timer = new Timer {
				Interval = 1000, // every second
			};

			_timer.Elapsed += timer_Elapsed;
			_timer.Start();
		}

		private void log (string value) {
			DateTime time = DateTime.Now;

			if (Directory.Exists("log/").Equals(false))
				Directory.CreateDirectory("log/");

			if (Directory.Exists("log/lte/").Equals(false))
				Directory.CreateDirectory("log/lte/");

			StreamWriter file = new StreamWriter(string.Concat("log/lte/", time.ToString("dd.MM.yyyy"), ".txt"), true);
			file.WriteLine(string.Concat("[", time.ToString("dd.MM.yyyy HH:mm:ss"), "]: ", value));
			file.Close();
		}

		void timer_Elapsed (object sender, ElapsedEventArgs e) {
			new System.Threading.Thread(() => {
				util.init("LTE2");

				LTE lte = Application.Current.FindResource("LTE2") as LTE;
				int rsrq = lte.rsrq.ToInt();
				int rsrp = lte.rsrp.ToInt();
				Application.Current.Dispatcher.BeginInvoke(new Action(() => {
					lteCollection.Add(new LTEData() { Date = DateTime.Now, Data = rsrq });
					lteCollection2.Add(new LTEData() { Date = DateTime.Now, Data = rsrp });

					if (btnLog.IsChecked.Equals(true)) {
						// log
						log(string.Concat("Pysical Cell ID: ", lte.phycellid, ", Cell ID: ", lte.cellid, ", RSRP: ", lte.rsrp, ", RSRQ: ", lte.rsrq));
					}
				}));
			}).Start();
		}

		private void button_click (object sender, RoutedEventArgs e) {
			if (sender.Equals(btnPin)) {
				if (btnPin.IsChecked.Equals(true)) {
					Topmost = true;
				}
				else {
					Topmost = false;
				}
			}
		}
		*/
	}
}
