using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CPUNichiconSupportWIP
{
    public static class SettingConfiguration
    {
        private static string pathConfig = System.Reflection.Assembly.GetEntryAssembly().Location + ".config";
        //AppDomain.CurrentDomain.BaseDirectory + @"\App.config"
        private static string singleNote = "configuration/appSettings";
        private static readonly string ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

        // Methods
        public static void F_AddKey(string i_StrKey, string i_StrValue)
        {
            if (!F_KeyExists(i_StrKey))
            {
                throw new ArgumentNullException("Key", "<" + i_StrKey + "> does not exist in the configuration. Update failed.");
            }
            XmlDocument document = new XmlDocument();
            document.Load(pathConfig);
            XmlNode node = document.SelectSingleNode(singleNote);
            try
            {
                if (node != null)
                {
                    XmlNode newChild = node.FirstChild.Clone();
                    if (newChild.Attributes != null)
                    {
                        newChild.Attributes["key"].Value = i_StrKey;
                        newChild.Attributes["value"].Value = i_StrValue;
                    }
                    node.AppendChild(newChild);
                }
                document.Save(pathConfig);
                document.Save(ConfigurationFile);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void F_DeleteKey(string i_StrKey)
        {
            if (!F_KeyExists(i_StrKey))
            {
                throw new ArgumentNullException("Key", "<" + i_StrKey + "> does not exist in the configuration. Update failed.");
            }
            XmlDocument document = new XmlDocument();
            document.Load(pathConfig);
            XmlNode node = document.SelectSingleNode(singleNote);
            if (node != null)
                foreach (XmlNode node2 in node)
                {
                    if (node2.Attributes != null && node2.Attributes["key"].Value == i_StrKey)
                    {
                        node.RemoveChild(node2);
                    }
                }
            document.Save(pathConfig);
            document.Save(ConfigurationFile);
        }

        public static bool F_KeyExists(string i_StrKey)
        {
            XmlDocument document = new XmlDocument();
            document.Load(pathConfig);
            XmlNode node = document.SelectSingleNode(singleNote);
            if (node != null)
                foreach (XmlNode node2 in node)
                {
                    if (node2.Attributes != null && node2.Attributes["key"].Value == i_StrKey)
                    {
                        return true;
                    }
                }
            return false;
        }

        public static void F_UpdateKey(string i_StrKey, string i_NewValue)
        {
            if (!F_KeyExists(i_StrKey))
            {
                throw new ArgumentNullException("Key", "<" + i_StrKey + "> does not exist in the configuration. Update failed.");
            }
            XmlDocument document = new XmlDocument();
            document.Load(pathConfig);
            XmlNode node = document.SelectSingleNode(singleNote);
            foreach (XmlNode node2 in node)
            {
                if (node2.Attributes["key"].Value == i_StrKey)
                {
                    node2.Attributes["value"].Value = i_NewValue;
                }
            }
            document.Save(pathConfig);
            document.Save(ConfigurationFile);
        }
    }
}
