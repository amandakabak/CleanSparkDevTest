using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeMachine.Client
{
	public partial class frmMain : Form
	{
       
        public Stack<String> stack = new Stack<string>();
        private float OrderTotal;
        private int orderNum = 1;
		public frmMain()
		{
			InitializeComponent();
		}

		private void btnAddCoffee_Click(object sender, EventArgs e)
		{
            String size = txtSize.Text;
            int sugar = int.Parse(txtSugar.Text);
            int cream = int.Parse(txtCream.Text);
            String order = orderNum + " " + size + " Coffee" + ": " + sugar + " sugar" + ": " + cream + " cream" + "\r\n";

            stack.Push(order);
            float oTotal = total(size, sugar, cream);

            this.txtCurrentOrder.Text += stack.Pop();
            this.lblOrderTotal.Text = oTotal.ToString();
            orderNum++;
		}

		private void btnAddPayment_Click(object sender, EventArgs e)
		{
            float moneyInsert = float.Parse(txtPayment.Text);
            this.lblCurrentPayment.Text = moneyInsert.ToString();
		}

		private void btnVend_Click(object sender, EventArgs e)
		{
            String orderLabel = lblOrderTotal.Text;
            String currentPayment = lblCurrentPayment.Text;

            float orderT = float.Parse(orderLabel);
            float currentPaymentH = float.Parse(currentPayment);
            float zero = 0.00f;
            float amtLeft;

            amtLeft = remainingTotal(orderT, currentPaymentH);

            if(orderT > currentPaymentH)
            {
                MessageBox.Show("Sorry, not enough money");
            }
            else
            {
                this.lblOrderTotal.Text = amtLeft.ToString();

                this.lblCurrentPayment.Text = zero.ToString();

                this.txtCurrentOrder.Clear();

                MessageBox.Show("Thank you, enjoy!");

                MessageBox.Show("Here's your change $" + Math.Abs(amtLeft));
                this.lblOrderTotal.Text = zero.ToString();
            }
        }

        public float total(String size, int sugar, int cream)
        {
            if (size == "Large" || size == "large" || size == "l" || size == "L")
            {
                OrderTotal += 2.25f;
            }
            else if (size == "Medium" || size == "medium" || size == "m" || size == "M")
            {
                OrderTotal += 2.00f;
            }
            else if (size == "Small" || size == "small" || size == "S" || size == "s")
            {
                OrderTotal += 1.75f;
            }
            else
            {
                OrderTotal += 0.00f;
            }

            if (cream == 0)
            {
                OrderTotal += 0.00f;
            }
            else
            {
                for (int i = 0; i < cream; i++)
                {
                    OrderTotal += 0.50f;
                }
            }

            if (sugar == 0)
            {
                OrderTotal += 0.00f;
            }
            else
            {
                for (int j = 0; j < sugar; j++)
                {
                    OrderTotal += 0.25f;
                }
            }
            float total = OrderTotal;
            return total;
        }

        public float remainingTotal(float price, float pay)
        {
            float remainingTotal;

            remainingTotal = price - pay;

            return remainingTotal;
        }




	}
}
