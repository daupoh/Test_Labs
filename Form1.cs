using System;
using System.Windows.Forms;

namespace wf_testLabs
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            int iSize = 5, iRandomDistance=20, iRound= 2;
            double[][] aGraph = GetGraph(iSize, iRandomDistance);
            DgvGraph.RowCount = iSize;
            DgvGraph.ColumnCount = iSize;
            for (int i = 0; i < iSize; i++)
            {
                DgvGraph.Rows[i].HeaderCell.Value = i;
                
                for (int j = 0; j < iSize; j++)
                {
                    DgvGraph[i, j].Value = Math.Round(aGraph[i][j], iRound);
                    DgvGraph.Columns[j].HeaderCell.Value = j;
                }
            }
            for (int k = 0; k < iSize; k++)
            {
                for (int j = 0; j < iSize; j++)
                {
                    if (k != j)
                    {
                        TbxShortPath.Text += "\r\nКратчайший путь из " + k.ToString() + " в " + j.ToString() + "\r\n";
                        int[] aPath = SCAlgorithms.DijkstraPath(aGraph, k, j);
                        double fLength = GetPathLength(aPath, aGraph);
                        TbxShortPath.Text += "Кратчайший путь: {" + aPath[0].ToString();
                        for (int i = 1; i < aPath.Length; i++)
                        {
                            if (aPath[i] != -1)
                            {
                                TbxShortPath.Text += "," + aPath[i].ToString();
                            }
                            else
                            {
                                break;
                            }

                        }
                        TbxShortPath.Text += "}" + "\r\n" + "Длина пути: " + Math.Round(fLength, iRound).ToString();
                        TbxShortPath.Text += "\r\n";
                    }
                }
            }
        }
        private double GetPathLength(int[] aPath, double[][] aGraph)
        {
            double fLength = 0;
            for (int i = 1; i < aPath.Length; i++)
            {
                if (aPath[i] != -1)
                {
                    fLength += aGraph[aPath[i-1]][aPath[i]];
                }
                else
                {
                    break;
                }
            }
            return fLength;
        }
        private double[][] GetGraph(int iSize, int iRandomDistance)
        {
            double[][] aGraph = new double[iSize][];

            for (int i = 0; i < iSize; i++)
            {
                aGraph[i] = new double[iSize];
                for (int j = i; j < iSize; j++)
                {
                    if (i == j)
                    {
                        aGraph[i][j] = 0;
                    }
                    else
                    {
                        aGraph[i][j] = SCAlgorithms.Random * iRandomDistance;
                    }
                }
            }
            for (int j = 0; j < iSize; j++)
            {
                for (int i = j + 1; i < iSize; i++)
                {
                    aGraph[i][j] = aGraph[j][i];
                }
            }
            return aGraph;
        }
    }
}
