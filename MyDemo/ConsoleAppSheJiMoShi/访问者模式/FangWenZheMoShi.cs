using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSheJiMoShi.访问者模式
{
    class FangWenZheMoShi
    {
       public static void Main0()
        {
            Action action = new Success();
            new Man().GetConclusion(action);
            new Woman().GetConclusion(action);

            Action action1 = new Failing();
            new Man().GetConclusion(action1);
            new Woman().GetConclusion(action1);

            Action action2 = new Amativeness();
            new Man().GetConclusion(action2);
            new Woman().GetConclusion(action2);
        }

    }




    /// <summary>
    /// 人员
    /// </summary>
    public abstract class Person
    {
        //得到结论或反应
        public abstract void GetConclusion(Action action);

    }

    /// <summary>
    /// 男人
    /// </summary>
    public class Man : Person
    {
        public override void GetConclusion(Action action)
        {
            action.ManConclusion(this);
        }
    }

    /// <summary>
    /// 女人
    /// </summary>
    public class Woman : Person
    {
        public override void GetConclusion(Action action)
        {
            action.WomanConclusion(this);
        }
    }


    /// <summary>
    /// 表现
    /// </summary>
    public interface Action
    {
        void ManConclusion(Man man);

        void WomanConclusion(Woman woman);
    }

    /// <summary>
    /// 成功
    /// </summary>
    public class Success : Action
    {
        public void ManConclusion(Man man)
        {
            Console.WriteLine("{0},{1}时，背后多半有一个伟大的女人。", man.GetType().Name, this.GetType().Name);
        }

        public void WomanConclusion(Woman woman)
        {
            Console.WriteLine("{0},{1}时，背后大多有一个不成功的男人。", woman.GetType().Name, this.GetType().Name);
        }
    }

    /// <summary>
    /// 失败
    /// </summary>
    public class Failing : Action
    {
        public void ManConclusion(Man man)
        {
            Console.WriteLine("{0},{1}时，闷头喝酒，谁也不用劝。", man.GetType().Name, this.GetType().Name);
        }

        public void WomanConclusion(Woman woman)
        {
            Console.WriteLine("{0},{1}时，眼泪汪汪，谁也劝不了。", woman.GetType().Name, this.GetType().Name);
        }
    }

    /// <summary>
    /// 恋爱
    /// </summary>
    public class Amativeness : Action
    {
        public void ManConclusion(Man man)
        {
            Console.WriteLine("{0},{1}时，凡事不懂也要装懂。", man.GetType().Name, this.GetType().Name);
        }

        public void WomanConclusion(Woman woman)
        {
            Console.WriteLine("{0},{1}时，遇事懂也装作不懂。", woman.GetType().Name, this.GetType().Name);
        }
    }

}
