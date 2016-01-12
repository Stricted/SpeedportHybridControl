namespace SpeedportHybridControl.Model
{
    class Connection : SuperViewModel
    {
        private string _dsl_operaing_mode;
        private string _path_mode;
        private string _state;
        private string _training_results;
        private string _mode_lo;
        private string _vpi_vpc;

        public string dsl_operaing_mode
        {
            get { return _dsl_operaing_mode; }
            set { SetProperty(ref _dsl_operaing_mode, value); }
        }

        public string path_mode
        {
            get { return _path_mode; }
            set { SetProperty(ref _path_mode, value); }
        }

        public string state
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        public string training_results
        {
            get { return _training_results; }
            set { SetProperty(ref _training_results, value); }
        }

        public string mode_lo
        {
            get { return _mode_lo; }
            set { SetProperty(ref _mode_lo, value); }
        }

        public string vpi_vci
        {
            get { return _vpi_vpc; }
            set { SetProperty(ref _vpi_vpc, value); }
        }
    }
}
