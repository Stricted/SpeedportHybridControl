using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using SpeedportHybridControl.Implementations.Enum;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace SpeedportHybridControl.Implementations
{
    public static class util
    {
        public static byte[] HexToByte(string hex)
        {
            return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }

        /**
		 * get sha256
		 *
		 * @param	string	password
		 * @return	string
		 */
        public static string sha256(this string password)
        {
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
        public static string pbkdf2(this string password, string salt, int iterations = 1000, int length = 16)
        {
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
        public static string getVar(this JToken jArray, string varid)
        {
            foreach (JToken jToken in jArray)
            {
                JToken jVarid = jToken["varid"];
                if (jVarid.ToString().Equals(varid))
                {
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
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /**
		 * convert string to int
		 *
		 * @param	string	value
		 * @return	int
		 */
        public static int ToInt(this string value)
        {
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
        public static Brush getRSRPColor(int rsrp)
        {
            if (rsrp >= -65)
            {
                return Brushes.DarkGreen;
            }
            else if (rsrp <= -66 && rsrp >= -83)
            {
                return Brushes.Green;
            }
            else if (rsrp <= -84 && rsrp >= -95)
            {

                return Brushes.Yellow;
            }
            else if (rsrp <= -96 && rsrp >= -105)
            {
                return Brushes.Orange;
            }
            else if (rsrp <= -106 && rsrp >= -125)
            {
                return Brushes.Red;
            }
            else if (rsrp <= -126)
            {
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
        public static Brush getRSRQColor(int rsrq)
        {
            if (rsrq >= -3)
            {
                return Brushes.DarkGreen;
            }
            else if (rsrq <= -4 && rsrq >= -6)
            {
                return Brushes.Green;
            }
            else if (rsrq <= -7 && rsrq >= -8)
            {
                return Brushes.Yellow;
            }
            else if (rsrq <= -9 && rsrq >= -11)
            {
                return Brushes.Orange;
            }
            else if (rsrq <= -12 && rsrq >= -15)
            {
                return Brushes.Red;
            }
            else if (rsrq <= -16 && rsrq >= -20)
            {
                return Brushes.DarkRed;
            }

            return Brushes.Transparent;
        }

        /**
		 * check for update
		 */
        public static bool checkUpdate(string currentVersion)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("https://stricted.net/version.xml");

                string version = xmlDocument.DocumentElement["version"].InnerText;
                if (currentVersion.Equals(version).Equals(false))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public static bool checkInstalled(string c_name)
        {
            string displayName = string.Empty;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;

                    if (string.IsNullOrWhiteSpace(displayName).Equals(false) && displayName.Equals(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;

                    if (string.IsNullOrWhiteSpace(displayName).Equals(false) && displayName.Equals(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            return false;
        }

		public static bool checkLteModul ()
		{
			Ping ping = new Ping();
			try
			{
				PingReply reply = ping.Send("172.10.10.1", 2);

				if (reply.Status == IPStatus.Success)
				{
					return true;
				}
#if DEBUG
				else
				{
					LogManager.WriteToLog("unable to reach LTE Modul");
				}
#endif
			}
			catch (PingException) {
#if DEBUG
				LogManager.WriteToLog("unable to reach LTE Modul");
#endif
			}

			return false;
		}

		public static void sendCommandToLteModul(string Command)
		{
			if (checkLteModul().Equals(true) && Command.IsNullOrEmpty().Equals(false))
			{
				try
				{
					Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					IPAddress serverAddr = IPAddress.Parse("172.10.10.1");
					IPEndPoint endPoint = new IPEndPoint(serverAddr, 1280);
					byte[] cmd = Encoding.ASCII.GetBytes(Command);
					sock.SendTo(cmd, endPoint);
					sock.Close();
				}
				catch (Exception)
				{
					new Thread(() => { MessageBox.Show("couldn't send Command to LTE Modul", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
					LogManager.WriteToLog("couldn't send Command to LTE Modul");
				}
			}
		}

		public static void setLteFrequency (Band band)
		{
			/**
			 * pissible lte frequency band commands:
			 * 
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,80000,,  # 800
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,4,,      # 1800
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,40,,     # 2600
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,80044,,  # 800 | 1800 | 2600
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,80004,,  # 800 | 1800
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,80040,,  # 800 | 2600
			 * AT^SYSCFGEX="03",3FFFFFFF,3,1,44,,     # 1800 | 2600
			 */

			string Command = string.Empty;

			if ((band & Band.LTE800) == Band.LTE800)
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,80000,,";
			}
			else if ((band & Band.LTE1800) == Band.LTE1800)
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,4,,";
			}
			else if ((band & Band.LTE2600) == Band.LTE2600)
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,40,,";
			}
			else if ((band & (Band.LTE800 | Band.LTE1800 | Band.LTE2600)) == (Band.LTE800 | Band.LTE1800 | Band.LTE2600))
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,80044,,";
			}
			else if ((band & (Band.LTE800 | Band.LTE1800)) == (Band.LTE800 | Band.LTE1800))
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,80004,,";
			}
			else if ((band & (Band.LTE800 | Band.LTE2600)) == (Band.LTE800 | Band.LTE2600))
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,80040,,";
			}
			else if ((band & (Band.LTE1800 | Band.LTE2600)) == (Band.LTE1800 | Band.LTE2600))
			{
				Command = "AT^SYSCFGEX=\"03\",3FFFFFFF,3,1,44,,";
			}

			sendCommandToLteModul(Command);
		}
    }
}
