using System;

namespace LR_3
{
    class ArrayVector : IVectorable
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
        public int Length { 
            get { return coords.Length; }
            set {; }
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

        public override string ToString()
        {
            string res = Convert.ToString(Length) + ' ';
            for (int i = 0; i < Length; i++)
            {
                res += Convert.ToString(coords[i]) + ' ';
            }
            return res;
        }
    }
}

