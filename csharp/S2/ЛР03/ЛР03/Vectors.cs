using System;

namespace LR_3
{
    static class Vectors
    {
        public static IVectorable Sum(IVectorable array1, IVectorable array2)
        {
            if (array1.Length == array2.Length)
            {
                IVectorable arrayVector = new ArrayVector(array1.Length);

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


        public static double Scalar(IVectorable array1, IVectorable array2)
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
        public static double GetNormSt(IVectorable array1)
        {
            int summa = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                summa += array1[i] * array1[i];
            }
            return Math.Sqrt(summa);
        }
    }
}