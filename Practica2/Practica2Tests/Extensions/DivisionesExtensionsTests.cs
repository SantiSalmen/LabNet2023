using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Extensions.Tests
{
    [TestClass()]
    public class DivisionesExtensionsTests
    {

        //TODO: Asserts para controlar las exepciones del metodo dividir.
        [TestMethod()]
        public void DividirTest()
        {
            // Arrange
            int Dividendo1 = 12;
            double Dividendo2 = 10;

            // act
            Dividendo1.Dividir();
            Dividendo2.Dividir(10);
            Dividendo2.Dividir(0);

        }
    }
}