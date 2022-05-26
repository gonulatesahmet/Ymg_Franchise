using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class CITY
    {
        private int cityID;
        private string cityName = string.Empty;

        public int CityID { get => cityID; set => cityID = value; }
        public string CityName { get => cityName; set => cityName = value; }
    }
}
