
namespace tkBravoTool.AllForm
{
    partial class FrmCopyCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCopyCommand));
            this.lblBranchName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCommand = new System.Windows.Forms.Label();
            this.cbbCommand = new System.Windows.Forms.ComboBox();
            this.btnGenCode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbDelete = new System.Windows.Forms.CheckBox();
            this.ckbTrigger = new System.Windows.Forms.CheckBox();
            this.ckbView = new System.Windows.Forms.CheckBox();
            this.ckbFunction = new System.Windows.Forms.CheckBox();
            this.ckbProcedure = new System.Windows.Forms.CheckBox();
            this.ckbCommand = new System.Windows.Forms.CheckBox();
            this.ckbData = new System.Windows.Forms.CheckBox();
            this.ckbTable = new System.Windows.Forms.CheckBox();
            this.ckbLayout = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.rtbKeyWhere = new System.Windows.Forms.RichTextBox();
            this.lblKeyWhere = new System.Windows.Forms.Label();
            this.lblCreateUsp = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBranchName
            // 
            this.lblBranchName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.BackColor = System.Drawing.Color.Transparent;
            this.lblBranchName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranchName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBranchName.Location = new System.Drawing.Point(12, 539);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(63, 13);
            this.lblBranchName.TabIndex = 18;
            this.lblBranchName.Text = "Hợp đồng:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(601, 524);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // lblCommand
            // 
            this.lblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(619, 15);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 21;
            this.lblCommand.Text = "Command";
            // 
            // cbbCommand
            // 
            this.cbbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbCommand.FormattingEnabled = true;
            this.cbbCommand.Location = new System.Drawing.Point(679, 12);
            this.cbbCommand.Name = "cbbCommand";
            this.cbbCommand.Size = new System.Drawing.Size(193, 21);
            this.cbbCommand.TabIndex = 1;
            this.cbbCommand.Leave += new System.EventHandler(this.cbbCommand_Leave);
            // 
            // btnGenCode
            // 
            this.btnGenCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenCode.Location = new System.Drawing.Point(679, 157);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenCode.TabIndex = 3;
            this.btnGenCode.Text = "Gen code";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenCode_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ckbDelete);
            this.groupBox2.Controls.Add(this.ckbTrigger);
            this.groupBox2.Controls.Add(this.ckbView);
            this.groupBox2.Controls.Add(this.ckbFunction);
            this.groupBox2.Controls.Add(this.ckbProcedure);
            this.groupBox2.Controls.Add(this.ckbCommand);
            this.groupBox2.Controls.Add(this.ckbData);
            this.groupBox2.Controls.Add(this.ckbTable);
            this.groupBox2.Controls.Add(this.ckbLayout);
            this.groupBox2.Location = new System.Drawing.Point(672, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 166);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // ckbDelete
            // 
            this.ckbDelete.AutoSize = true;
            this.ckbDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbDelete.Location = new System.Drawing.Point(7, 143);
            this.ckbDelete.Name = "ckbDelete";
            this.ckbDelete.Size = new System.Drawing.Size(105, 17);
            this.ckbDelete.TabIndex = 12;
            this.ckbDelete.Text = "Xóa command";
            this.ckbDelete.UseVisualStyleBackColor = true;
            // 
            // ckbTrigger
            // 
            this.ckbTrigger.AutoSize = true;
            this.ckbTrigger.Location = new System.Drawing.Point(6, 65);
            this.ckbTrigger.Name = "ckbTrigger";
            this.ckbTrigger.Size = new System.Drawing.Size(59, 17);
            this.ckbTrigger.TabIndex = 8;
            this.ckbTrigger.Text = "Trigger";
            this.ckbTrigger.UseVisualStyleBackColor = true;
            // 
            // ckbView
            // 
            this.ckbView.AutoSize = true;
            this.ckbView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbView.Location = new System.Drawing.Point(112, 65);
            this.ckbView.Name = "ckbView";
            this.ckbView.Size = new System.Drawing.Size(49, 17);
            this.ckbView.TabIndex = 9;
            this.ckbView.Text = "View";
            this.ckbView.UseVisualStyleBackColor = true;
            // 
            // ckbFunction
            // 
            this.ckbFunction.AutoSize = true;
            this.ckbFunction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbFunction.Location = new System.Drawing.Point(112, 88);
            this.ckbFunction.Name = "ckbFunction";
            this.ckbFunction.Size = new System.Drawing.Size(67, 17);
            this.ckbFunction.TabIndex = 11;
            this.ckbFunction.Text = "Function";
            this.ckbFunction.UseVisualStyleBackColor = true;
            // 
            // ckbProcedure
            // 
            this.ckbProcedure.AutoSize = true;
            this.ckbProcedure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbProcedure.Location = new System.Drawing.Point(6, 88);
            this.ckbProcedure.Name = "ckbProcedure";
            this.ckbProcedure.Size = new System.Drawing.Size(75, 17);
            this.ckbProcedure.TabIndex = 10;
            this.ckbProcedure.Text = "Procedure";
            this.ckbProcedure.UseVisualStyleBackColor = true;
            // 
            // ckbCommand
            // 
            this.ckbCommand.AutoSize = true;
            this.ckbCommand.Checked = true;
            this.ckbCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbCommand.Location = new System.Drawing.Point(6, 19);
            this.ckbCommand.Name = "ckbCommand";
            this.ckbCommand.Size = new System.Drawing.Size(73, 17);
            this.ckbCommand.TabIndex = 4;
            this.ckbCommand.Text = "Command";
            this.ckbCommand.UseVisualStyleBackColor = true;
            // 
            // ckbData
            // 
            this.ckbData.AutoSize = true;
            this.ckbData.Location = new System.Drawing.Point(112, 42);
            this.ckbData.Name = "ckbData";
            this.ckbData.Size = new System.Drawing.Size(49, 17);
            this.ckbData.TabIndex = 7;
            this.ckbData.Text = "Data";
            this.ckbData.UseVisualStyleBackColor = true;
            // 
            // ckbTable
            // 
            this.ckbTable.AutoSize = true;
            this.ckbTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbTable.Location = new System.Drawing.Point(6, 42);
            this.ckbTable.Name = "ckbTable";
            this.ckbTable.Size = new System.Drawing.Size(53, 17);
            this.ckbTable.TabIndex = 6;
            this.ckbTable.Text = "Table";
            this.ckbTable.UseVisualStyleBackColor = true;
            this.ckbTable.CheckedChanged += new System.EventHandler(this.ckbTable_CheckedChanged);
            // 
            // ckbLayout
            // 
            this.ckbLayout.AutoSize = true;
            this.ckbLayout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ckbLayout.Location = new System.Drawing.Point(112, 19);
            this.ckbLayout.Name = "ckbLayout";
            this.ckbLayout.Size = new System.Drawing.Size(58, 17);
            this.ckbLayout.TabIndex = 5;
            this.ckbLayout.Text = "Layout";
            this.ckbLayout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::tkBravoTool.Properties.Resources.Logo_tkBRAVO;
            this.pictureBox1.Location = new System.Drawing.Point(709, 504);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFile.Location = new System.Drawing.Point(797, 358);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFile.TabIndex = 14;
            this.btnSaveFile.Text = "Lưu ra file";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // rtbKeyWhere
            // 
            this.rtbKeyWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbKeyWhere.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbKeyWhere.Location = new System.Drawing.Point(679, 39);
            this.rtbKeyWhere.Name = "rtbKeyWhere";
            this.rtbKeyWhere.Size = new System.Drawing.Size(193, 102);
            this.rtbKeyWhere.TabIndex = 2;
            this.rtbKeyWhere.Text = "";
            // 
            // lblKeyWhere
            // 
            this.lblKeyWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyWhere.AutoSize = true;
            this.lblKeyWhere.Location = new System.Drawing.Point(619, 48);
            this.lblKeyWhere.Name = "lblKeyWhere";
            this.lblKeyWhere.Size = new System.Drawing.Size(57, 13);
            this.lblKeyWhere.TabIndex = 27;
            this.lblKeyWhere.Text = "Key where";
            // 
            // lblCreateUsp
            // 
            this.lblCreateUsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateUsp.AutoSize = true;
            this.lblCreateUsp.Location = new System.Drawing.Point(752, 488);
            this.lblCreateUsp.Name = "lblCreateUsp";
            this.lblCreateUsp.Size = new System.Drawing.Size(129, 13);
            this.lblCreateUsp.TabIndex = 99;
            this.lblCreateUsp.TabStop = true;
            this.lblCreateUsp.Text = "Tạo lại các thủ tục chuẩn";
            this.lblCreateUsp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreateUsp_LinkClicked);
            // 
            // FrmCopyCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblCreateUsp);
            this.Controls.Add(this.lblKeyWhere);
            this.Controls.Add(this.rtbKeyWhere);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGenCode);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.cbbCommand);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblBranchName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmCopyCommand";
            this.Text = "Copy/Xóa command";
            this.Load += new System.EventHandler(this.FrmCopyCommand_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCopyCommand_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.ComboBox cbbCommand;
        private System.Windows.Forms.Button btnGenCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbFunction;
        private System.Windows.Forms.CheckBox ckbProcedure;
        private System.Windows.Forms.CheckBox ckbCommand;
        private System.Windows.Forms.CheckBox ckbData;
        private System.Windows.Forms.CheckBox ckbTable;
        private System.Windows.Forms.CheckBox ckbLayout;
        private System.Windows.Forms.CheckBox ckbView;
        private System.Windows.Forms.CheckBox ckbTrigger;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.RichTextBox rtbKeyWhere;
        private System.Windows.Forms.Label lblKeyWhere;
        private System.Windows.Forms.LinkLabel lblCreateUsp;
        private System.Windows.Forms.CheckBox ckbDelete;
    }
}