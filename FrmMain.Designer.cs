
namespace tkBravoTool
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuSystemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemMnuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuMailTkBravoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ItemMnuSystemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuCopyDeleteCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuCreateList = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuCreateCommandList = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuAutoBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuCheckLogMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMnuDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ckbShowPass = new System.Windows.Forms.CheckBox();
            this.cmsImport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnsplOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsplSaveMore = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnsplExportAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsplExportChoseOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.pictkBravoTool = new System.Windows.Forms.PictureBox();
            this.splExport = new SplitButtonDemo.SplitButton();
            this.splImport = new SplitButtonDemo.SplitButton();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsImport.SuspendLayout();
            this.cmsExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictkBravoTool)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSystem,
            this.chứcNăngToolStripMenuItem,
            this.ItemMnuDonate});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(826, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // MnuSystem
            // 
            this.MnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemMnuSystemLogin,
            this.toolStripMenuItem2,
            this.ItemMnuConfig,
            this.ItemMnuFunc,
            this.ItemMnuMailTkBravoTool,
            this.toolStripMenuItem1,
            this.ItemMnuSystemExit});
            this.MnuSystem.Name = "MnuSystem";
            this.MnuSystem.Size = new System.Drawing.Size(69, 20);
            this.MnuSystem.Text = "Hệ thống";
            // 
            // ItemMnuSystemLogin
            // 
            this.ItemMnuSystemLogin.Name = "ItemMnuSystemLogin";
            this.ItemMnuSystemLogin.Size = new System.Drawing.Size(290, 22);
            this.ItemMnuSystemLogin.Text = "Kết nối";
            this.ItemMnuSystemLogin.Click += new System.EventHandler(this.ItemMnuSystemLogin_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(287, 6);
            // 
            // ItemMnuConfig
            // 
            this.ItemMnuConfig.Enabled = false;
            this.ItemMnuConfig.Name = "ItemMnuConfig";
            this.ItemMnuConfig.Size = new System.Drawing.Size(290, 22);
            this.ItemMnuConfig.Text = "Tham số hệ thống";
            // 
            // ItemMnuFunc
            // 
            this.ItemMnuFunc.Name = "ItemMnuFunc";
            this.ItemMnuFunc.Size = new System.Drawing.Size(290, 22);
            this.ItemMnuFunc.Text = "Hàm hệ thống";
            this.ItemMnuFunc.Click += new System.EventHandler(this.ItemMnuFunc_Click);
            // 
            // ItemMnuMailTkBravoTool
            // 
            this.ItemMnuMailTkBravoTool.Enabled = false;
            this.ItemMnuMailTkBravoTool.Name = "ItemMnuMailTkBravoTool";
            this.ItemMnuMailTkBravoTool.Size = new System.Drawing.Size(290, 22);
            this.ItemMnuMailTkBravoTool.Text = "Đăng ký nhận mail thông tin tkBravoTool";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(287, 6);
            // 
            // ItemMnuSystemExit
            // 
            this.ItemMnuSystemExit.Name = "ItemMnuSystemExit";
            this.ItemMnuSystemExit.Size = new System.Drawing.Size(290, 22);
            this.ItemMnuSystemExit.Text = "Thoát";
            this.ItemMnuSystemExit.Click += new System.EventHandler(this.ItemMnuSystemExit_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemMnuTranslate,
            this.ItemMnuCopyDeleteCommand,
            this.ItemMnuCreateList,
            this.ItemMnuCreateCommandList,
            this.ItemMnuAutoBackup,
            this.ItemMnuCheckLogMerge});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // ItemMnuTranslate
            // 
            this.ItemMnuTranslate.Name = "ItemMnuTranslate";
            this.ItemMnuTranslate.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuTranslate.Text = "Dịch layout";
            this.ItemMnuTranslate.Click += new System.EventHandler(this.FrmMnuChucNang_Dich_Click);
            // 
            // ItemMnuCopyDeleteCommand
            // 
            this.ItemMnuCopyDeleteCommand.Name = "ItemMnuCopyDeleteCommand";
            this.ItemMnuCopyDeleteCommand.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuCopyDeleteCommand.Text = "Copy/Xóa Command";
            this.ItemMnuCopyDeleteCommand.Click += new System.EventHandler(this.ItemMnuCopyDeleteCommand_Click);
            // 
            // ItemMnuCreateList
            // 
            this.ItemMnuCreateList.Name = "ItemMnuCreateList";
            this.ItemMnuCreateList.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuCreateList.Text = "Tạo danh mục cơ bản";
            this.ItemMnuCreateList.Click += new System.EventHandler(this.ItemMnuCreateList_Click);
            // 
            // ItemMnuCreateCommandList
            // 
            this.ItemMnuCreateCommandList.Name = "ItemMnuCreateCommandList";
            this.ItemMnuCreateCommandList.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuCreateCommandList.Text = "Tạo danh mục Command";
            this.ItemMnuCreateCommandList.Click += new System.EventHandler(this.ItemMnuCreateCommandList_Click);
            // 
            // ItemMnuAutoBackup
            // 
            this.ItemMnuAutoBackup.Enabled = false;
            this.ItemMnuAutoBackup.Name = "ItemMnuAutoBackup";
            this.ItemMnuAutoBackup.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuAutoBackup.Text = "Auto backup database";
            // 
            // ItemMnuCheckLogMerge
            // 
            this.ItemMnuCheckLogMerge.Enabled = false;
            this.ItemMnuCheckLogMerge.Name = "ItemMnuCheckLogMerge";
            this.ItemMnuCheckLogMerge.Size = new System.Drawing.Size(212, 22);
            this.ItemMnuCheckLogMerge.Text = "Kiểm tra Log, Merge Code";
            // 
            // ItemMnuDonate
            // 
            this.ItemMnuDonate.Name = "ItemMnuDonate";
            this.ItemMnuDonate.Size = new System.Drawing.Size(147, 20);
            this.ItemMnuDonate.Text = "Mời Rũng một tách cafe";
            this.ItemMnuDonate.Click += new System.EventHandler(this.ItemMnuDonate_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInfo1.Location = new System.Drawing.Point(12, 437);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(446, 14);
            this.lblInfo1.TabIndex = 2;
            this.lblInfo1.Text = "Chương trình được xây dựng và phát triển bởi: Ngô Tiến Dũng - phòng KTTK3 - Bravo" +
    " HN";
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblInfo2.Location = new System.Drawing.Point(12, 451);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(406, 14);
            this.lblInfo2.TabIndex = 3;
            this.lblInfo2.Text = "Mọi ý kiến đóng góp về chương trình xin gửi về hòm mail: dungnt3@bravo.com.vn";
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBranchName.Location = new System.Drawing.Point(12, 421);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(63, 13);
            this.lblBranchName.TabIndex = 6;
            this.lblBranchName.Text = "Hợp đồng:";
            // 
            // lblVer
            // 
            this.lblVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVer.AutoSize = true;
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVer.Location = new System.Drawing.Point(788, 421);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(39, 13);
            this.lblVer.TabIndex = 7;
            this.lblVer.Text = "v.X.X.X";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(388, 27);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(396, 20);
            this.txtLink.TabIndex = 10;
            // 
            // btnLink
            // 
            this.btnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLink.Location = new System.Drawing.Point(790, 27);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(25, 20);
            this.btnLink.TabIndex = 11;
            this.btnLink.Text = "...";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(562, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 24;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(222, 335);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pass";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(436, 106);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "User Id";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(436, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(120, 20);
            this.txtUser.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(481, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(481, 132);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 15;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(436, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(481, 161);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbShowPass
            // 
            this.ckbShowPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbShowPass.AutoSize = true;
            this.ckbShowPass.Location = new System.Drawing.Point(419, 109);
            this.ckbShowPass.Name = "ckbShowPass";
            this.ckbShowPass.Size = new System.Drawing.Size(15, 14);
            this.ckbShowPass.TabIndex = 99;
            this.ckbShowPass.UseVisualStyleBackColor = true;
            this.ckbShowPass.CheckedChanged += new System.EventHandler(this.ckbShowPass_CheckedChanged);
            // 
            // cmsImport
            // 
            this.cmsImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsplOverwrite,
            this.btnsplSaveMore});
            this.cmsImport.Name = "contextMenuStrip1";
            this.cmsImport.Size = new System.Drawing.Size(138, 48);
            // 
            // btnsplOverwrite
            // 
            this.btnsplOverwrite.Name = "btnsplOverwrite";
            this.btnsplOverwrite.Size = new System.Drawing.Size(137, 22);
            this.btnsplOverwrite.Text = "Lưu đè";
            this.btnsplOverwrite.Click += new System.EventHandler(this.btnsplOverwrite_Click);
            // 
            // btnsplSaveMore
            // 
            this.btnsplSaveMore.Name = "btnsplSaveMore";
            this.btnsplSaveMore.Size = new System.Drawing.Size(137, 22);
            this.btnsplSaveMore.Text = "Lưu nối tiếp";
            this.btnsplSaveMore.Click += new System.EventHandler(this.btnsplSaveMore_Click);
            // 
            // cmsExport
            // 
            this.cmsExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnsplExportAll,
            this.btnsplExportChoseOnly});
            this.cmsExport.Name = "cmsExport";
            this.cmsExport.Size = new System.Drawing.Size(192, 48);
            // 
            // btnsplExportAll
            // 
            this.btnsplExportAll.Name = "btnsplExportAll";
            this.btnsplExportAll.Size = new System.Drawing.Size(191, 22);
            this.btnsplExportAll.Text = "Tất cả";
            this.btnsplExportAll.Click += new System.EventHandler(this.btnsplExportAll_Click);
            // 
            // btnsplExportChoseOnly
            // 
            this.btnsplExportChoseOnly.Name = "btnsplExportChoseOnly";
            this.btnsplExportChoseOnly.Size = new System.Drawing.Size(191, 22);
            this.btnsplExportChoseOnly.Text = "Chỉ dữ liệu được chọn";
            this.btnsplExportChoseOnly.Click += new System.EventHandler(this.btnsplExportChoseOnly_Click);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(562, 53);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(222, 20);
            this.txtFind.TabIndex = 20;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.BackgroundImage = global::tkBravoTool.Properties.Resources.Find;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFind.Location = new System.Drawing.Point(790, 53);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 20);
            this.btnFind.TabIndex = 21;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pictkBravoTool
            // 
            this.pictkBravoTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictkBravoTool.BackColor = System.Drawing.Color.Transparent;
            this.pictkBravoTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictkBravoTool.Enabled = false;
            this.pictkBravoTool.Image = global::tkBravoTool.Properties.Resources.Logo_tkBRAVO;
            this.pictkBravoTool.Location = new System.Drawing.Point(618, 421);
            this.pictkBravoTool.Name = "pictkBravoTool";
            this.pictkBravoTool.Size = new System.Drawing.Size(218, 61);
            this.pictkBravoTool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictkBravoTool.TabIndex = 4;
            this.pictkBravoTool.TabStop = false;
            // 
            // splExport
            // 
            this.splExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splExport.Location = new System.Drawing.Point(481, 219);
            this.splExport.Menu = this.cmsExport;
            this.splExport.Name = "splExport";
            this.splExport.Size = new System.Drawing.Size(75, 23);
            this.splExport.TabIndex = 18;
            this.splExport.Text = "Export";
            this.splExport.UseVisualStyleBackColor = true;
            // 
            // splImport
            // 
            this.splImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splImport.Location = new System.Drawing.Point(481, 248);
            this.splImport.Menu = this.cmsImport;
            this.splImport.Name = "splImport";
            this.splImport.Size = new System.Drawing.Size(75, 23);
            this.splImport.TabIndex = 19;
            this.splImport.Text = "Import";
            this.splImport.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 474);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.splExport);
            this.Controls.Add(this.splImport);
            this.Controls.Add(this.ckbShowPass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.pictkBravoTool);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tkBravoTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsImport.ResumeLayout(false);
            this.cmsExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictkBravoTool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuSystem;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuSystemLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuSystemExit;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuTranslate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuConfig;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuCopyDeleteCommand;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuCheckLogMerge;
        private System.Windows.Forms.PictureBox pictkBravoTool;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuFunc;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuCreateList;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuAutoBackup;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuDonate;
        private System.Windows.Forms.CheckBox ckbShowPass;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuMailTkBravoTool;
        private SplitButtonDemo.SplitButton splImport;
        private System.Windows.Forms.ContextMenuStrip cmsImport;
        private System.Windows.Forms.ToolStripMenuItem btnsplOverwrite;
        private System.Windows.Forms.ToolStripMenuItem btnsplSaveMore;
        private SplitButtonDemo.SplitButton splExport;
        private System.Windows.Forms.ContextMenuStrip cmsExport;
        private System.Windows.Forms.ToolStripMenuItem btnsplExportAll;
        private System.Windows.Forms.ToolStripMenuItem btnsplExportChoseOnly;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ToolStripMenuItem ItemMnuCreateCommandList;
    }
}

