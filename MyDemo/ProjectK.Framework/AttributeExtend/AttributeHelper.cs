using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Framework.AttributeExtend
{
   public static class AttributeHelper
    {
        /// <summary>
        /// 获取属性column名称
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetColumnName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ColumnAttribute), true))
            {
                ColumnAttribute attr = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                return attr.GetColumnName();
            }
            else
            {
                return prop.Name
;            }
        }


    }
}
