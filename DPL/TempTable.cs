using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkBravoTool.DPL
{
    class TempTable     //class xử lý các bảng trên datatable
    {
        public void addColumnTable(ref DataTable tb, string ColName, string Type, bool Uni)
        {
            DataColumn cl = new DataColumn();
            cl.DataType = System.Type.GetType(Type);
            cl.ColumnName = ColName;
            cl.Unique = Uni;
            tb.Columns.Add(cl);
        }

        /// <summary>
        /// Thêm dòng vào bảng
        /// </summary>
        /// <param name="tb">Bảng dữ liệu</param>
        /// <param name="Data">Dòng dữ liệu được thêm vào là một list với số phần tử bằng với số cột</param>
        public void addRowTable(ref DataTable tb, string[] Data)
        {
            DataRow rw = tb.NewRow();

            for (int i = 0; i < Data.Length; i++)
            {
                string _tmp = Data[i];
                rw[i] = _tmp;
            }
            tb.Rows.Add(rw);
        }

        public void addRowTableIndex(ref DataTable tb, string[] Data, int index)
        {
            DataRow rw = tb.NewRow();

            for (int i = 0; i < Data.Length; i++)
            {
                string _tmp = Data[i];
                rw[i] = _tmp;
            }
            tb.Rows.InsertAt(rw, index);
        }
    }
}
