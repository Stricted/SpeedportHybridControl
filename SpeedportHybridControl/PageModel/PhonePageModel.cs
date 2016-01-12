using System;
using System.Collections.Generic;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Data;
using SpeedportHybridControl.Implementations;
using System.Threading;
using System.Windows;

namespace SpeedportHybridControl.PageModel
{
    class PhonePageModel : SuperViewModel
    {
        private DelegateCommand _reloadCommand;
        private DelegateCommand _copyCommand;
        private DelegateCommand _clearCommand;
        private PhoneCallList _selectedItem;

        private List<PhoneCallList> _missedCalls;
        private List<PhoneCallList> _takenCalls;
        private List<PhoneCallList> _dialedCalls;
        private string _datetime;

        public DelegateCommand ReloadCommand
        {
            get { return _reloadCommand; }
            set { SetProperty(ref _reloadCommand, value); }
        }

        public DelegateCommand CopyCommand
        {
            get { return _copyCommand; }
            set { SetProperty(ref _copyCommand, value); }
        }

        public DelegateCommand ClearCommand
        {
            get { return _clearCommand; }
            set { SetProperty(ref _clearCommand, value); }
        }

        public PhoneCallList SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public List<PhoneCallList> missedCalls
        {
            get { return _missedCalls; }
            set { SetProperty(ref _missedCalls, value); }
        }

        public List<PhoneCallList> takenCalls
        {
            get { return _takenCalls; }
            set { SetProperty(ref _takenCalls, value); }
        }

        public List<PhoneCallList> dialedCalls
        {
            get { return _dialedCalls; }
            set { SetProperty(ref _dialedCalls, value); }
        }

        public string datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        private void OnReloadCommandExecute()
        {
            new Thread(() => { SpeedportHybrid.initPhone(); }).Start();
        }

        private void OnCopyCommandExecute()
        {
            Clipboard.SetText(SelectedItem.ToString());
        }

        private void OnClearCommandExecute()
        {
            //TODO
        }

        public PhonePageModel()
        {
            ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
            CopyCommand = new DelegateCommand(new Action(OnCopyCommandExecute));
            ClearCommand = new DelegateCommand(new Action(OnClearCommandExecute));
        }
    }
}
