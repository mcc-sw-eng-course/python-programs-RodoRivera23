using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestmyPowerList
{
    [TestClass]
    public class myPowerListTest
    {
        [TestMethod]
        public void TestmyPowerList()
        {
            //Arrange
            var fileName = "test_file.txt";
            string expected_msg = "Este sera el archivo de prueba 1";

            //Act
            myPowerList.myPowerList readFile = new myPowerList.myPowerList();
            string actual_msg = readFile.ReadFromTexFile(fileName);

            //Asserts
            Assert.AreEqual(expected_msg, actual_msg, "Ocurrio un error al leer el archivo");
        }

        [TestMethod]
        public void TestFileExist()
        {
            //Arrange
            var file = "test_file.txt";
            var desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Act
            var fullFilePath = desktop_path + "\\" + file;

            //Asserts
            Assert.IsTrue(File.Exists(fullFilePath));
        }
    }
}
