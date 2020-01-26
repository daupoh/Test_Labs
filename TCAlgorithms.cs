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
        [Test, TestCaseSource("CorrectDataDejkstra")]
        public void TestCorrectDataDejktsra(double[][] aGraph, int iStart, int iFinish, int[] aExpectedPath)
        {
            int[] aActualPath = SCAlgorithms.DijkstraPath(aGraph, iStart, iFinish);
            Assert.AreEqual(aExpectedPath.Length, aActualPath.Length, "Длина массива должна быть равна {0},а равна {1}",
                aExpectedPath.Length, aActualPath.Length);
            for (int i = 0; i < aExpectedPath.Length; i++)
            {
                Assert.AreEqual(aExpectedPath[i], aActualPath[i], "Вершина в пути под номером {0} должна быть равна {1}" +
                    ",а равна {2}", i, aExpectedPath[i], aActualPath[i]);
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

        static object[] CorrectDataDejkstra =
        {
            new object[] { new double[][] {
                                new double[] {0, 3, 5, 1 },
                                new double[] {3, 0, 4, 8 }, 
                                new double[] {5, 4, 0, 6 }, 
                                new double[] {1, 8, 6, 0 } }
                            ,1,3,
                            new int[3] {1,0,3}},          
            new object[] { new double[][] {
                                new double[] { double.MaxValue, 2, double.MaxValue, double.MaxValue },
                                new double[] { double.MaxValue, double.MaxValue, 3, double.MaxValue },
                                new double[] { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
                                new double[] { double.MaxValue, 5, double.MaxValue, double.MaxValue } }
                            ,0,2,
                           new int[3] {0,1,2}},
        };

    
    }
}
