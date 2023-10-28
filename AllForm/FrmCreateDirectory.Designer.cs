
namespace tkBravoTool.AllForm
{
    partial class FrmCreateDirectory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateDirectory));
            this.lblBranchName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirNameVni = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHiddenValue = new System.Windows.Forms.TextBox();
            this.lblHidden = new System.Windows.Forms.Label();
            this.txtValueMember = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ckbTransfer = new System.Windows.Forms.CheckBox();
            this.txtEditorCommand = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbCreateCommand = new System.Windows.Forms.CheckBox();
            this.txtExplorerCommand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckbCreateLookup = new System.Windows.Forms.CheckBox();
            this.ckbCreateMerge = new System.Windows.Forms.CheckBox();
            this.ckbCreateLog = new System.Windows.Forms.CheckBox();
            this.txtLookupKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMergeCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLogCol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblB20 = new System.Windows.Forms.Label();
            this.tabCtrKQ = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewKQ = new System.Windows.Forms.DataGridView();
            this.txtDirNameEng = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.ttipForm = new System.Windows.Forms.ToolTip(this.components);
            this.ckbDuplication = new System.Windows.Forms.CheckBox();
            this.lblCreateUsp = new System.Windows.Forms.LinkLabel();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabCtrKQ.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBranchName.Location = new System.Drawing.Point(9, 498);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(63, 13);
            this.lblBranchName.TabIndex = 19;
            this.lblBranchName.Text = "Hợp đồng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Danh mục";
            // 
            // txtDirNameVni
            // 
            this.txtDirNameVni.Location = new System.Drawing.Point(71, 6);
            this.txtDirNameVni.Name = "txtDirNameVni";
            this.txtDirNameVni.Size = new System.Drawing.Size(130, 20);
            this.txtDirNameVni.TabIndex = 1;
            this.ttipForm.SetToolTip(this.txtDirNameVni, "F3 để dịch");
            this.txtDirNameVni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDirNameVni_KeyDown);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(32, 22);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(141, 20);
            this.txtTableName.TabIndex = 6;
            this.ttipForm.SetToolTip(this.txtTableName, "F3 để mặc định thiết lập");
            this.txtTableName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tên bảng";
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(9, 66);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(164, 20);
            this.txtViewName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên view";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.txtHiddenValue);
            this.tabPage2.Controls.Add(this.lblHidden);
            this.tabPage2.Controls.Add(this.txtValueMember);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.ckbTransfer);
            this.tabPage2.Controls.Add(this.txtEditorCommand);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.ckbCreateCommand);
            this.tabPage2.Controls.Add(this.txtExplorerCommand);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ckbCreateLookup);
            this.tabPage2.Controls.Add(this.ckbCreateMerge);
            this.tabPage2.Controls.Add(this.ckbCreateLog);
            this.tabPage2.Controls.Add(this.txtLookupKey);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtMergeCode);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtLogCol);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(850, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File/Field/Lookup/Command/Layout";
            // 
            // txtHiddenValue
            // 
            this.txtHiddenValue.Location = new System.Drawing.Point(715, 56);
            this.txtHiddenValue.Name = "txtHiddenValue";
            this.txtHiddenValue.Size = new System.Drawing.Size(123, 20);
            this.txtHiddenValue.TabIndex = 17;
            // 
            // lblHidden
            // 
            this.lblHidden.AutoSize = true;
            this.lblHidden.Location = new System.Drawing.Point(603, 59);
            this.lblHidden.Name = "lblHidden";
            this.lblHidden.Size = new System.Drawing.Size(106, 13);
            this.lblHidden.TabIndex = 40;
            this.lblHidden.Text = "HiddenValueMember";
            // 
            // txtValueMember
            // 
            this.txtValueMember.Location = new System.Drawing.Point(474, 56);
            this.txtValueMember.Name = "txtValueMember";
            this.txtValueMember.Size = new System.Drawing.Size(123, 20);
            this.txtValueMember.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(396, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "ValueMember";
            // 
            // ckbTransfer
            // 
            this.ckbTransfer.AutoSize = true;
            this.ckbTransfer.Location = new System.Drawing.Point(6, 78);
            this.ckbTransfer.Name = "ckbTransfer";
            this.ckbTransfer.Size = new System.Drawing.Size(87, 17);
            this.ckbTransfer.TabIndex = 18;
            this.ckbTransfer.Text = "Tạo Transfer";
            this.ckbTransfer.UseVisualStyleBackColor = true;
            // 
            // txtEditorCommand
            // 
            this.txtEditorCommand.Location = new System.Drawing.Point(474, 102);
            this.txtEditorCommand.Name = "txtEditorCommand";
            this.txtEditorCommand.Size = new System.Drawing.Size(123, 20);
            this.txtEditorCommand.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Editor";
            // 
            // ckbCreateCommand
            // 
            this.ckbCreateCommand.AutoSize = true;
            this.ckbCreateCommand.Location = new System.Drawing.Point(6, 101);
            this.ckbCreateCommand.Name = "ckbCreateCommand";
            this.ckbCreateCommand.Size = new System.Drawing.Size(95, 17);
            this.ckbCreateCommand.TabIndex = 19;
            this.ckbCreateCommand.Text = "Tạo Command";
            this.ckbCreateCommand.UseVisualStyleBackColor = true;
            this.ckbCreateCommand.CheckedChanged += new System.EventHandler(this.ckbCreateCommand_CheckedChanged);
            // 
            // txtExplorerCommand
            // 
            this.txtExplorerCommand.Location = new System.Drawing.Point(226, 102);
            this.txtExplorerCommand.Name = "txtExplorerCommand";
            this.txtExplorerCommand.Size = new System.Drawing.Size(164, 20);
            this.txtExplorerCommand.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tên command";
            // 
            // ckbCreateLookup
            // 
            this.ckbCreateLookup.AutoSize = true;
            this.ckbCreateLookup.Location = new System.Drawing.Point(6, 55);
            this.ckbCreateLookup.Name = "ckbCreateLookup";
            this.ckbCreateLookup.Size = new System.Drawing.Size(84, 17);
            this.ckbCreateLookup.TabIndex = 14;
            this.ckbCreateLookup.Text = "Tạo Lookup";
            this.ckbCreateLookup.UseVisualStyleBackColor = true;
            this.ckbCreateLookup.CheckedChanged += new System.EventHandler(this.ckbCreateLookup_CheckedChanged);
            // 
            // ckbCreateMerge
            // 
            this.ckbCreateMerge.AutoSize = true;
            this.ckbCreateMerge.Location = new System.Drawing.Point(6, 32);
            this.ckbCreateMerge.Name = "ckbCreateMerge";
            this.ckbCreateMerge.Size = new System.Drawing.Size(103, 17);
            this.ckbCreateMerge.TabIndex = 12;
            this.ckbCreateMerge.Text = "Tạo MergeCode";
            this.ckbCreateMerge.UseVisualStyleBackColor = true;
            this.ckbCreateMerge.CheckedChanged += new System.EventHandler(this.ckbCreateMerge_CheckedChanged);
            // 
            // ckbCreateLog
            // 
            this.ckbCreateLog.AutoSize = true;
            this.ckbCreateLog.Location = new System.Drawing.Point(6, 9);
            this.ckbCreateLog.Name = "ckbCreateLog";
            this.ckbCreateLog.Size = new System.Drawing.Size(62, 17);
            this.ckbCreateLog.TabIndex = 10;
            this.ckbCreateLog.Text = "Tạo log";
            this.ckbCreateLog.UseVisualStyleBackColor = true;
            this.ckbCreateLog.CheckedChanged += new System.EventHandler(this.ckbCreateLog_CheckedChanged);
            // 
            // txtLookupKey
            // 
            this.txtLookupKey.Location = new System.Drawing.Point(226, 56);
            this.txtLookupKey.Name = "txtLookupKey";
            this.txtLookupKey.Size = new System.Drawing.Size(164, 20);
            this.txtLookupKey.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "LookupKey";
            // 
            // txtMergeCode
            // 
            this.txtMergeCode.Location = new System.Drawing.Point(226, 33);
            this.txtMergeCode.Name = "txtMergeCode";
            this.txtMergeCode.Size = new System.Drawing.Size(164, 20);
            this.txtMergeCode.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Cột liên kết";
            // 
            // txtLogCol
            // 
            this.txtLogCol.Location = new System.Drawing.Point(226, 10);
            this.txtLogCol.Name = "txtLogCol";
            this.txtLogCol.Size = new System.Drawing.Size(164, 20);
            this.txtLogCol.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "CreateLogColList";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.lblB20);
            this.tabPage1.Controls.Add(this.txtViewName);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTableName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bảng/view";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(179, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(665, 419);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // lblB20
            // 
            this.lblB20.AutoSize = true;
            this.lblB20.Location = new System.Drawing.Point(6, 25);
            this.lblB20.Name = "lblB20";
            this.lblB20.Size = new System.Drawing.Size(26, 13);
            this.lblB20.TabIndex = 28;
            this.lblB20.Text = "B20";
            // 
            // tabCtrKQ
            // 
            this.tabCtrKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrKQ.Controls.Add(this.tabPage1);
            this.tabCtrKQ.Controls.Add(this.tabPage2);
            this.tabCtrKQ.Controls.Add(this.tabPage3);
            this.tabCtrKQ.Location = new System.Drawing.Point(13, 38);
            this.tabCtrKQ.Name = "tabCtrKQ";
            this.tabCtrKQ.SelectedIndex = 0;
            this.tabCtrKQ.Size = new System.Drawing.Size(858, 457);
            this.tabCtrKQ.TabIndex = 22;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.dataGridViewKQ);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(850, 431);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kết quả";
            // 
            // dataGridViewKQ
            // 
            this.dataGridViewKQ.AllowUserToAddRows = false;
            this.dataGridViewKQ.AllowUserToDeleteRows = false;
            this.dataGridViewKQ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKQ.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewKQ.Name = "dataGridViewKQ";
            this.dataGridViewKQ.RowHeadersVisible = false;
            this.dataGridViewKQ.Size = new System.Drawing.Size(838, 419);
            this.dataGridViewKQ.TabIndex = 23;
            this.dataGridViewKQ.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewKQ_ColumnHeaderMouseClick);
            // 
            // txtDirNameEng
            // 
            this.txtDirNameEng.Location = new System.Drawing.Point(254, 6);
            this.txtDirNameEng.Name = "txtDirNameEng";
            this.txtDirNameEng.Size = new System.Drawing.Size(103, 20);
            this.txtDirNameEng.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "English";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(792, 9);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Gen code";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // ttipForm
            // 
            this.ttipForm.AutoPopDelay = 5000;
            this.ttipForm.InitialDelay = 500;
            this.ttipForm.ReshowDelay = 10;
            this.ttipForm.ShowAlways = true;
            this.ttipForm.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ckbDuplication
            // 
            this.ckbDuplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbDuplication.AutoSize = true;
            this.ckbDuplication.Location = new System.Drawing.Point(695, 13);
            this.ckbDuplication.Name = "ckbDuplication";
            this.ckbDuplication.Size = new System.Drawing.Size(91, 17);
            this.ckbDuplication.TabIndex = 3;
            this.ckbDuplication.Text = "Kiểm tra trùng";
            this.ckbDuplication.UseVisualStyleBackColor = true;
            // 
            // lblCreateUsp
            // 
            this.lblCreateUsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateUsp.AutoSize = true;
            this.lblCreateUsp.Location = new System.Drawing.Point(738, 498);
            this.lblCreateUsp.Name = "lblCreateUsp";
            this.lblCreateUsp.Size = new System.Drawing.Size(129, 13);
            this.lblCreateUsp.TabIndex = 99;
            this.lblCreateUsp.TabStop = true;
            this.lblCreateUsp.Text = "Tạo lại các thủ tục chuẩn";
            this.lblCreateUsp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreateUsp_LinkClicked);
            // 
            // FrmCreateDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 520);
            this.Controls.Add(this.lblCreateUsp);
            this.Controls.Add(this.ckbDuplication);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtDirNameEng);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDirNameVni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.tabCtrKQ);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmCreateDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo danh mục cơ bản";
            this.Load += new System.EventHandler(this.FrmCreateList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCreateDirectory_KeyDown);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabCtrKQ.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirNameVni;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabCtrKQ;
        private System.Windows.Forms.TextBox txtLogCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMergeCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLookupKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbCreateMerge;
        private System.Windows.Forms.CheckBox ckbCreateLog;
        private System.Windows.Forms.CheckBox ckbCreateLookup;
        private System.Windows.Forms.CheckBox ckbCreateCommand;
        private System.Windows.Forms.TextBox txtExplorerCommand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditorCommand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewKQ;
        private System.Windows.Forms.TextBox txtDirNameEng;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ToolTip ttipForm;
        private System.Windows.Forms.Label lblB20;
        private System.Windows.Forms.CheckBox ckbTransfer;
        private System.Windows.Forms.CheckBox ckbDuplication;
        private System.Windows.Forms.LinkLabel lblCreateUsp;
        private System.Windows.Forms.TextBox txtValueMember;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHiddenValue;
        private System.Windows.Forms.Label lblHidden;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}