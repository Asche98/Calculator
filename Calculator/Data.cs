using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Data
    {
        // СС - система счисления
        int StartNotation; // СС из которой переводится число
        int EndNotation;   // СС в которую переводится число
        string Number;     // заданное число

        public int GetStartNotation
        {
            get { return StartNotation; }
            set { StartNotation = value; }
        }
        public int GetEndNotation
        {
            get { return EndNotation; }
            set { EndNotation = value; }
        }
        public string GetNumber
        {
            get { return Number; }
            set { Number = value; }
        }

        public bool CorrectNumber(string number, int startNotation)    // проверка числа на соответствие заданной СС
        {
            int[] arr = FormArray(number);
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] >= startNotation) return false;
            return true;
        }

        private static int[] FormArray(string number) // разбиение полученной строки (числа) на символы (цифры)
        {
            int posDot = number.IndexOf(",");
            int length;                             // длина числа без запятой
            if (posDot == -1)
                length = number.Length;
            else
                length = number.Length - 1;
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)        // создание массива символов заданного числа
            {
                if (posDot == -1)
                {
                    if (number[i] == 'A' || number[i] == 'a') arr[i] = 10;
                    else
                      if (number[i] == 'B' || number[i] == 'b') arr[i] = 11;
                    else
                      if (number[i] == 'C' || number[i] == 'c') arr[i] = 12;
                    else
                      if (number[i] == 'D' || number[i] == 'd') arr[i] = 13;
                    else
                      if (number[i] == 'E' || number[i] == 'e') arr[i] = 14;
                    else
                      if (number[i] == 'F' || number[i] == 'f') arr[i] = 15;
                    else
                        arr[i] = Convert.ToInt32(Convert.ToString(number[i]));
                }
                else
                {
                    if (i < posDot)
                    {
                        if (number[i] == 'A' || number[i] == 'a') arr[i] = 10;
                        else
                        if (number[i] == 'B' || number[i] == 'b') arr[i] = 11;
                        else
                        if (number[i] == 'C' || number[i] == 'c') arr[i] = 12;
                        else
                        if (number[i] == 'D' || number[i] == 'd') arr[i] = 13;
                        else
                        if (number[i] == 'E' || number[i] == 'e') arr[i] = 14;
                        else
                        if (number[i] == 'F' || number[i] == 'f') arr[i] = 15;
                        else
                            arr[i] = Convert.ToInt32(Convert.ToString(number[i]));
                    }
                    else
                    {
                        if (number[i + 1] == 'A' || number[i] == 'a') arr[i] = 10;
                        else
                    if (number[i + 1] == 'B' || number[i] == 'b') arr[i] = 11;
                        else
                    if (number[i + 1] == 'C' || number[i] == 'c') arr[i] = 12;
                        else
                    if (number[i + 1] == 'D' || number[i] == 'd') arr[i] = 13;
                        else
                    if (number[i + 1] == 'E' || number[i] == 'e') arr[i] = 14;
                        else
                    if (number[i + 1] == 'F' || number[i] == 'f') arr[i] = 15;
                        else
                            arr[i] = Convert.ToInt32(Convert.ToString(number[i + 1]));
                    }
                }

            }
            return arr;
        }

        private static double ConvertionToDecimal(int startNotation, string number) // перевод из любой СС в десятичную
        {
            int posDot = number.IndexOf(",");
            double res = 0;
            int[] arr = FormArray(number);
            if (posDot == -1)
            {
                int degree = arr.Length - 1;
                for (int i = 0; i < arr.Length; i++)
                {
                    res = res + arr[i] * Math.Pow(startNotation, degree);
                    degree--;
                }
                return res;
            }
            else
            {
                int degreeLeft = posDot - 1;
                int degreeRight = -1;
                for (int i = 0; i < posDot; i++)
                {
                    res = res + arr[i] * Math.Pow(startNotation, degreeLeft);
                    degreeLeft--;
                }
                for (int j = posDot; j < arr.Length; j++)
                {
                    res = res + arr[j] * Math.Pow(startNotation, degreeRight);
                    degreeRight--;
                }
                return res;
            }
        }

        static string letter = "ABCDEF";
        private static string FormResultNumber(string sym)
        {
            string s = "";
            if (Convert.ToInt32(sym) > 10)
                s += letter.Substring(Convert.ToInt32(sym) - 10, 1);
            else
                s += sym;
            return s;
        }

        public static string ConvertionFromDecimal(int startNotation, int endNotation, string number) // перевод из десятичной СС в любую
        {
            double decimalNumber = ConvertionToDecimal(startNotation, number);
            string decNum = Convert.ToString(decimalNumber);
            int posDot = decNum.IndexOf(",");
            int[] arr = FormArray(decNum);
            double left = 0, right = 0;
            string res;
            if (posDot == -1)
            {
                res = "";
                int num = Convert.ToInt32(decimalNumber);
                int chast = Convert.ToInt32(decimalNumber);
                ArrayList numTemp = new ArrayList();
                while (chast > 0)
                {
                    chast = chast / endNotation;
                    numTemp.Add(num - chast * endNotation);
                    num = chast;
                }
                int j;
                for (j = numTemp.Count - 1; j >= 0; j--)
                    res += FormResultNumber(numTemp[j].ToString());
            }
            else
            {
                string leftStr = "";
                for (int i = 0; i < posDot; i++)
                    leftStr = leftStr + arr[i];
                left = Convert.ToInt32(leftStr);
                right = decimalNumber - left;

                string newNum = "";
                int num = Convert.ToInt32(left);
                int chast = Convert.ToInt32(left);
                ArrayList numTemp = new ArrayList();
                while (chast > 0)
                {
                    chast = chast / endNotation;
                    numTemp.Add(num - chast * endNotation);
                    num = chast;
                }
                int j;
                for (j = numTemp.Count - 1; j >= 0; j--)
                    newNum += FormResultNumber(numTemp[j].ToString());

                string newNumR = "";
                double temp = right;
                ArrayList numTempR = new ArrayList();
                for (int i = 0; i < 8; i++)
                {
                    temp = temp * endNotation;
                    string tempStr = Convert.ToString(temp);
                    if (tempStr.IndexOf(",") != -1)
                    {
                        numTempR.Add(tempStr.Substring(0, tempStr.IndexOf(",")));
                        temp = temp - Convert.ToInt32(tempStr.Substring(0, tempStr.IndexOf(",")));
                    }
                    else
                    {
                        numTempR.Add(tempStr.Substring(0));
                        break;
                    }
                }
                for (j = 0; j < numTempR.Count; j++)
                    newNumR += FormResultNumber(numTempR[j].ToString());

                res = newNum + "," + newNumR;

            }
            return res;
        }
    }
}
