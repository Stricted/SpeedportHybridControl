using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace SpeedportHybridControl.Implementations {
	public static class util {
		public static byte[] HexToByte (string hex) {
			return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
		}

		/**
		 * get sha256
		 *
		 * @param	string	password
		 * @return	string
		 */
		public static string sha256 (this string password) {
			SHA256Managed crypt = new SHA256Managed();
			string hash = BitConverter.ToString(crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password)));
			crypt = null;
			return hash.Replace("-", "").ToLower();
		}

		/**
		 * get pbkdf2
		 *
		 * @param	string	password
		 * @param	string	salt
		 * @param	int		iterations
		 * @param	int		length
		 * @return	string
		 */
		public static string pbkdf2 (this string password, string salt, int iterations = 1000, int length = 16) {
			Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), iterations);
			string derivedk = BitConverter.ToString(hash.GetBytes(length));
			hash = null;
			return derivedk.Replace("-", "").ToLower(); ;
		}

		/**
		 * get specific value from JToken
		 *
		 * @param	JToken	jArray
		 * @param	string	varid
		 * @return	string
		 */
		public static string getVar (this JToken jArray, string varid) {
			foreach (JToken jToken in jArray) {
				JToken jVarid = jToken["varid"];
				if (jVarid.ToString().Equals(varid)) {
					jVarid = null;
					jArray = null;
					varid = null;
					return jToken["varvalue"].ToString();
				}

				jVarid = null;
			}

			jArray = null;
			varid = null;

			return string.Empty;
		}

		/**
		 * check if string is empty or null
		 *
		 * @param	string	value
		 * @return	bool
		 */
		public static bool IsNullOrEmpty (this string value) {
			return string.IsNullOrEmpty(value);
		}

		/**
		 * convert string to int
		 *
		 * @param	string	value
		 * @return	int
		 */
		public static int ToInt (this string value) {
			int b = 0;
			int.TryParse(value, out b);

			return b;
		}

		/**
		 * calculate the background color for rsrp
		 * see http://www.lte-anbieter.info/technik/rsrp.php
		 *
		 * @param	int	rsrp
		 * @return	Brush
		 */
		public static Brush getRSRPColor (int rsrp) {
			if (rsrp >= -65) {
				return Brushes.DarkGreen;
			}
			else if (rsrp <= -66 && rsrp >= -83) {
				return Brushes.Green;
			}
			else if (rsrp <= -84 && rsrp >= -95) {

				return Brushes.Yellow;
			}
			else if (rsrp <= -96 && rsrp >= -105) {
				return Brushes.Orange;
			}
			else if (rsrp <= -106 && rsrp >= -125) {
				return Brushes.Red;
			}
			else if (rsrp >= -126) {
				return Brushes.DarkRed;
			}

			return Brushes.Transparent;
		}

		/**
		 * calculate the background color for rsrq
		 * see http://www.lte-anbieter.info/technik/rsrq.php
		 *
		 * @param	int	rsrp
		 * @return	Brush
		 */
		public static Brush getRSRQColor (int rsrq) {
			if (rsrq >= -3) {
				return Brushes.DarkGreen;
			}
			else if (rsrq <= -4 && rsrq >= -6) {
				return Brushes.Green;
			}
			else if (rsrq <= -7 && rsrq >= -8) {
				return Brushes.Yellow;
			}
			else if (rsrq <= -9 && rsrq >= -11) {
				return Brushes.Orange;
			}
			else if (rsrq <= -12 && rsrq >= -15) {
				return Brushes.Red;
			}
			else if (rsrq <= -16 && rsrq >= -20) {
				return Brushes.DarkRed;
			}

			return Brushes.Transparent;
		}
		
		/**
		 * check for update
		 */
		/*
		public static bool checkUpdate () {
			try {
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load("https://stricted.net/version.xml");

				string version = xmlDocument.DocumentElement["version"].InnerText;
				if (MainWindow.VERSION.Equals(version).Equals(false)) {
					return true;
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}

			return false;
		}
		*/

		/**
		 * process login stuff
		 */
		/*
		public static void login () {
			try {
				Application.Current.Dispatcher.BeginInvoke(new Action(() => {
					MainWindow MainWindow = Application.Current.MainWindow as MainWindow;

					// LoginPage
					LoginPage LoginPage = MainWindow.loginPage as LoginPage;
					LoginPage.button1.Content = "Logout";
					LoginPage.PasswordCheckBox.Visibility = Visibility.Hidden;
					LoginPage.tbip.Visibility = Visibility.Hidden;
					LoginPage.diTextBlock.Visibility = Visibility.Hidden;
					LoginPage.tbpw.Visibility = Visibility.Hidden;
					LoginPage.PasswordBox.Visibility = Visibility.Hidden;
					LoginPage.cbSave.Visibility = Visibility.Hidden;

					// MainWindow
					MainWindow.btnLogin.Content = "Logout";

					MainWindow.btnOverview.IsEnabled = true;
					MainWindow.btnDsl.IsEnabled = true;
					MainWindow.btnLteInfo.IsEnabled = true;
					MainWindow.btnSyslog.IsEnabled = true;
					MainWindow.btnTR181.IsEnabled = true;
					MainWindow.btnPhone.IsEnabled = true;
					MainWindow.btnLan.IsEnabled = true;
					MainWindow.btnControls.IsEnabled = true;
				}));
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		*/
		/**
		 * process logout stuff
		 */
		/*
		public static void logout () {
			try {
				Application.Current.Dispatcher.BeginInvoke(new Action(() => {
					MainWindow MainWindow = Application.Current.MainWindow as MainWindow;

					// LteInfoPage
					LteInfoPage lteInfo = MainWindow.lteInfoPage as LteInfoPage;
					if (Object.Equals(lteInfo._ltepopup, null).Equals(false)) {
						lteInfo._ltepopup.StopTimer();
						lteInfo._ltepopup.Hide();
						lteInfo._ltepopup = null;
					}
					lteInfo.StopTimer();

					// DslPage
					DslPage dslInfo = MainWindow.dslPage as DslPage;
					dslInfo.StopTimer();

					// LoginPage
					LoginPage LoginPage = MainWindow.loginPage as LoginPage;
					LoginPage.PasswordBox.Visibility = Visibility.Visible;
					LoginPage.tbip.Visibility = Visibility.Visible;
					LoginPage.diTextBlock.Visibility = Visibility.Visible;
					LoginPage.tbpw.Visibility = Visibility.Visible;
					LoginPage.PasswordCheckBox.Visibility = Visibility.Visible;
					LoginPage.button1.Content = "Login";
					LoginPage.cbSave.Visibility = Visibility.Visible;
					LoginPage.PasswordBox.Focus();

					// MainWindow
					MainWindow.btnLogin.Content = "Login";
					MainWindow.frame.Content = MainWindow.loginPage;
					MainWindow.changeColor(MainWindow.btnLogin);

					MainWindow.btnOverview.IsEnabled = false;
					MainWindow.btnDsl.IsEnabled = false;
					MainWindow.btnLteInfo.IsEnabled = false;
					MainWindow.btnSyslog.IsEnabled = false;
					MainWindow.btnTR181.IsEnabled = false;
					MainWindow.btnPhone.IsEnabled = false;
					MainWindow.btnLan.IsEnabled = false;
					MainWindow.btnControls.IsEnabled = false;
				}));
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		*/
	}
}
