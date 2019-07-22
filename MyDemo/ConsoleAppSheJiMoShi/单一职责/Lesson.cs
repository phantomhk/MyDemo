using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单一职责
{
    public  class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }


        public void Study()
        {
            Console.WriteLine("周二跟老师学习net核心语法");
        }

    }
}
