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

namespace tkBravoTool.AllForm
{
    public partial class FrmCheckMergeCode : Form
    {
        public FrmCheckMergeCode()
        {
            InitializeComponent();
        }

        private void btCommit_Click(object sender, EventArgs e)
        {
            DataAccess dtA = new DataAccess();
            DataSet ds = new DataSet();
            string sql = txtString.Text;
            ds = dtA.ExecuteAsDataSetSql(sql);  
            grdResult.DataSource = ds.Tables[0];


        }

        private void txtField_TextChanged(object sender, EventArgs e)
        {
            txtString.Text = "SELECT CAST(1 AS Bit) as Selection, *\r\nINTO #Tmp\r\nFROM INFORMATION_SCHEMA.COLUMNS\r\nWHERE COLUMN_NAME LIKE '%" + txtField.Text.ToString() + "Id%'\r\n\tAND LEFT(TABLE_NAME,1) <> 'v'\r\n\tAND RTRIM(COLUMN_NAME) + RTRIM(TABLE_NAME) NOT IN (SELECT RTRIM(Field_Name) + RTRIM(Table_Name)\r\n\t\tFROM dbo.B00FieldList WHERE MasterTable = 'B20" + txtField.Text.ToString() + "')\r\n\tAND DATA_TYPE = 'INT'\r\n\tAND TABLE_NAME NOT LIKE 'B00%'\r\n\t--AND TABLE_NAME NOT IN ('B30StatsDocPlanMachine','B30StatsDocPlanPackaging')\r\n\r\nSELECT * FROM #Tmp ORDER BY TABLE_NAME\r\n\r\n/*\r\nINSERT INTO dbo.B00FieldList(MasterTable, MasterField, Table_Name, Field_Name)\r\nSELECT 'B20" + txtField.Text.ToString() + "', 'Id', TABLE_NAME, COLUMN_NAME\r\nFROM #Tmp\r\n--*/\r\n\r\nDROP TABLE #Tmp\r\n";
        }

        private void FrmCheckMergeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btCommit_Click(null, null);
            }
        }
    }
}
