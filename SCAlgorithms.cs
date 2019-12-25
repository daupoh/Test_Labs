using System;

namespace wf_testLabs
{
    static class SCAlgorithms
    {
        public static Random m_rRandom=new Random();
        public static string sSelectionSortErrorText = "Невозможно отсортировать пустой массив.",
            sDeikstraInvalidErrorText = "Невозможно найти кратчайший путь в пустом графе.",
            sDeikstraIncorrectErrorText = "Некорректная матрица путей.";
        public static double Random { get { return m_rRandom.NextDouble(); } }
        public static void SelectionSort(double[] aSequence)
        {
            if (aSequence == null || aSequence.Length == 0)
            {
                throw new InvalidOperationException(sSelectionSortErrorText);
            }
            else
            {
                int iStart = 0;
                for (int i = 0; i < aSequence.Length - 1; i++)
                {
                    int iMinNumber = FindMin(aSequence, iStart);
                    aSequence = Swap(aSequence, iStart, iMinNumber);
                    iStart++;
                }
            }
        }
        public static int[] DijkstraPath(double[][] aGraphDistances, int iStart, int iFinish)
        {
            if (aGraphDistances == null || aGraphDistances.Length == 0 || iStart < 0 || iStart >= aGraphDistances.Length || iFinish < 0 || iFinish >= aGraphDistances.Length)
            {
                throw new InvalidOperationException(sDeikstraInvalidErrorText);
            }
            else if (IsPathGraphCorrect(aGraphDistances))
            {
                int iVertexCount = aGraphDistances.Length;
                int[] aDijkstraPath = new int[iVertexCount];
                double[] aDijkstraDistances = new double[iVertexCount];
                for (int i = 0; i < iVertexCount; i++)
                {             
                    aDijkstraDistances[i] = double.MaxValue;
                    aDijkstraPath[i] = -1;                    
                }                
                aDijkstraDistances[iStart] = 0;
                aDijkstraPath[0] = iStart;
                double fDistance = 0;
                int iPos = 0, iNextVertex = FindMinNotVisited(aGraphDistances[aDijkstraPath[iPos]], aDijkstraPath, ref aDijkstraDistances, fDistance);
                Console.WriteLine("Первая следующая вершина {0}", iNextVertex);
                while (iNextVertex!=iFinish)
                {
                    fDistance += aGraphDistances[aDijkstraPath[iPos]][iNextVertex];
                    iPos++;
                    aDijkstraPath[iPos] = iNextVertex;
                    Console.WriteLine("Следующая вершина {0}", iNextVertex);
                    iNextVertex = FindMinNotVisited(aGraphDistances[aDijkstraPath[iPos]], aDijkstraPath, ref aDijkstraDistances, fDistance);
                   
                }               
                return aDijkstraPath;
            }
            else
            {
                throw new InvalidOperationException(sDeikstraInvalidErrorText);
            }
        }
        private static int FindMinNotVisited(double[] aDistance,int[] aVisited,ref double[] aDijkstraDistances, double fDistance)
        {
            int iMinPos = -1;
            double fMin = double.MaxValue;
            for (int i = 0; i < aDistance.Length; i++)
            {
                if (!AlreadyVisited(aVisited, i))
                {
                    if (aDistance[i]>0)
                    {
                        if ((aDistance[i]+fDistance)<aDijkstraDistances[i])
                        {
                            aDijkstraDistances[i] = aDistance[i] + fDistance;
                        }
                        if (aDijkstraDistances[i]<fMin)
                        {
                            iMinPos = i;
                            fMin = aDijkstraDistances[i];
                        }
                    }
                }

            }
            return iMinPos;
        }
        private static bool AlreadyVisited(int[] aVisited, int iPos)
        {
            bool bVisited = false;
            for (int i = 0; i < aVisited.Length; i++)
            {
                if (aVisited[i]==iPos)
                {
                    bVisited = true;
                    break;
                }
            }
            return bVisited;
        }
        
        private static bool IsPathGraphCorrect(double[][] aPathGraph)
        {
            bool bIsIt = true;
            int iVertexCount = aPathGraph.Length;
            for (int i = 0; i < iVertexCount; i++)
            {
                if (aPathGraph[i].Length != iVertexCount)
                {
                    bIsIt = false;
                    break;
                }
            }
            return bIsIt;
        }
        private static int FindMin(double[] aSequence, int iStart)
        {
            int iMinNumber = iStart;
            double fMin = aSequence[iStart];
            for (int i = iStart+1; i < aSequence.Length; i++)
            {
                if (aSequence[i]<fMin)
                {
                    fMin = aSequence[i];
                    iMinNumber = i;
                }
            }
            return iMinNumber;
        }
        private static double[] Swap(double[] aSequence, int iFirstNumber, int iSecondNumber)
        {
            double fTemp = aSequence[iFirstNumber];
            aSequence[iFirstNumber] = aSequence[iSecondNumber];
            aSequence[iSecondNumber] = fTemp;
            return aSequence;
        }
        
    }
}
