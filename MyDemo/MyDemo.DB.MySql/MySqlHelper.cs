using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MyDemo.DB.Interface;

namespace MyDemo.DB.MySql
{
   public class MySqlHelper:IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public void Query()
        {
            Console.WriteLine("{0}.Query()", this.GetType().Name);
        }
    }
}