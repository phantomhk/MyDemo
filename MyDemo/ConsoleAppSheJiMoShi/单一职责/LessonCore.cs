using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单一职责
{
    public class LessonCore : BaseLesson
    {
        public override void study()
        {
            Console.WriteLine("这是学习Core课程");
            //throw new NotImplementedException();
        }
    }
}
