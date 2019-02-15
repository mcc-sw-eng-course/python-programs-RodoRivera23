using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertirNumeroTest
{
    [TestClass]
    public class ConvertirNumTest
    {
        [TestMethod]
        public void TestConvierteNumRomano()
        {
            //Arrange
            int num_prueba01 = 234;
            int num_prueba02 = 876956;
            int num_prueba03 = 165264;
            int num_prueba04 = 53422;

            string expected_number1 = "CCXXXIV";
            string expected_number2 = "D°C°C°C°L°X°X°V°MCMLVI"; //Para los casos en que los numeros son mayores a mil
                                                                //se agrega el caracter ° a la derecha del simbolo para
                                                                //indicar que se trata del valor del simbolo multiplicado
                                                                //por mil, por ejemplo D equivale a 500, usando nuestra
                                                                //D° equivale a 500 mil
            string expected_number3 = "C°L°X°V°CCLXIV";
            string expected_number4 = "L°MMMCDXXII";

            ConvertirNumero.ConvertirNumero calcula = new ConvertirNumero.ConvertirNumero();

            //Act
            string actual_number1 = calcula.ConvierteNumero(num_prueba01);
            string actual_number2 = calcula.ConvierteNumero(num_prueba02);
            string actual_number3 = calcula.ConvierteNumero(num_prueba03);
            string actual_number4 = calcula.ConvierteNumero(num_prueba04);

            //Assert
            Assert.AreEqual(expected_number1,actual_number1,"Error al comparar primero numero");
            Assert.AreEqual(expected_number2, actual_number2,"Error al comparar segundo numero");
            Assert.AreEqual(expected_number3, actual_number3, "Error al comparar tercer numero");
            Assert.AreEqual(expected_number4, actual_number4, "Error al comparar cuarto numero");

        }
    }
}
