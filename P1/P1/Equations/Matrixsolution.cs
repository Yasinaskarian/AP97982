using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A10;

namespace P1.Equations
{
    class Matrixsolution
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
        public static List<double> Solvetheequation(SquareMatrix<double> matrix,SquareMatrix<double> copymatrix, List<double> rightside)
        {
            List<double> solveeq = new List<double>();
            double totdet = det(matrix);
            
            for (int i = 0; i < copymatrix.ColumnCount; i++)
            {
                  
                for (int j = 0; j <copymatrix.ColumnCount; j++)
                {
                    copymatrix[j][i] = rightside[j];
                }
                double d = det(copymatrix) / totdet;
                solveeq.Add(d);
                copymatrix = matrix;
            }
            return solveeq;
        }

        public static double det(SquareMatrix<double> matrix)
        {
            double d = 1;
            if (matrix.ColumnCount == 2)
            {
                d = (matrix[0][0] * matrix[1][1]) - (matrix[0][1] * matrix[1][0]);
            }
            return d;
        }
    }
}
