using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmSuanFa : Form
    {
        public FrmSuanFa()
        {
            InitializeComponent();
        }

        List<int> listi = new List<int>() { 9, 1, 5, 2, 8, 4, 3, 7, 34, 65, 22, 11, 34, 55, 87, 21 };

        private void button1_Click(object sender, EventArgs e)
        {
            new algorithmTool().BubbleSort<int>(listi,  false);

            Console.WriteLine(string.Join(", ", listi.ToArray()));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new algorithmTool().SelectSort<int>(listi, false);

            Console.WriteLine(string.Join(", ", listi.ToArray()));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new algorithmTool().QuickSort<int>(listi, 0,listi.Count-1, false);

            Console.WriteLine(string.Join(", ", listi.ToArray()));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new algorithmTool().InsertSort<int>(listi,  false);

            Console.WriteLine(string.Join(", ", listi.ToArray()));

        }
    }
}
