using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单一职责
{
    public   class LessonVip:BaseLesson
    {

        public override void study()
        {
            //throw new NotImplementedException();
            Console.WriteLine("这是学习vip课程");
        }
    }
}
