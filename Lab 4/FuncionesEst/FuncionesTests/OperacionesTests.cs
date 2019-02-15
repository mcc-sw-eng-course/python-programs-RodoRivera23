using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncionesTests
{
    [TestClass]
    public class OperacionesTests
    {
        [TestMethod]
        public void TestPromedio()
        {
            //Arrange
            int[] array_odd = new int[5] {1,2,3,4,5};
            int[] array_even = new int[6] {6,5,4,3,2,1};

            double odd_expected = 3;
            double even_expected = 3.5;

            Funciones.Operaciones calcula = new Funciones.Operaciones();

            //Act
            double odd_actual = calcula.Promedio(array_odd);
            double even_actual = calcula.Promedio(array_even);

            //Asserts
            Assert.AreEqual(odd_expected, odd_actual, 0.001, "Error en promedio Impar");
            Assert.AreEqual(even_expected, even_actual, 0.001, "Error en promedio Par");
        }

        [TestMethod]
        public void TestDesviacionEstandar()
        {
            //Arrange
            int[] array_odd = new int[5] { 600, 470,170, 430, 300 };
            int[] array_even = new int[6] { 10, 32, 24, 26, 40, 30 };

            double odd_expected = 147;
            double even_expected = 9.09;

            Funciones.Operaciones calcula = new Funciones.Operaciones();

            //Act
            double odd_actual = calcula.DesviacionEstandar(array_odd);
            double even_actual = calcula.DesviacionEstandar(array_even);

            //Asserts
            Assert.AreEqual(odd_expected,odd_actual, 0.5,"Error en Desviacion Estandar Impar");
            Assert.AreEqual(even_expected,even_actual, 0.5,"Error en Desviacion Estandar Par");
        }

        [TestMethod]
        public void TestMedia()
        {
            //Arrange
            int[] array_odd = new int[5] { 10, 20, 30, 40, 50 };
            int[] array_even = new int[6] { 60, 50, 40, 30, 20, 10 };

            double odd_expected = 30;
            double even_expected = 35;

            Funciones.Operaciones calcula = new Funciones.Operaciones();

            //Act
            double odd_actual = calcula.Media(array_odd);
            double even_actual = calcula.Media(array_even);

            //Asserts
            Assert.AreEqual(odd_expected,odd_actual,0.001,"Error en Media Impar");
            Assert.AreEqual(even_expected, even_actual, 0.001, "Error en Media Par");
        }
    }
}
