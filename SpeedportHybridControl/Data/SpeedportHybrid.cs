using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Windows;
using SpeedportHybridControl.Model;
using SpeedportHybridControl.PageModel;
using SpeedportHybridControl.Implementations;

namespace SpeedportHybridControl.Data {
	public class SpeedportHybrid {
		public SpeedportHybrid() { }
		
		public static void initOverview () {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				OverviewPageModel overview = Application.Current.FindResource("OverviewPageModel") as OverviewPageModel;

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/Overview.json");
				if (response.IsNullOrEmpty())
					return;

				JToken jArray = JToken.Parse(response);
				response = null;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";

				string onlinestatus = jArray.getVar("onlinestatus");
				if (onlinestatus.Equals("offline")) {
					overview.onlinestatus = "DSL-Verbindung getrennt";
				}
				else if (onlinestatus.Equals("disabled")) {
					overview.onlinestatus = "DSL-Verbindung gesperrt";
				}
				else if (onlinestatus.Equals("online")) {
					overview.onlinestatus = "DSL-Verbindung aktiv";
				}
				else if (onlinestatus.Equals("fail")) {
					overview.onlinestatus = "DSL-Verbindung getrennt";
				}
				else {
					overview.onlinestatus = "DSL-Verbindung nicht eingerichtet";
				}

				if (jArray.getVar("dsl_link_status").Equals("online")) {
					overview.dsl_link_status = "DSL-Link synchron";
				}
				else {
					overview.dsl_link_status = "DSL-Link nicht synchron";
				}

				overview.lte_image = string.Concat("../assets/lte", jArray.getVar("lte_signal"), ".png");

				if (onlinestatus.Equals("online") || jArray.getVar("gre_status").Equals("1")) {
					bool chk = true;
					foreach (JToken jToken in jArray) {
						JToken varid = jToken["varid"];
						if (varid.ToString().Equals("addipnumber")) {
							if (jToken["varvalue"].getVar("number_status").Equals("ok").Equals(false)) {
								chk = false;
							}
						}

						varid = null;
					}

					if (chk.Equals(true)) {
						overview.number_status = "Internet Telefonie aktiv";
					}
					else {
						overview.number_status = "Internet Telefonie aus";
					}
				}
				else {
					overview.number_status = "Telefonie nicht nutzbar";
				}

				if (jArray.getVar("use_dect").Equals("0")) {
					overview.use_dect = "DECT-Basisstation aus";
				}
				else {
					overview.use_dect = "DECT-Basisstation an";
				}

				int c = 0;
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("adddect")) {
						c++;
					}

					varid = null;
				}

				if (c.Equals(1)) {
					overview.dect_devices = "1 angemeldetes Schnurlostelefon";
				}
				else {
					overview.dect_devices = string.Concat(c.ToString(), " angemeldete Schnurlostelefone");
				}

				int wc = 0;
				if (jArray.getVar("use_wlan").Equals("1")) {
					foreach (JToken jToken in jArray) {
						JToken varid = jToken["varid"];
						if (varid.ToString().Equals("addmdevice")) {
							if (jToken["varvalue"].getVar("mdevice_type").Equals("1") && jToken["varvalue"].getVar("mdevice_connected").Equals("1")) {
								wc++;
							}
						}

						varid = null;
					}
				}

				if (jArray.getVar("use_wlan_5ghz").Equals("1")) {
					foreach (JToken jToken in jArray) {
						JToken varid = jToken["varid"];
						if (varid.ToString().Equals("addmdevice")) {
							if (jToken["varvalue"].getVar("mdevice_type").Equals("2") && jToken["varvalue"].getVar("mdevice_connected").Equals("1")) {
								wc++;
							}
						}

						varid = null;
					}
				}

				int lc = 0;
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addmdevice")) {
						if (jToken["varvalue"].getVar("mdevice_type").Equals("0") && jToken["varvalue"].getVar("mdevice_connected").Equals("1")) {
							lc++;
						}
					}

					varid = null;
				}

				int uc = 0;
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addotherdevice")) {
						if (jToken["varvalue"].getVar("nas_device_connection").Equals("USB")) {
							uc++;
						}
					}

					varid = null;
				}

				overview.devices = string.Concat(wc.ToString(), " an WLAN, ", lc.ToString(), " an LAN, ", uc.ToString(), " an USB");

				if (jArray.getVar("use_wlan").Equals("1")) {
					overview.use_wlan = "2,4-GHz-Frequenzband an";
				}
				else {
					overview.use_wlan = "2,4-GHz-Frequenzband aus";
				}

				if (jArray.getVar("use_wlan_5ghz").Equals("1")) {
					overview.use_wlan_5ghz = "5-GHz-Frequenzband an";
				}
				else {
					overview.use_wlan_5ghz = "5-GHz-Frequenzband aus";
				}

				if (jArray.getVar("wlan_enc").Equals("0")) {
					overview.wlan_enc = "WLAN unverschlüsselt";
				}
				else {
					overview.wlan_enc = "WLAN verschlüsselt";
				}

				if (jArray.getVar("wlan_power").Equals("0")) {
					overview.wlan_power = "Sendeleistung hoch";
				}
				else if (jArray.getVar("wlan_power").Equals("1")) {
					overview.wlan_power = "Sendeleistung mittel";
				}
				else {
					overview.wlan_power = "Sendeleistung niedrig";
				}

				int ec = 0;
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addotherdevice")) {
						if (jToken["varvalue"].getVar("nas_device_type").Equals("NAS")) {
							ec++;
						}
					}

					varid = null;
				}

				if (ec.Equals(1)) {
					overview.external_devices = "1 externer Datenträger verfügbar";
				}
				else {
					overview.external_devices = string.Concat(ec.ToString(), " externe Datenträger verfügbar");
				}

				if (jArray.getVar("nas_sync_active").Equals("true")) {
					overview.nas_sync_active = "Ordner synchronisieren an";
				}
				else {
					overview.nas_sync_active = "Ordner synchronisieren aus";
				}

				if (jArray.getVar("nas_backup_active").Equals("true")) {
					overview.nas_backup_active = "Daten sichern an";
				}
				else {
					overview.nas_backup_active = "Daten sichern aus";
				}

				if (jArray.getVar("mc_password").IsNullOrEmpty()) {
					overview.mc_state = "Verbindung mit Mediencenter nicht eingerichtet";
				}
				else {
					if (jArray.getVar("mc_allow_connect").Equals("0")) {
						overview.mc_state = "Verbindung mit Mediencenter nicht erlaubt";
					}
					else {
						if (jArray.getVar("mc_login_success").Equals("1")) {
							overview.mc_state = "Verbindung mit Mediencenter eingerichtet";
						}
						else {
							overview.mc_state = "Verbindung mit Mediencenter fehlgeschlagen";
						}
					}
				}

				// overview.days_online = ""; // TODO

				overview.datetime = time.ToString(format);

				jArray = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}

		public static void initTR181 () {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				TR181 tr181 = Application.Current.FindResource("TR181") as TR181;

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/bonding_tr181.json");
				if (response.IsNullOrEmpty())
					return;

				TR181 obj = JsonConvert.DeserializeObject<TR181>(response);
				response = null;

				tr181.enable1 = obj.enable1;
				tr181.status1 = obj.status1;
				tr181.mode = obj.mode;
				tr181.servername = obj.servername;
				tr181.severip = obj.severip;
				tr181.bw = obj.bw;
				tr181.errorinfo = obj.errorinfo;
				tr181.hellostatus = obj.hellostatus;
				tr181.QueueSkbTimeOut = obj.QueueSkbTimeOut;

				response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/bonding_tunnel.json");

				obj = JsonConvert.DeserializeObject<TR181>(response);
				response = null;

				tr181.lte_tunnel = obj.lte_tunnel;
				tr181.dsl_tunnel = obj.dsl_tunnel;
				tr181.bonding = obj.bonding;

				response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/bonding_client.json");
				bonding_client obj2 = JsonConvert.DeserializeObject<bonding_client>(response);

				tr181.bypass_up_bw = obj2.hybrid_show[4].bypass_up_bw;
				tr181.bypass_dw_bw = obj2.hybrid_show[4].bypass_dw_bw;
				tr181.bypass_up_rb = obj2.hybrid_show[4].bypass_up_rb;
				tr181.bypass_dw_rb = obj2.hybrid_show[4].bypass_dw_rb;
				tr181.bypass_check = obj2.hybrid_show[4].bypass_check;
				
				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				tr181.datetime = time.ToString(format);

				obj = null;
				obj2 = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}
		
		public static void initLTE (bool popup = false) {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				LTE lte = null;
				if (popup.Equals(true)) {
					lte = Application.Current.FindResource("LTE2") as LTE;
				}
				else {
					lte = Application.Current.FindResource("LTE") as LTE;
				}

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/lteinfo.json");
				if (response.IsNullOrEmpty())
					return;

				LTE obj = JsonConvert.DeserializeObject<LTE>(response);
				response = null;

				lte.imei = obj.imei;
				lte.imsi = obj.imsi;
				lte.device_status = obj.device_status;
				lte.card_status = obj.card_status;
				lte.antenna_mode = obj.antenna_mode;

				if (obj.antenna_mode.Equals("Antennal set to internal")) {
					lte.antenna_mode2 = "Inner";
				}
				else if (obj.antenna_mode.Equals("Antennal set to external")) {
					lte.antenna_mode2 = "Outer";
				}
				else {
					lte.antenna_mode2 = "Auto";
				}

				lte.phycellid = obj.phycellid;
				lte.cellid = obj.cellid;
				lte.rsrp = obj.rsrp;
				lte.rsrp_bg = util.getRSRPColor(obj.rsrp.ToInt());
				lte.rsrq = obj.rsrq;
				lte.rsrq_bg = util.getRSRQColor(obj.rsrq.ToInt());
				lte.service_status = obj.service_status;
				lte.tac = obj.tac;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				lte.datetime = time.ToString(format);
				if (popup.Equals(false)) {
					initSyslog(true);
				}

				obj = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}
		
		public static void initDSL () {
			if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
				return;

			DslPageModel dsl = Application.Current.FindResource("DslPageModel") as DslPageModel;

			string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/dsl.json");
			if (response.IsNullOrEmpty())
				return;
			
			try {
				DslPageModel obj = JsonConvert.DeserializeObject<DslPageModel>(response);

				double difference = Math.Ceiling((DateTime.Now - SpeedportHybridAPI.getInstance().getLastReboot()).TotalSeconds) / 60;

				obj.Line.uCRCsec = Math.Ceiling(obj.Line.uCRC / difference);
				obj.Line.dCRCsec = Math.Ceiling(obj.Line.dCRC / difference);

				obj.Line.uHECsec = Math.Ceiling(obj.Line.uHEC / difference);
				obj.Line.dHECsec = Math.Ceiling(obj.Line.dHEC / difference);

				obj.Line.uFECsec = Math.Ceiling(obj.Line.uFEC / difference);
				obj.Line.dFECsec = Math.Ceiling(obj.Line.dFEC / difference);
				
				dsl.Connection = obj.Connection;
				dsl.Line = obj.Line;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				dsl.datetime = time.ToString(format);
				
				obj = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}

			response = null;
		}

		public static void initStatus() {
			try {
				StatusPageModel status = Application.Current.FindResource("StatusPageModel") as StatusPageModel;
				string response = SpeedportHybridAPI.getInstance().sendRequest("data/status.json");
				if (response.IsNullOrEmpty())
					return;
				
				JToken jArray = JToken.Parse(response);
				response = null;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				string ltesignal = jArray.getVar("lte_signal");

				status.device_name = jArray.getVar("device_name");

				if (jArray.getVar("use_lte").Equals("0")) {
					status.lte_status = "Deaktiviert";
				}
				else {
					if (jArray.getVar("lte_status").Equals("10") || jArray.getVar("lte_status").Equals("11")) {
						status.lte_status = "Aktiv";
					}
					else {
						status.lte_status = "Nicht aktiv";
					}
				}

				status.lte_signal = string.Concat(ltesignal.ToInt() * 20, " %");
				status.lte_image = string.Concat("../assets/lte", ltesignal, ".png");
				status.datetime = time.ToString(format);
				status.imei = jArray.getVar("imei");

				if (jArray.getVar("dsl_link_status").Equals("online")) {
					status.dsl_link_status = "Synchron";
				}
				else {
					status.dsl_link_status = "Nicht synchron"; // check size
				}

				if (jArray.getVar("status").Equals("online")) {
					status.status = "Aktiv";
				}
				else {
					status.status = "Getrennt";
				}

				status.dsl_downstream = string.Concat(jArray.getVar("dsl_downstream"), " kBit/s");
				status.dsl_upstream = string.Concat(jArray.getVar("dsl_upstream"), " kBit/s");

				List<StatusPhoneListModel> statusPhoneList = new List<StatusPhoneListModel>();
				status.addphonenumber = null;

				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addphonenumber")) {
						string pnumber = jToken["varvalue"].getVar("phone_number");
						string pstatus = string.Empty;
						if (jToken["varvalue"].getVar("status").Equals("ok")) {
							pstatus = "Aktiv";
						}
						else {
							pstatus = "Nicht aktiv";
						}

						statusPhoneList.Add(new StatusPhoneListModel() { number = pnumber, status = pstatus });
					}
				}

				status.addphonenumber = statusPhoneList;

				if (jArray.getVar("use_dect").Equals("0")) {
					status.use_dect = "Nicht aktiv";
				}
				else {
					status.use_dect = "Aktiv";
				}

				int c = 0;
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("adddect")) {
						c++;
					}
				}

				status.dect_devices = c.ToString();

				status.wlan_ssid = jArray.getVar("wlan_ssid");
				status.wlan_5ghz_ssid = jArray.getVar("wlan_5ghz_ssid");

				if (jArray.getVar("use_wlan").Equals("0")) {
					status.use_wlan = "Aus";
				}
				else {
					status.use_wlan = "Eingeschaltet";
				}

				if (jArray.getVar("use_wlan_5ghz").Equals("0")) {
					status.use_wlan_5ghz = "Aus";
				}
				else {
					status.use_wlan_5ghz = "Eingeschaltet";
				}

				status.wlan_devices = jArray.getVar("wlan_devices");
				status.wlan_5ghz_devices = jArray.getVar("wlan_5ghz_devices");
				if (jArray.getVar("lan1_device").Equals("1")) {
					status.lan1_device = "../assets/check.png";
				}
				else {
					status.lan1_device = "../assets/x.png";
				}

				if (jArray.getVar("lan2_device").Equals("1")) {
					status.lan2_device = "../assets/check.png";
				}
				else {
					status.lan2_device = "../assets/x.png";
				}

				if (jArray.getVar("lan3_device").Equals("1")) {
					status.lan3_device = "../assets/check.png";
				}
				else {
					status.lan3_device = "../assets/x.png";
				}

				if (jArray.getVar("lan4_device").Equals("1")) {
					status.lan4_device = "../assets/check.png";
				}
				else {
					status.lan4_device = "../assets/x.png";
				}

				if (jArray.getVar("hsfon_status").Equals("2")) {
					status.hsfon_status = "Aktiv";
				}
				else {
					status.hsfon_status = "Aus";
				}

				status.firmware_version = jArray.getVar("firmware_version");
				status.serial_number = jArray.getVar("serial_number");


				double difference = (DateTime.Now - SpeedportHybridAPI.getInstance().getLastReboot()).TotalSeconds;
				TimeSpan uptime = TimeSpan.FromSeconds(difference);
				status.uptime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", uptime.Days, uptime.Hours, uptime.Minutes, uptime.Seconds);

				jArray = null;
				statusPhoneList = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}
		
		public static void initSyslog (bool isLTE = false) {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				SyslogData syslog = Application.Current.FindResource("SyslogData") as SyslogData;

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/SystemMessages.json");
				if (response.IsNullOrEmpty())
					return;

				JToken jArray = JToken.Parse(response);
				response = null;

				List<SyslogList> syslogList = new List<SyslogList>();
				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addmessage")) {
						var a = jToken["varvalue"];
						var stamp = a[1]["varvalue"];
						var msg = a[2]["varvalue"];

						// login
						if (msg.ToString().Contains("(G101)").Equals(true))
							continue;

						// logout
						if (msg.ToString().Contains("(G102)").Equals(true))
							continue;

						// session timeout
						if (msg.ToString().Contains("(G103)").Equals(true))
							continue;

						// dnsv6 error
						if (msg.ToString().Contains("(P008)").Equals(true))
							continue;

						// Funkzellen Info
						if (msg.ToString().Contains("(LT004)") && isLTE.Equals(true)) {
							LTE lte = Application.Current.FindResource("LTE") as LTE;
							//LTE lte2 = Application.Current.FindResource("LTE2") as LTE;

							string[] parts = msg.ToString().Split(',');
							string frequenz = parts[2];

							if (frequenz.Equals("20")) {
								frequenz = "800 MHz";
							}
							else if (frequenz.Equals("3")) {
								frequenz = "1800 MHz";
							}
							else if (frequenz.Equals("7")) {
								frequenz = "2600 MHz";
							}

							lte.frequenz = frequenz;
							//lte2.frequenz = frequenz;

							varid = null;
							jArray = null;
							a = null;
							stamp = null;
							msg = null;
							syslogList = null;
							return;
						}

						syslogList.Add(new SyslogList() { timestamp = stamp.ToString(), message = msg.ToString() });

						a = null;
						stamp = null;
						msg = null;
					}
					varid = null;
				}

				syslog.syslogList = syslogList;
				syslogList = null;
				jArray = null;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				syslog.datetime = time.ToString(format);

				syslog = null;
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}

		public static void initPhone() {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				PhoneCallData phone = Application.Current.FindResource("PhoneCallData") as PhoneCallData;

				List<PhoneCallList> missedCalls = new List<PhoneCallList>();
				List<PhoneCallList> takenCalls = new List<PhoneCallList>();
				List<PhoneCallList> dialedCalls = new List<PhoneCallList>();

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/PhoneCalls.json");
				if (response.IsNullOrEmpty())
					return;

				JToken jArray = JToken.Parse(response);
				response = null;

				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addmissedcalls")) {
						JToken a = jToken["varvalue"];
						int _id = a[0]["varvalue"].ToString().ToInt();
						string _date = a[1]["varvalue"].ToString();
						string _time = a[2]["varvalue"].ToString();
						string _who = a[3]["varvalue"].ToString();

						missedCalls.Add(new PhoneCallList() { id = _id, date = _date, time = _time, who = _who });
						a = null;
						_id = 0;
						_date = null;
						_time = null;
						_who = null;
					}
					else if (varid.ToString().Equals("addtakencalls")) {
						JToken a = jToken["varvalue"];
						int _id = a[0]["varvalue"].ToString().ToInt();
						string _date = a[1]["varvalue"].ToString();
						string _time = a[2]["varvalue"].ToString();
						string _who = a[3]["varvalue"].ToString();
						string _duration = a[4]["varvalue"].ToString();

						takenCalls.Add(new PhoneCallList() { id = _id, date = _date, time = _time, who = _who, duration = _duration });
						a = null;
						_id = 0;
						_date = null;
						_time = null;
						_who = null;
						_duration = null;
					}
					else if (varid.ToString().Equals("adddialedcalls")) {
						JToken a = jToken["varvalue"];
						int _id = a[0]["varvalue"].ToString().ToInt();
						string _date = a[1]["varvalue"].ToString();
						string _time = a[2]["varvalue"].ToString();
						string _who = a[3]["varvalue"].ToString();
						string _duration = a[4]["varvalue"].ToString();

						dialedCalls.Add(new PhoneCallList() { id = _id, date = _date, time = _time, who = _who, duration = _duration });
						a = null;
						_id = 0;
						_date = null;
						_time = null;
						_who = null;
						_duration = null;
					}

					varid = null;
                }

				// sort calls
				missedCalls.Sort((x, y) => y.id.CompareTo(x.id));
				takenCalls.Sort((x, y) => y.id.CompareTo(x.id));
				dialedCalls.Sort((x, y) => y.id.CompareTo(x.id));

				missedCalls.OrderBy(x => x.time).ThenBy(x => x.date);

				phone.missedCalls = missedCalls;
				phone.takenCalls = takenCalls;
				phone.dialedCalls = dialedCalls;

				missedCalls = null;
				takenCalls = null;
				dialedCalls = null;
				jArray = null;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				phone.datetime = time.ToString(format);
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}
		
		public static void initLan () {
			try {
				if (SpeedportHybridAPI.getInstance().checkLogin().Equals(false))
					return;

				DeviceData deviceData = Application.Current.FindResource("DeviceData") as DeviceData;

				List<DeviceList> deviceList = new List<DeviceList>();

				string response = SpeedportHybridAPI.getInstance().sendEnryptedRequest("data/LAN.json");
				if (response.IsNullOrEmpty())
					return;

				JToken jArray = JToken.Parse(response);
				response = null;

				string ipv6_prefix = jArray.getVar("lan_ip_v6_prefix");
				string ipv6_range = jArray.getVar("lan_ip_v6_range");

				foreach (JToken jToken in jArray) {
					JToken varid = jToken["varid"];
					if (varid.ToString().Equals("addmdevice")) {
						int id = jToken["varvalue"].getVar("id").ToInt();
						string name = jToken["varvalue"].getVar("mdevice_name");
						string mac = jToken["varvalue"].getVar("mdevice_mac");
						int type = jToken["varvalue"].getVar("mdevice_type").ToInt(); // 0 = lan, 1/2 = wlan
						int connected = jToken["varvalue"].getVar("mdevice_connected").ToInt();
						string ipv4 = jToken["varvalue"].getVar("mdevice_ipv4");
						string ipv6 = jToken["varvalue"].getVar("mdevice_ipv6");
						int mstatic = jToken["varvalue"].getVar("mdevice_static").ToInt();

						ipv6 = string.Concat(ipv6_prefix, ipv6_range, ":", ipv6);

						deviceList.Add(new DeviceList() { id = id, name = name, mac = mac, type = type, connected = connected, ipv4 = ipv4, ipv6 = ipv6, mstatic = mstatic });

						id = 0;
						name = null;
						mac = null;
						type = 0;
						connected = 0;
						ipv4 = null;
						ipv6 = null;
						mstatic = 0;
					}

					varid = null;
				}

				deviceData.deviceList = deviceList;

				jArray = null;
				ipv6_prefix = null;
				ipv6_range = null;
				deviceList = null;

				DateTime time = DateTime.Now;
				string format = "dd.MM.yyyy HH:mm:ss";
				deviceData.datetime = time.ToString(format);
			}
			catch (Exception ex) {
				LogManager.WriteToLog(ex.Message);
			}
		}
	}
}
