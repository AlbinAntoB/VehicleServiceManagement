using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VehicleServiceManagement.Models;
using VehicleSeviceManagement.Framework.Helper;

namespace VehicleServiceManagement.Data
{
    public class Settingsconfiguration
    {
        /// <summary>
        /// Injecting setting configuration Model
        /// </summary>
        private static SettingConfigurations settingConfiguration = null;
        /// <summary>
        /// To read file path
        /// </summary>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static SettingConfigurations ReadConfiguration(string WebRootPath = "")
        {
            string strFileName = string.Concat("~/AppData/mailsettings.json");

            // Deserialize
            string fileData = "";

            SettingConfigurations resultObject = DeserializeObject<SettingConfigurations>(fileData);
            settingConfiguration = resultObject;
            return resultObject;
        }
        /// <summary>
        /// TO read data from file path
        /// </summary>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static SettingConfigurations ReadData(string WebRootPath = "")
        {
            if (WebRootPath == "")
                WebRootPath = (AppDomain.CurrentDomain.BaseDirectory).Replace(@"\bin\Debug\netcoreapp2.2", "") + @"\wwwroot\AppData\";

            string strFileName = string.Concat(WebRootPath, @"\mailsettings.json");
            // Deserialize
            string fileData = ReadFile(strFileName);
            SettingConfigurations resultObject = DeserializeObject<SettingConfigurations>(fileData);

            return resultObject;

        }
        /// <summary>
        /// Setting configuration is not null it read and store in object
        /// </summary>
        public static SettingConfigurations Configuration
        {
            get
            {
                if (settingConfiguration == null)
                {
                    settingConfiguration = ReadData();
                }
                return settingConfiguration;
            }
        }
        public static T DeserializeObject<T>(string objectValue)
        {
            return JsonConvert.DeserializeObject<T>(objectValue);
        }
        public static string ReadFile(string path)
        {
            string fileData = string.Empty;
            try
            {
                if (File.Exists(path))
                {
                    fileData = File.ReadAllText(path);
                    //fileData = File.ReadAllText(new Uri(path).AbsolutePath);
                }
            }
            catch (Exception ex)
            {
                using (ErrorLog errorLog = new ErrorLog())
                {
                    errorLog.WriteLog(ex);
                }
            }

            return fileData;
        }
    }
}
