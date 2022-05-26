using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELL = FRANCHISE_ELL;
using BLL = FRANCHISE_BLL;
using DevExpress.XtraEditors;

namespace FRANCHISE
{
    public partial class BranchGetPaid : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public BranchGetPaid()
        {
            InitializeComponent();
        }
        public void BoardInfoBring()
        {
            ELL.BOARD[] Board = BLL.BOARD.BoardList(BranchID);
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < Board.Length; i++)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Height = 95,
                    Width = 183,
                    Text = Board[i].BoardName,
                    Name = "btnBoard" + i.ToString() + "-" + Board[i].BoardID.ToString(),
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold)
                };
                if (Board[i].BoardState == "Aktif")
                {
                    btn.Appearance.BackColor = Color.GreenYellow;
                }
                else
                {
                    btn.Appearance.BackColor = Color.IndianRed;
                    btn.Enabled = false;
                }
                flowLayoutPanel1.Controls.Add(btn);
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int BoardID = Convert.ToInt32(((SimpleButton)sender).Name.Substring((((SimpleButton)sender).Name.IndexOf('-') + 1)));
            BranchGetPaidDetail frm = new BranchGetPaidDetail();
            frm.BranchID = BranchID;
            frm.BoardID = BoardID;
            frm.Show();
        }

        private void BranchGetPaid_Load(object sender, EventArgs e)
        {
            BoardInfoBring();
        }
    }
}
