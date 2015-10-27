using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.model;
using System.Windows.Controls;


namespace SpeedportHybridControl.model {
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

		private bool _buttonDSLPageIsActive = false;
		private Page _FrameSource = new page.test();

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

		public bool ButtonDSLPageIsActive {
			get { return _buttonDSLPageIsActive; }
			set { SetProperty(ref _buttonDSLPageIsActive, value); }
		}

		public Page FrameSource {
			get { return _FrameSource; }
			set { SetProperty(ref _FrameSource, value); }
		}

		private void OnSwitchToLogiPagenExecute () {
			Console.WriteLine("button...");
		}

		private void OnSwitchToAboutPageExecute () {
			Console.WriteLine("button...");
			ButtonDSLPageIsActive = true;
			FrameSource = new page.test1();
		}

		private void OnSwitchToDSLPageExecute () {
			Console.WriteLine("button...");
			ButtonDSLPageIsActive = true;
			FrameSource = new page.test();
		}

		private void ExampleExecute () {

		}

		public MainWindowModel () {
			SwitchToLoginPage = new DelegateCommand(new Action(OnSwitchToLogiPagenExecute));
			SwitchToStatusPage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToOverviewPage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToDSLPage = new DelegateCommand(new Action(OnSwitchToDSLPageExecute));
			SwitchToLteInfoPage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToSyslogPage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToTR181Page = new DelegateCommand(new Action(ExampleExecute));
			SwitchToPhonePage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToLanPage = new DelegateCommand(new Action(ExampleExecute));
			SwitchToControlsPage = new DelegateCommand(new Action(ExampleExecute));

			SwitchToAboutPage = new DelegateCommand(new Action(OnSwitchToAboutPageExecute));
		}
	}
}
