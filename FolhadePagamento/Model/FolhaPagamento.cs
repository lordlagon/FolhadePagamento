using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhadePagamento.Model
{
    class FolhaPagamento
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int HorasTrabalhadas { get; set; }
        public Double ValorHora { get; set; }
        public Funcionario Funcionario { get; set; }
        public Salario Salario { get; set; }
        public Double SalarioBruto { get; set; }

        public FolhaPagamento()
        {
            Funcionario = new Funcionario();
            Salario = new Salario();
        }

        public override string ToString()
        {
            return "\nFolha de Pagamento: Mês: " + Mes + " Ano: " + Ano + "\n--------------------------------------\n\nFuncionario: " + Funcionario.Nome + "\nSalário Bruto: " + SalarioBruto.ToString("C2") + "\n\n" + Salario + "\n--------------------------------------\n";
        }
    }
}
