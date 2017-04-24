using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FolhadePagamento.Model
{
    class Salario
    {
        public double ImpRenda { get; set; }
        public double Inss { get; set; }
        public double Fgts { get; set; }
        public double SalarioLiquido { get; set; }

        public override string ToString()
        {
            return " Imposto de renda: " + ImpRenda + " Inss: " + Inss + " Fgts: " + Fgts + " Salario liquido: " + SalarioLiquido;
        }
    }
}
