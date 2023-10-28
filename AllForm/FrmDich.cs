using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tkBravoTool.DAL;
using tkBravoTool.SO;
using System.IO;
using System.Threading;
using tkBravoTool.DPL;
using tkBravoTool.DesignView;

namespace tkBravoTool.AllForm
{
    public partial class FrmDich : Form
    {
        public FrmDich()
        {
            InitializeComponent();
        }
        DataLoading DatLoa = new DataLoading();
        DesignForm DesFor = new DesignForm();
        DataProcess DatPro = new DataProcess();

        int _Id;        //Id Layout đang xử lý
        string _Command; //Command đang xử lý

        #region action trên from
        //Load form
        private void FrmDich_Load(object sender, EventArgs e)
        {
            DesignForm.vForm = this;
            loadDataCommand();
            loadDataLayout();
            LoadDataTransStyle(ref cbbTransStyle);
            lblBranchName.Text = MyInfo.BranchName;
            EnableAll(true);
            DesFor.AlignCenterToScreen();
        }
        //xử lý sau khi chọn Command
        private void cbbCommand_Leave(object sender, EventArgs e)
        {
            if (cbbCommand.Text != "")
            {
                int rw = DatLoa.checkData("SELECT CommandKey FROM B00Command WHERE IsActive = 1 AND IsGroup = 0 " +
                                            " AND CommandKey = '" + cbbCommand.Text + "'");
                if (rw == 0)
                {
                    cbbCommand.Text = "";
                }
                else
                {
                    cbbCommand.Text = DatLoa.NameReturn("CommandKey", "B00Command", "CommandKey = '" + cbbCommand.Text + "'");

                    if (_Command != cbbCommand.Text)
                    {
                        clearDataGrid();
                    }


                    _Command = cbbCommand.Text;
                }
                loadDataLayout();
            }
        }
        //xử lý sau khi chọn Layout
        private void cbbLayout_TextChanged(object sender, EventArgs e)
        {
            EnableAll(false);
            loadDataGrid(false);
            EnableAll(true);
        }

        private void cbbLayout_Leave(object sender, EventArgs e)
        {
            EnableAll(false);
            loadDataGrid(false);
            EnableAll(true);
        }
        //Load lại
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            EnableAll(false);
            loadDataGrid(true);
            EnableAll(true);

            dataGridView1_SelectionChanged(sender, e);
        }
        //dán hoặc xóa data trên grid
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (dataGridView1.DataSource != null)
                {
                    BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                    DataTable tb = (DataTable)gdSource.DataSource;
                    if (tb != null)
                        PasteClipGrid();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                int _i, _j;
                foreach (DataGridViewCell cel in dataGridView1.SelectedCells)
                {
                    _i = cel.RowIndex;
                    _j = cel.ColumnIndex;

                    if (!dataGridView1.Rows[_i].Cells[_j].ReadOnly)
                        dataGridView1.Rows[_i].Cells[_j].Value = "";
                }
            }
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            //chuyển DataGridView về dạng XML
            BindingSource source = (BindingSource)this.dataGridView1.DataSource;
            string _XmlData = GetXML.DataTableToXML((DataTable)source.DataSource);
            //xử lý ký tự ' trên chuỗi
            _XmlData = _XmlData.Replace("'", "''");
            EnableAll(false);
            EditData(_XmlData);
            EnableAll(true);

        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckbEditEnglish.Checked == true) FixVariable(ref dataGridView1, "English", "Vietnamese");
                if (ckbEditJapanese.Checked == true) FixVariable(ref dataGridView1, "Japanese", "Vietnamese");
                if (ckbEditChinese.Checked == true) FixVariable(ref dataGridView1, "Chinese", "Vietnamese");
                if (ckbEditKorean.Checked == true) FixVariable(ref dataGridView1, "Korean", "Vietnamese");

                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1_SelectionChanged(sender, e);
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi " + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void rtbDataGridCell_Leave(object sender, EventArgs e)
        {
            if (rtbDataGridCell.Text == "")
                return;

            string DataStyle;

            DataStyle = dataGridView1.CurrentRow.Cells["Style"].Value.ToString();

            bool Read = dataGridView1.CurrentCell.ReadOnly;

            if (!Read)
            {
                if (DataStyle.Contains("Format:\"rtf\";"))
                    dataGridView1.CurrentCell.Value = rtbDataGridCell.Rtf;
                else
                    dataGridView1.CurrentCell.Value = rtbDataGridCell.Text;
            }

        }

        private void FrmDich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) btnSave.PerformClick();
            else if (e.Control && e.KeyCode == Keys.M) btnFix.PerformClick();
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

        private void rtbDataGridCell_KeyDown(object sender, KeyEventArgs e)
        {
            FormatFontStyle.RichTextBoxFormat(ref rtbDataGridCell, e);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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

            bool Read = dataGridView1.CurrentCell.ReadOnly;

            rtbDataGridCell.ReadOnly = Read;

            if (dataGridView1.CurrentCell.Value.ToString().StartsWith("{\\rtf"))
            {
                rtbDataGridCell.Rtf = dataGridView1.CurrentCell.Value.ToString();
            }
            else
            {
                System.Drawing.Font newFont = new Font("Times New Roman", 10f, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178, false);

                rtbDataGridCell.Text = dataGridView1.CurrentCell.Value.ToString();

                rtbDataGridCell.Select(0, rtbDataGridCell.Text.Length);

                rtbDataGridCell.SelectionFont = newFont;
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {
                EnableAll(false);
                if (ckbTransEnglish.Checked == true) TranslateGrid(ref dataGridView1, "English");
                if (ckbTransJapanese.Checked == true) TranslateGrid(ref dataGridView1, "Japanese");
                if (ckbTransChinese.Checked == true) TranslateGrid(ref dataGridView1, "Chinese");
                if (ckbTransKorean.Checked == true) TranslateGrid(ref dataGridView1, "Korean");

                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dataGridView1_SelectionChanged(sender, e);
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi " + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableAll(true);
            }
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

        private void ckbTransChinese_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTransChinese.Checked)
                ckbEditChinese.Checked = true;
            else
                ckbEditChinese.Checked = false;
        }

        private void ckbTransEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTransEnglish.Checked)
                ckbEditEnglish.Checked = true;
            else
                ckbEditEnglish.Checked = false;
        }

        private void ckbTransJapanese_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTransJapanese.Checked)
                ckbEditJapanese.Checked = true;
            else
                ckbEditJapanese.Checked = false;
        }

        private void ckbTransKorean_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTransKorean.Checked)
                ckbEditKorean.Checked = true;
            else
                ckbEditKorean.Checked = false;
        }
        #endregion

        #region hàm xử lý dữ liệu
        private void loadDataCommand()
        {
            string _Filter = "WHERE IsActive = 1 AND IsGroup = 0";
            if (cbbCommand.Text != "")
                _Filter = _Filter + " AND CommandKey LIKE '" + cbbCommand.Text + "%'";
            //else
            //    return;

            DatLoa.loadCBB("SELECT CommandKey FROM B00Command " + _Filter, ref cbbCommand);
            
        }

        private void loadDataLayout()
        {
            string _Filter = "WHERE IsActive = 1 ";
            if (cbbCommand.Text != "")
            {
                clearDataGrid();

                _Filter = _Filter + " AND FormName = '" + cbbCommand.Text + "'";
            }
            else
            {
                clearDataGrid();

                cbbLayout.Items.Clear();
                return;
            }    
            
            DatLoa.loadCBB("SELECT LayoutName FROM B00Layout " + _Filter, ref cbbLayout);

        }

        private void loadDataGrid(bool Reload)
        {
            string _tmp = DatLoa.NameReturn("Id", "B00Layout", "FormName = '" + cbbCommand.Text +
                            "' AND LayoutName = '" + cbbLayout.Text + "'");

            if (_tmp != "")
            {                   // với Reload thì luôn load lại 
                if (_Id != Convert.ToInt32(_tmp) || Reload)
                    _Id = Convert.ToInt32(_tmp);
                else
                    return;
            }
            else
            {
                clearDataGrid();

                return;
            }

            int rw = DatLoa.checkData("SELECT Id FROM B00LayoutData WHERE Id = " + _Id);

            if (rw == 0)
            {
                clearDataGrid();
            }
            else
            {
                //bắt đầu vào load data
                DatLoa.loadDataPROC("usp_sys_ReadTextFromXML @_Id = " + _Id, ref dataGridView1);

                DesFor.EditCollum(ref dataGridView1, "LocalName", false, true, "LocalName", 50);
                DesFor.EditCollum(ref dataGridView1, "PathXML", true, true, "Path", 50);
                DesFor.EditCollum(ref dataGridView1, "Vietnamese", true, false, "Vietnamese", 150);
                DesFor.EditCollum(ref dataGridView1, "English", true, false, "English", 150);
                DesFor.EditCollum(ref dataGridView1, "Japanese", true, false, "Japanese", 150);
                DesFor.EditCollum(ref dataGridView1, "Chinese", true, false, "Chinese", 150);
                DesFor.EditCollum(ref dataGridView1, "Korean", true, false, "Korean", 150);
                DesFor.EditCollum(ref dataGridView1, "Style", true, true, "Style", 150);

                //dataGridView1.AutoResizeRows();
                //dataGridView1.Columns["Vietnamese"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.Columns["English"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                DesFor.EditHeightRow(ref dataGridView1, 40);
                DesFor.AllowSortGrid(ref dataGridView1, true);
                //kết thúc load data
            }
        }

        private void PasteClipGrid()
        {
            int CurRow = Convert.ToInt32(dataGridView1.CurrentRow.Index.ToString());
            int CurCol = dataGridView1.CurrentCell.ColumnIndex;

            ClipboardProcess.PasteClipboardGrid(ref dataGridView1, CurRow, CurCol, ckbFixNow.Checked);
        }
        
        private void EditData(String _Xml)
        {
            string sql = "EXECUTE usp_sys_WriteTextFromXML @_Id = " + _Id + ", @_XmlData = N'" + _Xml + "'";
            int _ok = DatLoa.ExecuteCommand(sql);
            if (_ok == -1)
            {
                MessageBox.Show("Lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Chạy từ dòng đầu tiên đến dòng cuối cùng của cột được sửa
        /// </summary>
        /// <param name="dt">DataGrid</param>
        /// <param name="col">Cột được sửa</param>
        /// <param name="col0">Cột gốc</param>
        private void FixVariable(ref DataGridView dt, string col, string col0)
        {
            int _i = 0;
            //lấy lần lượt từ dòng đầu tiên đến dòng cuối dùng của cột đưa vào
            while (_i < dt.Rows.Count)
            {
                String Data, Data0, DataStyle;

                //lấy Data cần sửa
                Data = dt.Rows[_i].Cells[col].Value.ToString();
                Data0 = dt.Rows[_i].Cells[col0].Value.ToString();
                //Lấy style của dòng
                DataStyle = dt.Rows[_i].Cells["Style"].Value.ToString();
                //Lấy dữ liệu rtf trong Style   //Lấy thêm dữ liệu Img cũng copy giá trị sang
                if (DataStyle.Contains("Format:\"rtf\";") | DataStyle.Contains("Format:\"img\";"))
                {
                    //nếu là rtf thì copy nguyên giá trị của cột Vietnamese sang //hoặc img
                    dt.Rows[_i].Cells[col].Value = dt.Rows[_i].Cells["Vietnamese"].Value.ToString();
                }
                else
                {
                    Data = DatPro.FixVariableDetail(Data, Data0);

                    dt.Rows[_i].Cells[col].Value = Data;
                }

                _i = _i + 1;
            }
        }
        
        //Reset, xóa dữ liệu 
        private void clearDataGrid()
        {
            //bắt đầu vào clear data
            BindingSource gdSource = new BindingSource();
            dataGridView1.DataSource = gdSource;
            //kết thúc clear data
            rtbDataGridCell.Text = "";
        }
        //Gọi dịch layout
        private void TranslateGrid(ref DataGridView dt, string col)
        {
            int _i = 0, _i_ed = dt.Rows.Count;

            if (cbbTransStyle.Text == "Dịch các dòng đang chọn")
            {
                string _CheckRow = ";";
                foreach (DataGridViewCell cel in dt.SelectedCells)
                {
                    _i = cel.RowIndex;

                    if (!_CheckRow.Contains(";" + Convert.ToString(_i)))            //kiểm tra dòng i đã chạy qua chưa
                    {
                        _CheckRow = _CheckRow + Convert.ToString(_i) + ";";     //nếu chưa thì cộng vào chuỗi kiểm tra
                    }               
                    else continue;                                              //nếu rồi thì bỏ qua vòng này, tiếp tục lặp

                    TranslateGridDetail(ref dt, col, _i);                       //dịch
                }
                //Thoát thủ tục
                return;
            }    

            //lấy lần lượt từ dòng đầu tiên đến dòng cuối dùng của cột đưa vào
            while (_i < _i_ed)
            {
                
                //kiểm tra giá trị dịch
                if ((dt.Rows[_i].Cells[col].Value.ToString() != "") 
                        & cbbTransStyle.Text == "Dịch các dòng trắng")
                {
                    _i = _i + 1;
                    continue;
                }

                TranslateGridDetail(ref dt, col, _i);

                _i = _i + 1;
            }
        }

        //đoạn này viết hơi tù @@! Tạm thế đã
        private void TranslateGridDetail(ref DataGridView dt, string col, int _i)
        {
            string _From, _Target;

            if (col == "English") _Target = "en";
            else if (col == "Japanese") _Target = "ja";
            else if (col == "Chinese") _Target = "zh-CN";
            else if (col == "Korean") _Target = "ko";
            else return;

            _From = "vi"; //fix mặc định dịch từ tiếng việt sang các tiếng khác

            String Data, DataTrans, DataStyle;

            //Lấy giá trị Vietnamese của dòng tương ứng
            Data = dt.Rows[_i].Cells["Vietnamese"].Value.ToString();

            if (Data == "")
            {
                return;
            }

            //Lấy style của dòng
            DataStyle = dt.Rows[_i].Cells["Style"].Value.ToString();

            //Lấy dữ liệu rtf trong Style   //Lấy thêm dữ liệu Img cũng copy giá trị sang
            if (DataStyle.Contains("Format:\"rtf\";") | DataStyle.Contains("Format:\"img\";"))
            {
                //nếu là rtf thì copy nguyên giá trị sang   //hoặc img
                dt.Rows[_i].Cells[col].Value = Data;
                return;

            }
            else
            {
                if (Data.Length > 261)
                {
                    MessageBox.Show("Có lỗi tại dòng thứ " + Convert.ToString(_i + 1) +"\r\n" 
                        + "Dữ liệu dài vượt quá cho phép dịch (261 ký tự) có thể gây lỗi", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DataTrans = DatPro.TranslateStringWithVariable(Data, _From, _Target); //22-06-03: Dũng đổi hàm đoạn này từ hàm cũ TranslateValue

                //đưa vào sửa giá trị
                if (ckbFixNow.Checked == true)
                {
                    if ((col == "English" & ckbEditEnglish.Checked == true) |
                          (col == "Japanese" & ckbEditJapanese.Checked == true) |
                          (col == "Chinese" & ckbEditChinese.Checked == true) |
                          (col == "Korean" & ckbEditKorean.Checked == true))
                    DataTrans = DatPro.FixVariableDetail(DataTrans, Data);
                }    

                dt.Rows[_i].Cells[col].Value = DataTrans;
            }
        }

        //Load data kiểu dịch
        private void LoadDataTransStyle(ref ComboBox trans)
        {
            trans.Items.Add("Dịch tất cả");
            trans.Items.Add("Dịch các dòng trắng");
            trans.Items.Add("Dịch các dòng đang chọn");

            trans.Text = "Dịch các dòng trắng";
        }

        private void EnableAll(bool _bl)
        {
            lblBranchName.Enabled = _bl;
            lblCommand.Enabled = _bl;
            cbbCommand.Enabled = _bl;
            lblLayout.Enabled = _bl;
            cbbLayout.Enabled = _bl;
            btnReLoad.Enabled = _bl;
            btnSave.Enabled = _bl;
            btnTranslate.Enabled = _bl;
            ckbTransEnglish.Enabled = _bl;
            ckbTransChinese.Enabled = _bl;
            ckbTransJapanese.Enabled = _bl;
            ckbTransKorean.Enabled = _bl;
            lblStyle.Enabled = _bl;
            cbbTransStyle.Enabled = _bl;
            btnFix.Enabled = _bl;
            ckbEditEnglish.Enabled = _bl;
            ckbEditChinese.Enabled = _bl;
            ckbEditJapanese.Enabled = _bl;
            ckbEditKorean.Enabled = _bl;
            rtbDataGridCell.Enabled = _bl;
            ckbFixNow.Enabled = _bl;
            lblCreateUsp.Enabled = _bl;
        }

        #endregion
    }
}
