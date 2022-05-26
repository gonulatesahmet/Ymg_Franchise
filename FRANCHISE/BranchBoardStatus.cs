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
    public partial class BranchBoardStatus : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public BranchBoardStatus()
        {
            InitializeComponent();
        }
        public void BoardInfoBring()
        {
            ELL.BOARD[] Board = BLL.BOARD.BoardList(BranchID);
            flowLayoutPanel1.Controls.Clear();
            int AddedButtons_Height = 0;
            int Left = 0, OverHead = 0;

            for(int i = 0; i< Board.Length; i++)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Height = 95,
                    Width = 183,
                    Text = Board[i].BoardName,
                    Name = "btnBoard" + i.ToString() + "-" + Board[i].BoardID.ToString(),
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold)
                };
                if(Board[i].BoardState == "Aktif")
                {
                    btn.Appearance.BackColor = Color.GreenYellow;
                }
                else
                {
                    btn.Appearance.BackColor = Color.IndianRed;
                }
                flowLayoutPanel1.Controls.Add(btn);
                //Left = (btn.Width * (AddedButtons_Height / btn.Width));
                //AddedButtons_Height += btn.Width;
                //switch(AddedButtons_Height > pnlBoard.Width)
                //{
                //    case true:
                //        Left = 0;
                //        OverHead += btn.Height + 10;
                //        AddedButtons_Height = btn.Width;
                //        break;
                //}
                btn.Location = new Point(Left + (5 * i + 10), OverHead);
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int BoardID = Convert.ToInt32(((SimpleButton)sender).Name.Substring((((SimpleButton)sender).Name.IndexOf('-') + 1)));
            EmployeeControlCode frm = new EmployeeControlCode();
            frm.BoardID = BoardID;
            frm.BranchID = BranchID;
            frm.Show();
            
        }

        private void BranchBoardStatus_Load(object sender, EventArgs e)
        {
            BoardInfoBring();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BoardInfoBring();
        }
    }
}
