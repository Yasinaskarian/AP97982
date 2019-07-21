using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A10;

namespace P1.Equations
{
   public class Matrixsolution
    {
        public static SquareMatrix<double> Converttomatrix(string[] equlations, List<char> variables)
        {
            char[] chr = equlations[0].ToCharArray();
            List<Vector<double>> Rows = new List<Vector<double>>();

            for (int i = 0; i < equlations.Length; i++)
            {
                chr = equlations[i].ToCharArray();
                Vector<double> row = new Vector<double>(equlations.Length);
                int count = 0;
                double num = 0;
                for (int j = 0; j < chr.Length; j++)
                {
                    if (chr[j] != '+' && chr[j] != '=')
                    {
                        if (!variables.Contains(chr[j]))
                        {
                        
                            num = (num * 10) + double.Parse(chr[j].ToString());
                            row[count] = num;
                        }
                        else
                        {
                            count++;
                            num = 0;
                        }

                    }
                    else if (chr[j] == '=')
                        break;
                }
                Rows.Add(row);
            }
            SquareMatrix<double> matrix = new SquareMatrix<double>(Rows.Count) { };
            for (int i = 0; i < Rows.Count; i++)
                matrix[i] = Rows[i];
            return matrix;
        }
        public static List<double> Solvetheequation(SquareMatrix<double> matrix, List<double> rightside)
        {
            List<double> solveeq = new List<double>();
            double totdet = Det(matrix);
            SquareMatrix<double> copymatrix = new SquareMatrix<double>(Copy(matrix));
            for (int i = 0; i < copymatrix.ColumnCount; i++)
            {
                  
                for (int j = 0; j <copymatrix.ColumnCount; j++)
                {
                    copymatrix[j][i] = rightside[j];
                }
                double d = Det(copymatrix) / totdet;
                solveeq.Add(Math.Round(d,5));
                copymatrix = new SquareMatrix<double>(Copy(matrix));
                //copymatrix =Copy(matrix);
            }
            return solveeq;
        }

        private static SquareMatrix<double> Copy(SquareMatrix<double> matrix)
        {
            SquareMatrix<double> copy = new SquareMatrix<double>(matrix.ColumnCount);
            Vector<double> v = new Vector<double>(matrix.ColumnCount);
            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                v = new Vector<double>(matrix.ColumnCount);
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    v[j] = matrix[i][j];
                }
                copy[i] = v;  
            }
            return copy;
        }

        public static double Det(SquareMatrix<double> matrix)
        {
            double d = 0;
            if (matrix.ColumnCount == 2)
            {
                return (matrix[0][0] * matrix[1][1]) - (matrix[0][1] * matrix[1][0]);
            }
            else
            {
                for (int i = 0; i < matrix.ColumnCount; i++)
                {

                    d += matrix[0][i] * Det(Build(matrix, 0, i)) * (Math.Pow(-1, i));
                }
                return d;
            }
        }

        private static SquareMatrix<double> Build(SquareMatrix<double> matrix, int x, int y)
        {
            SquareMatrix<double> b = new SquareMatrix<double>(matrix.ColumnCount - 1) { };
            int q = 0, w = -1;
            Vector<double> v = new Vector<double>(matrix.ColumnCount - 1);

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                v = new Vector<double>(matrix.ColumnCount - 1);
                for (int j = 0; j < matrix.ColumnCount; j++)

                {

                    if (i != x && j != y)

                    {

                        //b[w][q] = matrix[i][j];
                        v[q] = matrix[i][j];
                        if (q != matrix.ColumnCount - 2)
                            q++;

                        else

                        {
                            q = 0;
                            w++;
                            b[w] = v;

                        }
                    }

                }
            }
            return b;
        }
    }
}
