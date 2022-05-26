using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class INSTITUTION
    {
        public static ELL.INSTITUTION InstitutionBring(int InsID)
        {
            ELL.INSTITUTION Ins = DAL.INSTITUTION.InsBring(InsID);
            return Ins;
        }
        public static void UpdateInstitution(ELL.INSTITUTION Ins)
        {
            DAL.INSTITUTION.UpdateInstitution(Ins);
        }
    }
}
