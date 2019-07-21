using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.Framework.AttributeExtend
{
    [AttributeUsage( AttributeTargets.Property| AttributeTargets.Field)]
    public class LengthAttribute : AbstractValidateAttribute
    {
        private int _min = 0;
        private int _max = 0;

        public LengthAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override bool Validate(object obj)
        {
            if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            {
                int length = obj.ToString().Length;
                if (_min <= length && length <= _max)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
