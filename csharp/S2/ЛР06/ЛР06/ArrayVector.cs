using System;

namespace LR_6
{
    [Serializable]
    class ArrayVector : IVectorable, IComparable, ICloneable
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
        public int Length
        {
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

        public override bool Equals(object obj)
        {
            if (obj.GetType() is IVectorable || Length != ((IVectorable)obj).Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (coords[i] != ((IVectorable)obj)[i]) return false;
                }
            }
            return true;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is IVectorable))
            {
                throw new Exception("Object is not IVectorable");
            }
            else
            {
                if (Length < ((IVectorable)obj).Length)
                {
                    return -1;
                }
                else if (Length > ((IVectorable)obj).Length)
                {
                    return 1;
                }
                return 0;
            }
        }

        public Object Clone()
        {
            ArrayVector clone = new ArrayVector(Length);
            for (int i = 0; i < Length; i++)
            {
                clone[i] = coords[i];
            }
            return clone;
        }
    }
}



