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
using tkBravoTool.DPL;
using tkBravoTool.DesignView;

namespace tkBravoTool.AllForm
{
    public partial class FrmCreateDirectory : Form
    {
        public FrmCreateDirectory()
        {
            InitializeComponent();
        }

        DesignForm DesFor = new DesignForm();
        DataProcess DarPro = new DataProcess();
        DataLoading DatLoa = new DataLoading();
        TempTable TmpTab = new TempTable();

        #region Action form
        private void FrmCreateList_Load(object sender, EventArgs e)
        {
            DesignForm.vForm = this;
            lblBranchName.Text = MyInfo.BranchName;
            LoadDataGrid(ref dataGridView1); //ref dataGridView1
            DefaultSetting();
            DesFor.AlignCenterToScreen();
        }

        private void txtDirNameVni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (string.IsNullOrWhiteSpace(txtDirNameVni.Text)) return;
                string DirectoryName = DarPro.TranslateStringWithVariable("Danh mục " + txtDirNameVni.Text, "vi", "en");
                //viết hoa chữ cái đầu
                DirectoryName = DirectoryName.Substring(0, 1).ToUpper() + DirectoryName.Substring(1);
                txtDirNameEng.Text = DirectoryName;
            }
        }

        private void txtTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (string.IsNullOrWhiteSpace(txtTableName.Text)) return;
                string TableName = txtTableName.Text;

                txtViewName.Text = "vB20" + TableName;
                txtLookupKey.Text = TableName;
                txtExplorerCommand.Text = TableName;
                txtEditorCommand.Text = "Edit_" + TableName;
            }
        }

        private void ckbCreateLog_CheckedChanged(object sender, EventArgs e)
        {
            LoadEnabled(ckbCreateLog, txtLogCol);
        }

        private void ckbCreateMerge_CheckedChanged(object sender, EventArgs e)
        {
            LoadEnabled(ckbCreateMerge, txtMergeCode);
        }

        private void ckbCreateLookup_CheckedChanged(object sender, EventArgs e)
        {
            LoadEnabled(ckbCreateLookup, txtLookupKey);
            LoadEnabled(ckbCreateLookup, txtValueMember);
            LoadEnabled(ckbCreateLookup, txtHiddenValue);
        }

        private void ckbCreateCommand_CheckedChanged(object sender, EventArgs e)
        {
            LoadEnabled(ckbCreateCommand, txtExplorerCommand);
            LoadEnabled(ckbCreateCommand, txtEditorCommand);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (ckbDuplication.Checked == true)
            {
                if (CheckDuplication() > 0)
                {
                    MessageBox.Show("Đã có thông tin bị trùng\r\n" +
                            "Kiểm tra lại hoặc bỏ tích Kiểm tra trùng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                LoadDataGridKQ();
                this.tabCtrKQ.SelectedTab = tabPage3;   //nhảy về tab 3
                MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception es)
            {
                MessageBox.Show("Có lỗi " + es.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridViewKQ_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //bỏ chọn tất cả
            for (int i = 0; i < dataGridViewKQ.Rows.Count; i++)
            {
                dataGridViewKQ.Rows[i].Selected = false;
            }

            int Col = dataGridViewKQ.Columns[e.ColumnIndex].Index;

            for (int i = 0; i < dataGridViewKQ.Rows.Count; i++)
            {
                dataGridViewKQ.Rows[i].Cells[Col].Selected = true;
            }
        }

        private void FrmCreateDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) btnRun.PerformClick();
        }
        #endregion

        #region Xử lý dữ liệu
        private void LoadDataGrid(ref DataGridView dtv) //ref DataGridView dtv
        {
            DataTable tb = TableTmp();

            BindingSource gdSource = new BindingSource();
            gdSource.DataSource = tb;
            dtv.DataSource = gdSource;

            //thiết kế 
            dtv.RowHeadersWidth = 30;
            //DesFor.EditCollum(ref dataGridView1, "Id", true, true, "Stt", 25);
            DesFor.EditCollum(ref dtv, "AllowNull", true, false, "Null", 50);
            DesFor.EditCollum(ref dtv, "Default", true, false, "Default", 70);
            DesFor.EditCollum(ref dtv, "EditorDisplay", true, false, "Editor Display", 50);
            DesFor.EditCollum(ref dtv, "ExplorerDisplay", true, false, "Explorer Display", 50);

            DesFor.AllowSortGrid(ref dtv, true);
            //dtv.Columns["Id"].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private DataTable TableTmp()
        {
            DataTable tb = new DataTable();

            //Ngày 23/10/2021: Bỏ cột Id
            //TmpTab.addColumnTable(ref tb, "Id", "System.Int32", false);         //Tạm đặt chỗ này không phải key, để sử dụng sau
            TmpTab.addColumnTable(ref tb, "ColName", "System.String", true);
            TmpTab.addColumnTable(ref tb, "DataType", "System.String", false);
            TmpTab.addColumnTable(ref tb, "AllowNull", "System.Boolean", false);
            TmpTab.addColumnTable(ref tb, "Default", "System.String", false);
            TmpTab.addColumnTable(ref tb, "EditorDisplay", "System.Boolean", false);
            TmpTab.addColumnTable(ref tb, "ExplorerDisplay", "System.Boolean", false);
            TmpTab.addColumnTable(ref tb, "NameVni", "System.String", false);
            TmpTab.addColumnTable(ref tb, "NameEng", "System.String", false);


            TmpTab.addRowTable(ref tb, new string[] { "Id", "int", "false", "", "false", "true", "ID", "ID" });
            TmpTab.addRowTable(ref tb, new string[] { "ParentId", "int", "false", "-1" });
            TmpTab.addRowTable(ref tb, new string[] { "IsGroup", "bit", "false", "0" });
            TmpTab.addRowTable(ref tb, new string[] { "BranchCode", "NVARCHAR(3)", "false", "''", "true", "true", "Đơn vị cơ sở", "Branch" });
            TmpTab.addRowTable(ref tb, new string[] { "Code", "CodeType", "false", "", "true", "true", "Mã", "Code" });
            TmpTab.addRowTable(ref tb, new string[] { "Name", "NVARCHAR(128)", "false", "''", "true", "true", "Tên", "Name" });
            TmpTab.addRowTable(ref tb, new string[] { "Name2", "NVARCHAR(128)", "true", "", "true", "false", "Tên thứ 2", "Name 2" });
            TmpTab.addRowTable(ref tb, new string[] { "IsActive", "bit", "false", "1" });
            TmpTab.addRowTable(ref tb, new string[] { "CreatedBy", "int", "false", "-1" });
            TmpTab.addRowTable(ref tb, new string[] { "CreatedAt", "smalldatetime", "false", "getutcdate()" });
            TmpTab.addRowTable(ref tb, new string[] { "ModifiedBy", "int", "false", "-1" });
            TmpTab.addRowTable(ref tb, new string[] { "ModifiedAt", "smalldatetime", "false", "getutcdate()" });
            TmpTab.addRowTable(ref tb, new string[] { "timestamp", "timestamp", "false" });

            return tb;
        }

        private void DefaultSetting()
        {
            ckbCreateLog.Checked = true;
            ckbCreateMerge.Checked = true;
            ckbCreateLookup.Checked = true;
            ckbCreateCommand.Checked = true;
            ckbTransfer.Checked = true;
            ckbDuplication.Checked = true;

            txtLogCol.Text = "Id,Code,Name";
            txtMergeCode.Text = "Id";
            txtValueMember.Text = "Code";
            txtHiddenValue.Text = "Id";

            LoadEnabled(ckbCreateLog, txtLogCol);
            LoadEnabled(ckbCreateMerge, txtMergeCode);
            LoadEnabled(ckbCreateLookup, txtLookupKey);
            LoadEnabled(ckbCreateLookup, txtValueMember);
            LoadEnabled(ckbCreateLookup, txtHiddenValue);
            LoadEnabled(ckbCreateCommand, txtExplorerCommand);
            LoadEnabled(ckbCreateCommand, txtEditorCommand);
        }

        private void LoadEnabled(CheckBox ckb, TextBox tb)
        {
            if (ckb.Checked == true)
            {
                tb.Enabled = true;
            }
            else
            {
                tb.Text = "";
                tb.Enabled = false;
            }
        }

        private int CheckDuplication()
        {
            int i = 0;

            i += SysUsp.CheckToExist("B20" + txtTableName.Text);        //kiểm tra bảng
            i += SysUsp.CheckToExist(txtViewName.Text);         //kiểm tra view
            //kiểm tra log
            if (ckbCreateLog.Checked == true)
                i += DatLoa.checkData("SELECT * FROM dbo.B00FileList WHERE TableName = 'B20" + txtTableName.Text + "' ");
            //kiểm tra lookup
            if (ckbCreateLookup.Checked == true)
                i += DatLoa.checkData("SELECT * FROM dbo.B00Lookup WHERE LookupKey = '" + txtLookupKey.Text + "' ");
            //kiểm tra transfer
            if (ckbTransfer.Checked == true)
                i += DatLoa.checkData("SELECT * FROM dbo.B00TransferList WHERE TableName = 'B20" + txtTableName.Text + "' ");
            //kiểm tra command//layout
            if (ckbCreateCommand.Checked == true)
            {
                i += DatLoa.checkData("SELECT * FROM dbo.B00Command WHERE CommandKey IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ");
                i += DatLoa.checkData("SELECT * FROM dbo.B00Layout WHERE FormName IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ");
            }

            return i;
        }

        private void LoadDataGridKQ()
        {
            DataTable tb = new DataTable();

            TmpTab.addColumnTable(ref tb, "Name", "System.String", false);
            TmpTab.addColumnTable(ref tb, "Script", "System.String", false);

            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Điền tên bảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                LoadTable(ref tb);              //Tạo bảng
            }

            if (string.IsNullOrWhiteSpace(txtViewName.Text))
            {
                MessageBox.Show("Điền tên view", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                LoadView(ref tb);               //Tạo view
            }

            if (ckbCreateLog.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtLogCol.Text))
                {
                    MessageBox.Show("Điền tên cột log", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LoadFileList(ref tb);           //Tạo file 
                }
            }

            if (ckbCreateLookup.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtLookupKey.Text))
                {
                    MessageBox.Show("Điền lookup key", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtValueMember.Text) & string.IsNullOrWhiteSpace(txtHiddenValue.Text))
                {
                    MessageBox.Show("Điền giá trị của lookup", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LoadLookup(ref tb);             //Tạo lookup
                }
            }

            if (ckbCreateMerge.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtLookupKey.Text))
                {
                    MessageBox.Show("Điền cột liên kết merge", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LoadField(ref tb);
                }
            }

            if (ckbTransfer.Checked)
            {
                LoadTransfer(ref tb);
            }

            if (ckbCreateCommand.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtExplorerCommand.Text) | string.IsNullOrWhiteSpace(txtEditorCommand.Text))
                {
                    MessageBox.Show("Điền tên command", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LoadCommand(ref tb);
                }
            }


            BindingSource gdSource = new BindingSource();
            gdSource.DataSource = tb;
            dataGridViewKQ.DataSource = gdSource;

            DesFor.EditCollum(ref dataGridViewKQ, "Name", true, true, "Name", 150);
            DesFor.EditCollum(ref dataGridViewKQ, "Script", true, true, "Script", 900);

            dataGridViewKQ.Columns["Script"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewKQ.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DesFor.AllowSortGrid(ref dataGridViewKQ, true);

        }

        /// <summary>
        /// Tạo bảng danh mục
        /// </summary>
        /// <param name="tb"></param>
        private void LoadTable(ref DataTable tb)
        {
            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & SysUsp.CheckToExist("B20" + txtTableName.Text) > 0)
            {
                string Script;

                Script = "DROP TABLE B20" + txtTableName.Text;

                TmpTab.addRowTable(ref tb, new string[] { "B20" + txtTableName.Text, Script });
                TmpTab.addRowTable(ref tb, new string[] { "B20" + txtTableName.Text, "GO" });
            }

            string Sql = "";

            Sql += "CREATE TABLE B20" + txtTableName.Text + "\r\n"
                + "(\r\n";

            //Tạo bảng từ grid
            DataTable tbTmp = CreateTableFromGrid(dataGridView1, new string[] { "ColName", "DataType", "AllowNull", "Default" });

            for (int i = 0; i < tbTmp.Rows.Count; i++)
            {
                Sql += "[" + tbTmp.Rows[i]["ColName"].ToString() + "] " + tbTmp.Rows[i]["DataType"].ToString() + " ";

                //kiểm tra nếu là Id và không có default thì lấy IDENTITY
                if (tbTmp.Rows[i]["ColName"].ToString() == "Id" & string.IsNullOrWhiteSpace(tbTmp.Rows[i]["Default"].ToString()))
                {
                    Sql += " IDENTITY(1,1) ";
                }

                if (tbTmp.Rows[i]["AllowNull"].ToString() == "True")
                {
                    Sql += " NULL ";
                }
                else
                {
                    Sql += " NOT NULL ";
                }

                //Check default dữ liệu
                if (!string.IsNullOrWhiteSpace(tbTmp.Rows[i]["Default"].ToString()))
                {
                    if (tbTmp.Rows[i]["ColName"].ToString() == "Id")
                    {
                        Sql += " CONSTRAINT [DF_B20" + txtTableName.Text + "_" + tbTmp.Rows[i]["ColName"].ToString() + "] DEFAULT(NEXT VALUE FOR [dbo].[" + tbTmp.Rows[i]["Default"].ToString() + "])";
                    }
                    else
                    {
                        Sql += " CONSTRAINT [DF_B20" + txtTableName.Text + "_" + tbTmp.Rows[i]["ColName"].ToString() + "] DEFAULT(" + tbTmp.Rows[i]["Default"].ToString() + ")";
                    }
                }

                Sql += ",\r\n";
            }

            //Sql = DarPro.ReverseString(DarPro.ReverseString(Sql).Substring(1));

            //Tạo index cho bảng, mặc định lấy cột Id và cột code
            Sql += "CONSTRAINT [PK_B20" + txtTableName.Text + "_Id] PRIMARY KEY NONCLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90) ON [PRIMARY],\r\n"
                + "CONSTRAINT [IX_B20" + txtTableName.Text + "_Code] UNIQUE CLUSTERED ([Code] ASC) WITH (FILLFACTOR = 90) ON [PRIMARY]\r\n"
                + ")\r\n" +
                "ALTER TABLE B20" + txtTableName.Text + " SET (LOCK_ESCALATION = TABLE)";

            TmpTab.addRowTable(ref tb, new string[] { "B20" + txtTableName.Text, Sql });
            TmpTab.addRowTable(ref tb, new string[] { "B20" + txtTableName.Text, "GO" });
        }

        /// <summary>
        /// Tạo view danh mục
        /// </summary>
        /// <param name="tb"></param>
        private void LoadView(ref DataTable tb)
        {
            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & SysUsp.CheckToExist(txtViewName.Text) > 0)
            {
                string Script;

                Script = "DROP VIEW " + txtViewName.Text;

                TmpTab.addRowTable(ref tb, new string[] { txtViewName.Text, Script });
                TmpTab.addRowTable(ref tb, new string[] { txtViewName.Text, "GO" });
            }

            string Sql = "";

            Sql += "CREATE VIEW " + txtViewName.Text + "\r\n"
                + "AS\r\n" +
                "SELECT ";

            DataTable tbTmp = CreateTableFromGrid(dataGridView1, new string[] { "ColName" });

            for (int i = 0; i < tbTmp.Rows.Count; i++)
            {
                Sql += "dm.[" + tbTmp.Rows[i]["ColName"].ToString() + "], ";
            }

            Sql = DarPro.ReverseString(DarPro.ReverseString(Sql).Substring(2));

            Sql += "\r\nFROM B20" + txtTableName.Text + " AS dm";

            TmpTab.addRowTable(ref tb, new string[] { txtViewName.Text, Sql });
            TmpTab.addRowTable(ref tb, new string[] { txtViewName.Text, "GO" });
        }

        /// <summary>
        /// Tạo log danh mục
        /// </summary>
        /// <param name="tb"></param>
        private void LoadFileList(ref DataTable tb)
        {
            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & DatLoa.checkData("SELECT * FROM dbo.B00FileList WHERE TableName = 'B20" + txtTableName.Text + "' ") > 0)
            {
                string Script;

                Script = "DELETE B00FileList WHERE TableName = 'B20" + txtTableName.Text + "'";

                TmpTab.addRowTable(ref tb, new string[] { "B00FileList", Script });
                TmpTab.addRowTable(ref tb, new string[] { "B00FileList", "GO" });
            }

            string Sql = "";

            Sql += "INSERT INTO B00FileList	(TableName, CreateLogName, CreateLogNum, CreateLogColList, XmlLogColList,LogByPass, SuggestCodeMethod)\r\n" +
                "SELECT 'B20" + txtTableName.Text + "', 'B20ChangeLog', '0', '" + txtLogCol.Text + "', '*', 'MergeCode', 2";

            TmpTab.addRowTable(ref tb, new string[] { "B00FileList", Sql });
            TmpTab.addRowTable(ref tb, new string[] { "B00FileList", "GO" });

            Sql = "";

            Sql += "EXECUTE dbo._CreateTriggerLog @_TableName = 'B20" + txtTableName.Text + "'," +
                                                    "@_TableList = NULL," +
                                                    "@_DropOldTable = 1";

            TmpTab.addRowTable(ref tb, new string[] { "B00FileList", Sql });
            TmpTab.addRowTable(ref tb, new string[] { "B00FileList", "GO" });
        }

        /// <summary>
        /// Tạo lookup danh mục
        /// </summary>
        /// <param name="tb"></param>
        private void LoadLookup(ref DataTable tb)
        {
            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & DatLoa.checkData("SELECT * FROM dbo.B00Lookup WHERE LookupKey = '" + txtLookupKey.Text + "' ") > 0)
            {
                string Script;

                Script = "DELETE B00Lookup WHERE LookupKey = '" + txtLookupKey.Text + "'";

                TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", Script });
                TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", "GO" });
            }

            string Sql = "";

            Sql += "INSERT INTO B00Lookup (LookupKey, LookupTable, LookupMode, ValueMember, DisplayMember, HiddenValueMember, " +
                                "ExtraMemberList, Sort, FilterKey, LinkCommand, NewCommand, LookupExtraMembers)\r\n" +
                "SELECT '" + txtLookupKey.Text + "', '" + txtViewName.Text + "', 0, '" + txtValueMember.Text + "', N'Name', '" + txtHiddenValue.Text + "', " +
                                "N'', 'Code', N'{=BRANCHFILTER(''BranchCode'')}', '" + txtExplorerCommand.Text + "', '" + txtEditorCommand.Text + "', 1";

            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", Sql });
            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", "GO" });
        }

        /// <summary>
        /// Tạo Field
        /// </summary>
        /// <param name="tb"></param>
        private void LoadField(ref DataTable tb)
        {

            string Sql = "";

            Sql += "INSERT INTO dbo.B00FieldList (MasterTable, MasterField, Table_Name, Field_Name)\r\n" +
                    "VALUES ('B20" + txtTableName.Text + "','" + txtMergeCode.Text + "','_CreateTriggerMergeCode','" + txtTableName.Text + "Code')";

            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", Sql });

            Sql = "EXEC dbo._CreateTriggerMergeCode @_Name='B20" + txtTableName.Text + "'";

            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", Sql });

            Sql = "DELETE B00FieldList WHERE MasterTable= 'B20" + txtTableName.Text + "' AND Table_Name = '_CreateTriggerMergeCode'";

            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", Sql });

            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", "GO" });
        }

        /// <summary>
        /// Tạo Transfer
        /// </summary>
        /// <param name="tb"></param>
        private void LoadTransfer(ref DataTable tb)
        {

            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & DatLoa.checkData("SELECT * FROM dbo.B00TransferList WHERE TableName = 'B20" + txtTableName.Text + "' ") > 0)
            {
                string Script;

                Script = "DELETE B00TransferList WHERE TableName = 'B20" + txtTableName.Text + "'";

                TmpTab.addRowTable(ref tb, new string[] { "B00TransferList", Script });
                TmpTab.addRowTable(ref tb, new string[] { "B00TransferList", "GO" });
            }

            string Sql = "";

            Sql += "INSERT INTO dbo.B00TransferList ([ParentId],[IsGroup],[BranchCode],[BuiltinOrder],[TableName],[ParentKey],[ChildKey]," +
                            "[Transfer],[ExprOut],[ExprIn],[ExprDelete],[ExplorerCommandKey],[ExplorerCommandArgs],[Overwrite],[UsingUniqueKey]," +
                            "[UsingExprOut],[UsingExprDelete],[ActionWhenNotExprIn],[IsActive],[ValueAsOut],[UsingValueAsOut])\r\n" +
                    "SELECT 369,1,NULL,18,'B20" + txtTableName.Text + "',N'',N'',1,N'',N'',N'','" + txtExplorerCommand.Text + "',N'',1,1,1,1,0,1,N'',1";

            TmpTab.addRowTable(ref tb, new string[] { "B00TransferList", Sql });
            TmpTab.addRowTable(ref tb, new string[] { "B00Lookup", "GO" });
        }

        /// <summary>
        /// Tạo Command
        /// </summary>
        /// <param name="tb"></param>
        private void LoadCommand(ref DataTable tb)
        {
            string Script;
            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & DatLoa.checkData("SELECT * FROM dbo.B00Command WHERE CommandKey IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ") > 0)
            {
                Script = "DELETE B00Command WHERE CommandKey IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ";
                TmpTab.addRowTable(ref tb, new string[] { "B00Command", Script });
            }

            //Kiếm tra danh mục
            if (ckbDuplication.Checked == false & DatLoa.checkData("SELECT * FROM dbo.B00Layout WHERE FormName IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ") > 0)
            {
                Script = "DELETE B00LayoutData WHERE Id IN (SELECT Id FROM B00Layout WHERE FormName IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "'))";
                TmpTab.addRowTable(ref tb, new string[] { "B00Layout", Script });

                Script = "DELETE B00Layout WHERE FormName IN ('" + txtEditorCommand.Text + "','" + txtExplorerCommand.Text + "') ";
                TmpTab.addRowTable(ref tb, new string[] { "B00Layout", Script });
            }

            //tạo command explorer
            string Sql = "INSERT INTO [B00command] ([ParentId],[IsGroup],[CommandKey],[Text],[Text_English],[Text_French],[Text_Japanese],[Text_Chinese],[Text_Korean],[Text_Custom],[DLLName],[ClassName],[CtorArgs],[MethodName],[InvokeArgs],[CommandType],[DefaultEnabledState],[ShortKeyText],[ShortKeyValue],[Image],[CommandClass],[AlterCommandClass],[CustomFlags],[CategoryFlags],[IsActive] )  SELECT 1531,0,'" + txtExplorerCommand.Text + "',N'Danh mục " + txtDirNameVni.Text.ToLower() + "',N'" + txtDirNameEng.Text + "',NULL,N'',N'',N'',NULL,N'DataExplorer',N'DataExplorer',N'',N'Show',N'',N'',1,NULL,NULL,N'',N'',N'',NULL,NULL,1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Command-Explorer", Sql });

            //tạo command Editor
            Sql = "INSERT INTO [B00command] ([ParentId],[IsGroup],[CommandKey],[Text],[Text_English],[Text_French],[Text_Japanese],[Text_Chinese],[Text_Korean],[Text_Custom],[DLLName],[ClassName],[CtorArgs],[MethodName],[InvokeArgs],[CommandType],[DefaultEnabledState],[ShortKeyText],[ShortKeyValue],[Image],[CommandClass],[AlterCommandClass],[CustomFlags],[CategoryFlags],[IsActive] )  SELECT 1531,0,'" + txtEditorCommand.Text + "',N'Cập nhật " + txtDirNameVni.Text.ToLower() + "',N'Edit " + txtDirNameEng.Text.ToLower() + "',NULL,N'',N'',N'',NULL,N'DataEditor',N'DataEditor',N'',N'Show',N'',N'',1,NULL,NULL,N'',N'',N'',NULL,NULL,1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Command-Editor", Sql });

            //tạo Layout explorer
            Sql = "INSERT INTO [B00Layout] ([IsTemplate],[FormName],[LayoutName],[IsActive] )  SELECT 3,'" + txtExplorerCommand.Text + "',N'<DataSource>',1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Layout-Explorer", Sql });

            Sql = "INSERT INTO [B00Layout] ([IsTemplate],[FormName],[LayoutName],[IsActive] )  SELECT 0,'" + txtExplorerCommand.Text + "',N'Layout1',1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Layout-Explorer", Sql });

            //tạo Layout Editor
            Sql = "INSERT INTO [B00Layout] ([IsTemplate],[FormName],[LayoutName],[IsActive] )  SELECT 4,N'" + txtEditorCommand.Text + "',N'GroupLayout',1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Layout-Editor", Sql });

            Sql = "INSERT INTO [B00Layout] ([IsTemplate],[FormName],[LayoutName],[IsActive] )  SELECT 3,N'" + txtEditorCommand.Text + "',N'<DataSource>',1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Layout-Editor", Sql });

            Sql = "INSERT INTO [B00Layout] ([IsTemplate],[FormName],[LayoutName],[IsActive] )  SELECT 0,N'" + txtEditorCommand.Text + "',N'Layout1',1";
            TmpTab.addRowTable(ref tb, new string[] { "B00Layout-Editor", Sql });

            //Tạo LayoutData Explorer
            Sql = DataSourceExplorer();
            TmpTab.addRowTable(ref tb, new string[] { "B00LayoutData-Explorer", Sql });

            Sql = LayoutExplorer();
            TmpTab.addRowTable(ref tb, new string[] { "B00LayoutData-Explorer", Sql });

            //Tạo layoutData Editor
            Sql = DataSourceEditor();
            TmpTab.addRowTable(ref tb, new string[] { "B00LayoutData-Editor", Sql });

            Sql = GroupEditor();
            TmpTab.addRowTable(ref tb, new string[] { "B00LayoutData-Editor", Sql });

            Sql = LayoutEditor();
            TmpTab.addRowTable(ref tb, new string[] { "B00LayoutData-Editor", Sql });

        }

        private string DataSourceExplorer()
        {
            string LayoutXML;
            LayoutXML =
                "<root>" + "\r\n" +
                    "<Tables>" + "\r\n" +
                        "<ParentTable>" + "\r\n" +
                            "<Name>" + txtViewName.Text + "</Name>" + "\r\n" +
                            "<Alias>par</Alias>" + "\r\n" +
                            "<Sort>Code</Sort>" + "\r\n" +
                            "<DisplayMember>Name</DisplayMember>" + "\r\n" +
                            "<FilterKey>{=BRANCHFILTER('BranchCode')}</FilterKey>" + "\r\n" +
                            "<Evaluators>" + "\r\n" +
                                "<Eval_Edit_" + txtTableName.Text + ">" + "\r\n" +
                                    "<ClassName>BravoCommandKey</ClassName>" + "\r\n" +
                                    "<CommandKey>" + txtEditorCommand.Text + "</CommandKey>" + "\r\n" +
                                    "<zCtorArgs>ParentTable.IsGroup={=ISNULL(IsGroup,0)};ParentTable.CodeCopied='{=ISNULL(Code,'')}';</zCtorArgs >" + "\r\n" +
                                    "<Expr>LastCommand() IN('New', 'NewAsCopy', 'Open')</Expr>" + "\r\n" +
                                "</Eval_Edit_" + txtTableName.Text + ">" + "\r\n" +
                            "</Evaluators>" + "\r\n" +
                        "</ParentTable>" + "\r\n" +
                    "</Tables>" + "\r\n" +
                "</root>";

            return DatLoa.SelectValueReturn("SELECT 'INSERT INTO B00LayoutData (Id, LayoutData) " +
                                        "SELECT Id, CAST(CAST(' + CONVERT(NVARCHAR(MAX),dbo.ufn_sys_ToLayoutBinary(N'" + LayoutXML.Replace("'", "''") + "'),1) + ' AS NVARCHAR(MAX)) AS VARBINARY(MAX)) " +
                                        "From B00Layout WHERE FormName = ''" + txtExplorerCommand.Text + "'' AND LayoutName = ''<DataSource>'''");
        }

        /// <summary>
        /// Tạo layout explorer
        /// </summary>
        /// <returns></returns>
        private string LayoutExplorer()
        {
            DataTable tbTmp = CreateTableFromGrid(dataGridView1, new string[] { "ColName", "ExplorerDisplay", "NameVni", "NameEng" });

            string layoutCol = "";
            for (int i = 0; i < tbTmp.Rows.Count; i++)
            {
                if (tbTmp.Rows[i]["ExplorerDisplay"].ToString() == "True")
                {
                    //Nếu là cột Name thì có chiều rộng bằng 250, không thì là 60
                    string width;
                    if (tbTmp.Rows[i]["ColName"].ToString() == "Name") width = "250";
                    else width = "60";

                    //Nếu là cột Id thì cho style nhạt, nghiêng
                    string Style;
                    if (tbTmp.Rows[i]["ColName"].ToString() == "Id") Style = "<Style>Font:,,style=Italic;ForeColor:Silver;</Style>" + "\r\n";
                    else Style = "";

                    string Editor;
                    if (ckbCreateLookup.Checked == true)
                    {
                        if (tbTmp.Rows[i]["ColName"].ToString() == "Name")
                        {
                            Editor = "<Editor><ClassName>BravoLookupBox</ClassName><LookupKey>" + txtLookupKey.Text + "</LookupKey><lookupMode>4</lookupMode><FilterKey>IsGroup=0</FilterKey></Editor>" + "\r\n";
                        }
                        else if (tbTmp.Rows[i]["ColName"].ToString() == "Code")
                        {
                            Editor = "<Editor><ClassName>BravoLookupBox</ClassName><LookupKey>" + txtLookupKey.Text + "</LookupKey><lookupMode>3</lookupMode><FilterKey>IsGroup=0</FilterKey></Editor>" + "\r\n";
                        }
                        else Editor = "";
                    }
                    else Editor = "";
                   

                    layoutCol = layoutCol +
                        "<" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n" +
                            "<Width>" + width + "</Width>" + "\r\n" +
                            Editor +
                            Style +
                            "<Rows>" + "\r\n" +
                                "<Row_0>" + "\r\n" +
                                "<Text>" + "\r\n" +
                                    "<Vietnamese>" + tbTmp.Rows[i]["NameVni"].ToString() + "</Vietnamese>" + "\r\n" +
                                    "<English>" + tbTmp.Rows[i]["NameEng"].ToString() + "</English>" + "\r\n" +
                                "</Text>" + "\r\n" +
                                Style +
                                "</Row_0>" + "\r\n" +
                            "</Rows>" + "\r\n" +
                        "</" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n";
                }
            }

            string LayoutXML;
            LayoutXML =
                "<root>" + "\r\n" +
                  "<panelExplorer>" + "\r\n" +
                    "<Controls>" + "\r\n" +
                      "<grdDetail>" + "\r\n" +
                        "<DataMember>par</DataMember>" + "\r\n" +
                        "<Assembly>Bravo.DataExplorer</Assembly>" + "\r\n" +
                        "<ClassName>BravoExplorerControl</ClassName>" + "\r\n" +
                        "<Dock>Fill</Dock>" + "\r\n" +
                        "<Execute>" + "\r\n" +
                          "<Eval_Edit_" + txtTableName.Text + " />" + "\r\n" +
                        "</Execute>" + "\r\n" +
                        "<Rows>" + "\r\n" +
                          "<Row_0 />" + "\r\n" +
                        "</Rows>" + "\r\n" +
                        "<Cols>" + "\r\n" +
                        layoutCol +
                        "</Cols>" + "\r\n" +
                      "</grdDetail>" + "\r\n" +
                    "</Controls>" + "\r\n" +
                  "</panelExplorer>" + "\r\n" +
                "</root>";

            return DatLoa.SelectValueReturn("SELECT 'INSERT INTO B00LayoutData (Id, LayoutData) " +
                                        "SELECT Id, CAST(CAST(' + CONVERT(NVARCHAR(MAX),dbo.ufn_sys_ToLayoutBinary(N'" + LayoutXML.Replace("'", "''") + "'),1) + ' AS NVARCHAR(MAX)) AS VARBINARY(MAX)) " +
                                        "From B00Layout WHERE FormName = ''" + txtExplorerCommand.Text + "'' AND LayoutName = ''Layout1'''");
        }

        private string DataSourceEditor()
        {
            string LayoutXML;
            LayoutXML =
               "<root>" + "\r\n" +
                  "<Tables>" + "\r\n" +
                    "<ParentTable>" + "\r\n" +
                      "<Name>" + txtViewName.Text + "</Name>" + "\r\n" +
                      "<Alias>par</Alias>" + "\r\n" +
                      "<Validators>" + "\r\n" +
                        "<NotNull>" + "\r\n" +
                          "<SourceColumn>Code,Name</SourceColumn>" + "\r\n" +
                        "</NotNull>" + "\r\n" +
                        "<Unique>" + "\r\n" +
                          "<ClassName>BravoUniqueKeyValidator</ClassName>" + "\r\n" +
                          "<SourceColumn>Code</SourceColumn>" + "\r\n" +
                        "</Unique>" + "\r\n" +
                      "</Validators>" + "\r\n" +
                      "<ServerLoading>" + "\r\n" +
                        "<CodeCopied>Code</CodeCopied>" + "\r\n" +
                      "</ServerLoading>" + "\r\n" +
                      "<RowAdded>" + "\r\n" +
                        "<Eval_AutoNewCode />" + "\r\n" +
                      "</RowAdded>" + "\r\n" +
                      "<RowCopied>" + "\r\n" +
                        "<Eval_AutoNewCode />" + "\r\n" +
                      "</RowCopied>" + "\r\n" +
                      "<ColumnChanged>" + "\r\n" +
                        "<Code>" + "\r\n" +
                          "<Eval_AutoNewCode>EMPTY(Code)</Eval_AutoNewCode>" + "\r\n" +
                        "</Code>" + "\r\n" +
                      "</ColumnChanged>" + "\r\n" +
                      "<Evaluators>" + "\r\n" +
                        "<NewGroupCommand>" + "\r\n" +
                          "<ClassName>BravoCommandKey</ClassName>" + "\r\n" +
                          "<CommandKey>New</CommandKey>" + "\r\n" +
                          "<zCtorArgs>IsGroup=True;</zCtorArgs>" + "\r\n" +
                        "</NewGroupCommand>" + "\r\n" +
                        "<NewCommand>" + "\r\n" +
                          "<ClassName>BravoCommandKey</ClassName>" + "\r\n" +
                          "<CommandKey>New</CommandKey>" + "\r\n" +
                          "<zCtorArgs>IsGroup=False;</zCtorArgs>" + "\r\n" +
                        "</NewCommand>" + "\r\n" +
                        "<Eval_AutoNewCode>" + "\r\n" +
                          "<ClassName>BravoServerConstraint</ClassName>" + "\r\n" +
                          "<Command>usp_sys_AutoNewCode</Command>" + "\r\n" +
                          "<DataMember>Code</DataMember>" + "\r\n" +
                          "<Parameters>" + "\r\n" +
                            "<Code>CodeCopied</Code>" + "\r\n" +
                            "<TableName>TableName</TableName>" + "\r\n" +
                            "<ColumnName>ColumnName</ColumnName>" + "\r\n" +
                            "<NormalNewCode>2</NormalNewCode>" + "\r\n" +
                          "</Parameters>" + "\r\n" +
                          "<Expr>ISNULL(Id,0)&lt;=0</Expr>" + "\r\n" +
                          "<Text />" + "\r\n" +
                        "</Eval_AutoNewCode>" + "\r\n" +
                      "</Evaluators>" + "\r\n" +
                      "<Expressions>" + "\r\n" +
                        "<TableName>'B20" + txtTableName.Text + "'</TableName>" + "\r\n" +
                        "<ColumnName>'Code'</ColumnName>" + "\r\n" +
                      "</Expressions>" + "\r\n" +
                    "</ParentTable>" + "\r\n" +
                  "</Tables>" + "\r\n" +
                "</root>";

            return DatLoa.SelectValueReturn("SELECT 'INSERT INTO B00LayoutData (Id, LayoutData) " +
                                        "SELECT Id, CAST(CAST(' + CONVERT(NVARCHAR(MAX),dbo.ufn_sys_ToLayoutBinary(N'" + LayoutXML.Replace("'", "''") + "'),1) + ' AS NVARCHAR(MAX)) AS VARBINARY(MAX)) " +
                                        "From B00Layout WHERE FormName = ''" + txtEditorCommand.Text + "'' AND LayoutName = ''<DataSource>'''");
        }

        private string GroupEditor()
        {
            string LayoutXML;
            LayoutXML =
               "<root>" + "\r\n" +
                  "<panelEditor>" + "\r\n" +
                    "<Controls>" + "\r\n" +
                      "<BravoExpandingPanel>" + "\r\n" +
                        "<Text>" + "\r\n" +
                          "<Vietnamese>Nhóm</Vietnamese>" + "\r\n" +
                          "<English>Group</English>" + "\r\n" +
                          "<Japanese>グループ</Japanese>" + "\r\n" +
                          "<Chinese>团体</Chinese>" + "\r\n" +
                          "<Korean>그룹</Korean>" + "\r\n" +
                        "</Text>" + "\r\n" +
                        "<Row />" + "\r\n" +
                        "<Column>0</Column>" + "\r\n" +
                        "<ClassName>BravoExpandingPanel</ClassName>" + "\r\n" +
                        "<Controls>" + "\r\n" +
                          "<lblCode>" + "\r\n" +
                            "<Text>" + "\r\n" +
                              "<Vietnamese>Mã</Vietnamese>" + "\r\n" +
                              "<English>Code</English>" + "\r\n" +
                              "<Japanese>コード</Japanese>" + "\r\n" +
                              "<Chinese>代码</Chinese>" + "\r\n" +
                              "<Korean>암호</Korean>" + "\r\n" +
                            "</Text>" + "\r\n" +
                            "<Row />" + "\r\n" +
                            "<Column>0</Column>" + "\r\n" +
                          "</lblCode>" + "\r\n" +
                          "<Code>" + "\r\n" +
                            "<DataMember>Code</DataMember>" + "\r\n" +
                            "<ClassName>BravoKeyInputBox</ClassName>" + "\r\n" +
                            "<Column>1</Column>" + "\r\n" +
                            "<Dock>Fill</Dock>" + "\r\n" +
                          "</Code>" + "\r\n" +
                          "<lblName>" + "\r\n" +
                            "<Text>" + "\r\n" +
                              "<Vietnamese>Tên</Vietnamese>" + "\r\n" +
                              "<English>Name</English>" + "\r\n" +
                              "<Japanese>名前</Japanese>" + "\r\n" +
                              "<Chinese>姓名</Chinese>" + "\r\n" +
                              "<Korean>이름</Korean>" + "\r\n" +
                            "</Text>" + "\r\n" +
                            "<Row />" + "\r\n" +
                            "<Column>0</Column>" + "\r\n" +
                          "</lblName>" + "\r\n" +
                          "<Name>" + "\r\n" +
                            "<DataMember>Name</DataMember>" + "\r\n" +
                            "<ClassName>BravoTextBox</ClassName>" + "\r\n" +
                            "<Column>1</Column>" + "\r\n" +
                            "<ColumnSpan>2</ColumnSpan>" + "\r\n" +
                            "<Dock>Fill</Dock>" + "\r\n" +
                          "</Name>" + "\r\n" +
                        "</Controls>" + "\r\n" +
                      "</BravoExpandingPanel>" + "\r\n" +
                    "</Controls>" + "\r\n" +
                  "</panelEditor>" + "\r\n" +
                "</root>";

            return DatLoa.SelectValueReturn("SELECT 'INSERT INTO B00LayoutData (Id, LayoutData) " +
                                        "SELECT Id, CAST(CAST(' + CONVERT(NVARCHAR(MAX),dbo.ufn_sys_ToLayoutBinary(N'" + LayoutXML.Replace("'", "''") + "'),1) + ' AS NVARCHAR(MAX)) AS VARBINARY(MAX)) " +
                                        "From B00Layout WHERE FormName = ''" + txtEditorCommand.Text + "'' AND LayoutName = ''GroupLayout'''");
        }

        private string LayoutEditor()
        {
            DataTable tbTmp = CreateTableFromGrid(dataGridView1, new string[] { "ColName", "EditorDisplay", "NameVni", "NameEng" });

            string layoutCol = "";
            for (int i = 0; i < tbTmp.Rows.Count; i++)
            {
                if (tbTmp.Rows[i]["EditorDisplay"].ToString() == "True")
                {
                    string ClassName, Tmp;
                    if (tbTmp.Rows[i]["ColName"].ToString() == "Code")
                    {
                        ClassName = "BravoKeyInputBox";
                        Tmp = "";
                    }
                    else if (tbTmp.Rows[i]["ColName"].ToString() == "BranchCode")
                    {
                        ClassName = "BravoLookupBox";
                        Tmp = "<LookupKey>Branch</LookupKey>" + "\r\n" +
                                "<SelectKey>IsGroup=0</SelectKey>";
                    }
                    else
                    {
                        ClassName = "BravoTextBox";
                        Tmp = "<ColumnSpan>2</ColumnSpan>" + "\r\n";
                    }

                    layoutCol = layoutCol +
                        "<lbl" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n" +
                            "<Text>" + "\r\n" +
                                "<Vietnamese>" + tbTmp.Rows[i]["NameVni"].ToString() + "</Vietnamese>" + "\r\n" +
                                "<English>" + tbTmp.Rows[i]["NameEng"].ToString() + "</English>" + "\r\n" +
                            "</Text>" + "\r\n" +
                            "<Row />" + "\r\n" +
                            "<Column>0</Column>" + "\r\n" +
                        "</lbl" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n" +
                        "<" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n" +
                            "<DataMember>" + tbTmp.Rows[i]["ColName"].ToString() + "</DataMember>" + "\r\n" +
                            "<ClassName>" + ClassName + "</ClassName>" + "\r\n" +
                            Tmp +
                            "<Column>1</Column>" + "\r\n" +
                            "<Dock>Fill</Dock>" + "\r\n" +
                        "</" + tbTmp.Rows[i]["ColName"].ToString() + ">" + "\r\n";

                }
            }

            string LayoutXML;
            LayoutXML =
                "<root>" + "\r\n" +
                  "<navigator>" + "\r\n" +
                    "<LinkCommand>" + "\r\n" +
                      "<Items>" + "\r\n" +
                        "<Item_0>" + "\r\n" +
                          "<Caption>" + "\r\n" +
                            "<Vietnamese>Nhóm</Vietnamese>" + "\r\n" +
                            "<English>Group</English>" + "\r\n" +
                            "<Japanese>グループ</Japanese>" + "\r\n" +
                            "<Chinese>团体</Chinese>" + "\r\n" +
                            "<Korean>그룹</Korean>" + "\r\n" +
                          "</Caption>" + "\r\n" +
                          "<Select>IsGroup=True</Select>" + "\r\n" +
                          "<Execute>" + "\r\n" +
                            "<NewGroupCommand />" + "\r\n" +
                          "</Execute>" + "\r\n" +
                        "</Item_0>" + "\r\n" +
                        "<Item_1>" + "\r\n" +
                          "<Caption>" + "\r\n" +
                            "<Vietnamese>Chi tiết</Vietnamese>" + "\r\n" +
                            "<English>Detail</English>" + "\r\n" +
                            "<Japanese>詳細</Japanese>" + "\r\n" +
                            "<Chinese>细节</Chinese>" + "\r\n" +
                            "<Korean>세부 묘사</Korean>" + "\r\n" +
                          "</Caption>" + "\r\n" +
                          "<Select>IsGroup=False</Select>" + "\r\n" +
                          "<Execute>" + "\r\n" +
                            "<NewCommand />" + "\r\n" +
                          "</Execute>" + "\r\n" +
                        "</Item_1>" + "\r\n" +
                      "</Items>" + "\r\n" +
                    "</LinkCommand>" + "\r\n" +
                  "</navigator>" + "\r\n" +
                  "<zSubLayout>IIF(IsGroup=True,'GroupLayout','')</zSubLayout>" + "\r\n" +
                  "<panelEditor>" + "\r\n" +
                    "<Controls>" + "\r\n" +
                      "<BravoExpandingPanel>" + "\r\n" +
                        "<Text>" + "\r\n" +
                          "<Vietnamese>Chi tiết</Vietnamese>" + "\r\n" +
                          "<English>Detail </English>" + "\r\n" +
                          "<Japanese>詳細</Japanese>" + "\r\n" +
                          "<Chinese>细节</Chinese>" + "\r\n" +
                          "<Korean>세부 묘사</Korean>" + "\r\n" +
                        "</Text>" + "\r\n" +
                        "<Row />" + "\r\n" +
                        "<Column>0</Column>" + "\r\n" +
                        "<ClassName>BravoExpandingPanel</ClassName>" + "\r\n" +
                        "<Controls>" + "\r\n" +
                        layoutCol +
                        "</Controls>" + "\r\n" +
                      "</BravoExpandingPanel>" + "\r\n" +
                    "</Controls>" + "\r\n" +
                  "</panelEditor>" + "\r\n" +
                  "<bPreventEnterKeyWhenError>True</bPreventEnterKeyWhenError>" + "\r\n" +
                "</root>";

            return DatLoa.SelectValueReturn("SELECT 'INSERT INTO B00LayoutData (Id, LayoutData) " +
                                        "SELECT Id, CAST(CAST(' + CONVERT(NVARCHAR(MAX),dbo.ufn_sys_ToLayoutBinary(N'" + LayoutXML.Replace("'", "''") + "'),1) + ' AS NVARCHAR(MAX)) AS VARBINARY(MAX)) " +
                                        "From B00Layout WHERE FormName = ''" + txtEditorCommand.Text + "'' AND LayoutName = ''Layout1'''");
        }

        /// <summary>
        /// tạo bảng từ Grid, truyền vào list tên các cột
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ColumnList"></param>
        /// <returns></returns>
        private DataTable CreateTableFromGrid(DataGridView dt, string[] ColumnList)
        {
            BindingSource gdSource = (BindingSource)(dt.DataSource);
            DataTable tb = (DataTable)gdSource.DataSource;

            DataTable kq = new DataTable();

            kq = tb.DefaultView.ToTable("Tmp", false, ColumnList);

            return kq;
        }

        #endregion


        /// <summary>
        /// ---------------------------------------------------- xử lý kéo thả
        /// </summary>
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be converted to client coordinates.
            // Các vị trí chuột có liên quan đến màn hình, vì vậy chúng phải được chuyển đổi sang tọa độ máy khách.
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            // Lấy chỉ số hàng của mục mà con chuột đang ở bên dưới.
            rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove0 = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;

                string _ColName = rowToMove0.Cells["ColName"].Value.ToString();
                string _DataType = rowToMove0.Cells["DataType"].Value.ToString();
                string _AllowNull = rowToMove0.Cells["AllowNull"].Value.ToString();
                string _Default = rowToMove0.Cells["Default"].Value.ToString();
                string _EditorDisplay = rowToMove0.Cells["EditorDisplay"].Value.ToString();
                string _ExplorerDisplay = rowToMove0.Cells["ExplorerDisplay"].Value.ToString();
                string _NameVni = rowToMove0.Cells["NameVni"].Value.ToString();
                string _NameEng = rowToMove0.Cells["NameEng"].Value.ToString();

                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                //dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                //add thêm dòng vào DataGrid
                BindingSource gdSource = (BindingSource)(dataGridView1.DataSource);
                DataTable tb = (DataTable)gdSource.DataSource;

                TmpTab.addRowTableIndex(ref tb, new string[] { _ColName, _DataType, _AllowNull, _Default, _EditorDisplay, _ExplorerDisplay, _NameVni, _NameEng }, rowIndexOfItemUnderMouseToDrop);

                gdSource.DataSource = tb;
                dataGridView1.DataSource = gdSource;
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
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
    }
}
