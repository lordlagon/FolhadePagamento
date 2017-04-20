using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.Model;

namespace FolhadePagamento.Util
{
    class CalcSalario
    {
        




        public static double CalcSalarioBruto(FolhaPagamento folha)
        {
            return folha.HorasTrabalhadas * folha.ValorHora;
        }

        //Tabela Calculo INSS

        
        public static Salario CalcINSS(Salario salario)
        {
            if (salario.SalarioBruto < 1659.38)
            {
                salario.Inss = salario.SalarioBruto * 0.08;
            }
            if (salario.SalarioBruto >= 1659.39 && salario.SalarioBruto < 2765.66)
            {
                salario.Inss = salario.SalarioBruto * 0.09;
            }
            if (salario.SalarioBruto >= 2765.67 && salario.SalarioBruto <= 5531.31)
            {
                salario.Inss = salario.SalarioBruto * 0.11;
            }
            if (salario.SalarioBruto > 5531.31)
            {
                salario.Inss = 608.44;
            }

            return salario;
        }
        /*  
        a) Salário Bruto
        b) Imposto de Renda
        c) INSS
        d) FGTS
        e) Salário Líquido


    public static Salario salario
        {
        }*/
    }
}
