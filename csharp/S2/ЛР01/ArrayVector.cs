using System;

namespace LR_1
{
    class ArrayVector
    {
        int[] coords;

        public ArrayVector(int n)
        {
            coords = new int[n];
        }
        public ArrayVector()
        {
            coords = new int[5];
        }

        public int this[int index]
        {
            get { return coords[index]; }
            set { 
                if ((index < coords.Length) && (index >= 0)) { coords[index] = value; } 
                else { throw new Exception(); }
            }
        }

        public int ArrayVectorLength()
        {
            return coords.Length;
        }
        public double GetNorm()
        {
            int summa = 0;
            for (int i = 0; i < coords.Length; i++)
            {
                summa += coords[i] * coords[i];
            }
            return Math.Sqrt(summa);
        }

        public int SumPositivesFromChetIndex()
        {
            int summa = 0;
            for (int i = 0; i < coords.Length; i++)
            {
                if (((i+1) % 2 == 0) && (coords[i] > 0))
                {
                    summa += coords[i];
                }
            }
            return summa;
        }

        public int SumLessFromNechetIndex()
        {
            int summaAbs = 0;
            int summa = 0;
            for (int i = 0; i < coords.Length; i++)
            {
                summaAbs += Math.Abs(coords[i]);
            }
            summaAbs = summaAbs / coords.Length;
            for (int i = 0; i < coords.Length; i++)
            {
                if (((i + 1) % 2 != 0) && (coords[i] < summaAbs))
                {
                    summa += coords[i];
                }
            }
            return summa;
        }

        public int MultChet()
        {
            int multy = 1;
            for (int i = 0; i < coords.Length; i++)
            {
                if ((coords[i] % 2 == 0) && (coords[i]) > 0)
                {
                    multy *= coords[i];
                }
            }
            return multy;
        }

        public int MultNechet()
        {
            int multy = 1;
            for (int i = 0; i < coords.Length; i++)
            {
                if ((coords[i] % 2 != 0) && (coords[i]) % 3 != 0)
                {
                    multy *= coords[i];
                }
            }
            return multy;
        }

        public int[] SortUp()
        {
            Array.Sort(coords);
            return coords;
        }
        public int[] SortDown()
        {
            Array.Sort(coords);
            Array.Reverse(coords);
            return coords;
        }
    }
}
