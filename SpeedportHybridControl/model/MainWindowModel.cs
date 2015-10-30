using System;
using SpeedportHybridControl.Implementations;
using System.Windows.Controls;
using SpeedportHybridControl.page;
using System.Windows.Media;

namespace SpeedportHybridControl.Model {
	class MainWindowModel : SuperViewModel {
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
			FrameSource = new LoginPage();
			changeColor("login");
		}

		private void OnSwitchToStatusPageExecute () {
			FrameSource = new StatusPage();
			changeColor("status");
		}

		private void OnSwitchToOverviewPageExecute () {
			FrameSource = new OverviewPage();
			changeColor("overview");
		}

		private void OnSwitchToDSLPageExecute () {
			FrameSource = new DslPage();
			changeColor("dsl");
		}

		private void OnSwitchToLteInfoPageExecute () {
			FrameSource = new LteInfoPage();
			changeColor("lte");
		}

		private void OnSwitchToSyslogPageExecute () {
			FrameSource = new SyslogPage();
			changeColor("syslog");
		}

		private void OnSwitchToTR181PageExecute () {
			FrameSource = new TR181Page();
			changeColor("tr181");
		}

		private void OnSwitchToPhonePageExecute () {
			FrameSource = new PhonePage();
			changeColor("phone");
		}

		private void OnSwitchToLanPageExecute () {
			FrameSource = new LanPage();
			changeColor("lan");
		}

		private void OnSwitchToControlsPageExecute () {
			FrameSource = new ControlsPage();
			changeColor("controls");
		}

		private void OnSwitchToAboutPageExecute () {
			FrameSource = new AboutPage();
			changeColor("about");
		}

		public void changeColor (string sender) {
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


			if (sender.Equals("login")) {
				ButtonLoginPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("status")) {
				ButtonStatusPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("overview")) {
				ButtonOverviewPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("dsl")) {
				ButtonDSLPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("lte")) {
				ButtonLteInfoPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("syslog")) {
				ButtonSyslogPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("tr181")) {
				ButtonTR181PageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("phone")) {
				ButtonPhonePageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("lan")) {
				ButtonLanPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("controls")) {
				ButtonControlsPageBackground = Brushes.LightGreen;
			}

			if (sender.Equals("about")) {
				ButtonAboutPageBackground = Brushes.LightGreen;
			}
		}

		public MainWindowModel () {
			FrameSource = new LoginPage();
			changeColor("login");

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
