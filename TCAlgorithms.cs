using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace wf_testLabs
{
    [TestFixture]
    class TCAlgorithms
    {
        [Test, TestCaseSource("NonCorrectDataSelectionSort")]
        public void TestNonCorrectDataSelectionSort(double[] aSequence, string sErrorText)
        {
            double[] aSortSequence=null;
            InvalidOperationException rException = null;
            try
            {
                aSortSequence = SCAlgorithms.SelectionSort(aSequence);
            }            
            catch (InvalidOperationException rExep)
            {   
                rException = rExep;
            }
            Assert.IsNotNull(rException,"Алгоритм должен бросить ошибку");
            Assert.AreEqual(sErrorText, rException.Message, "Метод должен вернуть ошибку с текстом {0}, а фактически текст = '{1}'", sErrorText, rException.Message);
            Assert.IsNull(aSortSequence,"Алгоритм не вернул отсортированный массив, из-за некорректных данных.");
        }
        [Test,TestCaseSource("CorrectDataSelectionSort")]
        public void TestCorrectDataSelectionSort(double[] aSequence, double[] aSortedSequence)
        {
            double[] aSortSequence = SCAlgorithms.SelectionSort(aSequence);
            Assert.AreEqual(aSortedSequence.Length, aSortSequence.Length, "Длина отсортированного массива должны быть равна {0}, " +
                "а фактически равна {1}", aSortedSequence.Length, aSortSequence.Length);
            for (int i = 0; i < aSortSequence.Length; i++)
            {
                Assert.AreEqual(aSortedSequence[i], aSortSequence[i], "Элемент под номером {0} " +
                    "должен быть равен {1}, а фактически равен {2}", i, aSortedSequence[i], aSortSequence[i]);
            }

        }
        static object[] NonCorrectDataSelectionSort =
            {                
                new object[] { null, SCAlgorithms.sSelectionSortErrorText },
                  new object[] { new List<double>().ToArray(), SCAlgorithms.sSelectionSortErrorText },
            };
        static object[] CorrectDataSelectionSort =
            {
                new object[] { new double[6]  { -4,3,3.25,4,4,5}, new double[6]  { -4,3,3.25,4,4,5}},
                new object[] { new double[6]  { 4,5,4,3,3.25,-4}, new double[6]  { -4,3,3.25,4,4,5} },
                new object[] { new double[1]  {4}, new double[1]  { 4} },
                new object[] { new double[3]  {4,4,4}, new double[3]  { 4,4,4} },
            };


    }
}
