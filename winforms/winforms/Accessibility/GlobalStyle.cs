using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Accessibility
{
    public class GlobalStyle
    {
       
        public static List<string> ThemsConstarct=new List<string>() { "MaterialTeal", "VisualStudio2012Dark", "Desert"};
        public static int numClickChangeConstarct = 0;
        public static Font segoeFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static Font baseFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        public static Cursor cursor = Cursors.Arrow;
    }
}
