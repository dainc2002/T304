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
using tkBravoTool.DesignView;
using tkBravoTool.DPL;
using tkBravoTool.SO;
using tkBravoTool.SystemForm;

namespace tkBravoTool.AllForm
{
    public partial class FrmCreateCommandList : Form
    {
        public FrmCreateCommandList()
        {
            InitializeComponent();
        }

        TempTable TmpTab = new TempTable(); //class xử lý các datatable

        DesignForm DesFor = new DesignForm();

        DataLoading DatLoa = new DataLoading();

        string FormStatus = "";

        private string btnShowSourceChange
        {
            get { return btnShowSource.Text; }
            set { btnShowSource.Text = value; }
        }

        private void FrmCreateCommandList_Load(object sender, EventArgs e)
        {
            //Xác định trạng thái cho form
            FormStatus = "Load";
            SizeForm();

            //Load tên hợp đồng
            lblBranchName.Text = MyInfo.BranchName;

            //Load data từ file
            LoadData();
        }

        #region Các Event trên form 

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) SaveData();
            else if (e.Control && e.KeyCode == Keys.C)
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

                string _ClipboardText = CopyDataGridToClipboard();

                Clipboard.SetText(_ClipboardText);
            }
        }

        private void BtnShowSource_Click(object sender, EventArgs e)
        {
            if (FormStatus == "Load")
            {
                using (FrmPassCode PassCode = new FrmPassCode())
                {
                    if (PassCode.ShowDialog() == DialogResult.OK)
                    {
                        if (PassCode._checkPassCode)
                        {
                            FormStatus = "Show";
                        }
                    }
                }
            }
            else if (FormStatus == "Show")
            {
                FormStatus = "Load";
            }

            SizeForm();
        }

        /// <summary>
        /// Kích chạy 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            string _ExecuteSql = "";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                _ExecuteSql = dataGridView1.Rows[i].Cells["CreateCommand"].Value.ToString();

                if (!string.IsNullOrWhiteSpace(_ExecuteSql))
                {
                    int _ok = EditData(_ExecuteSql);
                    if (_ok == -2)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// kích xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string _ExecuteSql = "";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                _ExecuteSql = dataGridView1.Rows[i].Cells["DeleteCommand"].Value.ToString();

                if (!string.IsNullOrWhiteSpace(_ExecuteSql))
                {
                    int _ok = EditData(_ExecuteSql);
                    if (_ok == -2)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Kích đầu cột bôi đen toàn bộ cột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //bỏ tất cả selection trước
            dataGridView1.ClearSelection();

            int Col = dataGridView1.Columns[e.ColumnIndex].Index;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[Col].Selected = true;
            }
        }
        #endregion

        #region Xử lý data
        private void LoadData()
        {
            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\CommandList.txt";

            try
            {
                //Đọc ra lấy text thuần mã hóa
                StreamReader rd = new StreamReader(PathFile);
                string _sql0 = rd.ReadToEnd();
                rd.Close();

                //giải mã
                _sql0 = Encode.Decrypt(_sql0);

                DataSet ds = new DataSet();

                //chuyển sang dạng bảng
                using (TextReader _text = new StringReader(_sql0))
                {
                    ds.ReadXml(_text);
                }

                BindingSource gdSource = new BindingSource();

                try
                {       //Đọc bảng từ file 
                    gdSource.DataSource = ds.Tables[0];
                }
                catch   //Nếu không có file/không đọc được bảng thì tạo bảng tạm trắng
                {
                    gdSource.DataSource = TableTmp();
                    //_selectCell = false;
                }

                dataGridView1.DataSource = gdSource;

                DesFor.EditCollum(ref dataGridView1, "Description", true, false, "Ghi chú", 100);
                DesFor.EditCollum(ref dataGridView1, "CreateCommand", true, false, "Code tạo command", 300);
                DesFor.EditCollum(ref dataGridView1, "DeleteCommand", true, false, "Code xóa command", 250);

                //đặt xuống dòng cho cột
                dataGridView1.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns["CreateCommand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns["DeleteCommand"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                //đặt tự co dòng cho grid view
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //Chặn sắp xếp
                DesFor.AllowSortGrid(ref dataGridView1, true);

                //chặn copy trên form
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //    _selectCell = true;
            //}
        }

        /// <summary>
        /// Chỉnh kích thước của form
        /// </summary>
        private void SizeForm()
        {
            DesignForm.vForm = this;

            if (FormStatus == "Load")
            {
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = false;
                DesFor.FixFormSize(427, 262);
                btnShowSourceChange = "Xem SourceCode";
            }
            else if (FormStatus == "Show")
            {
                this.AutoSizeMode = AutoSizeMode.GrowOnly;
                this.MaximizeBox = true;
                DesFor.FixFormSize(1179, 491);
                btnShowSourceChange = "Hủy";
            }

            //Căn giữa form
            DesFor.AlignCenterToScreen();
        }

        //Bảng mặc định của chương trình
        private DataTable TableTmp()
        {
            DataTable tb = new DataTable();
            tb.TableName = "TableTmp";

            TmpTab.addColumnTable(ref tb, "Description", "System.String", true);
            TmpTab.addColumnTable(ref tb, "CreateCommand", "System.String", false);
            TmpTab.addColumnTable(ref tb, "DeleteCommand", "System.String", false);

            return tb;
        }

        //Lưu data
        private void SaveData()
        {
            //chuyển DataGridView về dạng XML
            BindingSource source = (BindingSource)this.dataGridView1.DataSource;
            string _XmlData = GetXML.DataTableToXML((DataTable)source.DataSource);

            string PathFile = System.IO.Directory.GetCurrentDirectory() + "\\Programs\\CommandList.txt";

            try
            {
                ExportFile.SaveFile(Encode.Encrypt(_XmlData), PathFile);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
            }
        }

        private int EditData(String _StrExe)
        {
            int _ok = DatLoa.ExecuteCommand(_StrExe);
            return _ok;           //Hàm này trả về số dòng bị thay đổi bởi câu lệnh
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

                string _Description = rowToMove0.Cells["Description"].Value.ToString();
                string _CreateCommand = rowToMove0.Cells["CreateCommand"].Value.ToString();
                string _DeleteCommand = rowToMove0.Cells["DeleteCommand"].Value.ToString();

                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                //dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                //add thêm dòng vào DataGrid
                BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                DataTable tb = (DataTable)gdSource.DataSource;

                TmpTab.addRowTableIndex(ref tb, new string[] { _Description, _CreateCommand, _DeleteCommand }, rowIndexOfItemUnderMouseToDrop);

                gdSource.DataSource = tb;
                dataGridView1.DataSource = gdSource;
            }
        }

        #endregion
    }
}
