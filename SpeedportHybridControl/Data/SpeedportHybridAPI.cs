using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Threading;
using System.Collections.Generic;
using SpeedportHybridControl.Implementations;
using Newtonsoft.Json;
using SpeedportHybridControl.PageModel;

namespace SpeedportHybridControl.Data
{
    public class SpeedportHybridAPI : SingletonFactory<SpeedportHybridAPI>
    {
        public string _ip = "speedport.ip";
        private DateTime _lastReboot = DateTime.MinValue;
        private bool _checkIsActive = false;
        public string _password;
        public string _challenge;
        public string _hash;
        public string _derivedk;
        public CookieContainer _cookie = new CookieContainer();

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        /**
		 * Requests the password-challenge from the router.
		 *
		 * @return	string
		 */
        public string getChallenge_old()
        {
			/* var challenge = "3FFBFE45EF0B7f76b6BCADD3fccBC5ab07b1aa36EC97Ab690C23F90Fd374c016"; */
			string response = sendRequest("data/Login.json", "csrf_token=nulltoken&showpw=0&challengev=null");
            if (response.IsNullOrEmpty())
                return string.Empty;

            string challenge = string.Empty;
            try
            {
                JToken jArray = JToken.Parse(response);

                challenge = jArray.getVar("challengev");
                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return challenge;
        }
		public string getChallenge()
		{
			string response = sendRequest("html/content/overview/index.html");
			if (response.IsNullOrEmpty())
				return string.Empty;

			string a = "challenge = \"";
			if (response.IndexOf(a) == -1)
			{
				response = null;
				return getChallenge_old();
			}

			string token = response.Substring((response.IndexOf(a) + a.Length), 64);

			response = null;

			return token;
		}

		/**
		 * calculate the derivedk
		 *
		 * @param	string	$password
		 * @return	string
		 */
		public string getDerviedk()
        {
            return _password.sha256().pbkdf2(_challenge.Substring(0, 16));
        }

        /**
		 * login into the router with the given password
		 * 
		 * @param	string	$password
		 * @return	bool
		 */
        public bool login(string password)
        {
            if (password.IsNullOrEmpty())
            {
                return false;
            }

            _cookie = new CookieContainer();

            _password = password;
            _challenge = getChallenge();
            _hash = string.Concat(_challenge, ":", password).sha256();

            string response = sendRequest("data/Login.json", string.Concat("csrf_token=nulltoken", "&challengev=", _challenge, "&showpw=0&password=", _hash));
            if (response.IsNullOrEmpty())
                return false;

			if (response.IndexOf("challenge") != -1)
			{
				response = sendRequest("data/Login.json", string.Concat("csrf_token=nulltoken&showpw=0&password=", _hash));
				if (response.IsNullOrEmpty())
					return false;

				_cookie.Add(new Cookie("challengev", _challenge) { Domain = _ip });
			}
			
            bool login = false;
            try
            {
                JToken jArray = JToken.Parse(response);
                if (jArray.getVar("login").Equals("success"))
                {
                    if (isLoggedin().Equals(false))
                    {
                        login = false;
                    }
                    else {
                        login = true;
                        _derivedk = getDerviedk();
                        _lastReboot = getLastReboot();
                    }
                }
                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return login;
        }

        /**
		 * logout
		 * 
		 * @return	bool
		 */
        public bool logout()
        {
            string response = sendRequest("data/Login.json", string.Concat("csrf_token=", getToken(), "&logout=byby"));
            if (response.IsNullOrEmpty())
                return false;

            bool logout = false;
            try
            {
                JToken jArray = JToken.Parse(response);
                if (jArray.getVar("status").Equals("ok"))
                {
                    logout = true;
                    _password = "";
                    _challenge = "";
                    _cookie = new CookieContainer();
                    _lastReboot = DateTime.MinValue;
                    _hash = "";
                    _derivedk = "";
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return logout;
        }

        /**
		 * check if we are logged in
		 *
		 * @return	bool
		 */
        public bool checkLogin()
        {
            if (_checkIsActive.Equals(false))
            {
                _checkIsActive = true;
                if (isLoggedin().Equals(false))
                {
                    Thread.Sleep(400);

                    if (login(_password).Equals(false))
                    {
                        // should we try to relogin? login(_password);...
                        new Thread(() => { LogManager.WriteToLog("Session expired."); }).Start();
                        _password = "";
                        _challenge = "";
                        _cookie = new CookieContainer();
                        _lastReboot = DateTime.MinValue;
                        _hash = "";
                        _derivedk = "";

                        LoginPageModel lpm = Application.Current.FindResource("LoginPageModel") as LoginPageModel;
                        lpm.LogoutAction();
                        MainWindowModel mwm = Application.Current.FindResource("MainWindowModel") as MainWindowModel;
                        mwm.SwitchToLoginPage.Execute();

                        new Thread(() => { MessageBox.Show("Session expired.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                        _checkIsActive = false;
                        return false;
                    }
                }

                _checkIsActive = false;
            }

            return true;
        }

        /**
		 * check if we are logged in
		 *
		 * @param	bool	ischeck
		 * @return	bool
		 */
        public bool isLoggedin()
        {
            string response = sendRequest("data/heartbeat.json");
            if (response.IsNullOrEmpty())
                return false;

            bool login = false;
            try
            {
                JToken jArray = JToken.Parse(response);

                if (jArray.getVar("loginstate").Equals("1"))
                {
                    login = true;
                }

                jArray = null;
            }

            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return login;
        }

        /**
		 * reboot the router
		 */
        public void reboot()
        {
            if (checkLogin().Equals(false))
                return;

            string response = sendRequest("data/Reboot.json", string.Concat("csrf_token=", Uri.EscapeUriString(getToken()), "&reboot_device=true"));
            if (response.IsNullOrEmpty())
                return;
            try
            {
                JToken jArray = JToken.Parse(response);
                if (jArray.getVar("status").Equals("ok"))
                {
                    new Thread(() => { MessageBox.Show("Router Reboot.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                    LogManager.WriteToLog("Router Reboot.");
                    _password = "";
                    _challenge = "";
                    _cookie = new CookieContainer();
                    _hash = "";
                    _derivedk = "";

                    LoginPageModel lpm = Application.Current.FindResource("LoginPageModel") as LoginPageModel;
                    lpm.LoginCommand.Execute();
                    MainWindowModel mwm = Application.Current.FindResource("MainWindowModel") as MainWindowModel;
                    mwm.SwitchToLoginPage.Execute();
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * reconnect LTE
		 *
		 * @return	bool
		 */
        public bool reconnectLte()
        {
            if (checkLogin().Equals(false))
                return false;

            Thread.Sleep(400);

            string response = sendEnryptedRequest("data/modules.json", string.Concat("lte_reconn=1&csrf_token=", Uri.EscapeUriString(getToken())));
            if (response.IsNullOrEmpty())
                return false;

            try
            {
                JToken jArray = JToken.Parse(response);

                response = null;

                if (jArray.getVar("status").Equals("ok"))
                {
                    jArray = null;
                    return true;
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return false;
        }

        /**
		 * reconnect DSL
		 *
		 * @return	bool
		 */
        public bool reconnectDSL()
        {
            if (checkLogin().Equals(false))
                return false;

            Thread.Sleep(400);

            string response = sendEnryptedRequest("data/Connect.json", string.Concat("csrf_token=", Uri.EscapeUriString(getToken()), "&showpw=0&password=", _hash, "&req_connect=offline"));
            if (response.IsNullOrEmpty())
                return false;

            bool offline = false;
            try
            {
                JToken jArray = JToken.Parse(response);

                response = null;

                if (jArray.getVar("status").Equals("ok"))
                {
                    offline = true;
                }

                jArray = null;

                if (offline.Equals(true))
                {
                    response = sendEnryptedRequest("data/Connect.json", string.Concat("csrf_token=", Uri.EscapeUriString(getToken()), "&showpw=0&password=", _hash, "&req_connect=online"));
                    jArray = JToken.Parse(response);
                    if (jArray.getVar("status").Equals("ok"))
                    {
                        jArray = null;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return false;
        }

        /**
		 * change dsl connection status
		 *
		 * @param	string	status
		 * @return	bool
		 */
        public bool changeDSLStatus(string status)
        {
            if (checkLogin().Equals(false))
                return false;

            if (status.Equals("online") || status.Equals("offline"))
            {

                string response = sendEnryptedRequest("data/Connect.json", string.Concat("req_connect=", status, "&csrf_token=", Uri.EscapeUriString(getToken())));
                if (response.IsNullOrEmpty())
                    return false;
                try
                {
                    JToken jArray = JToken.Parse(response);

                    response = null;

                    if (jArray.getVar("status").Equals("ok"))
                    {
                        jArray = null;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.WriteToLog(ex.ToString());
                }

                response = null;
            }

            return false;
        }

        /**
		 * change lte connection status
		 *
		 * @param	string	status
		 * @return	bool
		 */
        public bool changeLTEStatus(string status)
        {
            if (checkLogin().Equals(false))
                return false;

            if (status.Equals("online") || status.Equals("offline"))
            {
                if (status.Equals("online"))
                    status = "1";

                if (status.Equals("offline"))
                    status = "0";

                string response = sendEnryptedRequest("data/Modules.json", string.Concat("use_lte=", status, "&csrf_token=", Uri.EscapeUriString(getToken())));
                if (response.IsNullOrEmpty())
                    return false;
                try
                {
                    JToken jArray = JToken.Parse(response);

                    response = null;

                    if (jArray.getVar("status").Equals("ok"))
                    {
                        jArray = null;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    LogManager.WriteToLog(ex.ToString());
                }

                response = null;
            }

            return false;
        }

        /**
		 * reset the router to Factory Default
		 * not tested
		 *
		 * @return	bool
		 */
        public bool resetToFactoryDefault()
        {
            if (checkLogin().Equals(false))
                return false;

            Thread.Sleep(400);

            string response = sendEnryptedRequest("data/resetAllSetting.json", string.Concat("csrf_token=nulltoken&showpw=0&password=", _hash, "&reset_all=true"));
            if (response.IsNullOrEmpty())
                return false;

            try
            {
                JToken jArray = JToken.Parse(response);
                if (jArray.getVar("status").Equals("ok"))
                {
                    return true;
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;

            return false;
        }

        /**
		 * check for firmware update
		 */
        public void checkFirmware()
        {
            if (checkLogin().Equals(false))
                return;

            Thread.Sleep(400);

            string response = sendRequest("data/checkfirm.json");
            if (response.IsNullOrEmpty())
                return;

            try
            {
                bool fw_isActual = false;
                JToken jArray = JToken.Parse(response);

                if (jArray.getVar("fw_isActual").Equals("1"))
                {
                    fw_isActual = true;
                }

                if (fw_isActual.Equals(true))
                {
                    // Die Firmware ist aktuell.
                    MessageBox.Show("Die Firmware ist aktuell.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    // Es liegt eine neuere Firmware-Version vor. Möchten Sie diese Version jetzt installieren?
                    MessageBox.Show("Es liegt eine neuere Firmware-Version vor.\nMöchten Sie diese Version jetzt installieren?", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * flush dns cache
		 */
        public void flushDNS()
        {
            if (checkLogin().Equals(false))
                return;

            Thread.Sleep(400);

            string response = sendEnryptedRequest("data/dns.json", "op_type=flush_dns_cache");
            if (response.IsNullOrEmpty())
                return;

            try
            {
                JToken jArray = JToken.Parse(response);

                if (jArray["DCI"].Count().Equals(0))
                {
                    new Thread(() => { MessageBox.Show("DNS cache geleert", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
                else {
                    new Thread(() => { MessageBox.Show("unable to flush dns cache", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                }


                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * clear the Syslog
		 */
        public void clearSyslog()
        {
            if (checkLogin().Equals(false))
                return;

            Thread.Sleep(400);

            string response = sendEnryptedRequest("data/SystemMessages.json", string.Concat("action_clearlist=true&clear_type=0&", "csrf_token=", getToken()));
            if (response.IsNullOrEmpty())
                return;

            try
            {
                JToken jArray = JToken.Parse(response);

                if (jArray.getVar("status").Equals("ok"))
                {
                    // ok
                    new Thread(() => { MessageBox.Show("Syslog geleert", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
                else {
                    // fail
                    new Thread(() => { MessageBox.Show("Konnte Syslog nicht leeren.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                }

                jArray = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * set QueueSkbTimeOut
		 *
		 * @param	string	value
		 */
        public void setQueueSkbTimeOut(string value)
        {
            if (checkLogin().Equals(false))
                return;

            string response = sendEnryptedRequest("data/bonding_tr181.json", string.Concat("bonding_QueueSkbTimeOut=", value));
            if (response.IsNullOrEmpty())
                return;
            try
            {
                TR181PageModel obj = JsonConvert.DeserializeObject<TR181PageModel>(response);

                if (obj.QueueSkbTimeOut.Equals(value))
                {
                    new Thread(() => { MessageBox.Show("QueueSkbTimeOut geändert", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
                else {
                    new Thread(() => { MessageBox.Show("unable to change QueueSkbTimeOut", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                }

                obj = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * set Antenna Mode
		 *
		 * @param	string	value
		 */
        public void setAntennaMode(string value)
        {
            if (checkLogin().Equals(false))
                return;

            string response = sendEnryptedRequest("data/lteinfo.json", string.Concat("mode_select=", value));
            if (response.IsNullOrEmpty())
                return;
            try
            {
                LteInfoModel obj = JsonConvert.DeserializeObject<LteInfoModel>(response);

                string antenna_mode;
                if (obj.antenna_mode.Equals("Antennal set to internal"))
                {
                    antenna_mode = "Inner";
                }
                else if (obj.antenna_mode.Equals("Antennal set to external"))
                {
                    antenna_mode = "Outer";
                }
                else {
                    antenna_mode = "Auto";
                }

                if (antenna_mode.Equals(value))
                {
                    new Thread(() => { MessageBox.Show("Antennen Modus geändert", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information); }).Start();
                }
                else {
                    new Thread(() => { MessageBox.Show("Antennen Modus ändern Fehlgeschlagen", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error); }).Start();
                }

                antenna_mode = null;

                obj = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            response = null;
        }

        /**
		 * get Last Reboot time
		 * 
		 * @return	DateTime
		 */
        public DateTime getLastReboot()
        {
            if (_lastReboot.Equals(DateTime.MinValue).Equals(false))
            {
                return _lastReboot;
            }

            string response = sendRequest("data/Reboot.json");

            if (response.IsNullOrEmpty())
                return DateTime.Now;

            JToken jArray = JToken.Parse(response);

            DateTime lastReboot = DateTime.Parse(string.Concat(jArray.getVar("reboot_date"), " ", jArray.getVar("reboot_time")));

            jArray = null;

            return lastReboot;
        }

        /**
		 * get the csrf token from router
		 *
		 * @return	string
		 */
        public string getToken()
        {
            string response = sendRequest("html/content/overview/index.html");
            if (response.IsNullOrEmpty())
                return string.Empty;

            string a = "csrf_token = \"";
            string b = "\";";
            string token = response.Substring((response.IndexOf(a) + a.Length), (response.IndexOf(b) - response.IndexOf(a) - a.Length));

            response = null;
            a = null;
            b = null;
            
            return token;
        }

        /**
		 * send encrypted request to the router
		 *
		 * @param	string	path
		 * @param	string	post
		 * @param	bool	cookie
		 * @return	string
		 */
        public string sendEnryptedRequest(string path, string post = "", bool cookie = true)
        {
            string response = string.Empty;

            try
            {
                sjcl sjcl = new sjcl();

                string iv = _challenge.Substring(16, 16);
                string adata = _challenge.Substring(32, 16);
                string dKey = _derivedk;


                // TODO: check if we need this really?
                if (post.IsNullOrEmpty().Equals(false))
                {
                    post = sjcl.encrypt(dKey, post, iv, adata);
                }


                response = sendRequest(path, post, cookie);
                // check if the return value is hex (hex = enrypted)
                if (Regex.IsMatch(response, @"\A\b[0-9a-fA-F]+\b\Z").Equals(true))
                {
                    response = sjcl.decrypt(dKey, response, iv, adata);
                }

                post = null;
                iv = null;
                adata = null;
                dKey = null;
                sjcl = null;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            return response;
        }

        /**
		 * send request to the router
		 *
		 * @param	string	path
		 * @param	string	post
		 * @param	bool	cookie
		 * @return	string
		 */
        public string sendRequest(string path, string post = "", bool cookie = true)
        {
            string response = string.Empty;
            try
            {
                string url = string.Concat("http://", ip, "/", path, "?lang=de");

                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                /* set timeout to 10 seconds */
                webRequest.Timeout = 10000;

                if (cookie.Equals(true))
                {
                    webRequest.CookieContainer = _cookie;
                }

                if (post.IsNullOrEmpty().Equals(false))
                {
                    webRequest.Method = "POST";
                    byte[] dataStream = Encoding.UTF8.GetBytes(post);
                    webRequest.ContentLength = dataStream.Length;
                    Stream newStream = webRequest.GetRequestStream();
                    newStream.Write(dataStream, 0, dataStream.Length);
                    newStream.Close();
                    newStream.Dispose();
                    newStream = null;
                    dataStream = null;
                }

                WebResponse webResponse = webRequest.GetResponse();
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                response = reader.ReadToEnd().ToString();

                webResponse.Dispose();
                reader.Dispose();
                reader = null;
                webRequest = null;
                webResponse = null;
                post = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            return response;
        }

        public string sendRequest2(string path, Dictionary<string, object> files, string post = "", bool cookie = true)
        {
            string response = string.Empty;

            try
            {
                string url = string.Concat("http://", ip, "/", path, "?lang=de");

                string boundary = string.Concat("---------------------------", DateTime.Now.Ticks.ToString("x"));
                byte[] boundaryBytes = Encoding.ASCII.GetBytes(string.Concat("\r\n--", boundary, "\r\n"));

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = string.Concat("multipart/form-data; boundary=", boundary);
                request.Method = "POST";
                request.KeepAlive = true;

                if (cookie.Equals(true))
                {
                    request.CookieContainer = _cookie;
                }

                Stream requestStream = request.GetRequestStream();

                if (string.IsNullOrEmpty(post).Equals(false))
                {
                    byte[] dataStream = Encoding.UTF8.GetBytes(post);
                    requestStream.Write(dataStream, 0, dataStream.Length);
                    dataStream = null;
                }

                if (files != null && files.Count > 0)
                {
                    foreach (KeyValuePair<string, object> pair in files)
                    {
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                        if (pair.Value is FormFile)
                        {
                            FormFile file = pair.Value as FormFile;
                            string header = string.Concat("Content-Disposition: form-data; name=\"", pair.Key, "\"; filename=\"", file.Name, "\"\r\nContent-Type: ", file.ContentType, "\r\n\r\n");
                            byte[] bytes = Encoding.UTF8.GetBytes(header);
                            requestStream.Write(bytes, 0, bytes.Length);
                            byte[] buffer = new byte[32768];
                            int bytesRead;
                            if (file.Stream == null)
                            {
                                // upload from file
                                FileStream fileStream = File.OpenRead(file.FilePath);
                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                {
                                    requestStream.Write(buffer, 0, bytesRead);
                                }
                                fileStream.Close();
                            }
                            else {
                                // upload from given stream
                                while ((bytesRead = file.Stream.Read(buffer, 0, buffer.Length)) != 0)
                                    requestStream.Write(buffer, 0, bytesRead);
                            }
                        }
                        else {
                            string data = string.Concat("Content-Disposition: form-data; name=\"", pair.Key, "\"\r\n\r\n", pair.Value);
                            byte[] bytes = Encoding.UTF8.GetBytes(data);
                            requestStream.Write(bytes, 0, bytes.Length);
                        }
                    }

                    byte[] trailer = Encoding.ASCII.GetBytes(string.Concat("\r\n--", boundary, "--\r\n"));
                    requestStream.Write(trailer, 0, trailer.Length);
                    requestStream.Close();

                }

                WebResponse webResponse = request.GetResponse();
                Stream responseStream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                response = reader.ReadToEnd();

                webResponse.Dispose();
                reader.Dispose();
                reader = null;
                request = null;
                webResponse = null;
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.ToString());
            }

            return response;
        }
    }

    public class FormFile
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public string FilePath { get; set; }

        public Stream Stream { get; set; }
    }
}