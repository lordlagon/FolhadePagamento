﻿using System;
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

            };
            List<FolhaPagamento> folhasDePagamento = new List<FolhaPagamento>
            {
                new FolhaPagamento()
                {
                    Funcionario = { Nome = "Gabriel", Cpf = "083.809.369-81" },
                    Mes = 10,
                    Ano = 2015,
                    HorasTrabalhadas=0,
                    ValorHora = 2.4,
                
                },
            };
            
            /*
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
