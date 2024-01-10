using DesktopCalculator;
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
            txtOutPut.Enabled = false;
            btnEqual.Focus();
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
            Decimal();
        }
        private void Decimal()
        {
            //already a decimal point in operand? if so, ignore
            if (txtOutPut.Text.Contains(".")) return;
            //put one in if none there yet
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, ".", ref C);

        }
        private void MinusSign()
        {
            string junk; // to receive return value from Calc.NegButtonPush
            switch (C.State)
            {
                case 0:// starting with a negative number
                    {
                        hist0.Text = "-";
                        txtOutPut.Text = "-";
                        C.State = 1;
                        break;
                    }
                case 1:
                    {//doing a subtraction 
                        hist0.Text = hist0.Text + txtOutPut.Text + "-";
                        junk = Calc.NegButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        break;
                    }
                case 2:
                    {   //OP2 will be a negative number
                        txtOutPut.Text = "-";
                        C.State = 3;
                        break;
                    }
                case 3:
                    {//means next op will be a subtraction
                        hist0.Text = hist0.Text + txtOutPut.Text + "-";
                        txtOutPut.Text = Calc.NegButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "-";
                        break;
                    }


            }

        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            MinusSign();
        }
        private void EqualSign()
        {
            hist0.Text += txtOutPut.Text;
            txtOutPut.Text = Calc.Equals(txtOutPut.Text, ref C);
            C.State = 1;
            C.OP = "";

        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            EqualSign();
        }

        private void button11_Click(object sender, EventArgs e)
        {//clear button
            txtOutPut.Text = "0";
            hist0.Text= "";
            C.OP = "";
            C.OP1 = 0;
            C.OP2 = 0;
            C.State = 0;

        }
        private void PlusSign()
        {
            string junk;
            switch (C.State)
            {
                case 0: break; //ignore. not a valid entry
                case 2: break;
                case 1:
                    {
                        //doing an addition
                        hist0.Text = txtOutPut.Text + "+";
                        junk = Calc.PlusButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "+";
                        break;
                    }
                case 3:
                    {
                        //do the pending operation and start an addition
                        hist0.Text = hist0.Text + txtOutPut.Text + "+";
                        txtOutPut.Text = Calc.PlusButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "+";
                        break;
                    }

            }
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            PlusSign();
        }
        private void MultiplySign()
        {
            string junk;
            switch (C.State)
            {
                case 0: break;
                case 2: break;
                case 1:
                    {
                        //doing a multiplication
                        hist0.Text = txtOutPut.Text + "*";
                        junk = Calc.MultiplyButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "*";
                        break;
                        //save the multiply for later

                    }
                case 3:
                    {
                        //do the pending operation and start a multiply
                        hist0.Text = hist0.Text + txtOutPut.Text + "*";
                        txtOutPut.Text = Calc.DivideButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "*";
                        break;

                    }

            }

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            MultiplySign();
        }
        private void DivSign()
        {
            string junk;
            switch (C.State)
            {
                case 0: break;
                case 2: break;
                case 1:
                    {
                        //doing a division
                        hist0.Text = txtOutPut.Text + "/";
                        junk = Calc.DivideButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "/";
                        break;
                    }
                case 3:
                    {
                        //do the pending operation and start a division
                        hist0.Text = hist0.Text + txtOutPut.Text + "/";
                        txtOutPut.Text = Calc.DivideButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "/"; //store operator

                        break;

                    }
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            DivSign();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            string newstring = "";
            newstring = newstring + e.KeyChar;
            switch (newstring)
            {
                case ("0"):
                case ("1"):
                case ("2"):
                case ("3"):
                case ("4"):
                case ("5"):
                case ("6"):
                case ("7"):
                case ("8"):
                case ("9"):
                    {
                        txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, newstring, ref C);
                        break;
                    }
                case ("."):
                    { Decimal();break; }
                case ("+"):
                    { PlusSign(); break; }
                case ("-"):
                    { MinusSign(); break; }
                case ("*"):
                    { MultiplySign(); break; }
                case ("/"):
                    { DivSign(); break; }
                case ("="):
                    { EqualSign(); break; }
                break;
 

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
