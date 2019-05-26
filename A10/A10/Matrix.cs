using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> :
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
           this.Rows = new Vector<_Type>[rowCount];
            
        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
            : this(rows.ToArray().Length, rows.ToArray()[0].Size)
        {
            foreach(var row in rows)
            {
                this.Add(row);
               
            }
        }

        public void Add(Vector<_Type> row)
        {
           
            this.Rows[RowAddIndex++] = row;
           
        }

        public Vector<_Type> this[int index]
        {
            get
            {
                if (index < 0 || index >=RowCount)
                {
                    throw new IndexOutOfRangeException("index");
                }
                return Rows[index];
            }
            set
            {
                Rows[index] = value;
            }
        }

        public _Type this[int row, int col]
        {
            get
            {
                if ((row < 0 || row >= RowCount) && (col < 0 || col >= ColumnCount))
                {
                    throw new IndexOutOfRangeException("index");
                }
                return Rows[row].Data[col];
            }
            set
            {
                Rows[row].Data[col] = value;
            }
        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            Matrix<_Type> m3 = new Matrix<_Type>(m1.RowCount,m1.ColumnCount) ;
          
            if ((m1.RowCount == m2.RowCount) && (m1.ColumnCount == m2.ColumnCount))
            {
                for (int i = 0; i < m1.RowCount; i++)
                    m3.Rows[i] = m1.Rows[i] + m2.Rows[i];

                return m3;
            }
            throw new InvalidOperationException();
        }
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
       
            Matrix<_Type> m3 = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            if (m1.ColumnCount == m2.RowCount)
            {
                dynamic d=0;
                for (int i = 0; i < m1.RowCount; i++)
                {
                    m3.Rows[i] = new Vector<_Type>(m2.ColumnCount);
                    for (int j = 0; j < m2.ColumnCount; j++)
                        for (int k = 0; k < m1.ColumnCount; k++)
                            m3.Rows[i].Data[j] += (dynamic)(m1.Rows[i].Data[k])*(m2.Rows[k].Data[j]);
                }
                

                return m3;
            }
            throw new InvalidOperationException();
        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        //public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        //{

        //}

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        //protected IEnumerable<_Type> GetColumnEnumerator(int col)
        //{
        //}

        //protected Vector<_Type> GetColumn(int col) =>
        //    new Vector<_Type>(GetColumnEnumerator(col));


        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            if ((m1.RowCount == m2.RowCount) && (m1.ColumnCount == m2.ColumnCount))
            {
                int count = 0;
                for (int i = 0; i < m1.RowCount; i++)
                {
                    if (m1.Rows[i].Equals(m2[i]))
                        count++;
                }
                if (count == m1.RowCount)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2) => !(m1 == m2);
        public bool Equals(Matrix<_Type> other)
        {
            if ((this.RowCount == other.RowCount) && (this.ColumnCount == other.ColumnCount))
            {
                int count = 0;
                for (int i = 0; i < other.RowCount; i++)
                {
                    if (this.Rows[i].Equals(other[i]))
                        count++;
                }
                if (count == other.RowCount)
                    return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix<_Type>)
            {
                Matrix<_Type> m = obj as Matrix<_Type>;
                if ((this.RowCount == m.RowCount)&&(this.ColumnCount==m.ColumnCount))
                {
                    int count = 0;
                    for (int i = 0; i < m.RowCount; i++)
                    {
                        if (this.Rows[i].Equals(m[i]))
                            count++;
                    }
                    if (count == m.RowCount)
                        return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }
        public override string ToString()
        {
            string s = "[\n";
            for (int i = 0; i < RowCount; i++)
            {
                if (i == RowCount-1)
                {
                    s += $"{Rows[i].ToString()}\n";
                }
                else
                    s += $"{Rows[i].ToString()},\n";
            }
            s += "]";
            return s;
        }
        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }
    }
}