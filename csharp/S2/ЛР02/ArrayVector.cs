using System;

namespace LR_2
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

        public int this[int i]
        {
            get
            {
                if (0 <= i && i <= Length) return coords[i];
                else throw new Exception("Vector index out of range");
            }
            set
            {
                if (0 <= i && i <= Length) coords[i] = value;
                else throw new Exception("Vector index out of range");
            }
        }
        public int Length { get; set; }

        public double GetNorm()
        {
            int summa = 0;
            for (int i = 0; i < coords.Length; i++)
            {
                summa += coords[i] * coords[i];
            }
            return Math.Sqrt(summa);
        }
    }
}

