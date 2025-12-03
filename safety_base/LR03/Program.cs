using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XOREncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Задание 3. Одноразовый блокнот (файлы)\n");

            Console.Write("Введите путь к файлу для шифрования: ");
            string inputPath = Console.ReadLine()?.Trim() ?? "";

            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            try
            {
                byte[] data = System.IO.File.ReadAllBytes(inputPath);
                byte[] key = new byte[data.Length];
                byte[] encrypted = new byte[data.Length];
                byte[] decrypted = new byte[data.Length];

                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(key);
                }

                for (int i = 0; i < data.Length; i++)
                    encrypted[i] = (byte)(data[i] ^ key[i]);

                for (int i = 0; i < data.Length; i++)
                    decrypted[i] = (byte)(encrypted[i] ^ key[i]);

                System.IO.File.WriteAllBytes("encrypted.bin", encrypted);
                System.IO.File.WriteAllBytes("decrypted.bin", decrypted);

                Console.WriteLine("Файл зашифрован: encrypted.bin");
                Console.WriteLine("Файл расшифрован: decrypted.bin");

                bool ok = StructuralComparisons.StructuralEqualityComparer.Equals(data, decrypted);
                Console.WriteLine(ok
                    ? "Проверка: данные совпадают."
                    : "Ошибка: данные не совпадают.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке файла: " + ex.Message);
            }
        }
    }
}
