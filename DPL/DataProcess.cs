using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkBravoTool.DAL;

namespace tkBravoTool.DPL
{
    class DataProcess
    {
        DataLoading DatLoa = new DataLoading();

        //Xử lý phân tách chuỗi trước khi dịch
        public string TranslateStringWithVariable(string Data, String From, String Target)
        {
            char[] delimiterChars = { ' ', '\r', '\n', '\t' }; //Các ký tự có thể bỏ qua để tách

            string Data0 = Data;

            while (Data0.Contains("\n") || Data0.Contains("\r") || Data0.Contains("\t") || Data0.Contains("  "))
            {
                Data0 = Data0.Replace("\n", " ");
                Data0 = Data0.Replace("\r", " ");
                Data0 = Data0.Replace("\t", " ");
                Data0 = Data0.Replace("  ", " ");
            }
            
            //string[] DataTmp = Data.Split(new char[] { ' ' });
            string[] DataTmp = Data0.Split(delimiterChars);

            int n = DataTmp.Length, //Độ dài chuỗi
                _t0;

            string DataForTrans = "", //Chuỗi sẽ đưa vào dịch
                    DataProcessed = "", //Chuỗi đã kiểm tra qua 
                    DataTranslated = "", //Chuỗi đã đưa vào dịch
                    Result = ""; //Chuỗi kết quả sẽ trả về
            

            for (int i = 0; i < n; i++)
            {
                if (!(DataTmp[i].StartsWith("{") & DataTmp[i].EndsWith("}")))
                {
                    //Cộng ký tự nằm giữa
                    if (!string.IsNullOrEmpty(DataProcessed))
                    {
                        _t0 = DataProcessed.Length;

                        while (_t0 < Data.Length && Array.IndexOf(delimiterChars, Data[_t0]) > -1)
                        {
                            if (!string.IsNullOrEmpty(DataForTrans))
                            {
                                DataForTrans += Data[_t0];
                            }    
                                
                            DataProcessed += Data[_t0];
                            _t0 += 1;
                        }
                    }

                    DataForTrans += DataTmp[i];
                    DataProcessed += DataTmp[i];
                }
                else //Không dịch biến mà cộng thẳng luôn vào kết quả 
                {
                    //Cộng ký tự nằm giữa (cộng cho biến kết quả thôi) (Đoạn trước khi dịch)
                    if (!string.IsNullOrEmpty(Result))
                    {
                        _t0 = DataTranslated.Length;

                        while (_t0 < Data.Length && Array.IndexOf(delimiterChars, Data[_t0]) > -1)
                        {
                            Result += Data[_t0];
                            DataTranslated += Data[_t0];
                            _t0 += 1;
                        }
                    }

                    //Nếu có dữ liệu để dịch thì dịch và cộng vào chuỗi kết quả
                    if (!string.IsNullOrEmpty(DataForTrans))
                    {
                        Result += TranslateValue(DataForTrans, From, Target); //Dịch đoạn trước
                        DataTranslated += DataForTrans;

                        //Cộng chuỗi vào đoạn sau khi dịch
                        _t0 = DataProcessed.Length;

                        while (_t0 < Data.Length && Array.IndexOf(delimiterChars, Data[_t0]) > -1)
                        {
                            Result += Data[_t0];
                            DataProcessed += Data[_t0];
                            DataTranslated += Data[_t0];
                            _t0 += 1;
                        }
                        
                        DataForTrans = "";
                    }

                    //Cuối cùng cộng thẳng với biến ! Không qua dịch (DataTmp[i] ở bước này là biến)
                    Result += DataTmp[i];
                    DataProcessed += DataTmp[i];
                    DataTranslated += DataTmp[i];
                }
            }
            //Nếu sau khi cộng xong mà DataForTrans vẫn còn giá trị (giá trị cần dịch ở cuối)
            if (!string.IsNullOrEmpty(Result) && !string.IsNullOrEmpty(DataForTrans))
            {
                _t0 = DataTranslated.Length;

                while (_t0 < Data.Length && Array.IndexOf(delimiterChars, Data[_t0]) > -1)
                {
                    Result += Data[_t0];
                    _t0 += 1;
                }

                Result += TranslateValue(DataForTrans, From, Target);
            }

            //Nếu cuối cùng, chuỗi không có cái biến mẹ gì cả !
            if (string.IsNullOrEmpty(Result))
            {
                //Gán thẳng kết quả từ dịch về luôn
                Result = TranslateValue(Data, From, Target) + " ";
            }

            return Result;
        }

        //Dịch 
        private string TranslateValue(string Data, String From, String Target)
        {
            string DataTrans;
            //sửa lỗi dấu nháy
            Data = Data.Replace("'", "''");
            DataTrans = DatLoa.SelectValueReturn("Usp_Sys_Translate_Value " +
                    "@_Data = N'" + Data + "', @_From = N'" + From + "', @_Target = N'" + Target + "'");
            return DataTrans;
        }


        /// <summary>
        /// Sửa lỗi biến - Lấy giá trị chứa trong cặp dấu { } và bỏ hết dấu cách đi
        /// </summary>
        /// <param name="_inputData">Dữ liệu được check để sửa</param>
        /// <param name="DataOriginal">Dữ liệu gốc</param>
        /// <returns></returns>
        public string FixVariableDetail(string _inputData, string DataOriginal)
        {
            int _chk = 0, _chk1 = 0, _chk2 = 0;

            string _tmp, check = _inputData.Substring(_chk);
            //lấy dữ liệu và kiểm tra dữ liệu, từ ký tự đầu tiên đến hết
            while (_inputData.Substring(_chk).IndexOf("{") >= 0 &
                    _inputData.Substring(_chk).IndexOf("}") >= 0)
            {
                //biến check là dữ liệu từ đầu hoặc từ cặp {} đã được xử lý xong đến hết
                check = _inputData.Substring(_chk);
                //tìm vị trí cặp dấu {}
                _chk1 = _inputData.Substring(_chk).IndexOf("{");
                _chk2 = _inputData.Substring(_chk).IndexOf("}");
                //biến _tmp là dữ liệu nằm trong cặp dấu {}
                _tmp = _inputData.Substring(_chk + _chk1, _chk2 - _chk1 + 1);

                //Đưa vào xử lý trường hợp lỗi do Google trả về với ký tự C bị đọc mã ASCII = 63
                int x = 0;
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(_tmp);
                for (int i = 0; i < bytes.Count(); i++)
                {
                    if (bytes[i] == 63) //63 ở đây là dấu ?, khi kiểm tra có vài trường hợp hiển thị là C, nhưng select mã ASCII thì bị thành 3 kỹ tự C??
                    {
                        bytes[i] = 32;  //đưa hết các ký tự đặc biệt về khoảng trắng
                        x = x + 1;
                    }
                }
                //Đổi ngược lại mã ASCII về String
                _tmp = System.Text.Encoding.UTF8.GetString(bytes);

                _tmp = _tmp.Replace(" ", "");

                string test = _tmp.ToLower();
                string test0 = DataOriginal.ToLower();

                if (test0.Contains(test))
                {
                    int _t = DataOriginal.ToLower().IndexOf(_tmp.ToLower());
                    int _n = _tmp.Length;

                    _tmp = DataOriginal.Substring(_t, _n);
                }    

                _inputData = _inputData.Substring(0, _chk + _chk1) + _tmp + _inputData.Substring(_chk + _chk2 + 1);

                _chk = _inputData.Substring(0, _chk + _chk1).Length + _tmp.Length;
            }
            return _inputData;
        }

        /// <summary>
        /// Sửa lỗi biến - Lấy giá trị chứa trong cặp dấu { } và bỏ hết dấu cách đi
        /// </summary>
        /// <param name="_inputData">Dữ liệu được check để sửa</param>
        /// <returns></returns>
        public string FixVariableDetail(string _inputData)
        {
            int _chk = 0, _chk1 = 0, _chk2 = 0;

            string _tmp, check = _inputData.Substring(_chk);
            //lấy dữ liệu và kiểm tra dữ liệu, từ ký tự đầu tiên đến hết
            while (_inputData.Substring(_chk).IndexOf("{") >= 0 &
                    _inputData.Substring(_chk).IndexOf("}") >= 0)
            {
                //biến check là dữ liệu từ đầu hoặc từ cặp {} đã được xử lý xong đến hết
                check = _inputData.Substring(_chk);
                //tìm vị trí cặp dấu {}
                _chk1 = _inputData.Substring(_chk).IndexOf("{");
                _chk2 = _inputData.Substring(_chk).IndexOf("}");
                //biến _tmp là dữ liệu nằm trong cặp dấu {}
                _tmp = _inputData.Substring(_chk + _chk1, _chk2 - _chk1 + 1);

                //Đưa vào xử lý trường hợp lỗi do Google trả về với ký tự C bị đọc mã ASCII = 63
                int x = 0;
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(_tmp);
                for (int i = 0; i < bytes.Count(); i++)
                {
                    if (bytes[i] == 63) //63 ở đây là dấu ?, khi kiểm tra có vài trường hợp hiển thị là C, nhưng select mã ASCII thì bị thành 3 kỹ tự C??
                    {
                        bytes[i] = 32;  //đưa hết các ký tự đặc biệt về khoảng trắng
                        x = x + 1;
                    }
                }
                //Đổi ngược lại mã ASCII về String
                _tmp = System.Text.Encoding.UTF8.GetString(bytes);

                _tmp = _tmp.Replace(" ", "");

                _inputData = _inputData.Substring(0, _chk + _chk1) + _tmp + _inputData.Substring(_chk + _chk2 + 1);

                _chk = _inputData.Substring(0, _chk + _chk1).Length + _tmp.Length;
            }
            return _inputData;
        }

        //Đảo ngược chuỗi
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray(); // chuỗi thành mảng ký tự
            Array.Reverse(arr); // đảo ngược mảng
            return new string(arr); // trả về chuỗi mới sau khi đảo mảng
        }
    }
}
