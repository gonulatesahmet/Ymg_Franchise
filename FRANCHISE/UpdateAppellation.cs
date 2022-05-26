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
    public partial class UpdateAppellation : DevExpress.XtraEditors.XtraForm
    {
        public int AppellationID;
        public UpdateAppellation()
        {
            InitializeComponent();
        }
        private void AuthorityList()
        {
            ELL.AUTHORITY[] Authority = BLL.AUTHORITY.AuthorityList();
            lupAuthority.Properties.DataSource = Authority;
            lupAuthority.Properties.DisplayMember = "AuthorityName";
            lupAuthority.Properties.ValueMember = "AuthorityID";
            lupAuthority.Properties.PopulateColumns();
            lupAuthority.Properties.Columns[0].Visible = false;
            lupAuthority.Properties.Columns[2].Visible = false;
            lupAuthority.Properties.Columns[3].Visible = false;
            lupAuthority.Properties.Columns[4].Visible = false;
        }

        private void UpdateAppellation_Load(object sender, EventArgs e)
        {
            AuthorityList();
            ELL.APPELLATION Appellation = BLL.APPELLATION.AppellationBring(AppellationID);
            txtBranchName.Text = Appellation.AppellationName;
            txtBranchCode.Text = Appellation.AppellationCode;
            txtBranchDescription.Text = Appellation.AppellationDescription;
            lupAuthority.EditValue = Appellation.AuthorityID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.APPELLATION Appellation = new ELL.APPELLATION()
            {
                AppellationName = txtBranchName.Text,
                AppellationCode = txtBranchCode.Text,
                AppellationDescription = txtBranchDescription.Text,
                AppellationID = AppellationID,
                AuthorityID = Convert.ToInt32(lupAuthority.EditValue)
            };
            BLL.APPELLATION.UpdateAppellation(Appellation);
            InsAppellation frm = (InsAppellation)Application.OpenForms["InsAppellation"];
            frm.AppellationList();
            this.Hide();
        }
    }
}
