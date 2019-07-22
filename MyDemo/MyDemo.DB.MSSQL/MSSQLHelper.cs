using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDemo.DB.Interface;
using System.Collections.Generic;

namespace MyDemo.DB.MSSQL
{
    public class MSSQLHelper : IDBHelper
    {
        public MSSQLHelper()
        {
            Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public MSSQLHelper(string connectionString)
        {

        }


        public void Query()
        {
            Console.WriteLine("{0}.Query()", this.GetType().Name);
        }

    }

    public class GenericClass<T, S>
    {
        public void Show<T, S>(T str, S date)
        {
            Console.WriteLine("{0}+{1}", typeof(T).Name, typeof(S).Name);
        }

    }

}
