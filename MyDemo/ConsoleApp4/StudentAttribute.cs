using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    //AttributeUsage,用来修饰特性的特性。
    //AttributeTargets，有多个选择，all是全部，还有类class、委托delegate等
    //AllowMultiple，是否可以有多个同样的特性。默认为false，同样的特性只能有一个
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class StudentAttribute : Attribute
    {
        public void Show()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    public class StudentNameAttribute : Attribute
    {
       public string _name = "";
        public StudentNameAttribute(string name)
        {
            _name = name;
        }

        public void show()
        {
            Console.WriteLine(_name);
        }
    }
}
