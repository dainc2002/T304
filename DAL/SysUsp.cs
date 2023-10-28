using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Windows.Forms;
using tkBravoTool.SO;
using System.Threading;
using tkBravoTool.DPL;

namespace tkBravoTool.DAL
{
    class SysUsp
    {
        /*
        public static async Task<int> CreateUsp(CancellationToken token)
        {
            //Viết hàm int để sau này có thể xử lý bắt việc không tạo được thủ tục, tạm thời chỉ gọi đến, chưa xử lý
            DataAccess dbA = new DataAccess();

            string Path = System.IO.Directory.GetCurrentDirectory() + "\\Sys\\usp.txt";

            StreamReader rd = new StreamReader(Path);
            string _sql0 = await rd.ReadToEndAsync();       //có mất file dẫn đến chờ//ơ nhưng hàm này lại không cho hủy nhỉ ? 
            string[] sql = _sql0.Split('~');
            //string[] sql = rd.ReadToEnd().Split('~');       //có mất file dẫn đến chờ
            int _ok = 0;
            //int _i = sql.Length;

            for (int i = 0; i < sql.Length; i ++)
            {
                try
                {
                    _ok = await dbA.vExecuteDataAsync(sql[i], token);
                }
                catch (Exception es)
                {
                    MessageBox.Show("Không tạo được thủ tục hệ thống" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }    
                
            rd.Close();
            return _ok;
        }
        */
        public static int CreateUsp()
        {
            //Viết hàm int để sau này có thể xử lý bắt việc không tạo được thủ tục, tạm thời chỉ gọi đến, chưa xử lý

            int _ok = 0;

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Sys";

            if (!Directory.Exists(PathFile))       //có file trong thư mục không
            {
                MessageBox.Show("Không tìm thấy thư mục hàm hệ thống", "Thông báo");
                return _ok;
            }

            DataAccess dbA = new DataAccess();
            string[] fileList = Directory.GetFiles(PathFile);//lay danh sách file cho vao mảng
            string FuncName;
            StreamReader rd;

            //duyet mang file trong thư mục
            for (int i = 0; i < fileList.Length; i++)
            {
                FuncName = Path.GetFileName(fileList[i]).Trim().Replace(".txt", "");
                rd = new StreamReader(PathFile + "\\" + FuncName + ".txt");          //gán đường dẫn đọc file
                string _sql = Encode.Decrypt(rd.ReadToEnd());                    //có mất file dẫn đến chờ//

                try
                {
                    int _i = CheckToExist(FuncName);             //kiểm tra xem đã tồn tại hàm hay chưa
                    if (_i > 0) //nếu rồi thì xóa!
                    {
                        string _sql0 = "DROP PROCEDURE " + FuncName;
                        try
                        {
                            _ok = dbA.vExecuteData(_sql0);
                        }
                        catch (Exception es)
                        {
                            MessageBox.Show("Không xóa được thủ tục hệ thống " + FuncName + "\r\n" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    //tạo lại
                    _ok = dbA.vExecuteData(_sql);
                }
                catch (Exception es)
                {
                    MessageBox.Show("Không tạo được thủ tục hệ thống " + FuncName + "\r\n" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                finally
                {
                    rd.Close();
                }
            }

            return _ok;
        }

        public static int DropUsp()
        {
            if (MyApp.gConnected == false)
            {
                return 0;
            }

            DataAccess dbA = new DataAccess();
            int _ok = 0;

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Sys";

            if (!Directory.Exists(PathFile))       //có file trong thư mục không
            {
                MessageBox.Show("Không tìm thấy thư mục hàm hệ thống", "Thông báo");
                return _ok;
            }

            string[] fileList = Directory.GetFiles(PathFile);//lay danh sách file cho vao mảng
            string FuncName;

            //duyet mang file trong thư mục
            for (int i = 0; i < fileList.Length; i++)
            {
                FuncName = Path.GetFileName(fileList[i]).Trim().Replace(".txt","");
                string _sql = "IF EXISTS(SELECT * FROM sys.objects WHERE [name] = '"+ FuncName + "') " +
                                    "DROP PROCEDURE " + FuncName;

                try
                {
                    _ok = dbA.vExecuteData(_sql);
                }
                catch (Exception es)
                {
                    MessageBox.Show("Không xóa được thủ tục hệ thống " + FuncName + "\r\n" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }

            return _ok;
        }

        public static int CheckToExist(string ElementName)
        {
            DataLoading daL = new DataLoading();
            string _check = "SELECT * FROM sys.objects WHERE [name] = '" + ElementName + "' ";
            int _i = daL.checkData(_check);
            return _i;
        }
    }
}
