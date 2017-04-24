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

        public static bool AdicionarFolha(FolhaPagamento folhaPagamento)
        {
            if (BuscarFolha(folhaPagamento) != null)
            {
                folhasdepagamento.Add(folhaPagamento);
                return true;
            }
            return false;
        }
        
        public static List<FolhaPagamento> BuscarFolha(FolhaPagamento folhaPagamento)
        {
            List<FolhaPagamento> folhasAuxFuncionario = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaCadastrada in folhasdepagamento)
            {
                if (folhaCadastrada.Mes.Equals(folhaPagamento.Mes) && folhaCadastrada.Ano.Equals(folhaPagamento.Ano) && folhaCadastrada.Funcionario.Cpf.Equals(folhaPagamento.Funcionario.Cpf))
                {
                    return null;
                }
                folhasAuxFuncionario.Add(folhaCadastrada);
            }
            return folhasAuxFuncionario;
        }

        public static List<FolhaPagamento> BuscarFolhaPorMesAnoFunc(FolhaPagamento folhaPagamento)
        {
            List<FolhaPagamento> folhasAuxFuncionario = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaCadastrada in folhasdepagamento)
            {
                if (folhaCadastrada.Mes.Equals(folhaPagamento.Mes) && folhaCadastrada.Ano.Equals(folhaPagamento.Ano) && folhaCadastrada.Funcionario.Cpf.Equals(folhaPagamento.Funcionario.Cpf))
                {
                    folhasAuxFuncionario.Add(folhaCadastrada);
                }
            }
            return folhasAuxFuncionario;
        }
        public static List<FolhaPagamento> BuscarFolhaPorMesAno(FolhaPagamento folhaPagamento)
        {
            List<FolhaPagamento> folhasAuxMesAno = new List<FolhaPagamento>();
            foreach (FolhaPagamento folhaCadastrada in folhasdepagamento)
            {
                if (folhaCadastrada.Mes.Equals(folhaPagamento.Mes) && folhaCadastrada.Ano.Equals(folhaPagamento.Ano))
                {
                    folhasAuxMesAno.Add(folhaCadastrada);
                }
            }
            return folhasAuxMesAno;

        }
        public static List<FolhaPagamento> RetornarLista()
        {
            return folhasdepagamento;
        }
    } 
}
