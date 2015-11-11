using System;
using SpeedportHybridControl.Implementations;
using System.Windows.Controls;
using SpeedportHybridControl.page;
using System.Windows.Media;
using System.Threading;
using SpeedportHybridControl.Data;
using SpeedportHybridControl.Model;
using System.Windows;

namespace SpeedportHybridControl.PageModel {
	class MainWindowModel : SuperViewModel {
		public const string VERSION = "1.0-pre9"; //TODO: change this later

		private string _loginButtonContent = "Login";

		private DelegateCommand _switchToLoginPage;
		private DelegateCommand _switchToStatusPage;
		private DelegateCommand _switchToOverviewPage;
		private DelegateCommand _switchToDSLPage;
		private DelegateCommand _switchToLteInfoPage;
		private DelegateCommand _switchToSyslogPage;
		private DelegateCommand _switchToTR181Page;
		private DelegateCommand _switchToPhonePage;
		private DelegateCommand _switchToLanPage;
		private DelegateCommand _switchToControlsPage;
		private DelegateCommand _sitchToAboutPage;

		private bool _buttonOverviewPageIsActive = false;
		private bool _buttonDSLPageIsActive = false;
		private bool _buttonLteInfoPageIsActive = false;
		private bool _buttonSyslogPageIsActive = false;
		private bool _buttonTR181PageIsActive = false;
		private bool _buttonPhonePageIsActive = false;
		private bool _buttonLanPageIsActive = false;
		private bool _buttonControlsPageIsActive = false;

		private Brush _buttonLoginPageBackground = Brushes.LightGray;
		private Brush _buttonStatusPageBackground = Brushes.LightGray;
		private Brush _buttonOverviewPageBackground = Brushes.LightGray;
		private Brush _buttonDSLPageBackground = Brushes.LightGray;
		private Brush _buttonLteInfoPageBackground = Brushes.LightGray;
		private Brush _buttonSyslogPageBackground = Brushes.LightGray;
		private Brush _buttonTR181PageBackground = Brushes.LightGray;
		private Brush _buttonPhonePageBackground = Brushes.LightGray;
		private Brush _buttonLanPageBackground = Brushes.LightGray;
		private Brush _buttonControlsPageBackground = Brushes.LightGray;
		private Brush _buttonAboutPageBackground = Brushes.LightGray;

		private Page _FrameSource;

		public string LoginButtonContent {
			get { return _loginButtonContent; }
			set { SetProperty(ref _loginButtonContent, value); }
		}

		public DelegateCommand SwitchToLoginPage {
			get { return _switchToLoginPage; }
			set { SetProperty(ref _switchToLoginPage, value); }
		}

		public DelegateCommand SwitchToStatusPage {
			get { return _switchToStatusPage; }
			set { SetProperty(ref _switchToStatusPage, value); }
		}

		public DelegateCommand SwitchToOverviewPage {
			get { return _switchToOverviewPage; }
			set { SetProperty(ref _switchToOverviewPage, value); }
		}

		public DelegateCommand SwitchToDSLPage {
			get { return _switchToDSLPage; }
			set { SetProperty(ref _switchToDSLPage, value); }
		}

		public DelegateCommand SwitchToLteInfoPage {
			get { return _switchToLteInfoPage; }
			set { SetProperty(ref _switchToLteInfoPage, value); }
		}

		public DelegateCommand SwitchToSyslogPage {
			get { return _switchToSyslogPage; }
			set { SetProperty(ref _switchToSyslogPage, value); }
		}

		public DelegateCommand SwitchToTR181Page {
			get { return _switchToTR181Page; }
			set { SetProperty(ref _switchToTR181Page, value); }
		}

		public DelegateCommand SwitchToPhonePage {
			get { return _switchToPhonePage; }
			set { SetProperty(ref _switchToPhonePage, value); }
		}

		public DelegateCommand SwitchToLanPage {
			get { return _switchToLanPage; }
			set { SetProperty(ref _switchToLanPage, value); }
		}

		public DelegateCommand SwitchToControlsPage {
			get { return _switchToControlsPage; }
			set { SetProperty(ref _switchToControlsPage, value); }
		}

		public DelegateCommand SwitchToAboutPage {
			get { return _sitchToAboutPage; }
			set { SetProperty(ref _sitchToAboutPage, value); }
		}

		public bool ButtonOverviewPageIsActive {
			get { return _buttonOverviewPageIsActive; }
			set { SetProperty(ref _buttonOverviewPageIsActive, value); }
		}

		public bool ButtonDSLPageIsActive {
			get { return _buttonDSLPageIsActive; }
			set { SetProperty(ref _buttonDSLPageIsActive, value); }
		}

		public bool ButtonLteInfoPageIsActive {
			get { return _buttonLteInfoPageIsActive; }
			set { SetProperty(ref _buttonLteInfoPageIsActive, value); }
		}

		public bool ButtonSyslogPageIsActive {
			get { return _buttonSyslogPageIsActive; }
			set { SetProperty(ref _buttonSyslogPageIsActive, value); }
		}

		public bool ButtonTR181PageIsActive {
			get { return _buttonTR181PageIsActive; }
			set { SetProperty(ref _buttonTR181PageIsActive, value); }
		}

		public bool ButtonPhonePageIsActive {
			get { return _buttonPhonePageIsActive; }
			set { SetProperty(ref _buttonPhonePageIsActive, value); }
		}

		public bool ButtonLanPageIsActive {
			get { return _buttonLanPageIsActive; }
			set { SetProperty(ref _buttonLanPageIsActive, value); }
		}

		public bool ButtonControlsPageIsActive {
			get { return _buttonControlsPageIsActive; }
			set { SetProperty(ref _buttonControlsPageIsActive, value); }
		}

		public Brush ButtonLoginPageBackground {
			get { return _buttonLoginPageBackground; }
			set { SetProperty(ref _buttonLoginPageBackground, value); }
		}

		public Brush ButtonStatusPageBackground {
			get { return _buttonStatusPageBackground; }
			set { SetProperty(ref _buttonStatusPageBackground, value); }
		}

		public Brush ButtonOverviewPageBackground {
			get { return _buttonOverviewPageBackground; }
			set { SetProperty(ref _buttonOverviewPageBackground, value); }
		}

		public Brush ButtonDSLPageBackground {
			get { return _buttonDSLPageBackground; }
			set { SetProperty(ref _buttonDSLPageBackground, value); }
		}

		public Brush ButtonLteInfoPageBackground {
			get { return _buttonLteInfoPageBackground; }
			set { SetProperty(ref _buttonLteInfoPageBackground, value); }
		}

		public Brush ButtonSyslogPageBackground {
			get { return _buttonSyslogPageBackground; }
			set { SetProperty(ref _buttonSyslogPageBackground, value); }
		}

		public Brush ButtonTR181PageBackground {
			get { return _buttonTR181PageBackground; }
			set { SetProperty(ref _buttonTR181PageBackground, value); }
		}

		public Brush ButtonPhonePageBackground {
			get { return _buttonPhonePageBackground; }
			set { SetProperty(ref _buttonPhonePageBackground, value); }
		}

		public Brush ButtonLanPageBackground {
			get { return _buttonLanPageBackground; }
			set { SetProperty(ref _buttonLanPageBackground, value); }
		}

		public Brush ButtonControlsPageBackground {
			get { return _buttonControlsPageBackground; }
			set { SetProperty(ref _buttonControlsPageBackground, value); }
		}

		public Brush ButtonAboutPageBackground {
			get { return _buttonAboutPageBackground; }
			set { SetProperty(ref _buttonAboutPageBackground, value); }
		}

		public Page FrameSource {
			get { return _FrameSource; }
			set { SetProperty(ref _FrameSource, value); }
		}

		private void OnSwitchToLoginPageExecute () {
			changePage("login");
		}

		private void OnSwitchToStatusPageExecute () {
			changePage("status");
			new Thread(() => { SpeedportHybrid.initStatus(); }).Start();
		}

		private void OnSwitchToOverviewPageExecute () {
			changePage("overview");
			new Thread(() => { SpeedportHybrid.initOverview(); }).Start();
		}

		private void OnSwitchToDSLPageExecute () {
			changePage("dsl");
			new Thread(() => { SpeedportHybrid.initDSL(); }).Start();
		}

		private void OnSwitchToLteInfoPageExecute () {
			changePage("lte");
			new Thread(() => { SpeedportHybrid.initLTE(); }).Start();
		}

		private void OnSwitchToSyslogPageExecute () {
			changePage("syslog");
			new Thread(() => { SpeedportHybrid.initSyslog(); }).Start();
		}

		private void OnSwitchToTR181PageExecute () {
			changePage("tr181");
			new Thread(() => { SpeedportHybrid.initTR181(); }).Start();
		}

		private void OnSwitchToPhonePageExecute () {
			changePage("phone");
			new Thread(() => { SpeedportHybrid.initPhone(); }).Start();
		}

		private void OnSwitchToLanPageExecute () {
			changePage("lan");
			new Thread(() => { SpeedportHybrid.initLan(); }).Start();
		}

		private void OnSwitchToControlsPageExecute () {
			changePage("controls");
		}

		private void OnSwitchToAboutPageExecute () {
			changePage("about");
		}

		private void changePage (string page) {
			if (object.Equals(FrameSource, null).Equals(false)) {
				Console.WriteLine("HERE!!!");
				if (FrameSource.GetType().Equals(typeof(LteInfoPage))) {
					// TODO: lteInfoPage.StopTimer();
				}

                if (FrameSource.GetType().Equals(typeof(DslPage))) {
					DslPageModel dsl = Application.Current.FindResource("DslPageModel") as DslPageModel;
					dsl.StopTimer();
				}
			}

			if (page.Equals("login")) {
				FrameSource = new LoginPage();
			}
			else if (page.Equals("status")) {
				FrameSource = new StatusPage();
			}
			else if (page.Equals("overview")) {
				FrameSource = new OverviewPage();
			}
			else if (page.Equals("dsl")) {
				FrameSource = new DslPage();
			}
			else if (page.Equals("lte")) {
				FrameSource = new LteInfoPage();
			}
			else if (page.Equals("syslog")) {
				FrameSource = new SyslogPage();
			}
			else if (page.Equals("tr181")) {
				FrameSource = new TR181Page();
			}
			else if (page.Equals("phone")) {
				FrameSource = new PhonePage();
			}
			else if (page.Equals("lan")) {
				FrameSource = new LanPage();
			}
			else if (page.Equals("controls")) {
				FrameSource = new ControlsPage();
			}
			else if (page.Equals("about")) {
				FrameSource = new AboutPage();
			}

			changeColor(page);
		}

		private void changeColor (string page) {
			ButtonLoginPageBackground = Brushes.LightGray;
			ButtonStatusPageBackground = Brushes.LightGray;
			ButtonOverviewPageBackground = Brushes.LightGray;
			ButtonDSLPageBackground = Brushes.LightGray;
			ButtonLteInfoPageBackground = Brushes.LightGray;
			ButtonSyslogPageBackground = Brushes.LightGray;
			ButtonTR181PageBackground = Brushes.LightGray;
			ButtonPhonePageBackground = Brushes.LightGray;
			ButtonLanPageBackground = Brushes.LightGray;
			ButtonControlsPageBackground = Brushes.LightGray;
			ButtonAboutPageBackground = Brushes.LightGray;

			if (page.Equals("login")) {
				ButtonLoginPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("status")) {
				ButtonStatusPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("overview")) {
				ButtonOverviewPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("dsl")) {
				ButtonDSLPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("lte")) {
				ButtonLteInfoPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("syslog")) {
				ButtonSyslogPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("tr181")) {
				ButtonTR181PageBackground = Brushes.LightGreen;
			}

			if (page.Equals("phone")) {
				ButtonPhonePageBackground = Brushes.LightGreen;
			}

			if (page.Equals("lan")) {
				ButtonLanPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("controls")) {
				ButtonControlsPageBackground = Brushes.LightGreen;
			}

			if (page.Equals("about")) {
				ButtonAboutPageBackground = Brushes.LightGreen;
			}
		}

		public MainWindowModel () {
			if (util.checkInstalled("Microsoft Visual C++ 2010  x86 Redistributable - 10.0.40219").Equals(false)) {
				new Thread(() => { MessageBox.Show("Bitte installiere das 'Microsoft Visual C++ 2010 Redistributable Package' aus den ordner 'vcredis' um das programm vollständig benutzen zu können.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning); }).Start();
			}

			if (util.checkUpdate(VERSION).Equals(true)) {
				new Thread(() => { MessageBox.Show("Ein Update ist verfügbar.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning); }).Start();
			}


			changePage("login");

			SwitchToLoginPage = new DelegateCommand(new Action(OnSwitchToLoginPageExecute));
			SwitchToStatusPage = new DelegateCommand(new Action(OnSwitchToStatusPageExecute));
			SwitchToOverviewPage = new DelegateCommand(new Action(OnSwitchToOverviewPageExecute));
			SwitchToDSLPage = new DelegateCommand(new Action(OnSwitchToDSLPageExecute));
			SwitchToLteInfoPage = new DelegateCommand(new Action(OnSwitchToLteInfoPageExecute));
			SwitchToSyslogPage = new DelegateCommand(new Action(OnSwitchToSyslogPageExecute));
			SwitchToTR181Page = new DelegateCommand(new Action(OnSwitchToTR181PageExecute));
			SwitchToPhonePage = new DelegateCommand(new Action(OnSwitchToPhonePageExecute));
			SwitchToLanPage = new DelegateCommand(new Action(OnSwitchToLanPageExecute));
			SwitchToControlsPage = new DelegateCommand(new Action(OnSwitchToControlsPageExecute));

			SwitchToAboutPage = new DelegateCommand(new Action(OnSwitchToAboutPageExecute));
		}
	}
}
