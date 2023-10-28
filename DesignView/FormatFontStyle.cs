using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace tkBravoTool.DesignView
{
    class FormatFontStyle
    {

        public static void RichTextBoxFormat(ref RichTextBox rtb, KeyEventArgs e)
        {
            FontStyle _fontStyle = rtb.SelectionFont.Style;

            if (e.Control && e.KeyCode == Keys.B)
            {
                if (rtb.SelectionFont.Bold)
                {
                    _fontStyle = (FontStyle)(_fontStyle - FontStyle.Bold);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
                else
                {
                    _fontStyle = (FontStyle)(_fontStyle | FontStyle.Bold);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                if (rtb.SelectionFont.Italic)
                {
                    _fontStyle = (FontStyle)(_fontStyle - FontStyle.Italic);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
                else
                {
                    _fontStyle = (FontStyle)(_fontStyle | FontStyle.Italic);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                if (rtb.SelectionFont.Underline)
                {
                    _fontStyle = (FontStyle)(_fontStyle - FontStyle.Underline);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
                else
                {
                    _fontStyle = (FontStyle)(_fontStyle | FontStyle.Underline);

                    rtb.SelectionFont = new Font(rtb.SelectionFont, _fontStyle);
                }
            }
            else if (e.Control && e.KeyCode == Keys.OemOpenBrackets)
            {
                rtb.SelectionFont = new Font(rtb.SelectionFont.Name, rtb.SelectionFont.Size - 1, _fontStyle);
            }
            else if (e.Control && e.KeyCode == Keys.OemCloseBrackets)
            {
                rtb.SelectionFont = new Font(rtb.SelectionFont.Name, rtb.SelectionFont.Size + 1, _fontStyle);
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                rtb.SelectionAlignment = HorizontalAlignment.Left;
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                rtb.SelectionAlignment = HorizontalAlignment.Right;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                rtb.SelectionAlignment = HorizontalAlignment.Center;
            }
        }
    }
}
