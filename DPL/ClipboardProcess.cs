using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tkBravoTool.DPL
{
    class ClipboardProcess
    {
        public static void PasteClipboardGrid(ref DataGridView dt, int CurRow, int CurCol, bool _Fix)
        {
            if (Clipboard.GetText() == string.Empty)
                return;

            DataProcess DatPro = new DataProcess();

            string[] DataClipboard = Clipboard.GetText().Split(new char[] { '\r' });

            int MaxRow = dt.Rows.Count;
            int _i = 0;
            int _j = DataClipboard.Length;

            string Data, DataStyle;

            //chạy dần từ trên xuống dưới cột
            while (_i < _j)
            {
                //lấy data sẽ được paste
                Data = DataClipboard[_i];
                //Lấy style tại dòng đó
                DataStyle = dt.Rows[CurRow].Cells["Style"].Value.ToString();

                //cắt dấu Enter ở đầu dòng
                if (Data.StartsWith("\n")) 
                    Data = Data.Substring(1);

                if (_Fix & !DataStyle.Contains("Format:\"rtf\";"))  //bỏ qua fix nếu là rtf
                    Data = DatPro.FixVariableDetail(Data);

                if (CurRow < MaxRow)
                    dt.Rows[CurRow].Cells[CurCol].Value = Data;
                else
                    break;

                CurRow = CurRow + 1;
                _i = _i + 1;
            }
        }

        
    }
}
