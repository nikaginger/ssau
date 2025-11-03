using System;

namespace LR_2
{
    static class Vectors
    {
        public static ArrayVector Sum(ArrayVector array1, ArrayVector array2)
        {
            if (array1.Length == array2.Length)
            {
                ArrayVector arrayVector = new ArrayVector(array1.Length);

                for (int i = 0; i < arrayVector.Length; i++)
                {
                    arrayVector[i] = array1[i] + array2[i];
                }
                return arrayVector;
            }
            else
            {
                throw new Exception("Different length of vectors");
            }
        }
        public static double Scalar(ArrayVector array1, ArrayVector array2)
        {
            double summa = 0;
            if (array1.Length == array2.Length)
            {
                for (int i = 0; i < array1.Length; i++)
                {
                    summa += array1[i] * array2[i];
                }
                return summa;
            }
            else
            {
                throw new Exception("Different length of vectors");
            }
        }
        public static double GetNormSt(ArrayVector array1)
        {
            double summa = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                summa += Math.Abs(array1[i]);
            }
            return summa / array1.Length;
        }
    }
}