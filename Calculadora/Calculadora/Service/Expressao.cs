using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Service
{
    public class Expressao
    {
        private List<Elemento> Elementos { get; set; }
        private bool operadorExperado = false;
        private Action<string> onExpressaoAtualizada;

        public Expressao()
        {
            this.Elementos = new List<Elemento>();
        }

        public float Calcular()
        {
            return this.Resolver();
        }

        public void Adicionar(Elemento e)
        {
            if(!this.operadorExperado && e is Operador)
            {
                throw new Exception("Nao era esperado um operador");
            }

            this.operadorExperado = !this.operadorExperado;
            this.Elementos.Add(e);
            this.AtualizarExpressao();
        }

        public void Limpar()
        {
            this.Elementos.Clear();
            this.operadorExperado = false;
        }

        private void AtualizarExpressao()
        {
            string e = string.Join(string.Empty, this.Elementos);
            if(this.onExpressaoAtualizada != null)
            {
                this.onExpressaoAtualizada(e);
            }
        }
        
        public void OnExpressaoAtualizada(Action<string> val)
        {
            this.onExpressaoAtualizada = val;
        }

        private float Resolver()
        {
            var list = new List<Elemento>(this.Elementos.ToArray());

            this.ResolverOperacao(list, new string[] { "*", "/" });
            this.ResolverOperacao(list, new string[] { "+", "-" });

            return (list[0] as Operando).Valor;
        }

        private void ResolverOperacao(List<Elemento> expr, string[] operadores)
        {
            int idx = this.BuscarPrimeiroIndiceDeOperador(expr, new List<string>(operadores));
            if (idx > -1)
            {
                this.CalcularPar(expr, idx);
                this.ResolverOperacao(expr, operadores);
            }
        }
      
        private int BuscarPrimeiroIndiceDeOperador(List<Elemento> expr, List<string> operadoresPermitidos)
        {
            return expr.FindIndex(e =>
            {
                if (e is Operador)
                {
                    Operador o = e as Operador;
                    return operadoresPermitidos.Contains(o.Operacao);
                }
                return false;
            });
        }

        private void CalcularPar(List<Elemento> expr, int indiceDoOperador)
        {
            Operando o1 = expr[indiceDoOperador - 1] as Operando;
            Operador op = expr[indiceDoOperador] as Operador;
            Operando o2 = expr[indiceDoOperador + 1] as Operando;

            float val = 0;
            switch (op.Operacao)
            {
                case "-":
                    val = o1.Valor - o2.Valor; break;
                case "+":
                    val = o1.Valor + o2.Valor; break;
                case "*":
                    val = o1.Valor * o2.Valor; break;
                case "/":
                    val = o1.Valor / o2.Valor; break;
            }

            expr[indiceDoOperador - 1] = new Operando(val);
            expr.Remove(op);
            expr.Remove(o2);
        }

    }
}
