﻿using System;
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
                        junk = Calc.NegButtonPush(txtOutPut.Text,ref  C);
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
                        break;
                    }
                   

            }
 
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            hist0.Text += txtOutPut.Text;
            txtOutPut.Text = Calc.Equals(txtOutPut.Text, ref C);
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