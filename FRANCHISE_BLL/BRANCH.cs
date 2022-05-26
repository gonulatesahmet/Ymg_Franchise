using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class BRANCH
    {
        public static ELL.BRANCH BranchBring(int BranchID)
        {
            ELL.BRANCH Branch = DAL.BRANCH.BranchBring(BranchID);
            return Branch;
        }
        public static ELL.BRANCH[] BranchList(int InsID)
        {
            ELL.BRANCH[] Branch = DAL.BRANCH.BranchList(InsID);
            return Branch;
        }
        public static void AddBranch(ELL.BRANCH Branch)
        {
            DAL.BRANCH.AddBranch(Branch);
        }
        public static void UpdateBranch(ELL.BRANCH Branch)
        {
            DAL.BRANCH.UpdateBranch(Branch);
        }
        public static void ChangeStateBranch(int BranchID, string State)
        {
            DAL.BRANCH.ChangeStateBranch(BranchID, State);
        }
        public static void DeleteBranch(int BranchID)
        {
            DAL.BRANCH.DeleteBranch(BranchID);
        }
    }
}
