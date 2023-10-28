using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tkBravoTool.SO;
using tkBravoTool.DAL;
using System.Configuration;
using System.Threading;

namespace tkBravoTool.SystemForm
{
    public partial class FrmPassCode : Form
    {
        public FrmPassCode()
        {
            InitializeComponent();
        }

        //public Form vFormOpen;
        private string vPassCode = "Tiendungctn23";


        /// <summary>
        /// Kiểm tra dữ liệu được trả về
        /// </summary>
        public bool _checkPassCode
        {
            get
            {
                if (txtPassword.Text == vPassCode) return true;
                else return false;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == vPassCode)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                txtPassword.Text = "";
                MessageBox.Show("Sai mật khẩu, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}