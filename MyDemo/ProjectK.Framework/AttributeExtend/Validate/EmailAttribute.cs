using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectK.Framework.AttributeExtend
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public   class EmailAttribute:AbstractValidateAttribute
    {
        public override bool Validate(object obj)
        {
            return obj != null && Regex.IsMatch(obj.ToString(), @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

    }
}
