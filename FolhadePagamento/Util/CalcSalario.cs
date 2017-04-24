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
            folha.Salario.Fgts = folha.SalarioBruto * 0.08;
            return folha.Salario;
        }
        //Tabela Calculo INSS huashhuhasshuda

        public static Salario CalcINSS(FolhaPagamento folha)
        {
            if (folha.SalarioBruto < 1659.38)
            {
                folha.Salario.Inss = folha.SalarioBruto * 0.08;
            }
            if (folha.SalarioBruto >= 1659.39 && folha.SalarioBruto < 2765.66)
            {
                folha.Salario.Inss = folha.SalarioBruto * 0.09;
            }
            if (folha.SalarioBruto >= 2765.67 && folha.SalarioBruto <= 5531.31)
            {
                folha.Salario.Inss = folha.SalarioBruto * 0.11;
            }
            if (folha.SalarioBruto > 5531.31)
            {
                folha.Salario.Inss = 608.44;
            }
            return folha.Salario;
        }

        public static Salario CalcImpRenda(FolhaPagamento folha)
        {
            if (folha.SalarioBruto < 1903.98)
            {
                folha.Salario.ImpRenda = 0;
            }
            if (folha.SalarioBruto >= 1903.99 && folha.SalarioBruto < 2826.65)
            {
                folha.Salario.ImpRenda = (folha.SalarioBruto * 0.075) - 142.80;
            }
            if (folha.SalarioBruto >= 2826.66 && folha.SalarioBruto <= 3751.05)
            {
                folha.Salario.ImpRenda = (folha.SalarioBruto * 0.15) - 354.80;
            }
            if (folha.SalarioBruto >= 3751.06 && folha.SalarioBruto <= 4664.68)
            {
                folha.Salario.ImpRenda = (folha.SalarioBruto * 0.225) - 636.13;
            }
            if (folha.SalarioBruto > 4664.68)
            {
                folha.Salario.ImpRenda = (folha.SalarioBruto * 0.275) - 869.36;
            }
            return folha.Salario;

        }

        public static Salario CalcLiquido(FolhaPagamento folha)
        {
            folha.Salario.SalarioLiquido = folha.SalarioBruto - folha.Salario.ImpRenda - folha.Salario.Inss;

            return folha.Salario;


            //ihhhhhhh rapaz olha quem debugou essa porra
        }
    }
}
