using System;
using Calculadora.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculadora.Tests
{
    [TestClass]
    public class CalculadoraViewModelTests
    {
        [TestMethod]
        public void DigitarEExibir12()
        {
            var c = new CalculadoraViewModel();
            c.Informar("1");
            c.Informar("2");

            Assert.AreEqual("12", c.Display);
        }

        [TestMethod]
        public void Digitar2p2igual4p2igual6()
        {
            var c = new CalculadoraViewModel();
            c.Informar("2");
            c.Informar("+");
            c.Informar("2");
            c.Informar("=");
            c.Informar("+");
            c.Informar("2");
            c.Informar("=");

            Assert.AreEqual("6", c.Display);
        }
    }
}
