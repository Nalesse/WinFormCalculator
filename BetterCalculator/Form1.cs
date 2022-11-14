using System;
using System.Data;
using System.Windows.Forms;

namespace BetterCalculator
{
    public partial class Form1 : Form
    {

        private string expression;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "C":
                    expression = "";
                    break;
                case "CE":
                    if (expression.Length == 0) break;
                   expression = expression.Remove(expression.Length - 1, 1);
                    break;
                case "=":
                    DataTable dt = new DataTable();
                    expression = dt.Compute(expression,"").ToString();
                    break;
                default:
                    expression += button.Text;
                    break;
            }

            ExpressionTextBox.Text = expression;
        }
    }
}
