using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class APPELLATION
    {
        public static ELL.APPELLATION[] AppellationList()
        {
            ELL.APPELLATION[] Appellation = DAL.APPELLATION.AppellationList();
            return Appellation;
        }
        public static ELL.APPELLATION AppellationBring(int AppellationID)
        {
            ELL.APPELLATION Appellation = DAL.APPELLATION.AppellationBring(AppellationID);
            return Appellation;
        }
        public static void AddAppellation(ELL.APPELLATION Appellation)
        {
            DAL.APPELLATION.AddAppellation(Appellation);
        }
        public static void UpdateAppellation(ELL.APPELLATION Appellation)
        {
            DAL.APPELLATION.UpdateAppellation(Appellation);
        }
        public static void ChangeStateAppellation(int AppellationID, string State)
        {
            DAL.APPELLATION.ChangeStateAppellation(AppellationID, State);
        }
        public static void DeleteAppellation(int AppellationID)
        {
            DAL.APPELLATION.DeleteAppellation(AppellationID);
        }
    }
}
