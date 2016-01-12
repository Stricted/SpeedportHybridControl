using SpeedportHybridControl.Data;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeedportHybridControl.PageModel
{
    class InterfacePageModel : SuperViewModel
    {
        private DelegateCommand _reloadCommand;
        private List<InterfaceList> _interfaceList;
        private string _datetime;

        public DelegateCommand ReloadCommand
        {
            get { return _reloadCommand; }
            set { SetProperty(ref _reloadCommand, value); }
        }

        public List<InterfaceList> interfaceList
        {
            get { return _interfaceList; }
            set { SetProperty(ref _interfaceList, value); }
        }

        public string datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        private void OnReloadCommandExecute()
        {
            new Thread(() => { SpeedportHybrid.initInterface(); }).Start();
        }

        public InterfacePageModel()
        {
            ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
        }
    }
}
