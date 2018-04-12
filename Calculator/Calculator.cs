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
        
    }
}
