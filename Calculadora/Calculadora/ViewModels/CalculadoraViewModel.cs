using Calculadora.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculadora.ViewModels
{
    public class CalculadoraViewModel : BaseViewModel
    {
        private Expressao expr;
        private static List<string> operadores = new List<string>(new string[] { "+", "-", "X", "/" });
        private string display, expressao,digito;

        public CalculadoraViewModel()
        {
            this.display = this.digito = String.Empty;
            this.expr = new Expressao();

            this.expr.OnExpressaoAtualizada(s =>
            {
                this.Expressao = s;
            });
        }
        
        private void InformarValor(float val)
        {
            this.expr.Adicionar(new Operando(val));
            this.digito = String.Empty;
        }

        private void InformarOperador(string op)
        {
            this.expr.Adicionar(new Operador(op));
        }

        private void ExecutarIgual()
        {
            this.InformarValor(float.Parse(this.digito));
            this.Display = this.expr.Calcular().ToString();
            this.expr.Limpar();
            this.digito = this.Display;
        }

        private void Limpar()
        {
            this.digito = "0";
            this.Display = "0";
            this.expr.Limpar();
        }

        private void TratarSinal(string text)
        {
            if (text == "=")
            {
                this.ExecutarIgual();
            }
            if (text == "C")
            {
                this.Limpar();
            }
        }
        
        public void Informar(string text)
        {
            if (operadores.Contains(text))
            {
                this.InformarValor(float.Parse(this.digito));
                this.InformarOperador(text);
                return;
            }

            if(text == "=" || text == "C")
            {
                this.TratarSinal(text);
                return;
            }
            
            this.digito = String.Concat(this.digito, text);
            this.Display = this.digito;
        }

        public string Display
        {
            get
            {
                return this.display;
            }
            set
            {
                if(value != this.display)
                {
                    this.display = value;
                    this.OnPropertyChanged("Display");
                }
            }
        }

        public string Expressao
        {
            get
            {
                return this.expressao;
            }
            set
            {
                this.expressao = value;
                this.OnPropertyChanged("Expressao");
            }
        }
    }

}
