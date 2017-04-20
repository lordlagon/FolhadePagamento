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
                 
            };
            List<FolhaPagamento> folhasDePagamento = new List<FolhaPagamento>
            {
                new folhasDePagamento()
                {
                    Mes
                    Nome = "Felipe",
                    Cpf = "5"
                },
                new folhasDePagamento()
                {
                    Nome = "Augusto",
                    Cpf = "6"
                },
                new folhasDePagamento()
                {
                    Nome = "Rafaela",
                    Cpf = "7"
                },
            };/*
            List<Produto> produtos = new List<Produto>
            {
                new Produto()
                {
                    Nome = "Arroz",
                    Markup = 2,
                    Preco = 2
                },
                new Produto()
                {
                    Nome = "Feijão",
                    Markup = 3,
                    Preco = 3
                },
                new Produto()
                {
                    Nome = "Macarrão",
                    Markup = 4,
                    Preco = 4
                },
            };*/
            funcionarios.ForEach(x => FuncionarioDao.AdicionarFuncionario(x));

        }
    }
}
