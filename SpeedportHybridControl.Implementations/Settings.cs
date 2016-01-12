using System;
using System.IO;
using System.Text;
using System.Xml;

namespace SpeedportHybridControl.Implementations
{
    public class Settings
    {
        public static SettingsModel load()
        {
            SettingsModel result = new SettingsModel();
            try
            {
                if (File.Exists("settings.xml").Equals(true))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("settings.xml");
                    result = new SettingsModel
                    {
                        ip = xmlDocument.DocumentElement["ip"].InnerText,
                        password = Cryptography.Decrypt(xmlDocument.DocumentElement["password"].InnerText)
                    };
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteToLog(ex.Message);
            }

            return result;
        }

        public static bool save(SettingsModel settings)
        {
            bool result;
            try
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter("settings.xml", Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.Indentation = 4;
                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteStartElement("settings");
                    xmlTextWriter.WriteElementString("ip", settings.ip);
                    xmlTextWriter.WriteElementString("password", Cryptography.Encrypt(settings.password));
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndDocument();
                }
                result = true;
            }
            catch (Exception exception)
            {
                LogManager.WriteToLog(exception.Message);

                result = false;
            }
            return result;
        }
    }

    public class SettingsModel
    {
        private string _password;
        private string _ip;

        public string password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;

                _password = value;
            }
        }

        public string ip
        {
            get { return _ip; }
            set
            {
                if (_ip == value)
                    return;

                _ip = value;
            }
        }

        public SettingsModel()
        {
        }
    }
}
