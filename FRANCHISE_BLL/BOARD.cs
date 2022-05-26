using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class BOARD
    {
        public static ELL.BOARD[] BoardList(int BranchID)
        {
            ELL.BOARD[] Board = DAL.BOARD.BoardList(BranchID);
            return Board;
        }
        public static ELL.BOARD BoardBring(int BoardID)
        {
            ELL.BOARD Board = DAL.BOARD.BoardBring(BoardID);
            return Board;
        }
        public static void AddBoard(ELL.BOARD Board)
        {
            DAL.BOARD.AddBoard(Board);
        }
        public static void UpdateBoard(ELL.BOARD Board)
        {
            DAL.BOARD.UpdateBoard(Board);
        }
        public static void DeleteBoard(int BoardID)
        {
            DAL.BOARD.DeleteBoard(BoardID);
        }
        public static void ChangeStateBoard(int BoardID,string State)
        {
            DAL.BOARD.ChangeStateBoard(BoardID, State);
        }
    }
}
