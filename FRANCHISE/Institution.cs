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
    public partial class Institution : DevExpress.XtraEditors.XtraForm
    {
        public int InsID;
        public Institution()
        {
            InitializeComponent();
        }

        private void Institution_Load(object sender, EventArgs e)
        {
            ELL.INSTITUTION Ins = BLL.INSTITUTION.InstitutionBring(InsID);
            txtInsName.Text = Ins.InsName;
            txtInsCode.Text = Ins.InsCode;
            txtInsDescription.Text = Ins.InsDescription;
            txtInsWeb.Text = Ins.InsWeb;
            txtInsPhone.Text = Ins.InsPhone;
            txtInsMail.Text = Ins.InsMail;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ELL.INSTITUTION Ins = new ELL.INSTITUTION();
            Ins.InsID = InsID;
            Ins.InsName = txtInsName.Text;
            Ins.InsCode = txtInsCode.Text;
            Ins.InsDescription = txtInsDescription.Text;
            Ins.InsWeb = txtInsWeb.Text;
            Ins.InsPhone = txtInsPhone.Text;
            Ins.InsMail = txtInsMail.Text;
            try
            {
                BLL.INSTITUTION.UpdateInstitution(Ins);
                BLL.HELPER.MessageBox("Kurum Bilgileri Basariyla Guncelleni");
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Kurum Bilgileri Guncellenemedi");
                throw;
            }
        }
    }
}
