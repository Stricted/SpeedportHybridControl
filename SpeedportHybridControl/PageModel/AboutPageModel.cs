using System;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace SpeedportHybridControl.PageModel
{
    class AboutPageModel : SuperViewModel
    {
        private DelegateCommand _donateCommand;
        private DelegateCommand _bugtrackerCommand;
        private DelegateCommand _updateCommand;

        public string version
        {
            get { return MainWindowModel.VERSION; }
        }

        public DelegateCommand DonateCommand
        {
            get { return _donateCommand; }
            set { SetProperty(ref _donateCommand, value); }
        }

        public DelegateCommand BugtrackerCommand
        {
            get { return _bugtrackerCommand; }
            set { SetProperty(ref _bugtrackerCommand, value); }
        }

        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand; }
            set { SetProperty(ref _updateCommand, value); }
        }

        private void OnDonateCommandExecute()
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E7EBAC5NP928J");
        }

        private void OnBugtrackerCommandExecute()
        {
            Process.Start("https://stricted.net/bugtracker/index.php/ProductList/");
        }

        private void OnUpdateCommandExecute()
        {
            if (util.checkUpdate(MainWindowModel.VERSION).Equals(true))
            {
                new Thread(() => { MessageBox.Show("Ein Update ist verfügbar.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning); }).Start();
            }
            else {
                new Thread(() => { MessageBox.Show("SpeedportHybridControl ist auf dem neuesten Stand.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
            }
        }

        public AboutPageModel()
        {
            DonateCommand = new DelegateCommand(new Action(OnDonateCommandExecute));
            BugtrackerCommand = new DelegateCommand(new Action(OnBugtrackerCommandExecute));
            UpdateCommand = new DelegateCommand(new Action(OnUpdateCommandExecute));
        }
    }
}
