namespace SpeedportHybridControl.Model
{
    class Line : SuperViewModel
    {
        private string _uactual;
        private string _dactual;
        private string _uattainable;
        private string _dattainable;
        private string _uSNR;
        private string _dSNR;
        private string _uSignal;
        private string _dSignal;
        private string _uLine;
        private string _dLine;
        private string _uBIN;
        private string _dBIN;
        private string _uFEC_size;
        private string _dFEC_size;
        private string _uCodeword;
        private string _dCodeword;
        private string _uInterleave;
        private string _dInterleave;
        private int _uCRC;
        private int _dCRC;
        private int _uHEC;
        private int _dHEC;
        private int _uFEC;
        private int _dFEC;

        private double _uCRCsec;
        private double _dCRCsec;
        private double _uHECsec;
        private double _dHECsec;
        private double _uFECsec;
        private double _dFECsec;

        public string uactual
        {
            get { return _uactual; }
            set { SetProperty(ref _uactual, value); }
        }

        public string dactual
        {
            get { return _dactual; }
            set { SetProperty(ref _dactual, value); }
        }

        public string uattainable
        {
            get { return _uattainable; }
            set { SetProperty(ref _uattainable, value); }
        }

        public string dattainable
        {
            get { return _dattainable; }
            set { SetProperty(ref _dattainable, value); }
        }

        public string uSNR
        {
            get { return _uSNR; }
            set { SetProperty(ref _uSNR, value); }
        }

        public string dSNR
        {
            get { return _dSNR; }
            set { SetProperty(ref _dSNR, value); }
        }

        public string uSignal
        {
            get { return _uSignal; }
            set { SetProperty(ref _uSignal, value); }
        }

        public string dSignal
        {
            get { return _dSignal; }
            set { SetProperty(ref _dSignal, value); }
        }

        public string uLine
        {
            get { return _uLine; }
            set { SetProperty(ref _uLine, value); }
        }

        public string dLine
        {
            get { return _dLine; }
            set { SetProperty(ref _dLine, value); }
        }

        public string uBIN
        {
            get { return _uBIN; }
            set { SetProperty(ref _uBIN, value); }
        }

        public string dBIN
        {
            get { return _dBIN; }
            set { SetProperty(ref _dBIN, value); }
        }

        public string uFEC_size
        {
            get { return _uFEC_size; }
            set { SetProperty(ref _uFEC_size, value); }
        }

        public string dFEC_size
        {
            get { return _dFEC_size; }
            set { SetProperty(ref _dFEC_size, value); }
        }

        public string uCodeword
        {
            get { return _uCodeword; }
            set { SetProperty(ref _uCodeword, value); }
        }

        public string dCodeword
        {
            get { return _dCodeword; }
            set { SetProperty(ref _dCodeword, value); }
        }

        public string uInterleave
        {
            get { return _uInterleave; }
            set { SetProperty(ref _uInterleave, value); }
        }

        public string dInterleave
        {
            get { return _dInterleave; }
            set { SetProperty(ref _dInterleave, value); }
        }

        public int uCRC
        {
            get { return _uCRC; }
            set { SetProperty(ref _uCRC, value); }
        }

        public int dCRC
        {
            get { return _dCRC; }
            set { SetProperty(ref _dCRC, value); }
        }

        public int uHEC
        {
            get { return _uHEC; }
            set { SetProperty(ref _uHEC, value); }
        }

        public int dHEC
        {
            get { return _dHEC; }
            set { SetProperty(ref _dHEC, value); }
        }

        public int uFEC
        {
            get { return _uFEC; }
            set { SetProperty(ref _uFEC, value); }
        }

        public int dFEC
        {
            get { return _dFEC; }
            set { SetProperty(ref _dFEC, value); }
        }

        public double uCRCsec
        {
            get { return _uCRCsec; }
            set { SetProperty(ref _uCRCsec, value); }
        }

        public double dCRCsec
        {
            get { return _dCRCsec; }
            set { SetProperty(ref _dCRCsec, value); }
        }

        public double uHECsec
        {
            get { return _uHECsec; }
            set { SetProperty(ref _uHECsec, value); }
        }

        public double dHECsec
        {
            get { return _dHECsec; }
            set { SetProperty(ref _dHECsec, value); }
        }

        public double uFECsec
        {
            get { return _uFECsec; }
            set { SetProperty(ref _uFECsec, value); }
        }

        public double dFECsec
        {
            get { return _dFECsec; }
            set { SetProperty(ref _dFECsec, value); }
        }
    }
}
