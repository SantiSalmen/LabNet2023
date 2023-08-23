using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            int dividendo1 = 10, resultadoEsperado = 2, falloEsperado = -1, fallo1, fallo2, resultado;


            // act
            fallo1 = dividendo1.Dividir();
            resultado = dividendo1.Dividir(5);
            fallo2 = dividendo1.Dividir(0);

            //Asserts
            Assert.AreEqual(falloEsperado, fallo1);
            Assert.AreEqual(resultado, resultadoEsperado);
            Assert.AreEqual(falloEsperado, fallo2);
        }
    }
}