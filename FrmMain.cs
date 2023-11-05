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
using tkBravoTool.SystemForm;
using tkBravoTool.DAL;
using tkBravoTool.AllForm;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using tkBravoTool.DesignView;
using tkBravoTool.DPL;
//using System.Array;

namespace tkBravoTool
{
    public partial class FrmMain : Form
    {
        TempTable TmpTab = new TempTable(); //class xử lý các datatable

        public static FrmMain Current;
        DesignForm DesFor = new DesignForm();
        bool _selectCell = true;
        private string CurrentCell;

        public FrmMain()
        {
            InitializeComponent();
            Current = this;
        }

        public string ItemMnuLoginChange
        {
            get { return ItemMnuSystemLogin.Text; }
            set { ItemMnuSystemLogin.Text = value; }
        }

        public string BranchNameChange
        {
            get { return lblBranchName.Text; }
            set { lblBranchName.Text = value; }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Show();

            LoadData();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.White;
                }
            }
            MyApp.gConnected = false;
            //truyền đối tượng This (frmMain) cho class PhanQuyen
            PhanQuyen.FrmMain = this;
            //gọi HideAll để ẩn menu trong class PhanQuyen
            PhanQuyen.HideAll();
            LoadInfo();

            //gọi form kết nối //Bỏ gọi form kết nối do nhiều tính năng sử dụng khi không cần kết nối
            //if (!MyApp.gConnected)
            //{
            //    FrmLogin digForm = new FrmLogin();
            //    digForm.ShowDialog();
            //}
            //(new frmLogin()).Show();
        }

        private void LoadInfo()
        {
            //Xóa tên hợp đồng
            MyInfo.BranchName = MyInfo.LoadBranchName();
            FrmMain.Current.BranchNameChange = MyInfo.BranchName;

            //Gọi tên from
            FrmMain.Current.Text = MyInfo.AppName + " " + MyInfo.vVer;
            lblVer.Text = MyInfo.vVer;
        }

        #region Xử lý click load form

        private void ItemMnuSystemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ItemMnuSystemLogin_Click(object sender, EventArgs e)
        {
            if (!MyApp.gConnected)
            {
                FrmLogin digForm = new FrmLogin();
                digForm.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Có chắc chắn bỏ kết nối?", "Đăng xuất",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Đóng tất cả các form
                    CloseAllForm();
                    SysUsp.DropUsp();
                    MyApp.gConnected = false;
                    //Xóa tên hợp đồng
                    MyInfo.BranchName = MyInfo.LoadBranchName();
                    FrmMain.Current.BranchNameChange = MyInfo.BranchName;
                    FrmMain.Current.ItemMnuLoginChange = "Đăng nhập";
                    PhanQuyen.HideAll(); //ẩn tất cả các menu
                    FrmLogin digForm = new FrmLogin();
                    digForm.ShowDialog();
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if (dialog == DialogResult.Yes)
            {
                //Lưu thiết lập ShowPass
                MyConfig _Config = new MyConfig();
                _Config.EditOrAddConfig("ShowPass", Convert.ToString(ckbShowPass.Checked));
                _Config.SaveConfig();

                SysUsp.DropUsp();
            }
        }

        private void FrmMnuChucNang_Dich_Click(object sender, EventArgs e)
        {
            FrmDich callForm = new FrmDich();
            //callForm.LOAI = "N";
            callForm.Show();
        }

        private void CloseAllForm()
        {

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != this.Name)
                    Application.OpenForms[i].Close();
            }
        }

        private void ItemMnuCopyDeleteCommand_Click(object sender, EventArgs e)
        {
            FrmCopyCommand callForm = new FrmCopyCommand();
            //callForm.LOAI = "N";
            callForm.Show();
        }

        private void ItemMnuFunc_Click(object sender, EventArgs e)
        {
            //PassCode.vFormOpen = callForm;
            //callForm.LOAI = "N";

            using (FrmPassCode PassCode = new FrmPassCode())
            {
                if (PassCode.ShowDialog() == DialogResult.OK)
                {
                    if (PassCode._checkPassCode)
                    {
                        FrmSystemFunc callForm = new FrmSystemFunc();
                        callForm.Show();
                    }
                }
            }
        }

        private void ItemMnuCreateList_Click(object sender, EventArgs e)
        {
            FrmCreateDirectory callForm = new FrmCreateDirectory();
            //callForm.LOAI = "N";
            callForm.Show();
        }

        private void ItemMnuCreateCommandList_Click(object sender, EventArgs e)
        {
            FrmCreateCommandList callForm = new FrmCreateCommandList();
            //callForm.LOAI = "N";
            callForm.Show();
        }

        private void ItemMnuDonate_Click(object sender, EventArgs e)
        {
            FrmDonate callForm = new FrmDonate();
            callForm.ShowDialog();
        }

        #endregion


        #region Xử lý load data cho tính năng quản lý output

        private void LoadData()
        {
            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\ProgramsInfo.txt";

            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(PathFile);

                BindingSource gdSource = new BindingSource();

                try
                {       //Đọc bảng từ file 
                    gdSource.DataSource = ds.Tables[0];
                }
                catch   //Nếu không có file/không đọc được bảng thì tạo bảng tạm trắng
                {
                    gdSource.DataSource = TableTmp();
                    _selectCell = false;
                }

                dataGridView1.DataSource = gdSource;

                DesFor.EditCollum(ref dataGridView1, "Name", true, true, "Name", 200);
                DesFor.EditCollum(ref dataGridView1, "Link", false, true, "Link", 250);
                DesFor.EditCollum(ref dataGridView1, "User", false, true, "User", 250);
                DesFor.EditCollum(ref dataGridView1, "Password", false, true, "Password", 250);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MyConfig _Config = new MyConfig();
                //Đặt gọi show pass hay không ở đây
                ckbShowPass.Checked = Convert.ToBoolean(_Config.ReadConfig("ShowPass"));
                _selectCell = true;
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog sfd = new OpenFileDialog())
            {
                sfd.Filter = "Tất cả các tệp|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtLink.Text = sfd.FileName;
                }    
            }    
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!_selectCell) return;

            SelectionChanged();
        }

        private void SelectionChanged()
        {
            CurrentCell = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();

            txtName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtLink.Text = dataGridView1.CurrentRow.Cells["Link"].Value.ToString();
            txtUser.Text = dataGridView1.CurrentRow.Cells["User"].Value.ToString();
            txtPassword.Text = Encode.Decrypt(dataGridView1.CurrentRow.Cells["Password"].Value.ToString());     //riêng pass được mã hóa
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtLink.Text))
            {
                MessageBox.Show("Không tồn tại file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process ExternalProcess = new Process();
                ExternalProcess.StartInfo.FileName = txtLink.Text;
                ExternalProcess.StartInfo.WorkingDirectory = Path.GetDirectoryName(txtLink.Text);
                ExternalProcess.StartInfo.Arguments = "-u:" + txtUser.Text + " -p:" + txtPassword.Text;
                ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                ExternalProcess.Start();
            }
        }

        //Bảng mặc định của chương trình
        private DataTable TableTmp()
        {
            DataTable tb = new DataTable();
            tb.TableName = "TableTmp";

            TmpTab.addColumnTable(ref tb, "Name", "System.String", true);
            TmpTab.addColumnTable(ref tb, "Link", "System.String", false);
            TmpTab.addColumnTable(ref tb, "User", "System.String", false);
            TmpTab.addColumnTable(ref tb, "Password", "System.String", false);

            return tb;
        }

        private void SaveData()
        {
            //chuyển DataGridView về dạng XML
            BindingSource source = (BindingSource)this.dataGridView1.DataSource;
            string _XmlData = GetXML.DataTableToXML((DataTable)source.DataSource);

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\ProgramsInfo.txt";

            try
            {
                ExportFile.SaveFile(_XmlData, PathFile);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra links mới
                if (string.IsNullOrWhiteSpace(txtLink.Text))
                {
                    MessageBox.Show("Điền link chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!File.Exists(txtLink.Text))
                {
                    MessageBox.Show("Không tồn tại file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Điền tên chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Programs0 = CurrentCell;

                //Nếu là thêm mới
                if (string.IsNullOrEmpty(Programs0))
                {
                    //add thêm dòng vào DataGrid
                    BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                    DataTable tb = (DataTable)gdSource.DataSource;

                    TmpTab.addRowTable(ref tb, new string[] { txtName.Text, txtLink.Text, txtUser.Text, Encode.Encrypt(txtPassword.Text) });

                    gdSource.DataSource = tb;
                    dataGridView1.DataSource = gdSource;
                }
                else
                {
                    //Sửa dòng hiện tại
                    dataGridView1.CurrentRow.Cells["Name"].Value = txtName.Text;
                    dataGridView1.CurrentRow.Cells["Link"].Value = txtLink.Text;
                    dataGridView1.CurrentRow.Cells["User"].Value = txtUser.Text;
                    dataGridView1.CurrentRow.Cells["Password"].Value = Encode.Encrypt(txtPassword.Text);
                }    

                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //add xóa dòng khỏi DataGrid
            _selectCell = false;

            foreach (DataGridViewCell cel in dataGridView1.SelectedCells)        //tạo mảng các cell được chọn
            {
                int _i = cel.RowIndex;
                try
                {
                    DataGridViewRow rw = dataGridView1.Rows[_i];

                    dataGridView1.Rows.Remove(rw);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xóa dòng thứ "+Convert.ToString(_i) +"\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    txtLink.Text = "";
                    txtName.Text = "";
                    txtUser.Text = "";
                    txtPassword.Text = "";
                }
            }

            SaveData();

            _selectCell = true;
            LoadData();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) btnSave.PerformClick();
            else if (e.Control && e.KeyCode == Keys.F) txtFind.Focus();
            else if (e.KeyCode == Keys.F5) btnRun.PerformClick();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRun.PerformClick();
        }
        #endregion


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

        private void btnsplSaveMore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog sfd = new OpenFileDialog())
            {
                sfd.Filter = "Các tệp note|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string PathFile = sfd.FileName;

                    try
                    {
                        DataSet ds = new DataSet();     //tạo dataset để hứng xml từ file
                        ds.ReadXml(PathFile);           //hứng xml vào dataset

                        DataTable _TableImport = ds.Tables[0];  //lấy ra bảng từ file

                        //add thêm dòng vào DataGrid
                        BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                        DataTable tb = (DataTable)gdSource.DataSource;      //tạo bảng từ datagrid
                        for (int i = 0; i < _TableImport.Rows.Count; i++)       //chạy vòng lặp từ đầu đến cuối bảng import
                        {
                            TmpTab.addRowTable(ref tb, new string[] { _TableImport.Rows[i]["Name"].ToString(),
                                                                        _TableImport.Rows[i]["Link"].ToString(),
                                                                        _TableImport.Rows[i]["User"].ToString(),
                                                                        _TableImport.Rows[i]["Password"].ToString()});      //add dòng vào datagrid
                        }
                        gdSource.DataSource = tb;
                        dataGridView1.DataSource = gdSource;        //gán lại dataGrid vào bảng sau khi import

                        SaveData();     //Chạy save data vào file
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        LoadData();
                    }
                }
            }
        }

        private void btnsplOverwrite_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog sfd = new OpenFileDialog())
            {
                sfd.Filter = "Các tệp note|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string PathFile = sfd.FileName;

                    try
                    {
                        StreamReader rd = new StreamReader(PathFile);       //tạo reader đặt file vào
                        string Detail = rd.ReadToEnd();                     //chuyển reader sang string

                        string PathFile0 = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\ProgramsInfo.txt";  //tạo đường dẫn lưu file

                        try
                        {
                            ExportFile.SaveFile(Detail, PathFile0);     //ghi đè file vào đường dẫn
                            MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        LoadData();
                    }
                }
            }
        }

        private void btnsplExportAll_Click(object sender, EventArgs e)
        {
            BindingSource source = (BindingSource)this.dataGridView1.DataSource;
            string _XmlData = GetXML.DataTableToXML((DataTable)source.DataSource);

            ExportFile.ExportDetail(_XmlData);
        }

        private void btnsplExportChoseOnly_Click(object sender, EventArgs e)
        {
            int _i = 0;
            int[] SelCel = new int[dataGridView1.SelectedCells.Count];

            DataTable tb = TableTmp();          //tạo bảng trắng có các cột sẵn có
            
            foreach (DataGridViewCell cel in dataGridView1.SelectedCells)        //tạo mảng các cell được chọn
            {
                SelCel[_i] = cel.RowIndex;

                _i++;
            }

            string _CheckRow = ";"; //tạo biến check

            for (int f = SelCel.Min(); f <= SelCel.Max(); f ++) //f ở đây là index các dòng đc chọn, do ở đây có 1 cột nên ko cần kiểm tra trùng dòng (như dưới) nhưng vẫn viết phòng trg hợp sau này thêm cột
            {
                try
                {
                    if (Array.IndexOf(SelCel,f)>-1) //nếu có trong các giá trị được chọn    --> kiểm tra giá trị được chọn
                    {
                        if (!_CheckRow.Contains(";" + Convert.ToString(f)))            //kiểm tra dòng i đã chạy qua chưa
                        {
                            _CheckRow = _CheckRow + Convert.ToString(f) + ";";     //nếu chưa thì cộng vào chuỗi kiểm tra
                        }
                        else continue;                                              //nếu rồi thì bỏ qua vòng này, tiếp tục lặp

                        TmpTab.addRowTable(ref tb, new string[] { dataGridView1.Rows[f].Cells["Name"].Value.ToString(),
                                                            dataGridView1.Rows[f].Cells["Link"].Value.ToString(),
                                                            dataGridView1.Rows[f].Cells["User"].Value.ToString(),
                                                            dataGridView1.Rows[f].Cells["Password"].Value.ToString()});      //add dòng vào datatable tmp

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Có lỗi khi tạo bảng đẩy dữ liệu\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                    continue; //tiếp tục
                }
            }    

            string _XmlData = GetXML.DataTableToXML(tb);

            ExportFile.ExportDetail(_XmlData);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFind.Text)) return;      //nếu không có gì trong ô text thì quay lại 

            int cr = dataGridView1.CurrentCell.RowIndex;
            int cr0 = cr;

            int mr = dataGridView1.Rows.Count - 2;
            string _find = txtFind.Text.ToLower();

            while (cr + 1 <= mr)        //bắt đầu tìm từ ô kế tiếp trở đi
            {
                string _name = dataGridView1.Rows[cr + 1].Cells["Name"].Value.ToString().ToLower();

                if (_name.Contains(_find))
                {
                    _selectCell = false;            //chặn check thay đổi để nhảy info
                    dataGridView1.CurrentCell.Selected = false;
                    dataGridView1.CurrentCell = dataGridView1[0, cr + 1];
                    dataGridView1.Rows[cr + 1].Selected = true;
                    _selectCell = true;             //mở lại 
                    SelectionChanged();
                    return;
                }    

                cr++;
            }    

            if (cr0 != 0)
            {
                for (int i = 0; i <= cr0; i++)
                {
                    string _name = dataGridView1.Rows[i].Cells["Name"].Value.ToString().ToLower();

                    if (_name.Contains(_find))
                    {
                        _selectCell = false;            //chặn check thay đổi để nhảy info
                        dataGridView1.CurrentCell.Selected = false;
                        dataGridView1.CurrentCell = dataGridView1[0, i];
                        dataGridView1.Rows[i].Selected = true;
                        _selectCell = true;             //mở lại 
                        SelectionChanged();
                        return;
                    }
                }    
            }
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnFind.PerformClick();
        }





        #region Xử lý kéo thả trên tính năng quản lý output

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                // Nếu chuột di chuyển bên ngoài hình chữ nhật, hãy bắt đầu kéo.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.       
                    // Tiến hành kéo và thả, chuyển vào mục danh sách.
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(
                          dataGridView1.Rows[rowIndexFromMouseDown],
                          DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(
                          new Point(
                            e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)),
                      dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be converted to client coordinates.
            // Các vị trí chuột có liên quan đến màn hình, vì vậy chúng phải được chuyển đổi sang tọa độ máy khách.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove0 = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;

                string _Name = rowToMove0.Cells["Name"].Value.ToString();
                string _Link = rowToMove0.Cells["Link"].Value.ToString();
                string _User = rowToMove0.Cells["User"].Value.ToString();
                string _Password = rowToMove0.Cells["Password"].Value.ToString();

                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                //dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                //add thêm dòng vào DataGrid
                BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                DataTable tb = (DataTable)gdSource.DataSource;

                TmpTab.addRowTableIndex(ref tb, new string[] { _Name, _Link, _User, _Password }, rowIndexOfItemUnderMouseToDrop);

                gdSource.DataSource = tb;
                dataGridView1.DataSource = gdSource;
            }
        }

        #endregion

        private void ItemMnuCheckLogMerge_Click(object sender, EventArgs e)
        {
            FrmCheckMergeCode callForm = new FrmCheckMergeCode();
            //callForm.LOAI = "N";
            callForm.Show();
        }
    }
}