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
                Console.WriteLine("\n        ______________Folha de Pagamento_______________");
                Console.WriteLine("         |                                               |");
                Console.WriteLine("         |   1 - Cadastro de Funcionários                |");
                Console.WriteLine("         |   2 - Lista de Funcionários                   |");
                Console.WriteLine("         |   3 - Cadastro Folha de Pagamento             |");
                Console.WriteLine("         |   4 - Consultar Folha de Pagamento            |");
                Console.WriteLine("         |   5 - Listar Folhas de Pagamento              |");
                Console.WriteLine("         |   0 - Sair                                    |");
                Console.WriteLine("         |_______________________________________________|");
                Console.WriteLine("\nDigite a opção desejada: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    //Cadastro de Funcionário
                    case "1":
                        funcionario = new Funcionario();
                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Funcionario -- \n");
                        Console.WriteLine("Digite o nome do Funcionario: ");
                        funcionario.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do funcionario: ");
                        funcionario.Cpf = Console.ReadLine();

                        //Valida o CPF antes de Adicionar o Funcionário
                        if (Util.ValidaCPF.Cpf(Convert.ToInt64(funcionario.Cpf)) == true)
                        {
                            if (FuncionarioDao.AdicionarFuncionario(funcionario) == true)
                            {
                                Console.WriteLine("Funcionario gravado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar o Funcionario!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("CPF Inválido");
                        }
                        break;
                    case "2":
                        //Lista todos os funcionarios Cadastrados
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



