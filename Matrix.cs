using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class Matrix: IEnumerable
    {
        int n;
        int N
        {
            get
            {
                return n;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("N cannot be <= 0");
                n = value;
            }
        }

        int[,] array;
        int[,] Array
        {
            get
            {
                return array;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Array not set");
                array = value;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if ((i < 0 || i >= N) && (j < 0 || j >= N))
                    throw new IndexOutOfRangeException("Some of indexes are incorrect");
                return array[i, j];
            }
            set
            {
                if ((i < 0 || i >= N) && (j < 0 || j >= N))
                    throw new IndexOutOfRangeException("Some of indexes are incorrect");
                array[i, j] = value;
            }
        }

        public Matrix(int[,] array, int n)
        {
            N = n;
            this.array = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    this.array[i, j] = array[i, j];
        }

        public override string ToString()
        {
            string info = $"Matrix info: Size: {N}\n";

            foreach (var elem in this)
                info += $"{elem} ";

            return info + "\n";
        }

        public IEnumerator GetEnumerator()
        {
            return new MatrixEnumerator(Array, N);
        }

        private class MatrixEnumerator : IEnumerator
        {
            int positionN = -1;
            int positionM = -1;
            int n;
            int[,] array;

            public MatrixEnumerator(int[,] array, int n)
            {
                this.array = array;
                this.n = n;
                positionN = n - 1;
                positionM = n;
            }

            object IEnumerator.Current
            {
                get
                {
                    try
                    {
                        return array[positionN, positionM];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException("One of the index is out of MatrixEnumerator range");
                    }
                }
            }

            public bool MoveNext()
            {
                positionM--;
                if (positionM < 0)
                {
                    positionM = n - 1;
                    positionN--;
                }
                return positionN >= 0;
            }

            public void Reset()
            {
                positionN = positionM = n - 1;
            }
        }
    }
}
