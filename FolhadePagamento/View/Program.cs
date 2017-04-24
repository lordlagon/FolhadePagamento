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

                        if (folhaPagamento.Funcionario != null)
                        {
                            //folhaPagamento.Funcionario = funcionario;
                            Console.WriteLine("Digite o Mês da Trabalhado: (1 a 12)");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            if (ValidaMesAno.ValidaMes(folhaPagamento.Mes) == true)
                            {
                                Console.WriteLine("Digite o Ano: (entre 1950 e 2017)");
                                folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                                if (ValidaMesAno.ValidaAno(folhaPagamento.Ano) == true)
                                {
                                    if (FolhaPagamentoDao.BuscarFolha(folhaPagamento) != null)
                                    {
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
                                        Console.WriteLine("\nFolha Cadastrada com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Já existe uma folha cadastrada para o período");
                                        Console.WriteLine("Não foi possível adicionar a Folha de Pagamento");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Digite um ano válido");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um mes válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Funcionario não existe!");
                            Console.WriteLine("Não foi possível adicionar a Folha de Pagamento");
                        }
                        break;

                    case "3":

                        folhaPagamento = new FolhaPagamento();
                        Console.Clear();
                        Console.WriteLine(" -- Consulta a folha de pagamento -- \n");
                        Console.WriteLine("Digite o CPF do funcionario: ");
                        folhaPagamento.Funcionario.Cpf = ValidaCPF.maskCpf(Console.ReadLine());
                        folhaPagamento.Funcionario = FuncionarioDao.BuscarFuncionarioPorCPF(folhaPagamento.Funcionario);

                        if (folhaPagamento.Funcionario != null)
                        {
                            Console.WriteLine("Digite o Mês da Trabalhado: (1 a 12)");
                            folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                            if (ValidaMesAno.ValidaMes(folhaPagamento.Mes) == true)
                            {
                                Console.WriteLine("Digite o Ano: (entre 1950 e 2017)");
                                folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                                if (ValidaMesAno.ValidaAno(folhaPagamento.Ano) == true)
                                {
                                    Console.Clear();
                                    foreach (FolhaPagamento folhaCadastrada in FolhaPagamentoDao.BuscarFolhaPorMesAnoFunc(folhaPagamento))
                                    {
                                        Console.WriteLine(folhaCadastrada);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Digite um ano válido");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um mes válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Funcionario não localzado!");
                        }
                        break;

                    case "4":
                        folhaPagamento = new FolhaPagamento();
                        Console.Clear();
                        Console.WriteLine(" -- Listar Folha de Pagamento -- \n");
                        Console.WriteLine("Digite o Mês da Trabalhado: (1 a 12)");
                        folhaPagamento.Mes = Convert.ToInt32(Console.ReadLine());
                        if (ValidaMesAno.ValidaMes(folhaPagamento.Mes) == true)
                        {
                            Console.WriteLine("Digite o Ano: (entre 1950 e 2017)");
                            folhaPagamento.Ano = Convert.ToInt32(Console.ReadLine());
                            if (ValidaMesAno.ValidaAno(folhaPagamento.Ano) == true)
                            {
                                double salarioLiquidoTotal = 0;
                                double salarioBrutoTotal = 0;
                                foreach (FolhaPagamento folhaCadastrada in FolhaPagamentoDao.BuscarFolhaPorMesAno(folhaPagamento))
                                {
                                    Console.WriteLine(folhaCadastrada);
                                    salarioLiquidoTotal += folhaCadastrada.Salario.SalarioLiquido;
                                    salarioBrutoTotal += folhaCadastrada.SalarioBruto;
                                }

                                Console.WriteLine("\nTotal salário bruto: " + salarioBrutoTotal.ToString("C2"));
                                Console.WriteLine("\nTotal salário líquido: " + salarioLiquidoTotal.ToString("C2"));
                            }
                            else
                            {
                                Console.WriteLine("Digite um ano válido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Digite um mes válido");
                        }

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
                            Console.WriteLine(folhaCadastrada);
                        }
                        break;
                }
                        Console.WriteLine("\nAperte uma tecla para continuar");
                        Console.ReadKey();



                
            } while (!opcao.Equals("0")) ;
        } 
    }
}



