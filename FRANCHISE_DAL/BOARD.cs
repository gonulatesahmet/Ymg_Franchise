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
    public class BOARD
    {
        public static ELL.BOARD[] BoardList(int BranchID)
        {
            List<ELL.BOARD> Board = new List<ELL.BOARD>();
            SqlCommand kmt = new SqlCommand("PR_BOARDLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Board.Add(BoardLoad(dr));
            }
            return Board.ToArray();
        }
        public static ELL.BOARD BoardLoad(SqlDataReader dr)
        {
            ELL.BOARD Board = new ELL.BOARD()
            {
                BoardID = Convert.ToInt32(dr["BOARDID"]),
                BoardName = Convert.ToString(dr["BOARDNAME"]),
                BoardCode = Convert.ToString(dr["BOARDCODE"]),
                BoardDescription = Convert.ToString(dr["BOARDDESCRIPTION"]),
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"]),
                BoardState = Convert.ToString(dr["BOARDSTATE"])
            };
            if (Board.BoardState == "100") Board.BoardState = "Aktif";
            else Board.BoardState = "Pasif";
            return Board;
        }
        public static ELL.BOARD BoardBring(int BoardID)
        {
            SqlCommand kmt = new SqlCommand("PR_BOARDBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDID", BoardID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.BOARD Board = new ELL.BOARD()
                {
                    BoardID = BoardID,
                    BoardName = Convert.ToString(dr["BOARDNAME"]),
                    BoardCode = Convert.ToString(dr["BOARDCODE"]),
                    BoardDescription = Convert.ToString(dr["BOARDDESCRIPTION"]),
                    BranchID = Convert.ToInt32(dr["BRANCHID"]),
                    BoardState = Convert.ToString(dr["BOARDSTATE"])
                };
                return Board;
            }
            else return null;
        }
        public static void AddBoard(ELL.BOARD Board)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDBOARD", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDNAME", Board.BoardName);
            kmt.Parameters.AddWithValue("BOARDCODE", Board.BoardCode);
            kmt.Parameters.AddWithValue("BOARDDESCRIPTION", Board.BoardDescription);
            kmt.Parameters.AddWithValue("BRANCHID", Board.BranchID);
            kmt.Parameters.AddWithValue("BOARDSTATE", Board.BoardState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateBoard(ELL.BOARD Board)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEBOARD", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDNAME", Board.BoardName);
            kmt.Parameters.AddWithValue("BOARDCODE", Board.BoardCode);
            kmt.Parameters.AddWithValue("BOARDDESCRIPTION", Board.BoardDescription);
            kmt.Parameters.AddWithValue("BOARDID", Board.BoardID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteBoard(int BoardID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEBOARD", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDID", BoardID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateBoard(int BoardID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEBOARD", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDID", BoardID);
            kmt.Parameters.AddWithValue("BOARDSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
