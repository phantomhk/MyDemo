using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyDemo.DB.Interface;

namespace MyDemo.Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //加载dll，有三种方法
            {
                Assembly ass = Assembly.Load("MyDemo.DB.MSSQL");//从当前目录加载，无dll后缀
                //Assembly ass1 = Assembly.LoadFrom("MyDemo.DB.MSSQL.dll");//带后缀或完整路径
                //Assembly ass1 = Assembly.LoadFile(@"J:\个人demo\MyDemo\MyDemo.Reflection\bin\Debug\MyDemo.DB.MSSQL.dll");//从完整路径加载
            }

            {
                Assembly ass = Assembly.Load("MyDemo.DB.MSSQL");//从当前目录加载，无dll后缀
                foreach (var item in ass.GetModules())  //模块信息
                {
                    Console.WriteLine(item.FullyQualifiedName);
                }
                foreach (var item in ass.GetTypes())  //类型信息
                {
                    Console.WriteLine(item.FullName);
                }
            }
            //创建普通对象
            {
                Assembly ass = Assembly.Load("MyDemo.DB.MSSQL");  //1、加载dll
                Type type = ass.GetType("MyDemo.DB.MSSQL.MSSQLHelper");  //2、获取类型
                object oDBHelper = Activator.CreateInstance(type);  //3、创建类,调用无参数构造函数
                //object oDBHelper = Activator.CreateInstance(type, new object[] { "123" });  //3、创建类，带参数的构造函数
                IDBHelper helper = (IDBHelper)oDBHelper;  //4、类型转换(MSSQL继承IDBHelper)
                helper.Query();  //5、调用方法
            }
            //创建泛型对象
            {
                Assembly ass = Assembly.Load("MyDemo.DB.MSSQL");  //1、加载dll
                Type type = ass.GetType("MyDemo.DB.MSSQL.GenericClass`2");  //2、获取类型,"`2"是占位符
                Type newType = type.MakeGenericType(new Type[] { typeof(string), typeof(DateTime) });
                object oDBHelper = Activator.CreateInstance(newType);  //3、创建类
            }
            //调用方法
            {
                Assembly ass = Assembly.Load("MyDemo.DB.MSSQL");  //1、加载dll
                Type type = ass.GetType("MyDemo.DB.MSSQL.ReflectionTest");  //2、获取类型
                object oTest = Activator.CreateInstance(type);  //3、创建类,调用无参数构造函数

                //调用普通无参方法
                {
                    MethodInfo method = type.GetMethod("Show1");
                    method.Invoke(oTest, null);
                }
                //调用普通有参方法
                {
                    MethodInfo method = type.GetMethod("Show2");
                    method.Invoke(oTest, new object[] { 123});
                }
                //调用静态方法
                {
                    MethodInfo method = type.GetMethod("Show5");
                    method.Invoke(oTest, new object[] { "name" });  //调用静态方法时，Invoke()方法，第一个参数可以为null
                }
                //调用重载方法中指定的方法
                {
                    MethodInfo method = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                    method.Invoke(oTest, new object[] { "name", 123 });
                }
                //调用私有方法
                {
                    MethodInfo method = type.GetMethod("Show4", BindingFlags.Instance | BindingFlags.NonPublic);
                    method.Invoke(oTest, new object[] { "name"});
                }
                //调用泛型对象的泛型方法
                {
                    Type typeG = ass.GetType("MyDemo.DB.MSSQL.GenericClass`2");  //2、获取类型,"`2"是占位符
                    Type newType = typeG.MakeGenericType(new Type[] { typeof(string), typeof(DateTime) });
                    object obj = Activator.CreateInstance(newType);  //3、创建类

                    MethodInfo method = newType.GetMethod("Show");
                    MethodInfo newMethod = method.MakeGenericMethod(new Type[] { typeof(string), typeof(DateTime) });
                    newMethod.Invoke(obj, new object[] { "name", DateTime.Now });
                }
            }
            //操作属性
            {
                Type type = typeof(People);
                object obj = Activator.CreateInstance(type);
                //操作属性值
                foreach (var item in type.GetProperties())
                {
                    Console.WriteLine("{0}:{1}", item.Name,item.GetValue(obj));  //GetValue(obj),获取obj的属性值

                    if (item.Name.Equals("Name"))
                    {
                        item.SetValue(obj, "影子");  //属性赋值
                    }
                }
                //操作字段值
                foreach (var item in type.GetFields())
                {
                    Console.WriteLine("{0}:{1}", item.Name, item.GetValue(obj));  //GetValue(obj),获取obj的字段值

                    if (item.Name.Equals("CreateDate"))
                    {
                        item.SetValue(obj, DateTime.Now);  //字段赋值
                    }
                }

                {
                    People peo = new People();
                    peo.Id = 123;
                    peo.Name = "乱影";
                    peo.CreateDate = DateTime.Now;

                    object oPeople = Activator.CreateInstance(type);
                    foreach (var item in type.GetProperties())
                    {
                        object value = type.GetProperty(item.Name).GetValue(peo);
                        item.SetValue(oPeople, value);
                    }
                    foreach (var item in type.GetFields())
                    {
                        object value = type.GetField(item.Name).GetValue(peo);
                        item.SetValue(oPeople, value);
                    }
                }
            }
        }
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate;
    } 
}
