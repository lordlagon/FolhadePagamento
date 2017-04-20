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
        public double ValorHora { get; set; }
        public Funcionario Funcionario { get; set; }
        //public Salario Salario { get; set; }

        public FolhaPagamento()
        {
            Funcionario = new Funcionario();
            //Salario = new Salario();
        }

        public override string ToString()
        {
            return "Mês: " + Mes + " Ano: " + Ano + " Funcionario: " + Funcionario;
                        
        }
    }
}
