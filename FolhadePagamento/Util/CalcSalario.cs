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
            return folha.SalarioBruto * 0.08;
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



    }
}
