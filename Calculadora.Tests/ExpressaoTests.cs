using System;
using Calculadora.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Tests
{
    [TestClass]
    public class ExpressaoTest
    {
        [TestMethod]
        public void Somar2_2_igual_4()
        {
            Expressao e = new Expressao();

            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("+"));
            e.Adicionar(new Operando(2));

            Assert.AreEqual(e.Calcular(), 4);
        }

        [TestMethod]
        public void Complexa_2x2x2x2igual_16()
        {
            Expressao e = new Expressao();

            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("*"));
            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("*"));
            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("*"));
            e.Adicionar(new Operando(2));

            Assert.AreEqual(e.Calcular(), 16);
        }

        [TestMethod]
        public void Mista_2p2x2m2div2_3()
        {
            Expressao e = new Expressao();

            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("+"));
            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("*"));
            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("-"));
            e.Adicionar(new Operando(2));
            e.Adicionar(new Operador("/"));
            e.Adicionar(new Operando(2));

            Assert.AreEqual(e.Calcular(), 5);
        }


        [TestMethod]
        public void Mista_2pp2xigual4DeveTerException()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                Expressao e = new Expressao();

                e.Adicionar(new Operando(2));
                e.Adicionar(new Operador("+"));
                e.Adicionar(new Operador("+"));
                e.Adicionar(new Operando(2));
                e.Calcular();
            });
        }
    }
}
