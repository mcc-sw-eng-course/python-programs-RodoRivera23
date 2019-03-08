using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortMethod;

namespace TestSortMethod
{
    [TestClass]
    public class TestMethods
    {
        [TestMethod]
        public void Test_CreateFile()
        {
            //Arrange
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file_name = @"\unsorted_numbers.txt";
            string full_path = desktop + file_name;

            int cant = 20;

            //Act
            Sort action = new Sort();
            action.create_file(cant,1);

            //Assert
            Assert.IsTrue(File.Exists(full_path));
        }

        [TestMethod]
        public void Test_Merge_Sort()
        {
            //Arrange
            List<int> unsorted = new List<int>() { 7420, 1754, 7956, 7616, 8845, 1332, 558, 2004, 1258, 661, 749, 6199, 653, 7637, 9293, 9709, 7418, 7889, 3005, 7780 };
            List<int> expected_sorted = new List<int>() { 558, 653, 661, 749, 1258, 1332, 1754, 2004, 3005, 6199, 7418, 7420, 7616, 7637, 7780, 7889, 7956, 8845, 9293, 9709 };

            //Act
            Sort action = new Sort();
            List<int> sortedNums = action.execute_merge_sort(unsorted);

            //Assert
            CollectionAssert.AreEqual(expected_sorted, sortedNums);
        }
        [TestMethod]
        public void Test_Quick_Sort()
        {
            //Arrange
            List<int> unsorted = new List<int>() { 7420, 1754, 7956, 7616, 8845, 1332, 558, 2004, 1258, 661, 749, 6199, 653, 7637, 9293, 9709, 7418, 7889, 3005, 7780 };
            List<int> expected_sorted = new List<int>() { 558, 653, 661, 749, 1258, 1332, 1754, 2004, 3005, 6199, 7418, 7420, 7616, 7637, 7780, 7889, 7956, 8845, 9293, 9709 };

            //Act
            Sort action = new Sort();
            List<int> sortedNums = action.execute_quick_sort(unsorted);

            //Assert
            CollectionAssert.AreEqual(expected_sorted, sortedNums);
        }

        [TestMethod]
        public void Test_Heap_Sort()
        {
            //Arrange
            int[] unsortedArr = new int[] { 7420, 1754, 7956, 7616, 8845, 1332, 558, 2004, 1258, 661, 749, 6199, 653, 7637, 9293, 9709, 7418, 7889, 3005, 7780 };
            List<int> expected_sorted = new List<int>() { 558, 653, 661, 749, 1258, 1332, 1754, 2004, 3005, 6199, 7418, 7420, 7616, 7637, 7780, 7889, 7956, 8845, 9293, 9709 };

            //Act
            Sort action = new Sort();
            List<int> sortedNums = action.execute_heap_sort(unsortedArr);

            //Assert
            CollectionAssert.AreEqual(expected_sorted, sortedNums);
        }

        [TestMethod]
        public void Test_CheckNumbers()
        {
            //Arrange
            string line1 = "3542,8236523,6353,4325,92837,654,8534,5322,63452,12";
            string line2 = "14232s,534332,5243gd,fs4563,74543";

            bool expect_true = true;
            bool expect_false = false;

            bool actual_res1;
            bool actual_res2;

            //Act
            Sort operation = new Sort();
            actual_res1 = operation.checkNumbers(line1);
            actual_res2 = operation.checkNumbers(line2);

            //Assert
            Assert.AreEqual(expect_true,actual_res1);
            Assert.AreEqual(expect_false, actual_res2);
        }

        [TestMethod]
        public void TestSortedFiles()
        {
            //Arrange
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file_name = @"\sorted_numbers.txt";
            string full_path = desktop + file_name;

            List<int> unsorted = new List<int>() { 7420, 1754, 7956, 7616, 8845, 1332, 558, 2004, 1258, 661, 749, 6199, 653, 7637, 9293, 9709, 7418, 7889, 3005, 7780 };

            //Act
            Sort action = new Sort();
            List<int> sortedNums = action.execute_merge_sort(unsorted);
            action.set_up_data(sortedNums);

            //Assert
            Assert.IsTrue(File.Exists(full_path));
        }
    }
}
