using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhadePagamento.Util
{
    class ValidaMesAno
    {
        public static bool ValidaAno(int ano)
        {
            if (ano < 1950 || ano < DateTime.Now.Year + 1)
            {
                return true;
            }
            return false;
            
        }

        public static bool ValidaMes(int mes)
        {
            if (mes > 12)
            {
                return false;
            }
            return true;

        }

    }
}
