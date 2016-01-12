using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedportHybridControl.Model
{
    class InterfaceList : SuperViewModel
    {
        private string _ifc;
        private string _mtu;
        private string _tx_packets;
        private string _tx_errors;
        private string _rx_packets;
        private string _rx_errors;
        private string _collisions;

        public string ifc
        {
            get { return _ifc; }
            set { SetProperty(ref _ifc, value); }
        }

        public string mtu
        {
            get { return _mtu; }
            set { SetProperty(ref _mtu, value); }
        }

        public string tx_packets
        {
            get { return _tx_packets; }
            set { SetProperty(ref _tx_packets, value); }
        }

        public string tx_errors
        {
            get { return _tx_errors; }
            set { SetProperty(ref _tx_errors, value); }
        }

        public string rx_packets
        {
            get { return _rx_packets; }
            set { SetProperty(ref _rx_packets, value); }
        }

        public string rx_errors
        {
            get { return _rx_errors; }
            set { SetProperty(ref _rx_errors, value); }
        }

        public string collisions
        {
            get { return _collisions; }
            set { SetProperty(ref _collisions, value); }
        }
    }
}
