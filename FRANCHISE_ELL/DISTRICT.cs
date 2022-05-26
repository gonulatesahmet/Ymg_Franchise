using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class DISTRICT
    {
        private int districtID;
        private string districtName = string.Empty;
        private int cityID;

        public int DistrictID { get => districtID; set => districtID = value; }
        public string DistrictName { get => districtName; set => districtName = value; }
        public int CityID { get => cityID; set => cityID = value; }
    }
}
