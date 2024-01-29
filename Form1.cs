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
using static System.Net.Mime.MediaTypeNames;

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
            C.MEM = 0;
            
        }
   
        private void button7_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "7",ref C);
            btnEqual.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "8",ref C);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "9",ref C);
            btnEqual.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "4",ref C);
            btnEqual.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "5",ref C );
            btnEqual.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "6",ref C);
            btnEqual.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "1",ref C);
            btnEqual.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "2",ref C);
            btnEqual.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "3",ref C);
            btnEqual.Focus();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txtOutPut.Text = Calc.NumberButtonPush(txtOutPut.Text, "0",ref C);
            btnEqual.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Decimal();
            btnEqual.Focus();
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
                        
                        txtOutPut.Text = "-";
                        C.State = 1;
                        break;
                    }
                case 1:
                    {//doing a subtraction 
                        
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
                        hist0.Text = Calc.UpdateHistory(ref C, 2, txtOutPut.Text);
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
            btnEqual.Focus();
        }
        private void EqualSign()
        {
            hist0.Text =Calc.UpdateHistory(ref C, 2, txtOutPut.Text);
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
            btnEqual.Focus();

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
                        junk = Calc.PlusButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "+";
                        break;
                    }
                case 3:
                    {
                        //do the pending operation and start an addition
                        hist0.Text = Calc.UpdateHistory(ref C, 2, txtOutPut.Text);
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
            btnEqual.Focus();
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
                        junk = Calc.MultiplyButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "*";
                        break;
                        //save the multiply for later

                    }
                case 3:
                    {
                        //do the pending operation and start a multiply
                        hist0.Text = Calc.UpdateHistory(ref C, 2, txtOutPut.Text);
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
            btnEqual.Focus();
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
                        junk = Calc.DivideButtonPush(txtOutPut.Text, ref C);
                        C.State = 2;
                        C.OP = "/";
                        break;
                    }
                case 3:
                    {
                        //do the pending operation and start a division
                        hist0.Text = Calc.UpdateHistory(ref C, 2, txtOutPut.Text);
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
            btnEqual.Focus();

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
                case ("\b"):
                    BackSpace();
                    break;
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
        private void BackSpace ()
        {
            if (txtOutPut.Text.Length > 0)
            {
                int delpos = txtOutPut.Text.Length - 1;//0based end char
                txtOutPut.Text = txtOutPut.Text.Remove(delpos);
            }

        }
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            BackSpace();
            btnEqual.Focus();
        }

        private void btn_Sqrt_Click(object sender, EventArgs e)
        {
            hist0.Text = Calc.UpdateHistory(ref C, 1, "");
            txtOutPut.Text = Calc.SqrtPush(txtOutPut.Text, ref C);
           
        }

        private void btnMemoryStore_Click(object sender, EventArgs e)
        {

            if (!double.TryParse(txtOutPut.Text, out C.MEM))//convert to doubleC.MEM =txtOutPut.Text;
            {
                txtOutPut.Text = "NaN";
                C.MEM = 0;
            }
            btnEqual.Focus();
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            switch (C.State)
            {
                case 0:
                case 1:
                    {
                        C.OP1 = C.MEM; 
                        txtOutPut.Text=C.OP1.ToString();
                        break;
                    }
                case 2:
                case 3:
                    {
                        C.OP2 = C.MEM;
                        txtOutPut.Text = C.OP2.ToString();
                        break;
                    }
            }
            btnEqual.Focus();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            hist0.Text = Calc.UpdateHistory(ref C, 1, txtOutPut.Text);
            txtOutPut.Text = Calc.InvPush(txtOutPut.Text, ref C);
            btnEqual.Focus();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            C.MEM = 0;
            btnEqual.Focus();
        }
    }
}
