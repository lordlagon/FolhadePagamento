using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;

namespace FolhadePagamento.Util
{
    class ValidaCPF
    {

        /*Valida o CPF utilizando o Mod
        public static bool Cpf(int cpf)
        {
            string strCpf = cpf.ToString().PadLeft(11, '0');

            if (strCpf.All(x => x == strCpf[0]))
                return false;

            var listCpf = strCpf.Select(num => ToInt32(num.ToString())).ToList();

            if (listCpf[9] != Mod11Cpf(listCpf, 10))
                return false;

            if (listCpf[10] != Mod11Cpf(listCpf, 11))
                return false;

            return true;
        }

        internal static int Mod11Cpf(List<int> elementos, int @base)
        {
            int soma = 0;
            for (int i = 0; i < (@base - 1); i++)
                soma += (@base - i) * elementos[i];

            int dv1, resto = soma % 11;

            if (resto < 2)
                dv1 = 0;
            else
                dv1 = 11 - resto;

            return dv1;
        }*/

        public static bool Cpf(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }

    }
}