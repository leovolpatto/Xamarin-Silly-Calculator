using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Service
{
    public class Operando : Elemento
    {
        public Operando(float v)
        {
            this.Valor = v;
        }

        public override string ToString()
        {
            return this.Valor.ToString();
        }

        public float Valor { get; private set; }
    }
}
