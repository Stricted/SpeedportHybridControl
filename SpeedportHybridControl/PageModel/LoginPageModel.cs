using System;
using SpeedportHybridControl.Implementations;
using SpeedportHybridControl.Data;
using System.Windows;
using System.Threading;
using SpeedportHybridControl.Model;

namespace SpeedportHybridControl.PageModel
{
    class LoginPageModel : SuperViewModel
    {
        private string _ip = "speedport.ip";
        private string _password;
        private string _loginButtonText = "Login";
        private bool _showPassword;
        private bool _savePassword;
        private Visibility _passwordBoxVisibility = Visibility.Visible;
        private Visibility _passwordTextBoxVisibility = Visibility.Hidden;
        private Visibility _loginFieldsVisibility = Visibility.Visible;

        private DelegateCommand _showPasswordCommand;
        private DelegateCommand _loginCommand;

        public string ip
        {
            get { return _ip; }
            set { SetProperty(ref _ip, value); }
        }

        public string password
        {
            get { return _password; }
            set {
                // TODO: find a better way
                if (value.IsNullOrEmpty().Equals(true))
                {
                    if (SavePassword.Equals(true))
                        return;

                }
                SetProperty(ref _password, value);
            }
        }

        public string LoginButtonText
        {
            get { return _loginButtonText; }
            set { SetProperty(ref _loginButtonText, value); }
        }

        public bool ShowPassword
        {
            get { return _showPassword; }
            set { SetProperty(ref _showPassword, value); }
        }

        public bool SavePassword
        {
            get { return _savePassword; }
            set { SetProperty(ref _savePassword, value); }
        }

        public Visibility PasswordBoxVisibility
        {
            get { return _passwordBoxVisibility; }
            set { SetProperty(ref _passwordBoxVisibility, value); }
        }

        public Visibility PasswordTextBoxVisibility
        {
            get { return _passwordTextBoxVisibility; }
            set { SetProperty(ref _passwordTextBoxVisibility, value); }
        }

        public Visibility LoginFieldsVisibility
        {
            get { return _loginFieldsVisibility; }
            set { SetProperty(ref _loginFieldsVisibility, value); }
        }

        public DelegateCommand ShowPasswordCommand
        {
            get { return _showPasswordCommand; }
            set { SetProperty(ref _showPasswordCommand, value); }
        }

        public DelegateCommand LoginCommand
        {
            get { return _loginCommand; }
            set { SetProperty(ref _loginCommand, value); }
        }

        private void OnShowPasswordCommandExecute()
        {
            if (ShowPassword.Equals(true))
            {
                PasswordBoxVisibility = Visibility.Hidden;
                PasswordTextBoxVisibility = Visibility.Visible;
            }
            else {
                PasswordBoxVisibility = Visibility.Visible;
                PasswordTextBoxVisibility = Visibility.Hidden;
            }
        }

        private void OnLoginCommandExecute()
        {
            MainWindowModel mwm = Application.Current.FindResource("MainWindowModel") as MainWindowModel;

            if (LoginButtonText.Equals("Login"))
            {
                if (SpeedportHybridAPI.getInstance().ip.Equals(ip).Equals(false))
                {
                    SpeedportHybridAPI.getInstance().ip = ip;
                }

                bool login = SpeedportHybridAPI.getInstance().login(password);
                if (login.Equals(true))
                {
                    if (SavePassword.Equals(true))
                    {
                        SettingsModel SettingsModel = new SettingsModel
                        {
                            password = password,
                            ip = SpeedportHybridAPI.getInstance().ip
                        };

                        Settings.save(SettingsModel);
                    }
                    else {
                        SettingsModel SettingsModel = new SettingsModel
                        {
                            password = string.Empty,
                            ip = SpeedportHybridAPI.getInstance().ip
                        };

                        Settings.save(SettingsModel);
                    }

                    LoginFieldsVisibility = Visibility.Hidden;
                    mwm.ButtonOverviewPageIsActive = true;
                    mwm.ButtonDSLPageIsActive = true;
                    mwm.ButtonLteInfoPageIsActive = true;
                    mwm.ButtonSyslogPageIsActive = true;
                    mwm.ButtonTR181PageIsActive = true;
                    mwm.ButtonPhonePageIsActive = true;
                    mwm.ButtonLanPageIsActive = true;
                    mwm.ButtonInterfacePageIsActive = true;
                    mwm.ButtonControlsPageIsActive = true;

                    LoginButtonText = "Logout";
                    mwm.LoginButtonContent = "Logout";
                }
                else {
                    new Thread(() => { MessageBox.Show("Login fehlgeschlagen. Sie haben ein falsches Gerätepasswort eingegeben. Bitte versuchen Sie es erneut und achten Sie auf die korrekte Schreibweise.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                    LogManager.WriteToLog("Login Failed, wrong password");
                }
            }
            else {
                if (SpeedportHybridAPI.getInstance().logout().Equals(true))
                {
                    LogoutAction();
                }
            }
        }

        public void LogoutAction()
        {
            LteInfoModel lim = Application.Current.FindResource("LteInfoModel") as LteInfoModel;
            lim.ClosePopup();
            lim.StopTimer();

            DslPageModel dpm = Application.Current.FindResource("DslPageModel") as DslPageModel;
            dpm.StopTimer();
            
            MainWindowModel mwm = Application.Current.FindResource("MainWindowModel") as MainWindowModel;
            LoginFieldsVisibility = Visibility.Visible;
            mwm.ButtonOverviewPageIsActive = false;
            mwm.ButtonDSLPageIsActive = false;
            mwm.ButtonLteInfoPageIsActive = false;
            mwm.ButtonSyslogPageIsActive = false;
            mwm.ButtonTR181PageIsActive = false;
            mwm.ButtonPhonePageIsActive = false;
            mwm.ButtonLanPageIsActive = false;
            mwm.ButtonInterfacePageIsActive = false;
            mwm.ButtonControlsPageIsActive = false;

            LoginButtonText = "Login";
            mwm.LoginButtonContent = "Login";
        }

        public LoginPageModel()
        {
            SettingsModel settings = Settings.load();
            if (settings.ip.IsNullOrEmpty().Equals(false))
            {
                ip = settings.ip;
            }

            SpeedportHybridAPI.getInstance().ip = ip;

            if (settings.password.IsNullOrEmpty().Equals(false))
            {
                SavePassword = true;
                password = settings.password;
            }

            ShowPasswordCommand = new DelegateCommand(new Action(OnShowPasswordCommandExecute));
            LoginCommand = new DelegateCommand(new Action(OnLoginCommandExecute));
        }
    }
}
