﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolhadePagamento.Util;

namespace FolhadePagamento.Model
{
    class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public override string ToString()
        {
            return "Nome: " + Nome + " CPF: " + Cpf;
        }


    }
}
