using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using System.Threading;
using SpeedportHybridControl.Data;

namespace SpeedportHybridControl.PageModel {
	class StatusPageModel : SuperViewModel {
		private DelegateCommand _reloadCommand;

		public DelegateCommand ReloadCommand {
			get { return _reloadCommand; }
			set { SetProperty(ref _reloadCommand, value); }
		}

		private void OnReloadCommandExecute () {
			new Thread(() => { SpeedportHybrid.initStatus(); }).Start();
		}

		public StatusPageModel () {
			ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
		}
	}
}
