using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.DAL;
using FolhadePagamento.Model;
using FolhadePagamento.Util;

namespace FolhadePagamento.View
{
    class Program
    {
        static void Main(string[] args)
        {

            Dados.Inicializar();
            string opcao = null;
            Funcionario funcionario = new Funcionario();
            FolhaPagamento folhaPagamento = new FolhaPagamento();
            Salario salario = new Salario();

            do
            {
                Console.Clear();
                Console.WriteLine("\n          ______________Folha de Pagamento_______________");
                Console.WriteLine("         |                                               |");
                Console.WriteLine("         |   1 - Cadastro de Funcionários                |");
                Console.WriteLine("         |   2 - Cadastro Folha de Pagamento             |");
                Console.WriteLine("         |   3 - Consultar Folha de Pagamento            |");
                Console.WriteLine("         |   4 - Listar Folhas de Pagamento              |");
                Console.WriteLine("         |   5 - Listar Funcionarios                     |");
                Console.WriteLine("         |   6 - Listar folha de pagamentos              |");
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
                        funcionario.Cpf = ValidaCPF.maskCpf(Console.ReadLine()); //Valida o CPf e salva com a Mascará

                        if (Util.ValidaCPF.Cpf(funcionario.Cpf) == true)
                        {
                            if (FuncionarioDao.AdicionarFuncionario(funcionario) == true)
                            {
                                Console.WriteLine("Funcionario gravado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Cpf já foi utilizado");
                                Console.WriteLine("Não foi possível adicionar o Funcionario!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("CPF Inválido");
                            Console.WriteLine("Não foi possível adicionar o Funcionario!");
                        }
                        break;

                    case "2":
                        folhaPagamento = new FolhaPagamento();

                        Console.Clear();
                        Console.WriteLine(" -- Cadastrar Folha de Pagamento -- \n");
                        Console.WriteLine("Digite o CPF do funcionario: ");
                        folhaPagamento.Funcionario.Cpf = ValidaCPF.maskCpf(Console.ReadLine());
                        folhaPagamento.Funcionario = FuncionarioDao.BuscarFuncionarioPorCPF(folhaPagamento.Funcionario);

                        if (funcionario != null)
                        {
                            folhaPagamento.Funcionario = funcionario;
                            Console.WriteLine("Digite o Mês da Trabalhado: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o Ano: ");
                            folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                            //Colocar a busca correta
                            Console.WriteLine("Digite as horas Trabalhadas: ");
                            folhaPagamento.HorasTrabalhadas = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o Valor da hora Trabalhada: ");
                            folhaPagamento.ValorHora = Convert.ToDouble(Console.ReadLine());
                            folhaPagamento.SalarioBruto = CalcSalario.CalcSalarioBruto(folhaPagamento);
                            CalcSalario.CalcImpRenda(folhaPagamento);
                            CalcSalario.CalcINSS(folhaPagamento);
                            CalcSalario.CalcFGTS(folhaPagamento);
                            CalcSalario.CalcLiquido(folhaPagamento);
                                                      
                            FolhaPagamentoDao.AdicionarFolha(folhaPagamento);
                            Console.WriteLine("Cadastrado com sucesso!");
                            


                        }
                        else
                        {
                            Console.WriteLine("Funcionario não existe!");
                            Console.WriteLine("Não foi possível adicionar a Folha de Pagamento");
                        }
                        break;

                    case "3":
                        //Consulta a folha de pagamento e calcula o salario
                        folhaPagamento = new FolhaPagamento();
                        Console.Clear();
                        Console.WriteLine(" -- Consulta a folha de pagamento -- \n");
                        Console.WriteLine("Digite o CPF do funcionario: ");
                        folhaPagamento.Funcionario.Cpf = ValidaCPF.maskCpf(Console.ReadLine());
                        folhaPagamento.Funcionario = FuncionarioDao.BuscarFuncionarioPorCPF(funcionario);

                        if (folhaPagamento.Funcionario != null)
                        {
                            Console.WriteLine("Digite o Mês da Trabalhado: ");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o Ano: ");
                            folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                            foreach (FolhaPagamento folhaCadastrada in FolhaPagamentoDao.BuscarFolhaPorMesAnoFunc(folhaPagamento))
                            {
                                Console.WriteLine("Folhas cadastradas: " + folhaCadastrada);
                            }

                        }
                        else { Console.WriteLine("Funcionario não localzado!"); }
                        break;

                    case "4":
                        folhaPagamento = new FolhaPagamento();
                        Console.Clear();
                        Console.WriteLine(" -- Listar Folha de Pagamento -- \n");
                        Console.WriteLine("Digite o Mês: ");
                        folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o Ano: ");
                        folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                        double salarioLiquidoTotal = 0;
                        double salarioBrutoTotal = 0;
                        foreach (FolhaPagamento folhaCadastrada in FolhaPagamentoDao.BuscarFolhaPorMesAno(folhaPagamento))
                        {
                            Console.WriteLine("Folhas Cadastradas: " + folhaCadastrada);
                            salarioLiquidoTotal += folhaCadastrada.SalarioBruto;
                            salarioBrutoTotal += folhaCadastrada.Salario.SalarioLiquido;
                        }
                        Console.WriteLine("\nTotal salário líquido: " + salarioLiquidoTotal.ToString("C2"));
                        Console.WriteLine("\nTotal salário bruto: " + salarioBrutoTotal.ToString("C2"));
                        break;

                    case "5":
                        //Lista todos os funcionarios Cadastrados
                        Console.Clear();
                        Console.WriteLine(" -- Listar Funcionario -- \n");
                        foreach (Funcionario funcionarioCadastrado in FuncionarioDao.RetornarLista())
                        {
                            Console.WriteLine("Funcionário: " + funcionarioCadastrado);
                        }
                        break;

                    case "6":
                        //Consulta a folha de pagamento
                        Console.Clear();
                        Console.WriteLine(" -- Consulta a folha de pagamento -- \n");
                        foreach (FolhaPagamento folhaCadastrada in FolhaPagamentoDao.RetornarLista())
                        {
                            Console.WriteLine("Folhas cadastradas: " + folhaCadastrada);
                        }
                        break;
                }
                        Console.WriteLine("\n Aperte uma tecla para continuar");
                        Console.ReadKey();



                
            } while (!opcao.Equals("0")) ;
        } 
    }
}



