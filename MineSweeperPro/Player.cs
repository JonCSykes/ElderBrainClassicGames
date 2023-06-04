using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MineSweeperPro
{
    public class Player
    {
        private readonly string SETTINGS_FILE = "settings.xml";
        private string HOME_FOLDER;

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("PortraitName")]
        public string PortraitName { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Bitmap Portrait { get; set; }
        
        [JsonIgnore]
        [XmlElement("PortraitData")]
        public byte[] PortraitData
        {
            get
            {
                if (Portrait != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        Portrait.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        return memoryStream.ToArray();
                    }
                }
                return null;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    using (MemoryStream memoryStream = new MemoryStream(value))
                    {
                        Portrait = new Bitmap(memoryStream);
                    }
                }
                else
                {
                    Portrait = null;
                }
            }
        }

        public Player(string username, string portraitName, Bitmap portrait) { 
            
            Username = username;
            PortraitName = portraitName;
            Portrait = portrait;

            UpdateSettings();
        }

        public Player() {

        }

        public bool ProfileExists() {

            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string settingsFilePath = Path.Combine(HOME_FOLDER, SETTINGS_FILE);

                if (File.Exists(settingsFilePath))
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateSettings()
        {
            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string settingsFilePath = Path.Combine(HOME_FOLDER, SETTINGS_FILE);

                if (!Directory.Exists(HOME_FOLDER))
                {
                    Directory.CreateDirectory(HOME_FOLDER);
                }
                
                SerializeObject(settingsFilePath);
            }
        }

        public void GetSettings()
        {
            string assemblyPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            
            if (!string.IsNullOrEmpty(assemblyPath))
            {
                HOME_FOLDER = Path.Combine(assemblyPath, "MineSweeperPro");
            }

            if (!string.IsNullOrEmpty(HOME_FOLDER))
            {
                string settingsFilePath = Path.Combine(HOME_FOLDER, SETTINGS_FILE);

                if (Directory.Exists(HOME_FOLDER))
                {
                    var loadedSettings = DeserializeObject(settingsFilePath);
          
                    this.Username = loadedSettings.Username;
                    this.Portrait = loadedSettings.Portrait;
                    this.PortraitName = loadedSettings.PortraitName;
                    
                }
            }
        }

        private void SerializeObject(string filePath)
        {
            // Create a FileStream to write the XML file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Create an instance of the XmlSerializer with the MyObject type
                XmlSerializer serializer = new XmlSerializer(typeof(Player));

                // Serialize the MyObject object to the FileStream
                serializer.Serialize(fileStream, this);
            }
        }

        private static Player DeserializeObject(string filePath)
        {
            // Create a FileStream to read the XML file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                // Create an instance of the XmlSerializer with the MyObject type
                XmlSerializer serializer = new XmlSerializer(typeof(Player));

                // Deserialize the FileStream to a MyObject object
                Player player = (Player)serializer.Deserialize(fileStream);

                return player;
            }
        }
        
    }
}
