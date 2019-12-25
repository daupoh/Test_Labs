using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_testLabs
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            int iSize = 4, iRandomDistance=20, iRound= 2;
            double[][] aGraph = GetGraph(iSize, iRandomDistance);
            DgvGraph.RowCount = iSize;
            DgvGraph.ColumnCount = iSize;
            for (int i = 0; i < iSize; i++)
            {
                for (int j = 0; j < iSize; j++)
                {
                    DgvGraph[i, j].Value = Math.Round(aGraph[i][j], iRound);
                }
            }
            for (int j = 1; j < iSize; j++)
            {
                TbxShortPath.Text += "\r\nКратчайший путь из 0 в " +j.ToString()+ "\r\n";
                int[] aPath = SCAlgorithms.DijkstraPath(aGraph, 0, j);
                double fLength = GetPathLength(aPath, aGraph);
                TbxShortPath.Text += "Кратчайший путь: {" + aPath[0].ToString();
                for (int i = 0; i < aPath.Length; i++)
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
