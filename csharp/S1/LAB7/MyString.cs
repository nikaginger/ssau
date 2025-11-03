using System;

namespace LAB7
{
    class MyString
    {
        string str;
        public string[] words;
        public MyString()
        {
            str = "";
        }
        public MyString(string str)
        {
            this.str = str;
            words = str.Split(new Char[] { ' ', '!', '?', '.', ',', '%', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public string GetString
        {
            get { return str; }
        }
        public static int CountLetters(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (char.IsLetter(c))
                    count++;
            }
            return count;
        }

        public static double AverageWordLength(string str)
        {
            string[] words = str.Split(new Char[] { ' ', '!', '?', '.', ',', '%', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
            double average;
            double summa = 0;
            foreach (string word in words)
            {
                summa += CountLetters(word);
            }
            average = summa / words.Length;
            return average;
        }

        public static string ReplaceString(string str, string old, string newword)
        {
            string[] words = str.ToLower().Split();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == old)
                    words[i] = newword;
                if (words[i] == (old + ","))
                    words[i] = newword + ",";
                if (words[i] == (old + ":"))
                    words[i] = newword + ":";
                if (words[i] == (old + "!"))
                    words[i] = newword + "!";
                if (words[i] == (old + "?"))
                    words[i] = newword + "?";
                if (words[i] == (old + "."))
                    words[i] = newword + ".";
            }
            return String.Join(" ", words);
        }

        public void isDate(string str)
        {
            bool check;
            Console.WriteLine(str);
            string[] wordsarr = str.Split('.');
            if (wordsarr.Length == 3)
            {
                if ((Int16.Parse(wordsarr[0]) > 1 && Int16.Parse(wordsarr[0]) <= 31) && (Convert.ToInt16(wordsarr[1]) > 1 && Convert.ToInt16(wordsarr[1]) < 12) && ((wordsarr[2].Length == 2 || wordsarr[2].Length == 4)))
                {
                    if (Int16.Parse(wordsarr[2]) == 2 && Int16.Parse(wordsarr[3]) % 4 == 0 && Int16.Parse(wordsarr[1]) > 29)
                    {
                        check = false;
                    }
                    else if (Int16.Parse(wordsarr[2]) == 2 && Int16.Parse(wordsarr[3]) % 4 != 0 && Int16.Parse(wordsarr[1]) > 28)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                else { check = false; }
            }
            else { check = false; }
            if (check) { Console.WriteLine("Строка является датой."); }
            else { Console.WriteLine("Строка не является датой."); }
        }

        public static int CountSubString(string str, string sub)
        {
            int count = 0;
            string[] wordsarr = str.ToLower().Split(' ', '.', '!', '?', '-', ';', ':', ',', '"');
            for (int i = 0; i < wordsarr.Length; i++)
            {
                for (int j = 0; j < wordsarr[i].Length - sub.Length + 1; j++)
                {
                    if (String.Compare(sub, wordsarr[i].Substring(j, sub.Length)) == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static bool IsPalindrome(string text)
        {
            string inverted = "";
            string olds = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    olds += char.ToLower(text[i]);
                }
            }

            for (int i = 0; i < olds.Length; i++)
            {
                inverted += olds[olds.Length - 1 - i];
            }

            return olds == inverted;
        }

    }
}
