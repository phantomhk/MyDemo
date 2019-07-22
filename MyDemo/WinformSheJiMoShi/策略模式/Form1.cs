using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformSheJiMoShi.策略模式
{
    public partial class Form1 : Form
    {
        double total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(txtPrice.Text.Trim());
            double num = Convert.ToInt32(txtNum.Text.Trim());
            double totalPrice = price * num;

            CashContext cash = new CashContext(cmbType.SelectedItem.ToString());
            totalPrice = cash.GetResult(totalPrice);

            lbxList.Items.Add(totalPrice.ToString());

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }


    public class CashContext
    {
        CashSuper cs = null;
        public CashContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "满300返100":
                    cs = new CashReturn(300, 100);
                    break;
                case "打8折":
                    cs = new CashRebate(0.8);
                    break;
            }
        }

        public double GetResult(double money)
        {
            return cs.AcceptCash(money);
        }

    }


    #region 收费
    /// <summary>
    /// 现金收取父类
    /// </summary>
    public abstract class CashSuper
    {
        /// <summary>
        /// 收取现金，参数为原价，返回为当前价
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public abstract double AcceptCash(double money);
    }

    /// <summary>
    /// 正常收费
    /// </summary>
    public class CashNormal : CashSuper
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }

    /// <summary>
    /// 打折收费
    /// </summary>
    public class CashRebate : CashSuper
    {
        //折扣
        private double _moneyRebate = 1;

        public CashRebate(double moneyRebate)
        {
            _moneyRebate = moneyRebate;
        }
        public override double AcceptCash(double money)
        {
            return money * _moneyRebate;
        }
    }

    /// <summary>
    /// 满减，返利收费
    /// </summary>
    public class CashReturn : CashSuper
    {
        /// <summary>
        /// 满减金额
        /// </summary>
        private double _moneyCondition = 0;
        /// <summary>
        /// 优惠金额
        /// </summary>
        private double _moneyReturn = 0;

        public CashReturn(double moneyCondition, double moneyReturn)
        {
            _moneyCondition = moneyCondition;
            _moneyReturn = moneyReturn;
        }

        public override double AcceptCash(double money)
        {
            return money - Math.Floor(money / _moneyCondition) * _moneyReturn;
        }
    }
    #endregion

}
