using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinformSheJiMoShi
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /***********************************************/
            Form fm = new WinformSheJiMoShi.策略模式.Form1();


            /***********************************************/
            Application.Run(fm);
        }
    }
}
