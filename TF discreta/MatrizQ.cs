using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TF_discreta
{
    class MatrizQ
    {
        private int num;
        private int[][] matrix;
        public MatrizQ(int nu)
        {
            num = nu;

            matrix = new int[num][];
            for (int i = 0; i < num; i++)
            {
                matrix[i] = new int[num];
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (i == j)
                    {
                        matrix[i][j] = 1;//refelxiva
                    }
                    else
                        matrix[i][j] = 0;
                }
            }


        }
        public int getN() { return num; }
        public int getP(int i, int j) { return matrix[i][j]; }
        public int[][] returnMa() { return matrix; }
        public void setP(int i, int j, int value)
        { //simetrica
            matrix[i][j] = value;
            matrix[j][i] = value;
        }
        public void Print()//no sirve porque en android no se ve xD
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine("");
            }
        }

    }

}