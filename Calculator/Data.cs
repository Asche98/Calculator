using System;
using System.Collections.Generic;
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

        public bool CorrectNumber(string number)    // проверка числа на соответствие заданной СС
        {
            // пример: если число задано в двоичной системе счисления, то оно должно состоять только из 0 и 1
            return true;
        }

        public static int[] FormArray(string number) // разбиение полученной строки (числа) на символы (цифры)
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
            return arr;
        }

        public static double ConvertionToDecimal(int startNotation, string number) // перевод из любой СС в десятичную
        {
            int posDot = number.IndexOf(",");
            double res = 0;
            int[] arr = FormArray(number);
            if (posDot == -1)
            {
                int degree = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    res = res + arr[i] * Math.Pow(startNotation, degree);
                    degree++;
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

        public static string ConvertionFromDecimal(int startNotation, int endNotation, string number) // перевод из десятичной СС в любую
        {
            double decimalNumber = ConvertionToDecimal(startNotation, number);
            return null;
        }
    }
}
