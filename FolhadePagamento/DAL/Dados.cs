using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.Model;

namespace FolhadePagamento.DAL
{
    class Dados
    {
        public static void Inicializar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Funcionario()
                {
                    Nome = "André",
                    Cpf = "009.061.419-40"
                },
                new Funcionario()
                {
                    Nome = "Gabriel",
                    Cpf = "083.809.369-81"
                },
                new Funcionario()
                {
                    Nome = "Bruno",
                    Cpf = "092.181.829-78"
                },
                new Funcionario()
                {
                    Nome = "Ale",
                    Cpf = "116.205.589-80"
                },
                new Funcionario()
                {
                    Nome = "Diogo",
                    Cpf = "088.408.549-08"
                },

            };
            funcionarios.ForEach(x => FuncionarioDao.AdicionarFuncionario(x));
            

        }
    }
}
