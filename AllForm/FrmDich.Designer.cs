
namespace tkBravoTool.AllForm
{
    partial class FrmDich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDich));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblLayout = new System.Windows.Forms.Label();
            this.cbbLayout = new System.Windows.Forms.ComboBox();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.rtbDataGridCell = new System.Windows.Forms.RichTextBox();
            this.ckbEditEnglish = new System.Windows.Forms.CheckBox();
            this.ckbEditJapanese = new System.Windows.Forms.CheckBox();
            this.ckbEditChinese = new System.Windows.Forms.CheckBox();
            this.ckbEditKorean = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbFixNow = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbTransEnglish = new System.Windows.Forms.CheckBox();
            this.ckbTransKorean = new System.Windows.Forms.CheckBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.ckbTransJapanese = new System.Windows.Forms.CheckBox();
            this.ckbTransChinese = new System.Windows.Forms.CheckBox();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cbbTransStyle = new System.Windows.Forms.ComboBox();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCreateUsp = new System.Windows.Forms.LinkLabel();
            this.cbbCommand = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Size = new System.Drawing.Size(601, 458);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // lblCommand
            // 
            this.lblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(619, 15);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 2;
            this.lblCommand.Text = "Command";
            // 
            // lblLayout
            // 
            this.lblLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLayout.AutoSize = true;
            this.lblLayout.Location = new System.Drawing.Point(619, 42);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(39, 13);
            this.lblLayout.TabIndex = 4;
            this.lblLayout.Text = "Layout";
            // 
            // cbbLayout
            // 
            this.cbbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLayout.FormattingEnabled = true;
            this.cbbLayout.Location = new System.Drawing.Point(679, 39);
            this.cbbLayout.Name = "cbbLayout";
            this.cbbLayout.Size = new System.Drawing.Size(193, 21);
            this.cbbLayout.TabIndex = 2;
            this.cbbLayout.TextChanged += new System.EventHandler(this.cbbLayout_TextChanged);
            this.cbbLayout.Leave += new System.EventHandler(this.cbbLayout_Leave);
            // 
            // btnReLoad
            // 
            this.btnReLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReLoad.Location = new System.Drawing.Point(679, 91);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(75, 23);
            this.btnReLoad.TabIndex = 3;
            this.btnReLoad.Text = "Load lại";
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(797, 91);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFix.Location = new System.Drawing.Point(7, 0);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(75, 23);
            this.btnFix.TabIndex = 11;
            this.btnFix.Text = "Sửa lỗi biến";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // rtbDataGridCell
            // 
            this.rtbDataGridCell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDataGridCell.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rtbDataGridCell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDataGridCell.Location = new System.Drawing.Point(12, 476);
            this.rtbDataGridCell.Name = "rtbDataGridCell";
            this.rtbDataGridCell.Size = new System.Drawing.Size(601, 60);
            this.rtbDataGridCell.TabIndex = 18;
            this.rtbDataGridCell.Text = "";
            this.rtbDataGridCell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbDataGridCell_KeyDown);
            this.rtbDataGridCell.Leave += new System.EventHandler(this.rtbDataGridCell_Leave);
            // 
            // ckbEditEnglish
            // 
            this.ckbEditEnglish.AutoSize = true;
            this.ckbEditEnglish.Checked = true;
            this.ckbEditEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbEditEnglish.Location = new System.Drawing.Point(7, 29);
            this.ckbEditEnglish.Name = "ckbEditEnglish";
            this.ckbEditEnglish.Size = new System.Drawing.Size(60, 17);
            this.ckbEditEnglish.TabIndex = 12;
            this.ckbEditEnglish.Text = "English";
            this.ckbEditEnglish.UseVisualStyleBackColor = true;
            // 
            // ckbEditJapanese
            // 
            this.ckbEditJapanese.AutoSize = true;
            this.ckbEditJapanese.Location = new System.Drawing.Point(7, 52);
            this.ckbEditJapanese.Name = "ckbEditJapanese";
            this.ckbEditJapanese.Size = new System.Drawing.Size(72, 17);
            this.ckbEditJapanese.TabIndex = 14;
            this.ckbEditJapanese.Text = "Japanese";
            this.ckbEditJapanese.UseVisualStyleBackColor = true;
            // 
            // ckbEditChinese
            // 
            this.ckbEditChinese.AutoSize = true;
            this.ckbEditChinese.Location = new System.Drawing.Point(113, 29);
            this.ckbEditChinese.Name = "ckbEditChinese";
            this.ckbEditChinese.Size = new System.Drawing.Size(64, 17);
            this.ckbEditChinese.TabIndex = 13;
            this.ckbEditChinese.Text = "Chinese";
            this.ckbEditChinese.UseVisualStyleBackColor = true;
            // 
            // ckbEditKorean
            // 
            this.ckbEditKorean.AutoSize = true;
            this.ckbEditKorean.Location = new System.Drawing.Point(113, 52);
            this.ckbEditKorean.Name = "ckbEditKorean";
            this.ckbEditKorean.Size = new System.Drawing.Size(60, 17);
            this.ckbEditKorean.TabIndex = 15;
            this.ckbEditKorean.Text = "Korean";
            this.ckbEditKorean.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ckbFixNow);
            this.groupBox1.Controls.Add(this.ckbEditEnglish);
            this.groupBox1.Controls.Add(this.ckbEditKorean);
            this.groupBox1.Controls.Add(this.btnFix);
            this.groupBox1.Controls.Add(this.ckbEditJapanese);
            this.groupBox1.Controls.Add(this.ckbEditChinese);
            this.groupBox1.Location = new System.Drawing.Point(672, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 107);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // ckbFixNow
            // 
            this.ckbFixNow.AutoSize = true;
            this.ckbFixNow.Checked = true;
            this.ckbFixNow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbFixNow.ForeColor = System.Drawing.Color.DarkRed;
            this.ckbFixNow.Location = new System.Drawing.Point(7, 81);
            this.ckbFixNow.Name = "ckbFixNow";
            this.ckbFixNow.Size = new System.Drawing.Size(181, 17);
            this.ckbFixNow.TabIndex = 16;
            this.ckbFixNow.Text = "Sửa lỗi biến ngay khi dịch / copy";
            this.ckbFixNow.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ckbTransEnglish);
            this.groupBox2.Controls.Add(this.ckbTransKorean);
            this.groupBox2.Controls.Add(this.btnTranslate);
            this.groupBox2.Controls.Add(this.ckbTransJapanese);
            this.groupBox2.Controls.Add(this.ckbTransChinese);
            this.groupBox2.Location = new System.Drawing.Point(672, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 82);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // ckbTransEnglish
            // 
            this.ckbTransEnglish.AutoSize = true;
            this.ckbTransEnglish.Checked = true;
            this.ckbTransEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTransEnglish.Location = new System.Drawing.Point(7, 29);
            this.ckbTransEnglish.Name = "ckbTransEnglish";
            this.ckbTransEnglish.Size = new System.Drawing.Size(60, 17);
            this.ckbTransEnglish.TabIndex = 6;
            this.ckbTransEnglish.Text = "English";
            this.ckbTransEnglish.UseVisualStyleBackColor = true;
            this.ckbTransEnglish.CheckedChanged += new System.EventHandler(this.ckbTransEnglish_CheckedChanged);
            // 
            // ckbTransKorean
            // 
            this.ckbTransKorean.AutoSize = true;
            this.ckbTransKorean.Location = new System.Drawing.Point(113, 52);
            this.ckbTransKorean.Name = "ckbTransKorean";
            this.ckbTransKorean.Size = new System.Drawing.Size(60, 17);
            this.ckbTransKorean.TabIndex = 9;
            this.ckbTransKorean.Text = "Korean";
            this.ckbTransKorean.UseVisualStyleBackColor = true;
            this.ckbTransKorean.CheckedChanged += new System.EventHandler(this.ckbTransKorean_CheckedChanged);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.Location = new System.Drawing.Point(7, 0);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 5;
            this.btnTranslate.Text = "Dịch";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // ckbTransJapanese
            // 
            this.ckbTransJapanese.AutoSize = true;
            this.ckbTransJapanese.Location = new System.Drawing.Point(7, 52);
            this.ckbTransJapanese.Name = "ckbTransJapanese";
            this.ckbTransJapanese.Size = new System.Drawing.Size(72, 17);
            this.ckbTransJapanese.TabIndex = 8;
            this.ckbTransJapanese.Text = "Japanese";
            this.ckbTransJapanese.UseVisualStyleBackColor = true;
            this.ckbTransJapanese.CheckedChanged += new System.EventHandler(this.ckbTransJapanese_CheckedChanged);
            // 
            // ckbTransChinese
            // 
            this.ckbTransChinese.AutoSize = true;
            this.ckbTransChinese.Location = new System.Drawing.Point(113, 29);
            this.ckbTransChinese.Name = "ckbTransChinese";
            this.ckbTransChinese.Size = new System.Drawing.Size(64, 17);
            this.ckbTransChinese.TabIndex = 7;
            this.ckbTransChinese.Text = "Chinese";
            this.ckbTransChinese.UseVisualStyleBackColor = true;
            this.ckbTransChinese.CheckedChanged += new System.EventHandler(this.ckbTransChinese_CheckedChanged);
            // 
            // lblStyle
            // 
            this.lblStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(619, 232);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(51, 13);
            this.lblStyle.TabIndex = 16;
            this.lblStyle.Text = "Kiểu dịch";
            // 
            // cbbTransStyle
            // 
            this.cbbTransStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTransStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTransStyle.FormattingEnabled = true;
            this.cbbTransStyle.Location = new System.Drawing.Point(679, 229);
            this.cbbTransStyle.Name = "cbbTransStyle";
            this.cbbTransStyle.Size = new System.Drawing.Size(193, 21);
            this.cbbTransStyle.TabIndex = 10;
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
            this.lblBranchName.TabIndex = 17;
            this.lblBranchName.Text = "Hợp đồng:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::tkBravoTool.Properties.Resources.Logo_tkBRAVO;
            this.pictureBox1.Location = new System.Drawing.Point(704, 502);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblCreateUsp
            // 
            this.lblCreateUsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreateUsp.AutoSize = true;
            this.lblCreateUsp.Location = new System.Drawing.Point(756, 486);
            this.lblCreateUsp.Name = "lblCreateUsp";
            this.lblCreateUsp.Size = new System.Drawing.Size(129, 13);
            this.lblCreateUsp.TabIndex = 99;
            this.lblCreateUsp.TabStop = true;
            this.lblCreateUsp.Text = "Tạo lại các thủ tục chuẩn";
            this.lblCreateUsp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCreateUsp_LinkClicked);
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
            // FrmDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblCreateUsp);
            this.Controls.Add(this.lblBranchName);
            this.Controls.Add(this.lblStyle);
            this.Controls.Add(this.cbbTransStyle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbDataGridCell);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.lblLayout);
            this.Controls.Add(this.cbbLayout);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.cbbCommand);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmDich";
            this.Text = "Dịch layout";
            this.Load += new System.EventHandler(this.FrmDich_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDich_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox cbbLayout;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.RichTextBox rtbDataGridCell;
        private System.Windows.Forms.CheckBox ckbEditEnglish;
        private System.Windows.Forms.CheckBox ckbEditJapanese;
        private System.Windows.Forms.CheckBox ckbEditChinese;
        private System.Windows.Forms.CheckBox ckbEditKorean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbTransEnglish;
        private System.Windows.Forms.CheckBox ckbTransKorean;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.CheckBox ckbTransJapanese;
        private System.Windows.Forms.CheckBox ckbTransChinese;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.ComboBox cbbTransStyle;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.LinkLabel lblCreateUsp;
        private System.Windows.Forms.CheckBox ckbFixNow;
        private System.Windows.Forms.ComboBox cbbCommand;
    }
}