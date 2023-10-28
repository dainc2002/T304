using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;
using System.Data;
using tkBravoTool.SO;
using System.Threading;

namespace tkBravoTool.DAL
{
    class DataAccess
    {
        #region "Private Members"

        private string _connectionString = MyApp.MSSQLConnectionString;
        /// <summary>
        /// Provider may be: System.Data.SqlClient; Oracle.DataAccess.Client,...
        /// </summary>
        private string _providerName = MyApp.MSSQLProviderName;

        #endregion

        #region "Properties"

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        public string ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DbProviderFactory oFactory { get; set; }

        #endregion

        #region "Constructors"

        public DataAccess()
        {
            try
            {
                this.ProviderName = MyApp.MSSQLProviderName;
                this.ConnectionString = MyApp.MSSQLConnectionString;
                this.oFactory = DbProviderFactories.GetFactory(this.ProviderName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        ~DataAccess()
        {
            oFactory = null;
        }
        #endregion

        #region Execute methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StroredProcedureName"></param>
        /// <param name="ParaMeterCollection"></param>
        /// <returns></returns>
        /// 


        public async Task<DbDataReader> ExecuteAsDataReaderSql (string sSql, List<KeyValuePair<string, object>> ParaMeterCollection, CancellationToken token)
        {
            try
            {
                DbConnection cnn0 = oFactory.CreateConnection();        //Khởi tạo 1 connection
                cnn0.ConnectionString = this.ConnectionString;          //Gán connection string
                DbCommand cmd = oFactory.CreateCommand();               //Tạo 1 command 
                cmd.CommandTimeout = MyApp.CmdTimeout;                  //Gán thời gian chờ cho command
                DbDataReader reader;                                    //khởi tạo DataReader, dùng để đọc dữ liệu, tuần tự, không ghi vào trong sql
                cmd.Connection = cnn0;                                  //Gán connection cho command
                cmd.CommandText = sSql;                                 //Gán câu lệnh cho command
                cmd.CommandType = CommandType.Text;                     //Khai báo kiểu câu lệnh trong command là gì
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)     //Đối với mỗi list truyền vào, đọc lần lượt từ đầu xuống cuối
                {
                    DbParameter sqlParaMeter = oFactory.CreateParameter();      //tạo 1 ParaMeter (dạng như trong config với kiểu tham số này, ứng với giá trị nào)
                    sqlParaMeter.IsNullable = true;                             //Cho phép ParaMeter nhận giá trị null
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;    //Gán tham số
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;          //Gán giá trị 
                    cmd.Parameters.Add(sqlParaMeter);                           //Gán thêm vào command (? ? ? Không hiểu sao lại viết kiểu này ? ? / )
                }
                //End of for loop
                await cnn0.OpenAsync(token);        //Open kết nối
                reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection, token);    //Đọc dữ liệu từ Command , đồng thời đóng connection 
                //reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);    //Đọc dữ liệu từ Command  --> Câu lệnh đơn giản không cần await
                cmd.Parameters.Clear();                                         //Clear command                            
                return reader;                                                  //Trả về 1 DataReader

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*public DbDataReader ExecuteAsDataReaderSql(string sSql, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            try
            {
                DbConnection cnn = oFactory.CreateConnection();

                cnn.ConnectionString = this.ConnectionString;
                DbCommand cmd = oFactory.CreateCommand();
                cmd.CommandTimeout = MyApp.CmdTimeout;
                DbDataReader reader;
                cmd.Connection = cnn;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    DbParameter sqlParaMeter = oFactory.CreateParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    cmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                cnn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;

            }
            catch (Exception e)
            {
                throw e;
            }
        }*/


        /// <summary>
        /// Load bảng vào data set với câu lệnh tương ứng
        /// </summary>
        /// <param name="StroredProcedureName"></param>
        /// <returns></returns>
        public DataSet ExecuteAsDataSetSql(string sSql)
        {
            try
            {
                DbConnection cnn = oFactory.CreateConnection();
                cnn.ConnectionString = this.ConnectionString;
                DbCommand cmd = oFactory.CreateCommand();
                DbDataAdapter da = oFactory.CreateDataAdapter();
                DataSet ds = new DataSet();
                cmd.Connection = cnn;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = MyApp.CmdTimeout;
                da.SelectCommand = cmd;
                cnn.Open();
                da.Fill(ds);

                cnn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region "Load data từ Excel"
        public int ImportExcel(int dtnumber, string table, ref DataGridView dt)
        {
            using (DbConnection cnn = oFactory.CreateConnection())
            {
                int Iret = 0;
                cnn.ConnectionString = this.ConnectionString;
                DbTransaction transaction;
                try
                {
                    cnn.Open();
                    transaction = cnn.BeginTransaction();
                    for (int i = dtnumber; i < dt.Rows.Count; i++)
                    {
                        string columns = "";
                        string value = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].HeaderText.ToString() != "")
                            {
                                if (j == 0)
                                {
                                    columns = dt.Columns[j].HeaderText.ToString();
                                    value = "N'" + dt.Rows[i].Cells[j].Value.ToString() + "'";
                                }
                                else
                                {
                                    columns = columns + "," + dt.Columns[j].HeaderText.ToString();
                                    value = value + ",N'" + dt.Rows[i].Cells[j].Value.ToString() + "'";
                                }
                            }
                        }
                        string sSql = "insert into " + table + " (" + columns + ") values (" + value + ")";
                        DbCommand cmd = oFactory.CreateCommand();
                        cmd.Connection = cnn;
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        Iret = Iret + cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    RowEr = Iret + 1;
                    throw e;
                    transaction.Rollback();
                }
                finally
                {
                    cnn.Close();
                }
                return Iret;
            }
        }
        public int RowEr;
        #endregion

        public int EditDataGridView(string clupdate, string table, ref DataGridView dt)
        {
            using (DbConnection cnn = oFactory.CreateConnection())
            {
                int Iret = 0;
                cnn.ConnectionString = this.ConnectionString;
                DbTransaction transaction;
                try
                {
                    cnn.Open();
                    transaction = cnn.BeginTransaction();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string columns = "";
                        string value = "";
                        string sSql = "update " + table + " set ";
                        columns = dt.Columns[clupdate].Name.ToString();
                        value = "N'" + dt.Rows[i].Cells[clupdate].Value.ToString() + "'";
                        sSql = sSql + columns + " = " + value;//Lấy giá trị
                        string columnsdk = "";
                        string valuedk = "";
                        columnsdk = dt.Columns[0].Name.ToString();
                        valuedk = "'" + dt.Rows[i].Cells[0].Value.ToString() + "'";
                        sSql = sSql + " where " + columnsdk + " = " + valuedk;//đặt điều kiện
                        DbCommand cmd = oFactory.CreateCommand();
                        cmd.Connection = cnn;
                        cmd.CommandText = sSql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        Iret = Iret + cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    RowEr = Iret + 1;
                    throw e;
                    transaction.Rollback();
                }
                finally
                {
                    cnn.Close();
                }
                return Iret;
            }
        }


        /// <summary>
        /// Thực thi câu lệnh sql
        /// </summary>
        /// <param name="sSql"></param>
        public int ExecuteData(string sSql)
        {
            using (DbConnection cnn = oFactory.CreateConnection())  //tạo ngay lập tức connection nên không đưa vào task để kiểm tra được ?
            {
                int iret = 0;
                cnn.ConnectionString = this.ConnectionString;
                try
                {
                    DbCommand cmd = oFactory.CreateCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    iret = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    iret = -2;
                    throw e;
                }
                finally
                {
                    cnn.Close();
                }
                return iret;
            }
        }


        /// <summary>
        /// Thực thi câu lệnh sql - Trả kết quả là số dòng bị thay đổi
        /// </summary>
        /// <param name="sSql"></param>
        public int vExecuteData(string sSql)
        {
            int iret = 0;
            try
            {
                DbConnection cnn = oFactory.CreateConnection();
                cnn.ConnectionString = this.ConnectionString;
                DbCommand cmd = oFactory.CreateCommand();
                DbDataAdapter da = oFactory.CreateDataAdapter();
                //DataSet ds = new DataSet();
                cmd.Connection = cnn;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = MyApp.CmdTimeout;
                da.SelectCommand = cmd;
                cnn.Open();
                iret = cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception e)
            {
                iret = -1;
                throw e;
            }
            return iret;
        }

        public async Task<int> vExecuteDataAsync(string sSql, CancellationToken token)
        {
            int iret = 0;
            try
            {
                DbConnection cnn = oFactory.CreateConnection();
                cnn.ConnectionString = this.ConnectionString;
                DbCommand cmd = oFactory.CreateCommand();
                DbDataAdapter da = oFactory.CreateDataAdapter();
                //DataSet ds = new DataSet();
                cmd.Connection = cnn;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = MyApp.CmdTimeout;
                da.SelectCommand = cmd;
                await cnn.OpenAsync(token);                         //Đặt await ở đây phòng trường hợp đang sử dụng thì bị mất mạng 
                iret = await cmd.ExecuteNonQueryAsync(token);       //Chờ chạy câu lệnh
                cnn.Close();
            }
            catch (Exception e)
            {
                iret = -2;
                if (!token.IsCancellationRequested)
                    throw e;
            }
            return iret;
        }
        #endregion



    }
}
