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

        public static double CalcFGTS(FolhaPagamento folha)
        {
            return folha.SalarioBruto * 0.8;
        }
        //Tabela Calculo INSS
        
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
                salario.ImpRenda = folha.SalarioBruto-((folha.SalarioBruto * (7.5/100))-142.80);
            }
            if (folha.SalarioBruto >= 2826.66 && folha.SalarioBruto <= 3751.05)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * (15 / 100)) - 354.80);
            }
            if (folha.SalarioBruto >= 3751.06 && folha.SalarioBruto <= 4664.68)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * (22.5 / 100)) - 636.13);
            }
            if (folha.SalarioBruto > 4664.68)
            {
                salario.ImpRenda = folha.SalarioBruto - ((folha.SalarioBruto * (27.5 / 100)) - 869.36);
            }
            return salario;
        }



    }
}
