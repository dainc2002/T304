namespace tkBravoTool.AllForm
{
    partial class FrmCheckMergeCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckMergeCode));
            this.txtField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGridView();
            this.btCommit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabSample = new System.Windows.Forms.TabPage();
            this.txtString = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSample.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(123, 20);
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(174, 22);
            this.txtField.TabIndex = 0;
            this.txtField.Text = "Employee";
            this.txtField.TextChanged += new System.EventHandler(this.txtField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên trường";
            // 
            // grdResult
            // 
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Location = new System.Drawing.Point(8, 75);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowHeadersWidth = 51;
            this.grdResult.RowTemplate.Height = 24;
            this.grdResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResult.Size = new System.Drawing.Size(1074, 316);
            this.grdResult.TabIndex = 2;
            // 
            // btCommit
            // 
            this.btCommit.Location = new System.Drawing.Point(303, 20);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(189, 23);
            this.btCommit.TabIndex = 3;
            this.btCommit.Text = "execute";
            this.btCommit.UseVisualStyleBackColor = true;
            this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabSample);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1116, 558);
            this.tabControl1.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.txtField);
            this.tabMain.Controls.Add(this.grdResult);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.btCommit);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1108, 529);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Check field";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabSample
            // 
            this.tabSample.Controls.Add(this.txtString);
            this.tabSample.Location = new System.Drawing.Point(4, 25);
            this.tabSample.Name = "tabSample";
            this.tabSample.Padding = new System.Windows.Forms.Padding(3);
            this.tabSample.Size = new System.Drawing.Size(1108, 529);
            this.tabSample.TabIndex = 1;
            this.tabSample.Text = "...................";
            this.tabSample.UseVisualStyleBackColor = true;
            // 
            // txtString
            // 
            this.txtString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtString.Location = new System.Drawing.Point(8, 6);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(1096, 511);
            this.txtString.TabIndex = 0;
            this.txtString.Text = resources.GetString("txtString.Text");
            // 
            // FrmCheckMergeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 558);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "FrmCheckMergeCode";
            this.Text = "FrmCheckMergeCode";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCheckMergeCode_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabSample.ResumeLayout(false);
            this.tabSample.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCommit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSample;
        private System.Windows.Forms.TextBox txtString;
        protected System.Windows.Forms.DataGridView grdResult;
    }
}