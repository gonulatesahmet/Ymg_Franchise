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
namespace FRANCHISE
{
    public partial class UpdateBranchBoard : DevExpress.XtraEditors.XtraForm
    {
        public int BoardID;
        public UpdateBranchBoard()
        {
            InitializeComponent();
        }

        private void UpdateBranchBoard_Load(object sender, EventArgs e)
        {
            ELL.BOARD Board = BLL.BOARD.BoardBring(BoardID);
            txtBoardName.Text = Board.BoardName;
            txtBoardCode.Text = Board.BoardCode;
            txtBoardDescription.Text = Board.BoardDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.BOARD Board = new ELL.BOARD()
            {
                BoardName = txtBoardName.Text,
                BoardCode = txtBoardCode.Text,
                BoardDescription = txtBoardDescription.Text,
                BoardID = BoardID
            };
            try
            {
                BLL.BOARD.UpdateBoard(Board);
                BLL.HELPER.MessageBox("Masa Bilgileri Basariyla Guncellenmistir");
                BranchBoard frm = (BranchBoard)Application.OpenForms["BranchBoard"];
                frm.BoardList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
