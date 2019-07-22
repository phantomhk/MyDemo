using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.单例模式
{
    class DanLiMoShi
    {
    }


    /// <summary>
    /// 单例模式
    /// </summary>
    public class Singleton
    {
        private static Singleton _singleton = null;
        private static readonly object _lock = new object();  //程序运行时创建一个只读的进程辅助对象

        /// <summary>
        /// 构造函数私有化
        /// </summary>
        private Singleton()
        {
        }

        public static Singleton CreateInstance()
        {
            if (_singleton == null)  //先判断实例是否存在，不存在再加锁处理
            {
                lock (_lock)  //加锁，当多线程时，只能有一个线程进入
                {
                    if (_singleton == null)  //当多线程调用时，可能会有多个线程通过第一层判断，所以这里再次判断
                    {
                        _singleton = new Singleton();
                    }
                }
            }

            return _singleton;
        }
    }


    /// <summary>
    /// 单例模式
    /// </summary>
    public sealed class SingletonSecond  //sealed,阻止发生派生，派生可能会增加实例
    {
        //readonly,第一次引用类的任何成员时创建实例。公共语言运行库负责处理变量初始化
        private static readonly SingletonSecond _single = new SingletonSecond();

        private SingletonSecond()
        {
        }

        public static SingletonSecond CreateInstance()
        {
            return _single;
        }
    }


}
