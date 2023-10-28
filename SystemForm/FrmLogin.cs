using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tkBravoTool.SO;
using tkBravoTool.DAL;
using System.Configuration;
using System.Threading;
using tkBravoTool.DPL;
using tkBravoTool.DesignView;

namespace tkBravoTool.SystemForm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private DataTable loginInfo;
        TempTable TmpTab = new TempTable();
        private int indexSel;
        private bool save;

        Task<string> _login;
        //tạo biến để gọi hủy vào login
        private CancellationTokenSource _tokenSource;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Thực hiện kiểm tra các điều kiện
            if (_checkInfo(out StringBuilder _info) > 0)
            {
                string mMessage;
                mMessage = string.Format("Không thể để trống {0}. Vui lòng điền đủ các thông tin", _info);
                MessageBox.Show(mMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Ghi dữ liệu vào file Config
                _WriteConfig();
                return;
            }
            
            btnLogin_async().ConfigureAwait(continueOnCapturedContext: false);//.Wait();continueOnCapturedContext:
        }

        private async Task btnLogin_async()
        {
            EnableAll(false);
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;                     //gài lệnh hủy

            //throw new Exception();//ném ra 1 ngoại lệ

            //Thực hiện đăng nhập vào ứng Demo với thông tin trên   //Đây là câu lệnh gây treo chương trình
            //Chuyển vào bất đồng bộ
            _login = LoginProvider.LoginApp(txtDataSource.Text, txtDatabase.Text, txtUserId.Text, txtPassword.Text, token);

            var loginApp = await _login;

            try
            {
                if (loginApp.Equals("true"))
                {
                    MyApp.gConnected = true;
                    //nếu đăng nhập thành công, thực hiện gán các biến trong MyApp thành cơ sở dữ liệu hiện thời
                    MyApp.gHostDB = txtDataSource.Text;
                    MyApp.gServiceNameDB = txtDatabase.Text;
                    MyApp.gUserDB = txtUserId.Text;
                    MyApp.gPwdDB = txtPassword.Text;
                    
                    //Chạy tạo thủ tục 
                    SysUsp.CreateUsp();

                    //Load tên hợp đồng
                    MyInfo.BranchName = MyInfo.LoadBranchName();
                    FrmMain.Current.BranchNameChange = MyInfo.BranchName;

                    FrmMain.Current.ItemMnuLoginChange = "Ngắt kết nối";

                    //Goi phan quyen o day
                    PhanQuyen.ShowAll();
                    //close form
                    this.Close();
                }
                else if (loginApp.Equals("A task was canceled."))
                {
                    //nothing
                }
                else
                {
                    string mMessage;
                    mMessage = string.Format("Đăng nhập vào {0} không thành công. Bạn hãy kiểm tra lại các thông tin đăng nhập.\r\n{1}", txtDataSource.Text, loginApp);
                    MessageBox.Show(mMessage);
                }
                //Ghi dữ liệu vào file Config
                _WriteConfig();
            }
            catch (Exception ex)
            {
                MyApp.gConnected = false;
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Ghi dữ liệu vào list (nếu có)
                _WriteLoginInfo();
                EnableAll(true);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Load dữ liệu kết nối chương trình vào
            LoadTableLoginInfo();
            LoadDataSource();

            MyConfig _Config = new MyConfig();

            //Khi load, đọc dữ liệu của Config, đẩy các giá trị cũ vào
            txtDataSource.Text = _Config.ReadConfig("DataSource");
            txtUserId.Text = _Config.ReadConfig("UserId");
            txtPassword.Text = _Config.ReadConfig_Encode("Password");
            txtDatabase.Text = _Config.ReadConfig("Database");

            EnableAll(true);
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            PasswordEnabled();
        }

        private void PasswordEnabled()
        {
            if (txtUserId.Text == "")
            {
                txtPassword.Text = "";
                txtPassword.Enabled = false;
            }
            else
            {
                txtPassword.Enabled = true;
            }
        }

        private int _checkInfo(out StringBuilder info)
        {
            int _i = 0;
            StringBuilder _info = new StringBuilder("");

            if (string.IsNullOrWhiteSpace(txtDataSource.Text))
            {
                _i += 1;
                _info.Append("DataSource");
            }

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                _i += 1;

                if (!string.IsNullOrEmpty(_info.ToString())) _info.Append(", ");

                _info.Append("Database");
            }

            info = _info;

            return _i;
        }

        private void _WriteConfig()
        {
            #region Sau tất cả , luôn ghi dữ liệu vào Config

            MyConfig _Config = new MyConfig();

            _Config.EditOrAddConfig("DataSource", txtDataSource.Text);
            _Config.EditOrAddConfig("UserId", txtUserId.Text);
            _Config.EditOrAddConfig_Encode("Password", txtPassword.Text);
            _Config.EditOrAddConfig("Database", txtDatabase.Text);

            _Config.SaveConfig();
            #endregion
        }

        private void _WriteLoginInfo()
        {
            #region Nếu đăng nhập thành công, lưu dữ liệu vào danh sách list
            if (ckbSave.Checked & MyApp.gConnected)        //nếu chọn lưu và đã đăng nhập thành công
            {
                int _check = 0;
                for (int i = 0; i < loginInfo.Rows.Count; i++)      //chạy từ đầu đến cuối datatable
                {
                    //Nếu trùng
                    if (loginInfo.Rows[i]["DataSource"].ToString() == txtDataSource.Text & loginInfo.Rows[i]["Database"].ToString() == txtDatabase.Text)
                    {
                        loginInfo.Rows[i]["UserId"] = txtUserId.Text;
                        loginInfo.Rows[i]["Password"] = Encode.Encrypt(txtPassword.Text);
                        _check = 1;
                    }
                }

                //Nếu chạy hết vòng lặp rồi mà vẫn chưa update thì thêm mới
                if (_check == 0)
                {
                    TmpTab.addRowTable(ref loginInfo, new string[] { txtDataSource.Text, txtUserId.Text, Encode.Encrypt(txtPassword.Text), txtDatabase.Text });
                }
            }
            else if (!ckbSave.Checked) //nếu không lưu
            {
                for (int i = 0; i < loginInfo.Rows.Count; i++)      //chạy từ đầu đến cuối datatable
                {
                    //Nếu trùng => xóa
                    if (loginInfo.Rows[i]["DataSource"].ToString() == txtDataSource.Text & loginInfo.Rows[i]["Database"].ToString() == txtDatabase.Text)
                    {
                        DataRow rw = loginInfo.Rows[i];
                        loginInfo.Rows.Remove(rw);
                    }
                }
            }

            SaveData();
            #endregion
        }

        private void SaveData()
        {
            string _XmlData = GetXML.DataTableToXML(loginInfo);

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\LoginInfo.txt";

            ExportFile.SaveFile(_XmlData, PathFile);
        }

        private void EnableAll(bool _bl)
        {
            txtDataSource.Enabled = _bl;
            txtDatabase.Enabled = _bl;
            txtUserId.Enabled = _bl;
            txtPassword.Enabled = _bl;
            btnLogin.Enabled = _bl;

            save = _bl;

            //nếu gọi mở sáng thì mới check kiểm tra pass để khóa pass
            if (_bl)
                PasswordEnabled();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (LoginProvider._tokenSource == null)
            if (_login == null || _login.Status == TaskStatus.RanToCompletion)
            {
                this.Close();
            }
            else
            {
                _tokenSource.Cancel();
            }    

           
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
            //else if (e.Control && e.KeyCode == Keys.M) btnFix.PerformClick();
        }

        private void LoadTableLoginInfo()
        {
            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\LoginInfo.txt";

            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(PathFile);

                try
                {
                    loginInfo = ds.Tables[0];
                }
                catch
                {
                    loginInfo = TableTmp();
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSource()
        {
            if (loginInfo == null) return; 

            if (loginInfo.Rows.Count > 0)
            {
                //for (int i = 0; i < loginInfo.Rows.Count; i++)
                //{
                //    txtDataSource.Items.Add(loginInfo.Rows[i]["DataSource"].ToString());
                //}

                txtDataSource.DataSource = loginInfo;
                txtDataSource.ValueMember = "DataSource";
                txtDataSource.ColumnNames = "DataSource;Database";
                txtDataSource.ColumnWidths = "150;150";
            }
        }

        private void txtDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Nếu đang save thì không thực hiện nhảy
            if (!save) return;
            //gán index đang chọn
            indexSel = txtDataSource.SelectedIndex;

            if (indexSel == -1) return; //Nếu đã xóa hết thì ko gán giá trị nữa 

            txtUserId.Text = loginInfo.Rows[indexSel]["UserId"].ToString();
            txtPassword.Text = Encode.Decrypt(loginInfo.Rows[indexSel]["Password"].ToString());
            txtDatabase.Text = loginInfo.Rows[indexSel]["Database"].ToString();
        }

        private DataTable TableTmp()
        {
            DataTable tb = new DataTable();
            tb.TableName = "TableTmp";

            TmpTab.addColumnTable(ref tb, "DataSource", "System.String", true);
            TmpTab.addColumnTable(ref tb, "UserId", "System.String", false);
            TmpTab.addColumnTable(ref tb, "Password", "System.String", false);
            TmpTab.addColumnTable(ref tb, "Database", "System.String", false);

            return tb;
        }

        private void ckbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}