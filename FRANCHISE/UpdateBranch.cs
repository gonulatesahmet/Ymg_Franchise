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
    public partial class UpdateBranch : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public UpdateBranch()
        {
            InitializeComponent();
        }
        private void CityList()
        {
            ELL.CITY[] City = BLL.CITY.CityList();
            lupCity.Properties.DataSource = City;
            lupCity.Properties.DisplayMember = "CityName";
            lupCity.Properties.ValueMember = "CityID";
            lupCity.Properties.PopulateColumns();
            lupCity.Properties.Columns[0].Visible = false;
        }
        private void DistrictList()
        {
            ELL.DISTRICT[] District = BLL.DISTRICT.DistrictList(Convert.ToInt32(lupCity.EditValue));
            lupDistrict.Properties.DataSource = District;
            lupDistrict.Properties.DisplayMember = "DistrictName";
            lupDistrict.Properties.ValueMember = "DistrictID";
            lupDistrict.Properties.PopulateColumns();
            lupDistrict.Properties.Columns[0].Visible = false;
            lupDistrict.Properties.Columns[2].Visible = false;
        }
        private void UpdateBranch_Load(object sender, EventArgs e)
        {
            CityList();
            DistrictList();
            ELL.BRANCH Branch = BLL.BRANCH.BranchBring(BranchID);
            txtBranchName.Text = Branch.BranchName;
            txtBranchCode.Text = Branch.BranchCode;
            txtBranchDescription.Text = Branch.BranchDescription;
            lupCity.EditValue = Branch.CityID;
            lupDistrict.EditValue = Branch.DistrictID;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.BRANCH Branch = new ELL.BRANCH()
            {
                BranchName = txtBranchName.Text,
                BranchCode = txtBranchCode.Text,
                BranchDescription = txtBranchDescription.Text,
                CityID = Convert.ToInt32(lupCity.EditValue),
                DistrictID = Convert.ToInt32(lupDistrict.EditValue),
                BranchID = BranchID
            };
            try
            {
                BLL.BRANCH.UpdateBranch(Branch);
                BLL.HELPER.MessageBox("Sube Basariyla Guncellenmistir");
                InsBranch frm = (InsBranch)Application.OpenForms["InsBranch"];
                frm.BranchList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
