using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tkBravoTool.SystemForm
{
    public partial class FrmDonate : Form
    {
        public FrmDonate()
        {
            InitializeComponent();
        }

        private void FrmDonate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
