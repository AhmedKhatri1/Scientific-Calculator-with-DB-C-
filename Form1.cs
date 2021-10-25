using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPLFinalProject
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operation = "";
        Boolean enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 342;
            textBox_result.Width = 308;
        }
        private void nobutton_click(object sender, EventArgs e)
        {
            if ((textBox_result.Text == "0") || (enterValue))
            {
                textBox_result.Text = "";
            }
            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_result.Text.Contains("."))
                {
                    textBox_result.Text = textBox_result.Text + button.Text;
                }
            }
            else
            {
                textBox_result.Text = textBox_result.Text + button.Text;
            }
        }
        private void operator_click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text;
            resultValue = Double.Parse(textBox_result.Text);
            textBox_result.Text = "";
            labelCurrentOperation.Text = System.Convert.ToString(resultValue) + " " + operation;

            /*Button button = (Button)sender;
            if (resultValue != 0)
            {
                button19.PerformClick();
                operation = button.Text;
                labelCurrentOperation.Text = System.Convert.ToString(resultValue) + " " + operation;
                //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                enterValue = true;
            }
            else
            {
                operation = button.Text;
                resultValue = Double.Parse(textBox_result.Text);
                labelCurrentOperation.Text = System.Convert.ToString(resultValue) + " " + operation;
                //labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                enterValue = true;
            }*/
        }
        private void clearEntry_click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
        }
        private void clear_click(object sender, EventArgs e)
        {
            textBox_result.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }
        private void equalsTo_click(object sender, EventArgs e)
        {
            labelCurrentOperation.Text = "";
            switch (operation)
            {
                case "*":
                    textBox_result.Text = (resultValue * Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "+":
                    textBox_result.Text = (resultValue + Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "-":
                    textBox_result.Text = (resultValue - Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "/":
                    textBox_result.Text = (resultValue / Double.Parse(textBox_result.Text)).ToString();
                    break;
                case "x^2":
                    Double a;
                    a = Convert.ToDouble(textBox_result.Text) * Convert.ToDouble(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString(a);
                    break;
                case "x^3":
                    Double b;
                    b = Convert.ToDouble(textBox_result.Text) * Convert.ToDouble(textBox_result.Text) * Convert.ToDouble(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString(b);
                    break;
                case "%":
                    Double c;
                    c = Convert.ToDouble(textBox_result.Text) / Convert.ToDouble(100);
                    textBox_result.Text = System.Convert.ToString(c);
                    break;
                case "Sq.rt":
                    Double sq = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("Sq" + "(" + (textBox_result.Text) + ")");
                    sq = Math.Sqrt(sq);
                    textBox_result.Text = System.Convert.ToString(sq);
                    break;
                case "log":
                    Double ilog = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("log" + "(" + (textBox_result.Text) + ")");
                    ilog = Math.Log10(ilog);
                    textBox_result.Text = System.Convert.ToString(ilog);
                    break;
                case "Sin":
                    Double Sin = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("sin" + "(" + (textBox_result.Text) + ")");
                    Sin = Math.Sin(Sin);
                    textBox_result.Text = System.Convert.ToString(Sin);
                    break;
                case "Sinh":
                    Double Sinh = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("sinh" + "(" + (textBox_result.Text) + ")");
                    Sinh = Math.Sinh(Sinh);
                    textBox_result.Text = System.Convert.ToString(Sinh);
                    break;
                case "Cos":
                    Double Cos = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("cos" + "(" + (textBox_result.Text) + ")");
                    Cos = Math.Cos(Cos);
                    textBox_result.Text = System.Convert.ToString(Cos);
                    break;
                case "Cosh":
                    Double Cosh = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("cosh" + "(" + (textBox_result.Text) + ")");
                    Cosh = Math.Cosh(Cosh);
                    textBox_result.Text = System.Convert.ToString(Cosh);
                    break;
                case "Tan":
                    Double Tan = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("tan" + "(" + (textBox_result.Text) + ")");
                    Tan = Math.Tan(Tan);
                    textBox_result.Text = System.Convert.ToString(Tan);
                    break;
                case "Tanh":
                    Double Tanh = Double.Parse(textBox_result.Text);
                    textBox_result.Text = System.Convert.ToString("tanh" + "(" + (textBox_result.Text) + ")");
                    Tanh = Math.Tanh(Tanh);
                    textBox_result.Text = System.Convert.ToString(Tanh);
                    break;
                default:
                    break;
            }

            resultValue = Double.Parse(textBox_result.Text);
            labelCurrentOperation.Text = resultValue.ToString();

            DataClasses1DataContext dv = new DataClasses1DataContext();

            calculator cad = new calculator
            {
                results = resultValue.ToString(textBox_result.Text)
            };

            dv.calculators.InsertOnSubmit(cad);
            dv.SubmitChanges();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 342;
            textBox_result.Width = 308;
        }
        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 451;
            textBox_result.Width = 412;
        }
        private void labelCurrentOperation_Click(object sender, EventArgs e)
        {

        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSpace_click(object sender, EventArgs e)
        {
            if (textBox_result.Text.Length > 0)
            {
                textBox_result.Text = textBox_result.Text.Remove(textBox_result.Text.Length - 1, 1);
            }
            if (textBox_result.Text == "")
            {
                textBox_result.Text = "0";
            }
        }
    }
}
