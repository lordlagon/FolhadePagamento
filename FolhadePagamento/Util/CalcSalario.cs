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

        public static Salario CalcFGTS(FolhaPagamento folha)
        {
            Salario salario = new Salario();
            salario.Fgts = folha.SalarioBruto - (folha.SalarioBruto * 0.08);
            return salario;
        }
        //Tabela Calculo INSS huashhuhasshuda

        public static Salario CalcINSS(FolhaPagamento folha)
        {
            Salario salario = new Salario();
            if (folha.SalarioBruto < 1659.38)
            {
                salario.Inss = folha.SalarioBruto * 0.08;
            }
            if (folha.SalarioBruto >= 1659.39 && folha.SalarioBruto < 2765.66)
            {
                salario.Inss = folha.SalarioBruto * 0.09;
            }
            if (folha.SalarioBruto >= 2765.67 && folha.SalarioBruto <= 5531.31)
            {
                salario.Inss = folha.SalarioBruto * 0.11;
            }
            if (folha.SalarioBruto > 5531.31)
            {
                salario.Inss = 608.44;
            }
            return salario;
        }

        public static Salario CalcImpRenda(FolhaPagamento folha)
        {
            Salario salario = new Salario();
            if (folha.SalarioBruto < 1903.98)
            {
                salario.ImpRenda = folha.SalarioBruto;
            }
            if (folha.SalarioBruto >= 1903.99 && folha.SalarioBruto < 2826.65)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * 0.075) - 142.80);
            }
            if (folha.SalarioBruto >= 2826.66 && folha.SalarioBruto <= 3751.05)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * 0.15) - 354.80);
            }
            if (folha.SalarioBruto >= 3751.06 && folha.SalarioBruto <= 4664.68)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * 0.225) - 636.13);
            }
            if (folha.SalarioBruto > 4664.68)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * 0.275) - 869.36);
            }
            return salario;

        }

        public static Salario CalcLiquido(FolhaPagamento folha)
        {
            Salario salario = new Salario();

                  salario.SalarioLiquido = folha.SalarioBruto- salario.ImpRenda - salario.Inss  ;

            return salario;



        }
    }
}
