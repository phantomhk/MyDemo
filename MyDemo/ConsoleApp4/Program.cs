using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            Student stu = new Student();

            //StudentManager.Manager<Student>(stu);



            StudentManager.aaa<ChineseStudent>();
        }
    }
    public class StudentManager
    {
        public static void Manager<T>(T student) where T : Student
        {
            Type typ = student.GetType();

            //显示属性
            foreach (var item in typ.GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            //显示特性
            object[] oAttributes = typ.GetCustomAttributes(typeof(StudentAttribute), true);
            StudentAttribute attr = null;
            if (oAttributes != null && oAttributes.Length > 0)
            {
                attr = oAttributes[0] as StudentAttribute;
                Console.WriteLine(attr.GetType().Name);
            }
        }

        public static void aaa<T>() 
        {
            Type typ = typeof(T);

            //显示属性
            foreach (var item in typ.GetEnumNames())
            {
                Console.WriteLine(item);
                var arrObjAttr = typ.GetField(item).GetCustomAttribute(typeof(StudentNameAttribute), true);
                if (arrObjAttr != null)
                {
                    StudentNameAttribute attr = arrObjAttr as StudentNameAttribute;
                    Console.WriteLine(attr._name);
                }
            //object[] arrObjAttr = typeof(item).GetCustomAttributes(typeof(StudentNameAttribute), true);

            //foreach(var item in arrObjAttr)




                Console.WriteLine("------------");
            }

        }
    }
}
