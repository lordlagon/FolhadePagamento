using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FolhadePagamento.Model
{
    class Salario
    {
        public double SalarioBruto { get; set; }
        public double ImpostoRenda { get; set; }
        public double Inss { get; set; }
        public double Fgts { get; set; }
        public double SalarioLiquido { get; set; }

        
    }
}
