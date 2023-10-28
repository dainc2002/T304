using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tkBravoTool.DAL;
using tkBravoTool.DPL;
using tkBravoTool.SO;
using tkBravoTool.DesignView;

namespace tkBravoTool.AllForm
{
    public partial class FrmCopyCommand : Form
    {
        public FrmCopyCommand()
        {
            InitializeComponent();
        }

        DataLoading DatLoa = new DataLoading();
        DesignForm DesFor = new DesignForm();

        string _Command; //Command đang xử lý
        int _MaxLoadRowOnGrid = 50;     //Số dòng tối đa load trên grid

        #region action trên from
        private void FrmCopyCommand_Load(object sender, EventArgs e)
        {
            DesignForm.vForm = this;
            loadDataCommand();
            lblBranchName.Text = MyInfo.BranchName;
            LoadDataStyle();            //lấy ra những mục check mặc định
            EnableAll(true);            //gọi mở sáng cho tất cả
            DesFor.AlignCenterToScreen();
        }

        private void cbbCommand_Leave(object sender, EventArgs e)
        {
            if (cbbCommand.Text != "")
            {
                int rw = DatLoa.checkData("SELECT CommandKey FROM B00Command WHERE IsActive = 1 AND IsGroup = 0 " +
                                            " AND CommandKey = '" + cbbCommand.Text + "'");
                if (rw == 0)
                {
                    cbbCommand.Text = "";
                    rtbKeyWhere.Text = "";
                }
                else
                {
                    cbbCommand.Text = DatLoa.NameReturn("CommandKey", "B00Command", "CommandKey = '" + cbbCommand.Text + "'");

                    if (_Command != cbbCommand.Text)
                    {
                        clearDataGrid();
                    }

                    _Command = cbbCommand.Text;

                    rtbKeyWhere.Text = LoadKeyWhere();
                }
            }
        }

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            clearDataGrid();
            EnableAll(false);
            try
            {
                loadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableAll(true);
            }

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //bỏ chọn tất cả
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //}
            dataGridView1.ClearSelection();     //Code ngu -> Thay lại bằng cách này ngắn gọn hơn

            int Col = dataGridView1.Columns[e.ColumnIndex].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[Col].Selected = true;
            }
        }

        private void ckbTable_CheckedChanged(object sender, EventArgs e)
        {
            CheckTable();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                EnableAll(false);
                BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                DataTable tb = (DataTable)gdSource.DataSource;
                ExportFile.ExportDataTable(tb, "Sta");
                EnableAll(true);
            }
        }

        private void FrmCopyCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) btnSaveFile.PerformClick();
            else if (e.Control && e.KeyCode == Keys.Enter) btnGenCode.PerformClick();
        }

        private void lblCreateUsp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Chạy tạo thủ tục 
                SysUsp.CreateUsp();
                MessageBox.Show("Tạo thủ tục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi tạo thủ tục" + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (dataGridView1.DataSource == null)   //đoạn kiểm tra có dữ liệu trong DataGridView không
                {
                    return;
                }
                else
                {       //Đây là trường hợp đã từng load 1 lần rồi bị xóa đi thì DataSource không null, nhưng thực tế đã không còn dữ liệu
                    BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                    DataTable tb = (DataTable)gdSource.DataSource;
                    if (tb == null)
                    {
                        return;
                    }
                }                                      //đến đây mới hết kiểm tra

                string _ClipboardText = CopyDataGridToClipboard(); // Clipboard.GetText(); //dataGridView1.CurrentCell.Value.ToString();

                //for (int i = 2; i >= 1; i--)
                //{
                //    string _space = "\r\n";
                //    string _tab = "\r\n";
                //    for (int j = 1; j <= i; j++)
                //    {
                //        _space += " ";
                //        _tab += "\t";
                //    }

                //    _test = _test.Replace(_space, _tab);
                //}

                Clipboard.SetText(_ClipboardText);
            }

        }

        #endregion

        #region hàm xử lý dữ liệu
        private void loadDataCommand()
        {
            string _Filter = " WHERE IsActive = 1 AND IsGroup = 0 ";
            if (cbbCommand.Text != "")
                _Filter = _Filter + " AND CommandKey LIKE '" + cbbCommand.Text + "%'";
            //else
            //    return;

            DatLoa.loadCBB("SELECT CommandKey FROM B00Command " + _Filter, ref cbbCommand);

        }

        private void loadDataGrid()
        {
            String _KeyWhere = "@_Key_Where = N'" + rtbKeyWhere.Text.Replace("'", "''") + "'";

            if (ckbCommand.Checked == true) _KeyWhere = _KeyWhere + ", @_IsCommand = 1"; else _KeyWhere = _KeyWhere + ", @_IsCommand = 0";
            if (ckbLayout.Checked == true) _KeyWhere = _KeyWhere + ", @_IsLayout = 1"; else _KeyWhere = _KeyWhere + ", @_IsLayout = 0";
            if (ckbTable.Checked == true) _KeyWhere = _KeyWhere + ", @_IsTable = 1"; else _KeyWhere = _KeyWhere + ", @_IsTable = 0";
            if (ckbData.Checked == true) _KeyWhere = _KeyWhere + ", @_IsData = 1"; else _KeyWhere = _KeyWhere + ", @_IsData = 0";
            if (ckbTrigger.Checked == true) _KeyWhere = _KeyWhere + ", @_IsTrigger = 1"; else _KeyWhere = _KeyWhere + ", @_IsTrigger = 0";
            if (ckbView.Checked == true) _KeyWhere = _KeyWhere + ", @_IsView = 1"; else _KeyWhere = _KeyWhere + ", @_IsView = 0";
            if (ckbProcedure.Checked == true) _KeyWhere = _KeyWhere + ", @_IsProcedure = 1"; else _KeyWhere = _KeyWhere + ", @_IsProcedure = 0";
            if (ckbFunction.Checked == true) _KeyWhere = _KeyWhere + ", @_IsFunction = 1"; else _KeyWhere = _KeyWhere + ", @_IsFunction = 0";
            if (ckbDelete.Checked == true) _KeyWhere = _KeyWhere + ", @_IsDelete = 1"; else _KeyWhere = _KeyWhere + ",@_IsDelete = 0";

            DataTable tb = new DataTable();

            DatLoa.loadDataPROC_DataTable("usp_sys_CreateDataInsert_AllforCommand " + _KeyWhere, ref tb);

            if (tb.Rows.Count > _MaxLoadRowOnGrid)     //Để về 1 luôn lưu ra file //50
            {
                if (MessageBox.Show("Dữ liệu quá dài, lưu ra file?", "Lưu ra file",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    EnableAll(false);
                    ExportFile.ExportDataTable(tb, "Sta");
                    EnableAll(true);
                }
                return;
            }
            BindingSource gdSource = new BindingSource();
            gdSource.DataSource = tb;
            dataGridView1.DataSource = gdSource;

            DesFor.EditCollum(ref dataGridView1, "Stt", false, true, "Stt", 150);
            DesFor.EditCollum(ref dataGridView1, "_Name", true, true, "Name", 150);
            DesFor.EditCollum(ref dataGridView1, "Sta", true, true, "Script", 900);

            //dataGridView1.AutoResizeRows();
            //dataGridView1.Columns["Vietnamese"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //đặt xuống dòng cho cột sta
            dataGridView1.Columns["Sta"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //DesFor.AutoHeightGrid(ref dataGridView1);
            //đặt tự co dòng cho grid view 
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //chặn copy trên form
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

            //DesFor.EditHeightRow(ref dataGridView1, 40);
            DesFor.AllowSortGrid(ref dataGridView1, true);

            //Bỏ mặc định chọn đến ô
            dataGridView1.ClearSelection();
            //kết thúc load data

        }

        private void clearDataGrid()
        {
            BindingSource gdSource = new BindingSource();
            dataGridView1.DataSource = gdSource;
        }

        private void LoadDataStyle()
        {
            ckbCommand.Checked = true;
            ckbLayout.Checked = true;
            ckbTable.Checked = false;
            ckbData.Checked = false;
            ckbTrigger.Checked = false;
            ckbView.Checked = false;
            ckbProcedure.Checked = false;
            ckbFunction.Checked = false;
        }

        private void CheckTable()
        {
            if (ckbTable.Checked == true)
            {
                ckbData.Enabled = true;
                ckbTrigger.Enabled = true;
            }
            else
            {
                ckbData.Checked = false;
                ckbTrigger.Checked = false;
                ckbData.Enabled = false;
                ckbTrigger.Enabled = false;
            }
        }

        private void EnableAll(bool _bl)
        {
            lblBranchName.Enabled = _bl;
            lblCommand.Enabled = _bl;
            cbbCommand.Enabled = _bl;
            btnGenCode.Enabled = _bl;
            ckbCommand.Enabled = _bl;
            ckbLayout.Enabled = _bl;
            ckbTable.Enabled = _bl;
            ckbData.Enabled = _bl;
            ckbTrigger.Enabled = _bl;
            ckbView.Enabled = _bl;
            ckbProcedure.Enabled = _bl;
            ckbFunction.Enabled = _bl;
            lblKeyWhere.Enabled = _bl;
            rtbKeyWhere.Enabled = _bl;
            btnSaveFile.Enabled = _bl;
            lblCreateUsp.Enabled = _bl;

            CheckTable();               //kiểm tra table có check không thì mới cho mở những mục khác

        }

        private string LoadKeyWhere()
        {
            string _Key = "";
            if (cbbCommand.Text != "")
            {
                _Key = "CommandKey IN ('" + cbbCommand.Text + "')";
            }

            return _Key;
        }

        /// <summary>
        /// Do chưa xử lý được sự kiện changed ClipBoard nên tạm thời phải xử lý như này, 
        /// viết hơi dài, sẽ cố gắng khắc phục
        /// 
        /// </summary>
        /// <returns></returns>
        private string CopyDataGridToClipboard()
        {
            //Lấy số cell được chọn
            int selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);

            int[,] SelCel = new int[selectedCellCount, 2];

            //foreach (DataGridViewCell cel in dataGridView1.SelectedCells)//.Cast<DataGridViewCell>().Reverse()
            //gán vào mảng 2 chiều tập hợp cell selection
            for (int i = 0; i < selectedCellCount; i++)
            {
                SelCel[i, 0] = dataGridView1.SelectedCells[i].RowIndex;
                SelCel[i, 1] = dataGridView1.SelectedCells[i].ColumnIndex;
            }

            //sắp xếp lại mảng (theo cả row và column)
            for (int i = 0; i < selectedCellCount; i++)
            {
                for (int j = i + 1; j < selectedCellCount; j++)
                {
                    if (SelCel[i, 0] > SelCel[j, 0])        //soi theo dòng trước, nếu dòng nhỏ hơn thì luôn đứng trước
                    {
                        OrderArr2<int>(ref SelCel, i, j);
                    }
                    else if (SelCel[i, 0] == SelCel[j, 0])  //soi tiếp đến cột trên 1 dòng, nếu cột nhỏ hơn thì đứng trước
                    {
                        if (SelCel[i, 1] > SelCel[j, 1])
                        {
                            OrderArr2<int>(ref SelCel, i, j);
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            //Lấy ra chuỗi
            int _rowTmp = SelCel[0, 0];
            for (int i = 0; i < selectedCellCount; i++)
            {
                if (sb.Length == 0)
                {
                    //nothing
                }
                else if (SelCel[i, 0] == _rowTmp)
                {
                    sb.Append("\t");
                }
                else if (SelCel[i, 0] != _rowTmp)
                {
                    sb.Append(Environment.NewLine);
                }

                _rowTmp = SelCel[i, 0];

                //Lấy giá trị của dòng, cột tương ứng 
                sb.Append(dataGridView1.Rows[SelCel[i, 0]].Cells[SelCel[i, 1]].Value);
            }

            return sb.ToString();
        }

        /// <summary>
        /// đổi chỗ mảng 2 chiều theo dòng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void OrderArr2<T>(ref T[,] arr, int i, int j)
        {
            T tmp;
            //Đổi chỗ cột 1
            tmp = arr[i, 0];
            arr[i, 0] = arr[j, 0];
            arr[j, 0] = tmp;

            //Đổi chỗ cột 2
            tmp = arr[i, 1];
            arr[i, 1] = arr[j, 1];
            arr[j, 1] = tmp;

        }

        #endregion


    }
}
