using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using tkBravoTool.DPL;

namespace tkBravoTool.SO
{
    class MyConfig
    {
        //Tạo 1 biến config mới
        private Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Sửa thành phần Config
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void EditOrAddConfig(string key, string value)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);    //nếu trống thì thêm
            }
            else
            {
                config.AppSettings.Settings[key].Value = value; //Có rồi thì sửa
            }

            //SaveConfig(config);
        }

        /// <summary>
        /// Sửa thành phần config có mã hóa
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value0"></param>
        public void EditOrAddConfig_Encode(string key, string value0)
        {
            string value = Encode.Encrypt(value0);
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (ConfigurationManager.AppSettings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);    //nếu trống thì thêm
            }
            else
            {
                config.AppSettings.Settings[key].Value = value; //Có rồi thì sửa
            }
            //SaveConfig(config);
        }

        /// <summary>
        /// Chốt lưu config
        /// </summary>
        public void SaveConfig()
        {
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            Properties.Settings.Default.Reload();
        }

        /// <summary>
        /// Xóa thành phần config
        /// </summary>
        /// <param name="key"></param>
        public void RemoveConfigSetting(string key)
        {
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);

            //SaveConfig(config);
        }

        /// <summary>
        /// Đọc file config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadConfig(string key)
        {
            string value0 = ConfigurationManager.AppSettings[key];

            return value0;
        }

        /// <summary>
        /// Đọc file config có mã hóa
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadConfig_Encode(string key)
        {
            string value0 = ConfigurationManager.AppSettings[key];
            string value = Encode.Decrypt(value0);

            return value;
        }
    }
}
