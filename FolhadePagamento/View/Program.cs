using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.DAL;
using FolhadePagamento.Model;

namespace FolhadePagamento.View
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = null;
            Funcionario funcionario = new Funcionario();
            FolhaPagamento folhaPagamento = new FolhaPagamento();

            do
            {
                Console.Clear();
                Console.WriteLine(" -- ");
            } while (!opcao.Equals("0"));

        }
    }
}
