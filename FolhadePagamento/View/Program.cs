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
                Console.WriteLine("\n          _______________Folha de Pagamento_____________");
                Console.WriteLine("         |                                               |");
                Console.WriteLine("         |   1 - Cadastro de Funcionários                |");
                Console.WriteLine("         |   2 - Lista de Funcionários                   |");
                Console.WriteLine("         |   3 - Cadastro de Vendedor                    |");
                Console.WriteLine("         |   4 - Lista de Vendedores                     |");
                Console.WriteLine("         |   5 - Cadastro de Produto                     |");
                Console.WriteLine("         |   6 - Lista de Produtos                       |");
                Console.WriteLine("         |   7 - Registrar vendas                        |");
                Console.WriteLine("         |   8 - Listar vendas                           |");
                Console.WriteLine("         |   9 - Listar vendas por cliente               |");
                Console.WriteLine("         |   10 - Listar vendas por Endereço             |");
                Console.WriteLine("         |   11 - Cadastrar Endereço                     |");
                Console.WriteLine("         |   12 - Listar Endereço                        |");
                Console.WriteLine("         |   13 - Registro de Horario para Entrega       |");
                Console.WriteLine("         |   14 - Registro de Compras por Horario        |");
                Console.WriteLine("         |   15 - Cadastrar Forma de Pagamento           |");
                Console.WriteLine("         |   16 - Listar Compras por forma de Pagamento  |");
                Console.WriteLine("         |   0 - Sair                                    |");
                Console.WriteLine("         |_______________________________________________|");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        funcionario = new Funcionario();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Funcionario -- \n");
                        Console.WriteLine("Digite o nome do Funcionario: ");
                        funcionario.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do funcionario: ");
                        funcionario.Cpf = Console.ReadLine();
                        if (Util.ValidaCPF.Cpf(Convert.ToInt32(funcionario.Cpf)) == true)
                        {
                            if (FuncionarioDao.AdicionarFuncionario(funcionario) == true)
                            {
                                Console.WriteLine("Funcionario gravado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar o Funcionario!");
                            }
                        }else
                        {
                            Console.WriteLine("CPF Inválido");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(" -- Listar Funcionario -- \n");
                        foreach (Funcionario funcionarioCadastrado in FuncionarioDao.RetornarLista())
                        {
                            Console.WriteLine("Funcionário: " + funcionarioCadastrado);
                        }
                        break;


                    case "0":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
                Console.WriteLine("Aperte uma tecla para continuar");
                Console.ReadKey();
            

            } while (!opcao.Equals("0"));
        }
    }
}



