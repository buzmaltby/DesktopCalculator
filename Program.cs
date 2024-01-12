using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesktopCalculator
{
    internal static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
    public struct OPS
    {
        public double OP1;//operand 1
        public double OP2;//operand 2
        public string OP;//operator 
        //state 0 waiting for first character of OP1
        public int State;//getting OP1
      
        

    }


    public class Calc
    {

        public static string NumberButtonPush(string txt, string newnum, ref OPS C)
        {
            if (C.State == 0)//state 0
               { C.State = 1; return newnum; }//first digit of OP1

            if (C.State == 2) 
            { C.State = 3;  return newnum; }//first digit of OP2
            //states 1 and 3 keep concatenating
            return txt + newnum;
        }
        public static string DivideButtonPush(string txt, ref OPS C)
        {
            string result;
            if (C.State == 3)
            {
                if (!double.TryParse(txt, out C.OP2))//convert to double
                    return ("Error. Not a number");
                result = DoCalc(ref C);
                return result;
            } //else state 1. set OP1 
            C.OP = "/";
            if (!double.TryParse(txt, out C.OP1))//convert to double
                return ("Error. Not a number");

            result = ""; //return blank to await operand 2
            return result;

        }
        public static string MultiplyButtonPush(string txt, ref OPS C)
        {
            string result;
            if(C.State==3)
            { //do the pending operation
                if (!double.TryParse(txt, out C.OP2))//convert to double
                    return ("Error. Not a number");
                result = DoCalc(ref C);
                return result;
            }//else state 1. set OP1
            C.OP = "*";
            if (!double.TryParse(txt, out C.OP1))//convert to double
                return ("Error. Not a number");

            result = ""; //return blank to await operand 2
            return result;

        }
        public static string PlusButtonPush(string txt,ref OPS C)
        {
            string result;
            if (C.State == 3) //stringing together operations
            {
                if (!double.TryParse(txt, out C.OP2))//convert to double
                    return ("Error. Not a number");
                result = DoCalc(ref C);
                return result;
            }//else state 1. set OP1
            C.OP = "+"; //store operator
            if (!double.TryParse(txt, out C.OP1))//convert to double
                return ("Error. Not a number");

            result = ""; //return blank to await operand 2
            return result;

        }
        public static string NegButtonPush(string txt,ref OPS C)
        { // only call this in state1 or state3
            string result;
            if (C.State == 1)//state 1
            {
                if (!double.TryParse(txt, out C.OP1))//convert to double
                    return ("Error. Not a number");
                //store current entry 
                C.OP = "-";// doing subtraction. store operand 1 and operator
                C.State = 2;
                //move to state 2
                return ("");//clear input for second operand
            }
            else // (C.State == 3)//going to do another subtraction
            {
                if (!double.TryParse(txt, out C.OP2))//convert to double
                    return ("Error. Not a number");
                //**** review the following!!!
                result = DoCalc(ref C); //do the calulation
                //store the operand
               //go to state 2 waiting for another subtrahend
                C.State = 2;
                return result;
            }
        }
        public static string DoCalc(ref OPS C)

        {
            double CalcResult;
            if (C.OP == "+")//add
                CalcResult = C.OP1 + C.OP2;
            else if (C.OP == "-")//subtract
                CalcResult = C.OP1 - C.OP2;
            else if (C.OP == "*")//multiply
                CalcResult = C.OP1 * C.OP2;
            else //if (C.OP == "/")//divide
                try
                { CalcResult = C.OP1 / C.OP2; }
                catch //oops, div by 0
                {
                    CalcResult = 0;
                    //make em start over at state 0
                    C.OP = "";
                    C.OP2 = 0;
                    C.OP1 = 0;
                    C.State = 0;
                    
                    return "div 0 ERROR";
                }
            C.State = 2;//go to state 2
 
            C.OP1 = CalcResult;//put result in OP1
            C.OP2 = 0;
 
            return CalcResult.ToString();


        }
        public static string Equals(string txt, ref OPS C)
        {
            string result;
            if (!double.TryParse(txt, out C.OP2))//convert to double
                return ("Error. Not a number");
            result = DoCalc(ref C); //string for the return
                                //first reset C values
            if (!double.TryParse(txt, out C.OP1))
                return ("Error");
            C.OP = "";
            C.OP2 = 0;
            return result;



        }
        public static bool ClearOPS(ref OPS C )
        {
            C.OP1 = 0;
            C.OP2 = 0;
            C.OP = "";
            return true;
        }


    }
}
