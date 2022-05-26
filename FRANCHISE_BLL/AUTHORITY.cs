using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class AUTHORITY
    {
        public static ELL.AUTHORITY[] AuthorityList()
        {
            ELL.AUTHORITY[] Authority = DAL.AUTHORITY.AuthorityList();
            return Authority;
        }




        public static void AddAuthority(ELL.AUTHORITY Authority)
        {
            DAL.AUTHORITY.AddAuthority(Authority);
        }




        public static void UpdateAuthority(ELL.AUTHORITY Authority)
        {
            DAL.AUTHORITY.UpdateAuthority(Authority);
        }
        



        public static void ChangeStateAuthority(int AuthorityID, string State)
        {
            DAL.AUTHORITY.ChangeStateAuthority(AuthorityID, State);
        }
        



        public static void DeleteAuthority(int AuthorityID)
        {
            DAL.AUTHORITY.DeleteAuthority(AuthorityID);
        }
    }
}
