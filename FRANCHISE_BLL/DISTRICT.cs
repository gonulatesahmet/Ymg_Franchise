using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class DISTRICT
    {
        public static ELL.DISTRICT[] DistrictList(int CityID)
        {
            ELL.DISTRICT[] District = DAL.DISTRICT.DistrictList(CityID);
            return District;
        }
    }
}
