//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace A10
//{
//    /// <summary>
//    /// A vector of numbers. Implement vector addition and multiplication.
//    /// </summary>
//    /// <typeparam name="_Type"></typeparam>
//    public class Vector<_Type> : 
//        IEnumerable<_Type>, IEquatable<Vector<_Type>>
//        where _Type: IEquatable<_Type>        
//    {
//        /// <summary>
//        /// Vector data
//        /// </summary>
//        public readonly _Type[] Data;

//        /// <summary>
//        /// Add index. Only used for collection initialization.
//        /// </summary>
//        protected int AddIndex = 0;

//        /// <summary>
//        /// Vector Size
//        /// </summary>
//        public int Size => Data.Length;

//        /// <summary>
//        /// Add method to allow collection initialization.
//        /// </summary>
//        /// <param name="v"></param>
//        public void Add(_Type v)
//        {
//            Data[AddIndex++] = v;
//        }

//        /// <summary>
//        /// Create a new Vector
//        /// </summary>
//        /// <param name="length">Vector length</param>
//        public Vector(int length)
//        {
//            this.Data = new _Type[length];
//        }


//        /// <summary>
//        /// Copy constructor
//        /// </summary>
//        /// <param name="other"></param>
//        public Vector(Vector<_Type> other)
//            : this(other.Size)
//        {
            
//            for (int i = 0; i < other.Size; i++)
//            {
//                this.Data[i] = other[i];
//            }
//        }

//        /// <summary>
//        /// Constructor for IEnumerable
//        /// </summary>
//        /// <param name="list">IEnumerable of _Type</param>
//        public Vector(IEnumerable<_Type> list)
//            : this(list.Count())
//        {
//            int i = 0;
//            foreach (IEnumerable<_Type> l in list)
//            {
//                Data[i] =(_Type) l;
//                i++;
//            }

//        }

//        /// <summary>
//        /// Accessor for data elements
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public _Type this[int index]
//        {
//            get
//            {
//                if (index < 0 || index >= Size)
//                {
//                    throw new IndexOutOfRangeException("index");
//                }
//                return Data[index];
//            }
//        }


//        ///// <summary>
//        ///// Add two vectors
//        ///// </summary>
//        ///// <param name="v1">vector 1</param>
//        ///// <param name="v2">vector 2</param>
//        ///// <returns>sum of vector 1 and 2</returns>
//        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
//        {
            
//            Vector<_Type> v3=new Vector<_Type>(v1.Size);
//            if (v1.Size == v2.Size)
//            {
//                dynamic d;

//                for (int i = 0; i < v1.Size; i++)
//                {
//                    d = (dynamic)v1[i] + v2[i];
//                    v3.Add(d);
//                }

//            }
//            return v3;
//        }

//        ///// <summary>
//        ///// Inner product of two vectors
//        ///// </summary>
//        ///// <param name="v1">Vector 1</param>
//        ///// <param name="v2">Vector 2</param>
//        ///// <returns>Inner product of vector one and two</returns>
//        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
//        {
//            dynamic s = 0;
//            if (v1.Size == v2.Size)
//            {
//                dynamic d;
                
//                for (int i = 0; i < v1.Size; i++)
//                {
//                    d = (dynamic)v1[i] * v2[i];
//                    s += d;
//                }
             
//            }
//            return s;

//        }



//        ///// <summary>
//        ///// Equality operator
//        ///// </summary>
//        ///// <param name="v1">vector 1</param>
//        ///// <param name="v2">vector 2</param>
//        ///// <returns>whether v1 is equal to v2</returns>
//        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
//        {
//            if (v1.Size == v2.Size)
//            {
//                int count = 0;
//                for (int i = 0; i < v1.Size; i++)
//                {
//                    //dynamic d1 = v1[i];
//                    //dynamic d2 = v2[i];
//                    if ((dynamic)v1[i] == v2[i])
//                    {
//                        count++;
//                    }
//                }
//                if (count == v1.Size )
//                    return true;
//            }
//            return false;
//        }


//        ///// <summary>
//        ///// Inequality operator
//        ///// </summary>
//        ///// <param name="v1">vector 1</param>
//        ///// <param name="v2">vector 2</param>
//        ///// <returns>v1 not equal to v2</returns>
//        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
//        {
//            return !(v1 == v2);
            
//        }


//        ///// <summary>
//        ///// Override Object.Equals
//        ///// </summary>
//        ///// <param name="obj"></param>
//        ///// <returns>Whether this object is equal to obj</returns>
//        public override bool Equals(object obj)
//        {
//            if(obj is Vector<_Type>)
//            {
//                Vector<_Type> v1 = obj as Vector<_Type>;
//                if (this.Size == v1.Size)
//                {
//                    int count = 0;
//                    for (int i = 0; i < v1.Size; i++)
//                    {
//                        dynamic d1 = v1[i];
//                        dynamic d2 = this.Data[i];
//                        if (d1 == d2)
//                        {
//                            count++;
//                        }
//                    }
//                    if (count == v1.Size )
//                        return true;
//                }
//                return false;
//            }
//            return false;
//        }

//        /// <summary>
//        /// Implementing IEquatable interface
//        /// </summary>
//        /// <param name="other">another vector</param>
//        /// <returns>whether other vector is equal to this vector</returns>
//        public bool Equals(Vector<_Type> other)
//        {
//            if (this.Size == other.Size)
//            {
//                int count = 0;
//                for (int i = 0; i < other.Size; i++)
//                {
//                    dynamic d1 = other[i];
//                    dynamic d2 = this.Data[i];
//                    if (d1==d2)
//                    {
//                        count++;
//                    }
//                }
//                if (count == other.Size)
//                    return true;
//            }
//            return false;
//        }

//        public override int GetHashCode()
//        {
//            return this.Size.GetHashCode();
//        }
//        public override string ToString()
//        {
//            string s = "[";
//            for(int i = 0; i < this.Size; i++)
//            {
//                if (i == 0)
//                {
//                    s += $"{Data[i]}";
//                }
//                else
//                s += $",{Data[i]}";
//            }
//            s += "]";
//            return s;
//        }

//        public IEnumerator<_Type> GetEnumerator()
//        {
//            foreach (var s in Data)
//                yield return s;
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return Data.GetEnumerator();
//        }
//    }
//}
