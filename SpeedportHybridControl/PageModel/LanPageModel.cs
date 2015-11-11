using System;
using System.Collections.Generic;
using SpeedportHybridControl.Data;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using System.Threading;

namespace SpeedportHybridControl.PageModel {
	class LanPageModel : SuperViewModel {
		private DelegateCommand _reloadCommand;

		private List<DeviceList> _deviceList;
		private string _datetime;

		public DelegateCommand ReloadCommand {
			get { return _reloadCommand; }
			set { SetProperty(ref _reloadCommand, value); }
		}

		public List<DeviceList> deviceList {
			get { return _deviceList; }
			set { SetProperty(ref _deviceList, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		private void OnReloadCommandExecute () {
			new Thread(() => { SpeedportHybrid.initLan(); }).Start();
		}

		public LanPageModel () {
			ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
		}
	}
}
