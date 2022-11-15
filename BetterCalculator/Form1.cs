using System;
using System.Data;
using System.Linq;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Removes all chars from the end of the expression string up to and including the operator
        /// </summary>
        private void RemoveUntilOperator()
        {
            char[] operators = { '+', '-', '*', '/' };

            // outer backwards for loop sets i to the index of the char at the end of the expression
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                // forwards inner for loop checks the char at index i and compares it to the current index j in the operators array
                for (int j = 0; j < operators.Length; j++)
                {
                    //if the char at index i is an operator then remove it and exit both loops
                    if(expression[i] == operators[j])
                    {
                        expression = expression.Remove(i, 1);
                        return;
                    }
                }
                // if the char at index i is not an operator then remove it.
                expression = expression.Remove(i, 1);
            }


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
                    RemoveUntilOperator();
                    break;
                case "=":
                    DataTable dt = new DataTable();
                    // goes through the entire expression string and computes the result
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
