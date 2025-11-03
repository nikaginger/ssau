using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using LR_7;

namespace LR_7
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

        public static void InputVectors(List<IVectorable> vectors, FileStream fileStream)
        {

            fileStream.Seek(0, SeekOrigin.End);
            for (int i = 0; i < vectors.Count; i++)
            {
                string vectorString = vectors[i].ToString() + '\n';
                byte[] dataToWrite = Encoding.UTF8.GetBytes(vectorString);
                fileStream.Write(dataToWrite, 0, dataToWrite.Length);

            }
        }
        public static List<IVectorable> OutputVectors(FileStream fileStream)
        {
            string path = @"C:\Users\veron\source\repos\csharp\Console\LR-5\Vectors.txt";
            List<IVectorable> vectorsRead = new List<IVectorable>();
            int bytesRead = 1;
            string contentRead = "";
            do
            {
                byte[] buffer = new byte[1024];
                bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                contentRead += Encoding.UTF8.GetString(buffer, 0, bytesRead);

            } while (bytesRead > 0);
            string[] content = contentRead.Split(new char[] { '\n' });
            for (int i = 0; i < content.Length - 1; i++)
            {
                string[] vectorInfo = content[i].Split(' ');
                IVectorable vector = new ArrayVector(Convert.ToInt32(vectorInfo[0]));
                for (int j = 0; j < vector.Length; j++)
                {
                    vector[j] = Convert.ToInt32(vectorInfo[j + 1]);
                }
                vectorsRead.Add(vector);
            }
            return vectorsRead;
        }
        public static void WriteVector(IVectorable vector, TextWriter output)
        {
            output.WriteLine(vector.ToString());
        }
        public static IVectorable ReadVector(TextReader input)
        {
            string[] coordinates = input.ReadLine().Split(' ');
            IVectorable vector = new ArrayVector(Int32.Parse(coordinates[0]));
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = Int32.Parse(coordinates[i + 1]);
            }
            return vector;
        }
    }
}

