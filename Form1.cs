using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCalculator
{
    public partial class Form1 : Form
    {
        OPS C = new OPS();

        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtOutPut.Focus();
            C.OP1 = 0; 
            C.OP2 = 0;
            C.OP = "";
            C.State = 0; 
            
        }
   
        private void button7_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "7",ref C);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "8",ref C);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "9",ref C);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "4",ref C);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "5",ref C );
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "6",ref C);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "1",ref C);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "2",ref C);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "3",ref C);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "0",ref C);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //already a decimal point in operand? if so, ignore
            if (txtOutPut.Text.Contains(".")) return;
            //put one in if none there yet
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, ".",ref C);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
   
            //record OP1 and OP in history
            if (C.State == 3) 
            { //record full equation in history
                hist0.Text = hist0.Text + txtOutPut.Text; 
            }
                hist0.Text = txtOutPut.Text + "-";
            if (C.State !=2)
            {
                txtOutPut.Text = Calc.NegButtonPush(txtOutPut.Text,ref C);
            }
            else
            {
                C.State = 3;
                txtOutPut.Text = "-";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            hist0.Text += txtOutPut.Text;
            txtOutPut.Text = Calc.Equals(txtOutPut.Text, ref C);
        }

        private void button11_Click(object sender, EventArgs e)
        {//clear button
            txtOutPut.Text = "";
            hist0.Text= txtOutPut.Text;
            C.State = 0;

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (C.State == 1 | C.State == 3)
            {
                hist0.Text = txtOutPut.Text + "+";
                txtOutPut.Text = Calc.PlusButtonPush(txtOutPut.Text, ref C);
            }
            
        }

        
    }
}
