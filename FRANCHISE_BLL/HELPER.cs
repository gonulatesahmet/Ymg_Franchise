using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRANCHISE_BLL
{
    public class HELPER
    {
        public static void MessageBox(string Metin)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 4000;
            args.Caption = "Bilgi";
            args.Text = Metin;
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            XtraMessageBox.Show(args).ToString();
        }
    }
}
