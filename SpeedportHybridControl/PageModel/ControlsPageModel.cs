using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Data;
using System.Windows;
using System.Threading;
using System.Diagnostics;

namespace SpeedportHybridControl.PageModel
{
    class ControlsPageModel : SuperViewModel
    {
        private DelegateCommand _rebootCommand;
        private DelegateCommand _dslReconnectCommand;
        private DelegateCommand _lteReconnectCommand;
        private DelegateCommand _dslLteReconnectCommand;
        private DelegateCommand _checkFirmwareUpdateCommand;
        private DelegateCommand _clearDNSCacheCommand;
        private DelegateCommand _speedtestNetCommand;
        private DelegateCommand _speedtestTKCommand;
        private DelegateCommand _disconnectDslCommand;
        private DelegateCommand _connectDslCommand;
        private DelegateCommand _disconnectLteCommand;
        private DelegateCommand _connectLteCommand;
        private DelegateCommand _resetToFactoryCommand;

        public DelegateCommand RebootCommand
        {
            get { return _rebootCommand; }
            set { SetProperty(ref _rebootCommand, value); }
        }

        public DelegateCommand DslReconnectcommand
        {
            get { return _dslReconnectCommand; }
            set { SetProperty(ref _dslReconnectCommand, value); }
        }

        public DelegateCommand LteReconncetCommand
        {
            get { return _lteReconnectCommand; }
            set { SetProperty(ref _lteReconnectCommand, value); }
        }

        public DelegateCommand DslLteReconnectCommand
        {
            get { return _dslLteReconnectCommand; }
            set { SetProperty(ref _dslLteReconnectCommand, value); }
        }

        public DelegateCommand CheckFirmwareUpdateCommand
        {
            get { return _checkFirmwareUpdateCommand; }
            set { SetProperty(ref _checkFirmwareUpdateCommand, value); }
        }

        public DelegateCommand ClearDNSCacheCommand
        {
            get { return _clearDNSCacheCommand; }
            set { SetProperty(ref _clearDNSCacheCommand, value); }
        }

        public DelegateCommand SpeedtestNetCommand
        {
            get { return _speedtestNetCommand; }
            set { SetProperty(ref _speedtestNetCommand, value); }
        }

        public DelegateCommand SpeedtestTKCommand
        {
            get { return _speedtestTKCommand; }
            set { SetProperty(ref _speedtestTKCommand, value); }
        }

        public DelegateCommand DisconnectDslCommand
        {
            get { return _disconnectDslCommand; }
            set { SetProperty(ref _disconnectDslCommand, value); }
        }

        public DelegateCommand ConnectDslCommand
        {
            get { return _connectDslCommand; }
            set { SetProperty(ref _connectDslCommand, value); }
        }

        public DelegateCommand DisconnectLteCommand
        {
            get { return _disconnectLteCommand; }
            set { SetProperty(ref _disconnectLteCommand, value); }
        }

        public DelegateCommand ConnectLteCommand
        {
            get { return _connectLteCommand; }
            set { SetProperty(ref _connectLteCommand, value); }
        }

        public DelegateCommand ResetToFactoryCommand
        {
            get { return _resetToFactoryCommand; }
            set { SetProperty(ref _resetToFactoryCommand, value); }
        }

        private void OnRebootCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("Willst du den Router wirklich neustarten?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.Yes))
            {
                SpeedportHybridAPI.getInstance().reboot();
            }
        }

        private void OnDslReconnectcommandExecute()
        {
            new Thread(() => {
                bool reconnectDSL = SpeedportHybridAPI.getInstance().reconnectDSL();
                if (reconnectDSL.Equals(false))
                {
                    new Thread(() => { MessageBox.Show("Could not reconnect DSL.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                    LogManager.WriteToLog("Could not reconnect DSL.");
                }
                else {
                    new Thread(() => { MessageBox.Show("DSL reconnected", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
            }).Start();
        }

        private void OnLteReconncetCommandExecute()
        {
            new Thread(() => {
                bool reconnectLte = SpeedportHybridAPI.getInstance().reconnectLte();
                if (reconnectLte.Equals(false))
                {
                    new Thread(() => { MessageBox.Show("Could not reconnect LTE.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                    LogManager.WriteToLog("Could not reconnect LTE.");
                }
                else {
                    new Thread(() => { MessageBox.Show("LTE reconnected", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
            }).Start();
        }

        private void OnDslLteReconnectCommandExecute()
        {
            //TODO
        }

        private void OnCheckFirmwareUpdateCommandExecute()
        {
            SpeedportHybridAPI.getInstance().checkFirmware();
        }

        private void OnClearDNSCacheCommandExecute()
        {
            new Thread(() => { SpeedportHybridAPI.getInstance().flushDNS(); }).Start();
        }

        private void OnSpeedtestNetCommandExecute()
        {
            Process.Start("http://www.speedtest.net/");
        }

        private void OnSpeedtestTKCommandExecute()
        {
            Process.Start("http://speedtest.t-online.de/");
        }

        private void OnDisconnectDslCommandExecute()
        {
            bool status = SpeedportHybridAPI.getInstance().changeDSLStatus("offline");
            if (status.Equals(false))
            {
                new Thread(() => { MessageBox.Show("DSL Trennen Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                LogManager.WriteToLog("Could not disconnect DSL.");
            }
            else {
                new Thread(() => { MessageBox.Show("DSL Trennen erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
            }
        }

        private void OnConnectDslCommandExecute()
        {
            bool status = SpeedportHybridAPI.getInstance().changeDSLStatus("online");
            if (status.Equals(false))
            {
                new Thread(() => { MessageBox.Show("DSL Verbinden Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                LogManager.WriteToLog("Could not connect DSL.");
            }
            else {
                new Thread(() => { MessageBox.Show("DSL Verbinden erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
            }
        }

        private void OnDisconnectLteCommandExecute()
        {
            bool status = SpeedportHybridAPI.getInstance().changeLTEStatus("offline");
            if (status.Equals(false))
            {
                new Thread(() => { MessageBox.Show("LTE Trennen Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                LogManager.WriteToLog("Could not disconnect LTE.");
            }
            else {
                new Thread(() => { MessageBox.Show("LTE Trennen erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
            }
        }

        private void OnConnectLteCommandExecute()
        {
            bool status = SpeedportHybridAPI.getInstance().changeLTEStatus("online");
            if (status.Equals(false))
            {
                new Thread(() => { MessageBox.Show("LTE Verbinden Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                LogManager.WriteToLog("Could not connect LTE.");
            }
            else {
                new Thread(() => { MessageBox.Show("LTE Verbinden erfolgreich.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
            }
        }

        private void OnResetToFactoryCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("Beim Zurücksetzen auf die Werkseinstellungen gehen alle Ihre Einstellungen verloren.\nSind Sie sicher, dass Sie den Router zurücksetzen möchten ? ", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.Yes))
            {
                bool reconnectDSL = SpeedportHybridAPI.getInstance().resetToFactoryDefault();
                if (reconnectDSL.Equals(false))
                {
                    new Thread(() => { MessageBox.Show("Could not reset the router.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                    LogManager.WriteToLog("Could not reset the router.");
                }
            }
        }

        public ControlsPageModel()
        {
            RebootCommand = new DelegateCommand(new Action(OnRebootCommandExecute));
            DslReconnectcommand = new DelegateCommand(new Action(OnDslReconnectcommandExecute));
            LteReconncetCommand = new DelegateCommand(new Action(OnLteReconncetCommandExecute));
            DslLteReconnectCommand = new DelegateCommand(new Action(OnDslLteReconnectCommandExecute));
            CheckFirmwareUpdateCommand = new DelegateCommand(new Action(OnCheckFirmwareUpdateCommandExecute));
            ClearDNSCacheCommand = new DelegateCommand(new Action(OnClearDNSCacheCommandExecute));
            SpeedtestNetCommand = new DelegateCommand(new Action(OnSpeedtestNetCommandExecute));
            SpeedtestTKCommand = new DelegateCommand(new Action(OnSpeedtestTKCommandExecute));
            DisconnectDslCommand = new DelegateCommand(new Action(OnDisconnectDslCommandExecute));
            ConnectDslCommand = new DelegateCommand(new Action(OnConnectDslCommandExecute));
            DisconnectLteCommand = new DelegateCommand(new Action(OnDisconnectLteCommandExecute));
            ConnectLteCommand = new DelegateCommand(new Action(OnConnectLteCommandExecute));
            ResetToFactoryCommand = new DelegateCommand(new Action(OnResetToFactoryCommandExecute));
        }
    }
}
