using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.Model;

namespace FolhadePagamento.DAL
{
    class FolhaPagamentoDao
    {
        private static List<FolhaPagamento> folhasdepagamento = new List<FolhaPagamento>();

        public static void AdicionarFolha(FolhaPagamento folha)
        {
            folhasdepagamento.Add(folha);
        }

        public static List<FolhaPagamento> RetornarLista()
        {
            return folhasdepagamento;
        }

        public static List<FolhaPagamento> BuscarFolha(FolhaPagamento folhaPagamento)
        {
            List<FolhaPagamento> folhasAuxFuncionario = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaCadastrada in folhasdepagamento)
            {
                if (folhaCadastrada.Mes.Equals(folhaPagamento.Mes) && folhaCadastrada.Ano.Equals(folhaPagamento.Ano) && folhaPagamento.Funcionario.Cpf.Equals(folhaPagamento.Funcionario.Cpf))
                {
                    folhasAuxFuncionario.Add(folhaCadastrada);
                }
            }
            return folhasAuxFuncionario;
        }
    }
}
