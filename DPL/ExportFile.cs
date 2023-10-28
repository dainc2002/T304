using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace tkBravoTool.DPL
{
    class ExportFile
    {
        public static void ExportDataTable (DataTable tb, string _col)
        {
            if (tb == null)
            {
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Các tệp note|*.txt|Các tệp sql|*.sql|Tất cả các tệp|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(sfd.FileName);
                    try
                    {
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            tw.Write(tb.Rows[i][_col].ToString());

                            tw.WriteLine();
                        }
                        MessageBox.Show("Lưu tập tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu tệp tin\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        tw.Close();
                    }
                }
            }
        }

        public static void SaveFile(String Detail, string Path)
        {
            TextWriter tw = new StreamWriter(Path);
            try
            {
                tw.Write(Detail);
                tw.WriteLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tệp tin\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tw.Close();
            }
                
        }

        public static void ExportDetail(String Detail)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Các tệp note|*.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    TextWriter tw = new StreamWriter(sfd.FileName);
                    try
                    {
                        tw.Write(Detail);
                        tw.WriteLine();

                        MessageBox.Show("Lưu tập tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lưu tệp tin\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        tw.Close();
                    }
                }
            }
        }
    }
}
