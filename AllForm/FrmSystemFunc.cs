using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tkBravoTool.DAL;
using tkBravoTool.DPL;
using tkBravoTool.DesignView;

namespace tkBravoTool.AllForm
{
    public partial class FrmSystemFunc : Form
    {
        DesignForm DesFor = new DesignForm();
        bool _selectCell = true;

        private string CurrentCell;
        public FrmSystemFunc()
        {
            InitializeComponent();
        }
        #region Action trên form
        private void FrmSystemFunc_Load(object sender, EventArgs e)
        {
            DesignForm.vForm = this;
            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Sys";
            LoadFile(PathFile);
            DesFor.AlignCenterToScreen();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!_selectCell) return;

            string Func = dataGridView1.CurrentCell.Value.ToString();
            txtFuncName.Text = Func;
            CurrentCell = Func;

            if (Func == "")
            {
                rtbDetail.Text = "";
                return;
            }
            string FileName = Func + ".txt";
            string Path = System.IO.Directory.GetCurrentDirectory() + "\\Sys\\"+ FileName;
            StreamReader rd = new StreamReader(Path);
            string _sql0 = rd.ReadToEnd();

            rtbDetail.Text = Encode.Decrypt(_sql0);

            rd.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiểm tra tên hàm mới
            if (string.IsNullOrWhiteSpace(txtFuncName.Text)) return;

            string Func0 = CurrentCell;
            string Func = txtFuncName.Text;

            string FileName0 = Func0 + ".txt";
            string FileName = Func + ".txt";

            string Path0 = System.IO.Directory.GetCurrentDirectory() + "\\Sys\\" + FileName0;
            string Path = System.IO.Directory.GetCurrentDirectory() + "\\Sys\\" + FileName;

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Sys";

            _selectCell = false;
            //Nếu là thêm mới
            if (Func0 == "")
            {
                if (File.Exists(Path)) //Nếu đã tồn tại file (thuộc link)
                {
                    MessageBox.Show("Đã tồn tại thủ tục tương tự", "Thông báo");
                    return;
                }

                try
                {
                    ExportFile.SaveFile(Encode.Encrypt(rtbDetail.Text), Path);
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtFuncName.Text = "";
            }    
            //Nếu là sửa
            else if (Func0 != "")
            {
                //nếu không thay đổi tên hàm
                if (Func0 == Func)
                {
                    try
                    {
                        ExportFile.SaveFile(Encode.Encrypt(rtbDetail.Text), Path);
                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {

                        File.Delete(Path0); //xóa file cũ
                        ExportFile.SaveFile(Encode.Encrypt(rtbDetail.Text), Path);
                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CurrentCell = Func;             //đặt file mới là curent
                }
            }

            //sau tất cả, reload
            _selectCell = true;
            LoadFile(PathFile);
        }

        private void FrmSystemFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) btnSave.PerformClick();
            //else if (e.Control && e.KeyCode == Keys.M) btnFix.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Func = CurrentCell;

            if (Func == "")
            {
                MessageBox.Show("Chọn thủ tục phù hợp", "Thông báo");
                return;
            }    

            string FileName = Func + ".txt";
            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Sys";
            string Path = PathFile + "\\" + FileName;

            if (MessageBox.Show("xóa file đang chọn", "Xóa file",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    _selectCell = false;
                    File.Delete(Path);
                    MessageBox.Show("Xóa file thành công", "Thông báo");
                    rtbDetail.Text = "";
                    LoadFile(PathFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _selectCell = true;
                }
            }    
        }
        #endregion

        #region Xử lý dữ liệu
        public void LoadFile(string PathFile)
        {
            if (!Directory.Exists(PathFile))       //có file trong thư mục không
            {
                MessageBox.Show("Không tìm thấy file", "Thông báo");
                return;
            }

            string[] fileList = Directory.GetFiles(PathFile);//lay danh sách file cho vao mảng
            string[] ListFileName = new string[fileList.Length]; //danh sach tên file trong thư mục

            DataTable tb = new DataTable();
            DataColumn cl;
            DataRow rw;

            // Create first column and add to the DataTable.
            cl = new DataColumn();
            cl.DataType = System.Type.GetType("System.String");
            cl.ColumnName = "FuncName";
            cl.Unique = true;

            // Add the column to the DataColumnCollection.
            tb.Columns.Add(cl);

            //duyet mang file trong thư mục
            for (int i = 0; i < fileList.Length; i++)
            {
                ListFileName[i] = Path.GetFileName(fileList[i]).Trim();

                rw = tb.NewRow();
                rw["FuncName"] = ListFileName[i].Replace(".txt", "");
                tb.Rows.Add(rw);
            }

            BindingSource gdSource = new BindingSource();
            gdSource.DataSource = tb;
            dataGridView1.DataSource = gdSource;

            DesFor.EditCollum(ref dataGridView1, "FuncName", true, true, "Tên thủ tục", 250);
        }

        #endregion


    }
}
