using ProjectK.Framework.AttributeExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Model
{
    public class User : BaseModel
    {
        [Length(1,3)]
        public string Name { get; set; }

        [Long(1,100)]
        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        [Column("State")]
        public int Status { get; set; }

        public int UserType { get; set; }

        public DateTime LastLoginTime { get; set; }

        public int CreatorId { get; set; }

        public DateTime CreateTime { get; set; }

        public int LastModifierId { get; set; }

        public DateTime LastModifyTime { get; set; }
    }
}
