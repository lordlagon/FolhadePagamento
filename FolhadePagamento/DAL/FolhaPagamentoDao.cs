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

        public static bool AdicionarFolha (FolhaPagamento folhaPagamento)
        {
            if (BuscarFolha(folhaPagamento) != null)
            {
                folhasdepagamento.Add(folhaPagamento);
                return true;
            }
            return false;
        }
        /*public static FolhaPagamento BuscarFolha(FolhaPagamento folhaPagamento)
        {
            foreach (FolhaPagamento folhaCadastrado in folhasdepagamento)
            {
                if (folhaPagamento.Mes.Equals(folhaCadastrado.Mes))
                {
                    if (folhaPagamento.Ano.Equals(folhaCadastrado.Ano))
                    {
                        if (folhaPagamento.Funcionario.Equals(folhaCadastrado.Funcionario))
                        {
                            return folhaCadastrado;
                        }
                         
                    }
                    
                }
              
            }
            return null;


        }*/


        /*  public static void AdicionarFolha(FolhaPagamento folha)
          {
              folhasdepagamento.Add(folha);
          }*/
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
