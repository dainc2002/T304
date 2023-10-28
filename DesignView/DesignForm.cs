using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace tkBravoTool.DesignView
{
    class DesignForm
    {
        public static Form vForm = null;

        //Thiết kế cơ bản cho cột trong bảng
        public void EditCollum
            (ref DataGridView dt, string column, bool Vi, bool En, string NameCollum, int Width)
        {
            try
            {
                dt.Columns[column].Visible = Vi;
                dt.Columns[column].ReadOnly = En;
                dt.Columns[column].HeaderText = NameCollum;
                dt.Columns[column].Width = Width;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi thiết kế bảng " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Đẩy tất cả dòng trong grid về 1 chiều cao mặc định
        public void EditHeightRow
            (ref DataGridView dt, int Hei)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].Height = Hei;
                }
            }
        }

        public void AutoHeightGrid(ref DataGridView grid)
        {
            var proposedSize = grid.GetPreferredSize(new Size(0, 0));
            grid.Height = proposedSize.Height;
        }

        //Khóa sắp xếp cột trong grid
        public void AllowSortGrid
            (ref DataGridView dt, bool sor)
        {
            if (dt.Columns.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (sor)
                        dt.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        public Button BtnChange;
        public void ColorChange(ref Button _vbutton)
        {
            if (_vbutton.BackColor == Color.Gainsboro)
                _vbutton.BackColor = Color.LightCoral;
            else _vbutton.BackColor = Color.Gainsboro;
            BtnChange = _vbutton;
        }

        //Căn giữa cho form
        public void AlignCenterToScreen()
        {
            Screen screen = Screen.FromControl(vForm);

            Rectangle workingArea = screen.WorkingArea;
            vForm.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - vForm.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - vForm.Height) / 2)
            };
        }

        public void FixFormSize(int Width, int Height)
        {
            vForm.Height = Height;
            vForm.Width = Width;
        }
    }
}
