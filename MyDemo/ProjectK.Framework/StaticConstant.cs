using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Framework
{
    public class StaticConstant
    {
        public static string strSqlServerConnection = ConfigurationManager.ConnectionStrings["MyStudy"].ConnectionString;


        private static string dalTypeDLL = ConfigurationManager.AppSettings["DALDLL"];
        public static string DALDllName = dalTypeDLL.Split(',')[1];
        public static string DALTypeName = dalTypeDLL.Split(',')[0];
    }
}
