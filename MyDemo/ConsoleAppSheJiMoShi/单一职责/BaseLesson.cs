using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单一职责
{
    public abstract class BaseLesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }


        public abstract void study();
    }
}
