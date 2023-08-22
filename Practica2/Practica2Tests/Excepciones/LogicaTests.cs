using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Practica2.Excepciones.Tests
{
    [TestClass()]
    public class LogicaTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExcepcionTest()
        {
            // Arrange
            int? a = null;
            int b = 3;
            // Act
            Logica.Excepcion(a, b);
            // Assert manejado desde ExpectedException
        }

        [TestMethod()]
        [ExpectedException(typeof(ExepcionCustomizada))]
        public void ExcepcionCustomTest()
        {
            // Arrage
            var exepcion = new ExepcionCustomizada("Test");

            //Act
            throw exepcion;
            // Assert manejado desde ExpectedException
        }
    }
}