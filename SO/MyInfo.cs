using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkBravoTool.DAL;

namespace tkBravoTool.SO
{
    class MyInfo
    {
        #region Thông số chương trình

        public static string BranchName = "";

        public static string LoadBranchName()
        {
            string _BranchName;
            if (MyApp.gConnected)
            {
                DataLoading DL = new DataLoading();

                string _name = DL.NameReturn("TOP 1 BranchName", "B00Branch", "BranchCode LIKE '%1'");

                if (!string.IsNullOrEmpty(_name))
                {
                    _BranchName = "Hợp đồng: " + _name;
                }
                else
                {
                    _BranchName = "Hợp đồng: " + DL.NameReturn("TOP 1 BranchName", "B00Branch", "");
                }    
                
                        ;
                _BranchName += " - Server: " + MyApp.gHostDB;
            }
            else
                _BranchName = "";

            return _BranchName;
        }

        public static string AppName = "tkBravoTool";

        public static string vVer = "v.1.8.3";

        public static string EncodeKey = "tkBravoTool";

        #endregion
    }
}
