using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using tkBravoTool.SO;
using System.Threading;

namespace tkBravoTool.DAL
{
    class LoginProvider
    {
        

        #region Login vào ứng dụng
        //chuyển hàm về dạng async task
        public static async Task<string> LoginApp(
            string host, string servicename, string userdb, string pwddb, CancellationToken token)
        {
            string result = "Lỗi đăng nhập.";
            DataAccess dbA = new DataAccess();
            MyApp.MSSQLConnectionString = MyApp.GetLoginMSSQL(host, servicename, userdb, pwddb);
            dbA.ConnectionString = MyApp.MSSQLConnectionString;     //Gán connect String vào DataAccess
            string sql = "SELECT 1";                                //Câu lệnh kiểm tra (chỉ cần trả về bảng là kết nối thành công)
            List<KeyValuePair<string, object>> ParaMeterCollection = new List<KeyValuePair<string, object>>();      //Tạo một list biến mảng gồm String / Obj
            try
            {
                //chuyển về dạng chờ, đặt thêm phương thức hủy
                DbDataReader reader = await dbA.ExecuteAsDataReaderSql(sql, ParaMeterCollection, token);    
                if (reader.Read())
                { 
                    result = "true";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

       
        #endregion
    }
}
