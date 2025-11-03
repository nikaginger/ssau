using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze15
{
    internal class Analyze
    {
        enum State
        {
            start_id, finish_id, Id, start_const, finish_const,
            C0, C1, C2, C3,
            Start, Finish,

            D1, D2,
            W1, W2,
            T1, R1, T2,
            S1, S2, S3, S4, S5, S6
        };
        public static List<string> id_list = new List<string>();
        public static List<string> const_list = new List<string>();

        public static string[] Analyzing(string s)
        {
            int cur = 0;
            State status = State.Start;
            s = s + '\n';
            s = s.ToUpper();

            while (status != State.Finish && cur < s.Length)
            {
                switch (status)
                {
                    case State.Start:
                        if (s[cur] == ' ')
                        {
                            status = State.Start;
                            cur += 1;
                        }
                        else if (s.Length - cur < 2)
                        {
                            cur = s.Length;
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Неожиданный конец строки", cur);
                        }
                        else if (s[cur] == 'D' && s[cur + 1] == 'O')
                        {
                            status = State.D1;
                            cur += 2;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Допустим пробел или DO", cur);
                        }
                        break;
                    case State.D1:
                        if (s[cur] == ' ') { status = State.D2; cur += 1; }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел", cur);
                        break;
                    case State.D2:
                        if (s[cur] == ' ')
                        {
                            status = State.D2;
                            cur += 1;
                        }
                        else if (s.Length - cur < 5)
                        {
                            cur = s.Length;
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Неожиданный конец строки", cur);
                        }
                        else if (s[cur] == 'W' && s[cur + 1] == 'H' && s[cur + 2] == 'I' && s[cur + 3] == 'L' && s[cur + 4] == 'E')
                        {
                            status = State.W1;
                            cur += 5;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или WHILE", cur);
                        }
                        break;

                    case State.W1:
                        if (s[cur] == ' ')
                        {
                            status = State.W2;
                            cur++;
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел", cur);
                        break;
                    case State.W2:
                        if (s[cur] == ' ')
                        {
                            status = State.W2;
                            cur++;
                        }
                        else if (char.IsLetter(s[cur]))
                        {
                            status = State.T1;
                            cur = Identificator(s, cur);
                        }
                        else if (char.IsDigit(s[cur]) || s[cur] == '-' || s[cur] == '+')
                        {
                            status = State.T1;
                            cur = IsConst(s, cur);
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или продолжение идентификатора или константы", cur);
                        break;
                    // Состояние после первого сравнения
                    
                    case State.T1:
                        if (s[cur] == ' ')
                        {
                            status = State.T1;
                            cur++;
                        }
                        else if ((s[cur] == '=') || (s[cur] == '>') || (s[cur] == '<'))
                        {
                            status = State.R1;
                            cur++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидались '<|>|=' или пробел", cur);
                        }
                        break;
                    case State.R1:
                        if (s[cur] == ' ')
                        {
                            status = State.R1;
                            cur++;
                        }
                        else if (char.IsLetter(s[cur]))
                        {
                            status = State.T2;
                            cur = Identificator(s, cur);
                        }
                        else if (char.IsDigit(s[cur]) || s[cur] == '-' || s[cur] == '+')
                        {
                            status = State.T2;
                            cur = IsConst(s, cur);
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или продолжение идентификатора или константы", cur);
                        break;
                    case State.T2:
                        if (s[cur] == '\n') {
                            status = State.Finish;
                        }
                        else if (s[cur] == ' ')
                        {
                            status = State.S1;
                            cur++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или конец строки", cur);
                        }
                        break;
                    case State.S1:
                        if (s[cur] == ' ')
                        {
                            status = State.S1;
                            cur++;
                        }
                        else if (s[cur] == 'A' && s[cur + 1] == 'N' && s[cur + 2] == 'D')
                        {
                            status = State.S2;
                            cur += 3;
                        }
                        else if (s[cur] == 'O' && s[cur + 1] == 'R')
                        {
                            status = State.S2;
                            cur += 2;
                        }
                        else if (s[cur] == 'X' && s[cur + 1] == 'O' && s[cur + 2] == 'R')
                        {
                            status = State.S2;
                            cur += 3;
                        }

                        else throw new ExceptionWithPosition(" [!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался OR или XOR или AND", cur);
                        break;
                    case State.S2:
                        if (s[cur] == ' ')
                        {
                            status = State.S3;
                            cur += 1;
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел", cur);
                        break;
                    case State.S4:
                        if (s[cur] == ' ')
                        {
                            status = State.S4;
                            cur++;
                        }
                        else if ((s[cur] == '=') || (s[cur] == '>') || (s[cur] == '<'))
                        {
                            status = State.S5;
                            cur++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидались '<|>|=' или пробел", cur);
                        }
                        break;
                    case State.S3:
                        if (s[cur] == ' ')
                        {
                            status = State.S3;
                            cur++;
                        }
                        else if (char.IsLetter(s[cur]))
                        {
                            status = State.S4;
                            cur = Identificator(s, cur);
                        }
                        else if (char.IsDigit(s[cur]) || s[cur] == '-' || s[cur] == '+')
                        {
                            status = State.S4;
                            cur = IsConst(s, cur);
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или продолжение идентификатора или константы", cur);
                        break;
                    case State.S5:
                        if (s[cur] == ' ')
                        {
                            status = State.S5;
                            cur++;
                        }
                        else if (char.IsLetter(s[cur]))
                        {
                            status = State.S6;
                            cur = Identificator(s, cur);
                        }
                        else if (char.IsDigit(s[cur]) || s[cur] == '-' || s[cur] == '+')
                        {
                            status = State.S6;
                            cur = IsConst(s, cur);
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался пробел или продолжение идентификатора или константы", cur);
                        break;
                    case State.S6:
                        if (s.Length != cur && s[cur] == ' ')
                        {
                            status = State.S6;
                            cur += 1;
                        }
                        else if (s[cur] == '\n')
                        {
                            status = State.Finish;
                        }
                        else { throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожилася конец строки", cur); }
                        break;

                }
            }
            if (status != State.Finish)
            {
                throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Введённая строка не закончена!", cur);
            }
            return ResultToString(id_list, const_list);
        }

        public static string[] ResultToString(List<string> id_list, List<string> const_list)
        {
            string resultIds = string.Join(Environment.NewLine, id_list);
            string resultConsts = string.Join(Environment.NewLine, const_list);

            Clear_lists();

            return new string[] { resultIds, resultConsts };
        }
        public static void Clear_lists()
        {
            const_list.Clear();
            id_list.Clear();
        }

        public static int Identificator(string s, int cur)
        {
            int len = 0;
            int p0 = cur;
            State status_id = State.start_id;

            while (status_id != State.finish_id && cur != -1 && cur < s.Length)
            {
                switch (status_id)
                {
                    case State.start_id:
                        if (char.IsLetter(s[cur]))
                        {
                            status_id = State.Id;
                            cur++;
                            len++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидался буквенный символ", cur);
                        }
                        break;

                    case State.Id:
                        if (cur == s.Length)
                        {
                            status_id = State.finish_id;
                        }
                        else if (char.IsLetterOrDigit(s[cur]))
                        {
                            status_id = State.Id;
                            cur += 1;
                            len++;
                        }
                        else
                        {
                            status_id = State.finish_id;
                        }
                        break;
                }
            }

            if (len > 8)
            {
                throw new ExceptionWithPosition("[!] СЕМАНТИЧЕСКАЯ ОШИБКА: Слишком длинный идентификатор", cur);
            }

            string identifier = s.Substring(p0, len);
            if (IsKeyword(identifier))
            {
                throw new ExceptionWithPosition("[!] СЕМАНТИЧЕСКАЯ ОШИБКА: Идентификатор не может быть ключевым словом", cur);
            }

            UpdateIdList(identifier);

            return cur;
        }

        private static bool IsKeyword(string identifier)
        {
            string[] keywords = { "DO", "WHILE", "AND", "OR", "XOR"};
            return keywords.Contains(identifier);
        }

        private static void UpdateIdList(string identifier)
        {
            if (!id_list.Contains(identifier))
            {
                id_list.Add(identifier);
            }
        }

        static int IsConst(string s, int cur)
        {
            State status_const = State.start_const;
            List<string> chars = new List<string>();
            int p0 = cur;
            bool flag = false;
            int p_dot = 0;

            while (status_const != State.finish_const && cur != -1 && cur < s.Length)
            {
                switch (status_const)
                {
                    case State.start_const:
                        if (s[cur] == '-' || s[cur] == '+')
                        {
                            status_const = State.C0;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                        }
                        else if (char.IsDigit(s[cur]))
                        {
                            status_const = State.C1;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидалось +|-|1|..|9", cur);
                        break;
                    case State.C0:
                        if (char.IsDigit(s[cur]))
                        {
                            status_const = State.C1;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                        }
                        else throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидалось 1|..|9", cur);
                        break;

                    case State.C1:
                        if (char.IsDigit(s[cur]))
                        {
                            status_const = State.C1;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                            //p_dot = cur - 1;
                        }
                        else if (s[cur] == '.')
                        {
                            status_const = State.C2;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                            p_dot = cur - 1;
                        }
                        else { status_const = State.finish_const; }
                        break;

                    case State.C2:
                        if (char.IsDigit(s[cur]))
                        {
                            status_const = State.C3;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] СИНТАКСИЧЕСКАЯ ОШИБКА: Ожидалось 0|..|9", cur);
                        }
                        break;

                    case State.C3:
                        if (cur == s.Length)
                        {
                            status_const = State.finish_const;
                        }
                        else if (char.IsDigit(s[cur]))
                        {
                            status_const = State.C3;
                            chars.Add(Convert.ToString(s[cur]));
                            cur += 1;
                        }
                        else status_const = State.finish_const;
                        break;
                }
            }

            string ans = string.Join("", chars.ToArray());
            double anas = Convert.ToDouble(ans, new NumberFormatInfo { NumberDecimalSeparator = "." });

            if (anas < -32768 || anas > 32768)
            {
                throw new ExceptionWithPosition("[!] СЕМАНТИЧЕСКАЯ ОШИБКА: Число вне диапазона [-32768; 32768]", cur);
            }

            if (cur != -1)
            {
                string ind_str = s.Substring(p0, cur - p0);
                if (const_list.Count == 0 || !const_list.Contains(ind_str))
                {
                    const_list.Add(ind_str);
                }
            }

            return cur;
        }
    }
}
