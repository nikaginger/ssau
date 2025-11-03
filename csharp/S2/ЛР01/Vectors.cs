using System;

namespace LR_1
{
    static class Vectors
    {
        public static ArrayVector Sum(ArrayVector array1, ArrayVector array2)
        {
            ArrayVector arrayVector = new ArrayVector(array1.ArrayVectorLength());
            if (array1.ArrayVectorLength() == array2.ArrayVectorLength())
            {
                for (int i = 0; i < arrayVector.ArrayVectorLength(); i++)
                {
                    arrayVector[i] = array1[i] + array2[i];
                }
                return arrayVector;
            }
            else
            {
                throw new Exception("Разная размерность векторов");
            }
            ;
        }

        public static double Scalar(ArrayVector array1, ArrayVector array2)
        {
            double summa = 0;
            if (array1.ArrayVectorLength() == array2.ArrayVectorLength())
            {
                for (int i = 0; i < array1.ArrayVectorLength(); i++)
                {
                    summa += array1[i] * array2[i];
                }
                return summa;
            }
            else
            {
                throw new Exception("Разная размерность векторов");
            }
        }

        public static ArrayVector MultNumber(ArrayVector array1, int k)
        {
            ArrayVector arrayVector = new ArrayVector(array1.ArrayVectorLength());
            for (int i = 0; i < arrayVector.ArrayVectorLength(); i++)
            {
                arrayVector[i] = array1[i] * k;
            }
            return arrayVector;
        }

        public static double GetNormSt(ArrayVector array1)
        {
            double summa = 0;
            for (int i = 0; i < array1.ArrayVectorLength(); i++)
            {
                summa += Math.Abs(array1[i]);
            }
            return summa / array1.ArrayVectorLength();
        }
    }
}
