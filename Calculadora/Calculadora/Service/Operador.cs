using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Service
{
    public class Operador : Elemento
    {
        public Operador(string op)
        {
            this.Operacao = op;
        }

        public override string ToString()
        {
            return this.Operacao;
        }

        public string Operacao { get; private set; }
    }
}
