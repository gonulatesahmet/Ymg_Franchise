using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class CITY
    {
        public static ELL.CITY[] CityList()
        {
            ELL.CITY[] City = DAL.CITY.CityList();
            return City;
        }
    }
}
