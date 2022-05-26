using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ELL = FRANCHISE_ELL;
namespace FRANCHISE_DAL
{
    public class BRANCH
    {
        public static ELL.BRANCH[] BranchList(int InsID)
        {
            List<ELL.BRANCH> Branch = new List<ELL.BRANCH>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHLIST", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("INSID", InsID);
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Branch.Add(BranchLoad(dr));
            }
            return Branch.ToArray();
        }
        public static ELL.BRANCH BranchLoad(SqlDataReader dr)
        {
            ELL.BRANCH Branch = new ELL.BRANCH()
            {
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchCode = Convert.ToString(dr["BRANCHCODE"]),
                BranchDescription = Convert.ToString(dr["BRANCHDESCRIPTION"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"]),
                CityID = Convert.ToInt32(dr["CITYID"]),
                CityName = Convert.ToString(dr["CITYNAME"]),
                DistrictID = Convert.ToInt32(dr["DISTRICTID"]),
                DistrictName = Convert.ToString(dr["DISTRICTNAME"]),
                InsID = Convert.ToInt32(dr["INSID"]),
                InsName = Convert.ToString(dr["INSNAME"]),
                BranchState = Convert.ToString(dr["BRANCHSTATE"])
            };
            if(Branch.BranchState == "100")
            {
                Branch.BranchState = "Aktif";
            }
            else
            {
                Branch.BranchState = "Pasif";
            }
            return Branch;
        }
        public static ELL.BRANCH BranchBring(int BranchID)
        {
            SqlCommand kmt = new SqlCommand("PR_BRANCHBRING", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.BRANCH Branch = new ELL.BRANCH()
                {
                    BranchID = BranchID,
                    BranchName = Convert.ToString(dr["BRANCHNAME"]),
                    BranchCode = Convert.ToString(dr["BRANCHCODE"]),
                    BranchDescription = Convert.ToString(dr["BRANCHDESCRIPTION"]),
                    CityID = Convert.ToInt32(dr["CITYID"]),
                    CityName = Convert.ToString(dr["CITYNAME"]),
                    DistrictID = Convert.ToInt32(dr["DISTRICTID"]),
                    DistrictName = Convert.ToString(dr["DISTRICTNAME"]),
                    InsID = Convert.ToInt32(dr["INSID"]),
                    InsName = Convert.ToString(dr["INSNAME"]),
                    BranchState = Convert.ToString(dr["BRANCHSTATE"])
                };
                return Branch;
            }
            else return null;
        }



        public static void AddBranch(ELL.BRANCH Branch)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDBRANCH", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("BRANCHNAME", Branch.BranchName);
            kmt.Parameters.AddWithValue("BRANCHCODE", Branch.BranchCode);
            kmt.Parameters.AddWithValue("BRANCHDESCRIPTION", Branch.BranchDescription);
            kmt.Parameters.AddWithValue("CITYID", Branch.CityID);
            kmt.Parameters.AddWithValue("DISTRICTID", Branch.DistrictID);
            kmt.Parameters.AddWithValue("INSID", Branch.InsID);
            kmt.Parameters.AddWithValue("BRANCHSTATE", Branch.BranchState);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateBranch(ELL.BRANCH Branch)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEBRANCH", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("BRANCHNAME", Branch.BranchName);
            kmt.Parameters.AddWithValue("BRANCHCODE", Branch.BranchCode);
            kmt.Parameters.AddWithValue("BRANCHDESCRIPTION", Branch.BranchDescription);
            kmt.Parameters.AddWithValue("CITYID", Branch.CityID);
            kmt.Parameters.AddWithValue("DISTRICTID", Branch.DistrictID);
            kmt.Parameters.AddWithValue("BRANCHID", Branch.BranchID);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateBranch(int BranchID, string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEBRANCH", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            kmt.Parameters.AddWithValue("BRANCHSTATE", State);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteBranch(int BranchID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEBRANCH", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
