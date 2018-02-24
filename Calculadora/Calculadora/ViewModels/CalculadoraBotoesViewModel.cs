using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Calculadora.Models;
using System.Linq;

namespace Calculadora.ViewModels
{
    public class CalculadoraBotoes
    {

        public CalculadoraBotoes()
        {
            this.DefinirNumeros();
            this.DefinirOperadores();
        }

        private void DefinirNumeros()
        {
            this.Numeros = new List<BotaoNumerico>();
            Enumerable.Range(0, 9).ToList().ForEach(
                i =>
                {
                    this.Numeros.Add(new BotaoNumerico()
                    {
                        Descricao = i.ToString(),
                        Valor = i
                    });
                });
        }

        private void DefinirOperadores()
        {
            this.Operadores = new List<BotaoOperador>();

        }

        public List<BotaoNumerico> Numeros { get; set; }

        public List<BotaoOperador> Operadores { get; set; }
    }
}