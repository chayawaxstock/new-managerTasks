using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Accessibility
{
    public enum eKind { Smaller, Bigger, Non, Change, Reset }

    public enum eConstarct { Regular, Dark, Light }

    public delegate void MyDelegate(Control myControl, eKind kind);

    public partial class Accessibility : UserControl
    {
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursorFromFile(string lpFileName);
        float textSizeAdd = 1F / 3;
        bool isChange = false;

        public Accessibility()
        {
            InitializeComponent();

        }
        private void changeControls(MyDelegate myDelegate, eKind kind)
        {
            isChange = false;
            FormCollection formsList = Application.OpenForms;
            foreach (Form form in formsList)
            {
                foreach (Control c in form.Controls)
                {
                    myDelegate(c, kind);
                }
            }
        }

        private void item_bigger_text_Click(object sender, EventArgs e)
        {
            ChangeColorItem(item_bigger_text, eKind.Change);
            MyDelegate myDelegate = UpdateFontSizeControls;
            changeControls(myDelegate, eKind.Bigger);
        }

        private void item_smaller_fonts_Click(object sender, EventArgs e)
        {
            ChangeColorItem(item_bigger_text, eKind.Change);
            MyDelegate myDelegate = UpdateFontSizeControls;
            changeControls(myDelegate, eKind.Smaller);
        }

        /// <summary>
        /// UpdateFontSizeControls
        /// </summary>
        /// <param name="myControl"></param>
        /// <param name="kind">bigger or smaller</param>
        public void UpdateFontSizeControls(Control myControl, eKind kind)
        {
            if (isChange == false)
            {
                float y = GlobalStyle.segoeFont.Size;
                switch (kind)
                {
                    case eKind.Bigger: y += textSizeAdd; break;
                    default: y -= textSizeAdd; break;
                }
                GlobalStyle.segoeFont = new Font(GlobalStyle.segoeFont.FontFamily, y);
                isChange = true;
            }
            myControl.Font = GlobalStyle.segoeFont;
            foreach (Control subC in myControl.Controls)
            {
                UpdateFontSizeControls(subC, kind);
            }
        }

        /// <summary>
        /// UpdateFontBold
        /// </summary>
        /// <param name="myControl"></param>
        /// <param name="kind"></param>
        public void UpdateFontBold(Control myControl, eKind kind)
        {
            FontStyle style;
            switch (myControl.Font.Bold)
            {
                case false: style = FontStyle.Bold; break;
                default: style = FontStyle.Regular; break;
            }

            GlobalStyle.segoeFont = new Font(GlobalStyle.segoeFont, style);
            myControl.Font = GlobalStyle.segoeFont;
            foreach (Control subC in myControl.Controls)
            {
                UpdateFontBold(subC, kind);
            }
        }

        /// <summary>
        /// change cursor to bigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_big_cursor_Click(object sender, EventArgs e)
        {
            ChangeColorItem(item_big_cursor, eKind.Change);
            IntPtr cursor = LoadCursorFromFile(@"C:\Windows\Cursors\aero_arrow_xl.cur");
            GlobalStyle.cursor = new Cursor(cursor);
            FormCollection formsList = Application.OpenForms;
            foreach (Form form in formsList)
            {
                form.Cursor = GlobalStyle.cursor;
            }
        }

        private void item_legible_fonts_Click(object sender, EventArgs e)
        {
            ChangeColorItem(item_legible_fonts, eKind.Change);
            MyDelegate myDelegate = UpdateFontBold;
            changeControls(myDelegate, eKind.Non);
        }

        private void ChangeColorItem(RadMenuItem item, eKind kind)
        {
            if (kind == eKind.Reset)
            {
                item.BackColor = Color.Gray;
                return;
            }
            if (item.BackColor == Color.Gray)
                item.BackColor = Color.Green;
            else item.BackColor = Color.Gray;
        }

        private void item_reset_all_Click(object sender, EventArgs e)
        {
            item_Constarct.Text = "contract";
            ThemeResolutionService.ApplicationThemeName = GlobalStyle.ThemsConstarct[0];
            MyDelegate myDelegate = ResetAll;
            changeControls(myDelegate, eKind.Non);

        }
        /// <summary>
        /// reser all style to defult style
        /// </summary>
        /// <param name="myControl"></param>
        /// <param name="kind"></param>
        public void ResetAll(Control myControl, eKind kind)
        {
            GlobalStyle.cursor = Cursors.Arrow;
            myControl.FindForm().Cursor = GlobalStyle.cursor;
            float y = myControl.Tag != null ? float.Parse(myControl.Tag.ToString()) : myControl.Font.Size;
            GlobalStyle.segoeFont = GlobalStyle.baseFont;
            myControl.Font = GlobalStyle.segoeFont;
            foreach (Control subC in myControl.Controls)
            {
                ResetAll(subC, kind);
            }
        }

        public void Constarct()
        {
            int[] constarcts = eKind.GetValues(typeof(eConstarct)) as int[];
            FormCollection formsList = Application.OpenForms;
            ThemeResolutionService.ApplicationThemeName = GlobalStyle.ThemsConstarct[GlobalStyle.numClickChangeConstarct];
            item_Constarct.Text = "contract " +
                (eConstarct)constarcts[
                    GlobalStyle.numClickChangeConstarct + 1 < GlobalStyle.ThemsConstarct.Count
                ? GlobalStyle.numClickChangeConstarct + 1 : 0];
        }

        private void item_Constarct_Click(object sender, EventArgs e)
        {
            GlobalStyle.numClickChangeConstarct = GlobalStyle.numClickChangeConstarct + 1
                 < GlobalStyle.ThemsConstarct.Count ?
                 GlobalStyle.numClickChangeConstarct += 1
                 : 0;
            Constarct();
        }
    }
}
