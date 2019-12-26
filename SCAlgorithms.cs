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
                int iVertexCount = aGraphDistances.Length,
                    iNextVertex;
                int[] aVisited = new int[iVertexCount], 
                    aClosestPath = new int[iVertexCount];
                double[] aShortestDistances = new double[iVertexCount];
                for (int i = 0; i < iVertexCount; i++)
                {
                    aShortestDistances[i] = double.MaxValue;
                    aVisited[i] = 0;
                    aClosestPath[i] = -1;
                }
                aShortestDistances[iStart] = 0;
                aVisited[iStart] = 1;
                aClosestPath[iStart] = 0;
                iNextVertex = UpdateDistances(iStart, aGraphDistances[iStart],aVisited,ref aClosestPath,ref aShortestDistances);
                while (!AllVisited(aVisited))
                {
                    aVisited[iNextVertex] = 1;
                    iNextVertex = UpdateDistances(iNextVertex, aGraphDistances[iNextVertex],aVisited,ref aClosestPath,ref aShortestDistances);                    
                }                
                return GetPath(aClosestPath,iStart,iFinish);
            }
            else
            {
                throw new InvalidOperationException(sDeikstraInvalidErrorText);
            }
        }
        private static bool AllVisited(int[] aVisited)
        {
            bool bAllVisited = true;
            for (int i = 0; i < aVisited.Length; i++)
            {
                if (aVisited[i]==0)
                {
                    bAllVisited = false;
                    break;
                }
            }
            return bAllVisited;
        }
        private static int UpdateDistances(int iPosFrom, double[] aDistances,int[] aVisited, ref int[] aClosestVertex, ref double[] aShortestDistances)
        {
            double fMin = double.MaxValue;
            int iMinPos = -1;
            for (int i = 0; i < aDistances.Length; i++)
            {
                if (aDistances[i]>0 && aVisited[i]==0)
                {
                    Console.WriteLine("Compare {0} with {1}", aShortestDistances[iPosFrom] + aDistances[i], aShortestDistances[i]);
                    if (aShortestDistances[iPosFrom]+aDistances[i]<aShortestDistances[i])
                    {
                        aShortestDistances[i] = aShortestDistances[iPosFrom] + aDistances[i];
                        aClosestVertex[i] = iPosFrom;
                        Console.WriteLine("Update closest distances and vertex on {0}",iPosFrom);
                    }
                    if (aShortestDistances[i]<fMin)
                    {
                        fMin = aShortestDistances[i];
                        iMinPos = i;
                    }
                } 
            }
            Console.WriteLine("Next vertex is {0}", iMinPos);
            return iMinPos;
        }
        
       private static int[] GetPath(int[] aClosestPath, int iStart, int iFinish)
        {
            int[] aPath = new int[aClosestPath.Length], aResultPath;
            for (int i = 0; i < aPath.Length; i++)
            {
                aPath[i] = -1;
            }
            int iLastPos = iFinish, iPos = aClosestPath.Length - 1, iLen=1;
            aPath[iPos--] = iLastPos;
            while (iLastPos!=iStart)
            {
                iLastPos = aClosestPath[iLastPos];
                aPath[iPos--] = iLastPos;
                iLen++;
            }
            iPos = 0;
            aResultPath = new int[iLen];
            for (int i = 0; i < aPath.Length; i++)
            {
                if (aPath[i]>=0)
                {
                    aResultPath[iPos++] = aPath[i];
                }
            }
            return aResultPath;
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
