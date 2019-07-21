using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Libraries.IDAL;
using ProjectK.Framework;

namespace Libraries.Factory
{
   public class DALFactory
    {
        private static Type DALType = null;

        static DALFactory() {
            Assembly ass = Assembly.Load(StaticConstant.DALDllName);
            DALType = ass.GetType(StaticConstant.DALTypeName);
        }

        public static IDALBase CreateInstance()
        {
            return (IDALBase)Activator.CreateInstance(DALType);
        }

    }
}
