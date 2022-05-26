using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class BOARD
    {
        private int boardID;
        private string boardName = string.Empty;
        private string boardCode = string.Empty;
        private string boardDescription = string.Empty;
        private int branchID;
        private string branchName = string.Empty;
        private string boardState = string.Empty;

        public int BoardID { get => boardID; set => boardID = value; }
        public string BoardName { get => boardName; set => boardName = value; }
        public string BoardCode { get => boardCode; set => boardCode = value; }
        public string BoardDescription { get => boardDescription; set => boardDescription = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string BoardState { get => boardState; set => boardState = value; }
    }
}
