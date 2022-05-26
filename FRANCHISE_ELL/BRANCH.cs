using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class BRANCH
    {
        private int branchID;
        private string branchName = string.Empty;
        private string branchCode = string.Empty;
        private string branchDescription = string.Empty;
        private int cityID;
        private string cityName = string.Empty;
        private int districtID;
        private string districtName = string.Empty;
        private int insID;
        private string insName = string.Empty;
        private string branchState = string.Empty;

        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string BranchCode { get => branchCode; set => branchCode = value; }
        public string BranchDescription { get => branchDescription; set => branchDescription = value; }
        public int CityID { get => cityID; set => cityID = value; }
        public string CityName { get => cityName; set => cityName = value; }
        public int DistrictID { get => districtID; set => districtID = value; }
        public string DistrictName { get => districtName; set => districtName = value; }
        public int InsID { get => insID; set => insID = value; }
        public string InsName { get => insName; set => insName = value; }
        public string BranchState { get => branchState; set => branchState = value; }
    }
}
