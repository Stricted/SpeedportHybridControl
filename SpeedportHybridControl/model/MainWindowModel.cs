using System;
using SpeedportHybridControl.Implementations;
using System.Windows.Controls;
using SpeedportHybridControl.page;

namespace SpeedportHybridControl.Model {
	class MainWindowModel : SuperViewModel {
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

		private Page _FrameSource;

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

		public Page FrameSource {
			get { return _FrameSource; }
			set { SetProperty(ref _FrameSource, value); }
		}

		private void OnSwitchToLoginPageExecute () {
			FrameSource = new LoginPage();
		}

		private void OnSwitchToStatusPageExecute () {
			FrameSource = new StatusPage();
		}

		private void OnSwitchToOverviewPageExecute () {
			FrameSource = new OverviewPage();
		}

		private void OnSwitchToDSLPageExecute () {
			FrameSource = new DslPage();
		}

		private void OnSwitchToLteInfoPageExecute () {
			FrameSource = new LteInfoPage();
		}

		private void OnSwitchToSyslogPageExecute () {
			FrameSource = new SyslogPage();
		}

		private void OnSwitchToTR181PageExecute () {
			FrameSource = new TR181Page();
		}

		private void OnSwitchToPhonePageExecute () {
			FrameSource = new PhonePage();
		}

		private void OnSwitchToLanPageExecute () {
			FrameSource = new LanPage();
		}

		private void OnSwitchToControlsPageExecute () {
			FrameSource = new ControlsPage();
		}

		private void OnSwitchToAboutPageExecute () {
			ButtonOverviewPageIsActive = true;
			ButtonDSLPageIsActive = true;
			ButtonLteInfoPageIsActive = true;
			ButtonSyslogPageIsActive = true;
			ButtonTR181PageIsActive = true;
			ButtonPhonePageIsActive = true;
			ButtonLanPageIsActive = true;
			ButtonControlsPageIsActive = true;
			FrameSource = new AboutPage();
		}
		
		public MainWindowModel () {
			FrameSource = new LoginPage();

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
