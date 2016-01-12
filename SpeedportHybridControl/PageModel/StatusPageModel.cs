using System;
using System.Collections.Generic;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.Implementations;
using System.Threading;
using SpeedportHybridControl.Data;

namespace SpeedportHybridControl.PageModel
{
    class StatusPageModel : SuperViewModel
    {
        private DelegateCommand _reloadCommand;

        private string _device_name;
        private string _lte_status;
        private string _lte_signal;
        private string _lte_image = "../assets/lte0.png";
        private string _datetime;
        private string _imei;
        private string _dsl_link_status;
        private string _status;
        private string _dsl_downstream;
        private string _dsl_upstream;
        private List<StatusPhoneList> _addphonenumber;
        private string _use_dect;
        private string _dect_devices;
        private string _wlan_ssid;
        private string _wlan_5ghz_ssid;
        private string _use_wlan;
        private string _use_wlan_5ghz;
        private string _wlan_devices;
        private string _wlan_5ghz_devices;
        private string _lan1_device = "../assets/x.png";
        private string _lan2_device = "../assets/x.png";
        private string _lan3_device = "../assets/x.png";
        private string _lan4_device = "../assets/x.png";
        private string _hsfon_status;
        private string _firmware_version;
        private string _serial_number;
        private string _uptime;

        public DelegateCommand ReloadCommand
        {
            get { return _reloadCommand; }
            set { SetProperty(ref _reloadCommand, value); }
        }

        private void OnReloadCommandExecute()
        {
            new Thread(() => { SpeedportHybrid.initStatus(); }).Start();
        }

        public string device_name
        {
            get { return _device_name; }
            set { SetProperty(ref _device_name, value); }
        }

        public string lte_status
        {
            get { return _lte_status; }
            set { SetProperty(ref _lte_status, value); }
        }

        public string lte_signal
        {
            get { return _lte_signal; }
            set { SetProperty(ref _lte_signal, value); }
        }

        public string lte_image
        {
            get { return _lte_image; }
            set { SetProperty(ref _lte_image, value); }
        }

        public string datetime
        {
            get { return _datetime; }
            set { SetProperty(ref _datetime, value); }
        }

        public string imei
        {
            get { return _imei; }
            set { SetProperty(ref _imei, value); }
        }

        public string dsl_link_status
        {
            get { return _dsl_link_status; }
            set { SetProperty(ref _dsl_link_status, value); }
        }

        public string status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public string dsl_downstream
        {
            get { return _dsl_downstream; }
            set { SetProperty(ref _dsl_downstream, value); }
        }

        public string dsl_upstream
        {
            get { return _dsl_upstream; }
            set { SetProperty(ref _dsl_upstream, value); }
        }

        public List<StatusPhoneList> addphonenumber
        {
            get { return _addphonenumber; }
            set { SetProperty(ref _addphonenumber, value); }
        }

        public string use_dect
        {
            get { return _use_dect; }
            set { SetProperty(ref _use_dect, value); }
        }

        public string dect_devices
        {
            get { return _dect_devices; }
            set { SetProperty(ref _dect_devices, value); }
        }

        public string wlan_ssid
        {
            get { return _wlan_ssid; }
            set { SetProperty(ref _wlan_ssid, value); }
        }

        public string wlan_5ghz_ssid
        {
            get { return _wlan_5ghz_ssid; }
            set { SetProperty(ref _wlan_5ghz_ssid, value); }
        }

        public string use_wlan
        {
            get { return _use_wlan; }
            set { SetProperty(ref _use_wlan, value); }
        }

        public string use_wlan_5ghz
        {
            get { return _use_wlan_5ghz; }
            set { SetProperty(ref _use_wlan_5ghz, value); }
        }

        public string wlan_devices
        {
            get { return _wlan_devices; }
            set { SetProperty(ref _wlan_devices, value); }
        }

        public string wlan_5ghz_devices
        {
            get { return _wlan_5ghz_devices; }
            set { SetProperty(ref _wlan_5ghz_devices, value); }
        }

        public string lan1_device
        {
            get { return _lan1_device; }
            set { SetProperty(ref _lan1_device, value); }
        }

        public string lan2_device
        {
            get { return _lan2_device; }
            set { SetProperty(ref _lan2_device, value); }
        }

        public string lan3_device
        {
            get { return _lan3_device; }
            set { SetProperty(ref _lan3_device, value); }
        }

        public string lan4_device
        {
            get { return _lan4_device; }
            set { SetProperty(ref _lan4_device, value); }
        }

        public string hsfon_status
        {
            get { return _hsfon_status; }
            set { SetProperty(ref _hsfon_status, value); }
        }

        public string firmware_version
        {
            get { return _firmware_version; }
            set { SetProperty(ref _firmware_version, value); }
        }

        public string serial_number
        {
            get { return _serial_number; }
            set { SetProperty(ref _serial_number, value); }
        }

        public string uptime
        {
            get { return _uptime; }
            set { SetProperty(ref _uptime, value); }
        }

        public StatusPageModel()
        {
            ReloadCommand = new DelegateCommand(new Action(OnReloadCommandExecute));
        }
    }
}
