using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tkBravoTool.SO
{
    class PhanQuyen
    {
        public static FrmMain FrmMain = null;


        private static string _sPubItemMnu = ";MnuSystem;ItemMnuFunc;ItemMnuSystemLogin;ItemMnuSystemExit;ItemMnuDonate;".ToUpper();
        //các chức năng được sử dụng đưa vào đây
        private static string _sAvailableItemMnu = ";ItemMnuTranslate;ItemMnuCopyDeleteCommand;ItemMnuCreateList;ItemMnuCreateCommandList;".ToUpper();   //ItemMnuAutoBackup;
        /// <summary>
        /// Ẩn các menu trước khi kết nối thành công
        /// </summary>
        public static void HideAll()
        {
            //Duy menu bar (ngang)

            for (int i = 0; i < FrmMain.menuStrip.Items.Count; i++)
            {
                if (FrmMain.menuStrip.Items[i].GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    //Bắt đầu từ menu cấp 1
                    ToolStripMenuItem item1 = (ToolStripMenuItem)FrmMain.menuStrip.Items[i];

                    //Kiem tra neu itemmenu nam tong danh sach public
                    if (_sPubItemMnu.Contains(";" + item1.Name.ToUpper() + ";"))
                    {
                        //thi quay lai vong lap
                        //continue;
                    }
                    else
                    {
                        item1.Visible = false; //ẩn menu cấp 1 (menu bar)    
                    }

                    //tiếp tục xử lý ẩn menu cấp 2
                    if (item1.DropDownItems.Count > 0)
                    {
                        for (int j = 0; j < item1.DropDownItems.Count; j++)
                        {
                            if (item1.DropDownItems[j].GetType().ToString() == "System.Windows.Forms.ToolStripSeparator") // bỏ qua phân cách menu
                            {
                                continue;
                            }
                            else
                            {
                                ToolStripMenuItem item2 = (ToolStripMenuItem)item1.DropDownItems[j];
                                if (_sPubItemMnu.Contains(";" + item2.Name.ToUpper() + ";"))
                                    continue;
                                else
                                    item2.Enabled = false;  // làm mờ menu cấp 2 (dropdown of menubar)
                            }
                        }
                    }
                }
            }

            //Hien thi len 1 so menu chinh (manual)
            //frmmain.menuStrip.mnuSystem.Visible = true;
            //frmmain.ItemMnuSystemLogin.Visible = true;
        }
        /// <summary>
        /// Hiển thị các menu theo quyền
        /// </summary>
        public static void ShowAll()
        {
            //Duy menu bar (ngang)
            for (int i = 0; i < FrmMain.menuStrip.Items.Count; i++)
            {
                if (FrmMain.menuStrip.Items[i].GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
                {
                    // bắt đầu từ menu cấp 1
                    ToolStripMenuItem item1 = (ToolStripMenuItem)FrmMain.menuStrip.Items[i];
                    item1.Visible = true;

                    // xử lý menu cấp 2
                    if (item1.DropDownItems.Count > 0)
                    {
                        for (int j = 0; j < item1.DropDownItems.Count; j++)
                        {
                            if (item1.DropDownItems[j].GetType().ToString() == "System.Windows.Forms.ToolStripSeparator")
                            {
                                continue;
                            }
                            else
                            {
                                
                                ToolStripMenuItem item2 = (ToolStripMenuItem)item1.DropDownItems[j];
                                if (_sAvailableItemMnu.Contains(";" + item2.Name.ToUpper() + ";"))
                                    item2.Enabled = true;
                            }

                        }
                    }
                }
            }
        }
    }
}
