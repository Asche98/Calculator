using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public bool SuitableNumber(string Number, int SS) // проверка числа на соответствие его СС
        {
            long chislo;
            try
            {
                chislo = Convert.ToInt64(Number, SS);
                return true;
            }
            catch (Exception) { return false; }
        }

        public static string Result(string Number, string SS1, string SS2)
        {
            string res = "";
            if (SS1 == "" || SS2 == "" || Number == "")
            {
                System.Windows.Forms.MessageBox.Show("Не все данные указаны.", "Ошибка");
                return "";
            }
            else
            {
                int S1 = Convert.ToInt32(SS1);
                int S2 = Convert.ToInt32(SS2);
                if (!Data.CorrectNumber(Number, S1))
                {
                    System.Windows.Forms.MessageBox.Show("Неверный формат.", "Ошибка");
                    return "";
                }
                else
                {
                    res = Convert.ToString(Data.ConvertionToDecimal(S1, Number));
                    res = Data.ConvertionFromDecimal(S1, S2, res);
                    return res;
                }
            }
        }
    }
}
