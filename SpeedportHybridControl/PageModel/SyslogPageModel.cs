using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SpeedportHybridControl.Data;
using System.Windows;

namespace SpeedportHybridControl.PageModel {
	class SyslogPageModel : SuperViewModel {
		private DelegateCommand _reloadCommand;
		private DelegateCommand _copyCommand;
		private DelegateCommand _clearCommand;

		private string _searchText;
		private SyslogList _selectedItem;

		private List<SyslogList> _syslogList;
		private List<SyslogList> _filteredList;
		private string _datetime;

		public DelegateCommand ReloadCommand {
			get { return _reloadCommand; }
			set { SetProperty(ref _reloadCommand, value); }
		}

		public DelegateCommand CopyCommand {
			get { return _copyCommand; }
			set { SetProperty(ref _copyCommand, value); }
		}

		public DelegateCommand ClearCommand {
			get { return _clearCommand; }
			set { SetProperty(ref _clearCommand, value); }
		}

		public string SearchText {
			get { return _searchText; }
			set {
				SetProperty(ref _searchText, value);
				ApplyFilter();
			}
		}

		public SyslogList SelectedItem {
			get { return _selectedItem; }
			set { SetProperty(ref _selectedItem, value); }
		}

		public List<SyslogList> syslogList {
			get { return _syslogList; }
			set {
				SetProperty(ref _syslogList, value);
				ApplyFilter();
			}
		}

		public List<SyslogList> filteredList {
			get { return _filteredList; }
			set { SetProperty(ref _filteredList, value); }
		}

		public string datetime {
			get { return _datetime; }
			set { SetProperty(ref _datetime, value); }
		}

		private void OnReloadCommandExecute () {
			new Thread(() => { SpeedportHybrid.initSyslog(); }).Start();
		}

		private void OnCopyCommandExecute () {
			Clipboard.SetText(SelectedItem.ToString());
		}

		private void OnClearCommandExecute () {
			MessageBoxResult result = MessageBox.Show("Sollen die System-Informationen wirklich gelöscht werden?", "Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
			if (result.Equals(MessageBoxResult.Yes)) {
				SpeedportHybridAPI.getInstance().clearSyslog();
				SpeedportHybrid.initSyslog();
				SearchText = string.Empty;
			}
		}

		private void ApplyFilter () {
			if (object.ReferenceEquals(syslogList, null)) {
				filteredList = syslogList;
			}
			else {
				List<SyslogList> tmp = syslogList;
				filteredList = tmp.Where(item => SyslogFilter(item)).ToList();
			}
		}

		private bool SyslogFilter (object item) {
			if (SearchText.IsNullOrEmpty().Equals(false)) {
				return ((item as SyslogList).message.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
			}

			return true;
		}

		public SyslogPageModel () {
			ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
			CopyCommand = new DelegateCommand(new Action(OnCopyCommandExecute));
			ClearCommand = new DelegateCommand(new Action(OnClearCommandExecute));
		}
	}
}
