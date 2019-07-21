using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1.Equations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1;
using A10;

namespace P1.Equations.Tests
{
    [TestClass()]
    public class MatrixsolutionTests
    {
        [TestMethod()]
        public void ConverttomatrixTest()
        {
            string[] s1 = "2x+3y=0,3x+2y=10".Split(',');
            List<char> v1 = new List<char>(2) { 'x', 'y' };
            SquareMatrix<double> matrix1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){2,3},
                 new Vector<double>(2){3,2}
                 
            };

            string[] s2 = "10x+5y+2z=7,2x+10y+5z=10,5x+2y+10z=9".Split(',');
            List<char> v2 = new List<char>(3) { 'x', 'y', 'z' };
            SquareMatrix<double> matrix2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){10,5,2},
                 new Vector<double>(3){2,10,5},
                  new Vector<double>(3){5,2,10}
            };
            string[] s3 = "10x+2y+5z+6t=10,12x+11y+2z+2t=4,11x+12y+4z+9t=12,14x+16y+4z+11t=10".Split(',');
            List<char> v3 = new List<char>(3) { 'x', 'y', 'z','t' };
            SquareMatrix<double> matrix3 = new SquareMatrix<double>(4)
            {
                new Vector<double>(4){10,2,5,6},
                 new Vector<double>(4){12,11,2,2},
                  new Vector<double>(4){11,12,4,9},
                  new Vector<double>(4){14,16,4,11}
            };
            SquareMatrix<double> matrix11 = Matrixsolution.Converttomatrix(s1, v1);
            SquareMatrix<double> matrix22 = Matrixsolution.Converttomatrix(s2, v2);
            SquareMatrix<double> matrix33 = Matrixsolution.Converttomatrix(s3, v3);
            Assert.AreEqual(matrix11, matrix1);
            Assert.AreEqual(matrix22, matrix2);
            Assert.AreEqual(matrix33, matrix3);
            Assert.AreNotEqual(matrix33, matrix2);
        
        }

        [TestMethod()]
        public void SolvetheequationTest()
        {
            SquareMatrix<double> matrix1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){2,3},
                 new Vector<double>(2){3,2}

            };
            List<double> rightside1 = new List<double>(2) { 0, 10 };
            List<double> answer1 = new List<double>(2) { 6, -4 };
            List<double> answer11 = Matrixsolution.Solvetheequation(matrix1, rightside1);
            SquareMatrix<double> matrix2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){10,5,2},
                 new Vector<double>(3){2,10,5},
                  new Vector<double>(3){5,2,10}
            };
            List<double> rightside2 = new List<double>(3) { 7, 10,9 };
            List<double> answer2 = new List<double>(3)
            { 0.2581,
                0.62545,
            0.64586};
            List<double> answer22 = Matrixsolution.Solvetheequation(matrix2, rightside2);
            SquareMatrix<double> matrix3 = new SquareMatrix<double>(4)
            {
                new Vector<double>(4){10,2,5,6},
                 new Vector<double>(4){12,11,2,2},
                  new Vector<double>(4){11,12,4,9},
                  new Vector<double>(4){14,16,4,11}
            };
            List<double> rightside3 = new List<double>(4) { 10, 4,12,10 };
            List<double> answer3 = new List<double>(4)
            { -1.70093,
            1.29346,
            6.1271,
            -1.03551};
            List<double> answer33 = Matrixsolution.Solvetheequation(matrix3, rightside3);
            CollectionAssert.AreEqual(answer11, answer1);
            CollectionAssert.AreEqual(answer22, answer2);
            CollectionAssert.AreEqual(answer33, answer3);
            CollectionAssert.AreNotEqual(answer22, answer3);
        }

        [TestMethod()]
        public void DetTest()
        {
            SquareMatrix<double> matrix1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2){2,3},
                 new Vector<double>(2){3,2}

            };
            SquareMatrix<double> matrix2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3){10,5,2},
                 new Vector<double>(3){2,10,5},
                  new Vector<double>(3){5,2,10}
            };
            SquareMatrix<double> matrix3 = new SquareMatrix<double>(4)
            {
                new Vector<double>(4){10,2,5,6},
                 new Vector<double>(4){12,11,2,2},
                  new Vector<double>(4){11,12,4,9},
                  new Vector<double>(4){14,16,4,11}
            };
            Assert.AreEqual(Matrixsolution.Det(matrix1), -5);
            Assert.AreEqual(Matrixsolution.Det(matrix2), 833);
            Assert.AreEqual(Matrixsolution.Det(matrix3), 535);
            Assert.AreNotEqual(Matrixsolution.Det(matrix2), 535);
        }
        
    }
    
}