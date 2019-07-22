using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单一职责
{
    class DanYiZhiZe
    {
        public static void Main0()
        {
            {
                Console.WriteLine("*********************************");
                BaseLesson les = new LessonVip();
                les.study();
            }
            {
                Console.WriteLine("*********************************");
                BaseLesson les = new LessonCore();
                les.study();
            }

        }
    }



}
