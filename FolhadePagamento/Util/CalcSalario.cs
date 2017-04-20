﻿using System;
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
        public static double CalcINSS(FolhaPagamento folha)
        {
            return folha.HorasTrabalhadas * folha.ValorHora;
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
