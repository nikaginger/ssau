using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Analyzator15
{
    internal class Analyzer
    {
        enum State
        {
            start_id, Id, finish_id, start_const, finish_const, C1, C2, C3,
            C4, start_operator, finish_operator, O1, O2, O3, O4, O5, O7, O8,
            Sr, Fr, R1, R2, R3, R4, R5, R6, R7, R8,
            Start, Finish, A, B, C, D, E, F,
            G, H, J, K, L, M, N, O,
            P, Q
        };
        public static List<string> id_list = new List<string>();
        public static List<string> const_list = new List<string>();

        public static string[] Analyze(string s)
        {
            int current_i = 0;
            State status = State.Start;
            s = s.ToUpper();

            while (status != State.Finish && current_i < s.Length)
            {
                switch (status)
                {
                    case State.Start:
                        if (s[current_i] == ' ')
                        {
                            status = State.Start;
                            current_i += 1;
                        }
                        else if (s[current_i] == 'W' && s[current_i + 1] == 'H' && s[current_i + 2] == 'I' && s[current_i + 3] == 'L' && s[current_i + 4] == 'E')
                        {
                            status = State.A;
                            current_i += 5;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] ОШИБКА: Допустим пробел или WHILE", current_i);
                        }
                        break;
                    case State.A:
                        if (s[current_i] == ' ') { status = State.B; current_i += 1; }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел", current_i);
                        break;
                    case State.B:
                        if (s[current_i] == ' ')
                        {
                            status = State.B;
                            current_i += 1;
                        }
                        else if (s[current_i] == '(')
                        {
                            status = State.C;
                            current_i += 1;
                        }
                        else if (Relation(s, current_i) != -1)
                        {
                            current_i = Relation(s, current_i);
                            status = State.M;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] ОШИБКА: Ожидались '(' или отношение", current_i);
                        }
                        break;

                    case State.C:
                        if (s[current_i] == ' ')
                        {
                            status = State.C;
                            current_i++;
                        }
                        else if (Relation(s, current_i) != -1)
                        {
                            current_i = Relation(s, current_i);
                            status = State.D;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или отношение", current_i);
                        break;
                    case State.D:
                        if (s[current_i] == ' ')
                        {
                            status = State.D;
                            current_i++;
                        }
                        else if (s[current_i] == ')')
                        {
                            status = State.E;
                            current_i += 1;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или ')' или продолжение идентификатора или константы", current_i);
                        break;
                    case State.E:
                        if (s[current_i] == ' ')
                        {
                            status = State.E;
                            current_i++;
                        }
                        else if (s[current_i] == 'A' && s[current_i + 1] == 'N' && s[current_i + 2] == 'D')
                        {
                            status = State.F;
                            current_i += 3;
                        }
                        else if (s[current_i] == 'O' && s[current_i + 1] == 'R')
                        {
                            status = State.F;
                            current_i += 2;
                        }
                        else if (s[current_i] == ' ' && s[current_i + 1] == ' ')
                        {
                            status = State.L;
                            current_i++;
                        }
                        else if (s[current_i] == 'D' && s[current_i + 1] == 'O')
                        {
                            status = State.O; current_i += 2;
                        }
                        else throw new ExceptionWithPosition(" [!] ОШИБКА: Ожидался OR или AND", current_i);
                        break;
                    case State.F:
                        if (s[current_i] == ' ')
                        {
                            status = State.F;
                            current_i++;
                        }
                        else if (s[current_i] == '(')
                        {
                            status = State.G;
                            current_i++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] ОШИБКА: Ожидались '(' или пробел", current_i);
                        }
                        break;
                    case State.G:
                        if (s[current_i] == ' ')
                        {
                            status = State.G;
                            current_i++;
                        }
                        else if (Relation(s, current_i) != -1)
                        {
                            current_i = Relation(s, current_i);
                            status = State.H;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или отношение", current_i);
                        break;
                    case State.H:
                        if (s[current_i] == ' ')
                        {
                            status = State.H;
                            current_i++;
                        }
                        else if (s[current_i] == ')')
                        {
                            status = State.J;
                            current_i++;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалась ')' или пробел", current_i);
                        }
                        break;
                    case State.J:
                        if (s[current_i] == ' ')
                        {
                            status = State.K;
                            current_i += 1;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел", current_i);
                        break;
                    case State.K:
                        if (s[current_i] == ' ')
                        {
                            status = State.K;
                            current_i += 1;
                        }
                        else if (s[current_i] == 'D' && s[current_i + 1] == 'O')
                        {
                            status = State.O; current_i += 2;
                        }
                        else
                        {
                            new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или DO", current_i);
                        }
                        break;
                    case State.L:
                        if (s[current_i] == ' ')
                        {
                            status = State.L;
                            current_i++;
                        }
                        else if (s[current_i] == 'D' && s[current_i + 1] == 'O')
                        {
                            status = State.O; current_i += 2;
                        }
                        else
                        {
                            new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или DO", current_i);
                        }
                        break;
                    case State.M:
                        if (s[current_i] == ' ')
                        {
                            status = State.N;
                            current_i += 1;
                        }
                        else if (s[current_i] == 'D' && s[current_i + 1] == 'O')
                        {
                            status = State.O; current_i += 2;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или DO", current_i);
                        break;
                    case State.N:
                        if (s[current_i] == ' ')
                        {
                            status = State.N;
                            current_i += 1;
                        }
                        else if (s[current_i] == 'D' && s[current_i + 1] == 'O')
                        {
                            status = State.O; current_i += 2;
                        }
                        else
                        {
                            new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или D0", current_i);
                        }
                        break;
                    case State.O:
                        if (s[current_i] == ' ')
                        {
                            status = State.P;
                            current_i += 1;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел", current_i);
                        break;
                    case State.P:
                        if (s[current_i] == ' ')
                        {
                            status = State.P;
                            current_i += 1;
                        }
                        else if (IsOperator(s, current_i) != -1)
                        {
                            status = State.Q;
                            current_i = IsOperator(s, current_i);
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или A|...|Z", current_i);
                        break;
                    case State.Q:
                        if (s[current_i] == ' ')
                        {
                            status = State.Q;
                            current_i += 1;
                        }
                        else if (s[current_i] == ';')
                        {
                            current_i += 1;
                            status = State.Finish;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или ';'", current_i);
                        break;

                }
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

        public static int Identificator(string s, int current_i)
        {
            int len = 0;
            int p0 = current_i;
            State status_id = State.start_id;

            while (status_id != State.finish_id && current_i != -1)
            {
                switch (status_id)
                {
                    case State.start_id:
                        if (char.IsLetter(s[current_i]))
                        {
                            status_id = State.Id;
                            current_i++;
                            len++;
                        }
                        else
                        {

                            throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался буквенный символ", current_i);
                        }
                        break;

                    case State.Id:
                        if (char.IsLetterOrDigit(s[current_i]))
                        {
                            status_id = State.Id;
                            current_i += 1;
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
                throw new ExceptionWithPosition("[!] ОШИБКА: Слишком длинный идентификатор", current_i);
            }

            string identifier = s.Substring(p0, len);
            if (IsKeyword(identifier))
            {
                throw new ExceptionWithPosition("[!] ОШИБКА: Идентификатор не может быть ключевым словом", current_i);
            }

            UpdateIdList(identifier);

            return current_i;
        }

        private static bool IsKeyword(string identifier)
        {
            string[] keywords = { "DO", "WHILE", "AND", "OR" };
            return keywords.Contains(identifier);
        }

        private static void UpdateIdList(string identifier)
        {
            if (!id_list.Contains(identifier))
            {
                id_list.Add(identifier);
            }
        }




        static int IsConst(string s, int current_i)
        {
            State status_const = State.start_const;
            List<string> chars = new List<string>();
            int p0 = current_i;
            bool flag = false;
            int p_dot = 0;

            while (status_const != State.finish_const)
            {
                switch (status_const)
                {
                    case State.start_const:
                        if (s[current_i] == '0')
                        {
                            status_const = State.C1;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else if (s[current_i] == '-')
                        {
                            status_const = State.C2;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else if (char.IsDigit(s[current_i]) && s[current_i] != '0')
                        {
                            status_const = State.C3;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалось -|0|..|9", current_i);
                        break;

                    case State.C1:
                        if (s[current_i] == '.')
                        {
                            status_const = State.C4;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                            p_dot = current_i - 1;
                        }
                        else { status_const = State.finish_const; }
                        break;

                    case State.C2:
                        if (s[current_i] == '0')
                        {
                            status_const = State.C1;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else if (char.IsDigit(s[current_i]) && s[current_i] != '0')
                        {
                            status_const = State.C3;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else
                        {
                            throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалось 0|..|9", current_i);
                        }
                        break;

                    case State.C3:
                        if (char.IsDigit(s[current_i]))
                        {
                            status_const = State.C3;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else if (s[current_i] == '.')
                        {
                            status_const = State.C4;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                            p_dot = current_i - 1;
                        }
                        else status_const = State.finish_const;
                        break;

                    case State.C4:
                        if (char.IsDigit(s[current_i]))
                        {
                            status_const = State.C4;
                            chars.Add(Convert.ToString(s[current_i]));
                            current_i += 1;
                        }
                        else status_const = State.finish_const;
                        break;
                }
            }

            string ans = string.Join("", chars.ToArray());
            double anas = Convert.ToDouble(ans, new NumberFormatInfo { NumberDecimalSeparator = "." });

            if (anas < -32768 || anas > 32768)
            {
                throw new ExceptionWithPosition("[!] ОШИБКА: Число вне диапазона [-32768; 32768]", current_i);
            }

            if (current_i != -1)
            {
                string ind_str = s.Substring(p0, current_i - p0);
                if (const_list.Count == 0 || !const_list.Contains(ind_str))
                {
                    const_list.Add(ind_str);
                }
            }

            return current_i;
        }
        static int Relation(string s, int current_i)
        {
            int ans = 0;
            State status_rel = State.Sr;

            void CheckComparisonOperator()
            {
                if (s[current_i] == '<' || s[current_i] == '=' || s[current_i] == '>')
                {
                    status_rel = State.R3;
                    current_i += 1;
                }
                else
                {
                    status_rel = State.Fr;
                }
            }

            if (Identificator(s, current_i) != -1)
            {
                current_i = Identificator(s, current_i);
                status_rel = State.R1;
                while (status_rel != State.Fr)
                {
                    switch (status_rel)
                    {
                        case State.R1:
                            if (s[current_i] == ' ')
                            {
                                status_rel = State.R1;
                                current_i += 1;
                            }
                            else
                            {
                                CheckComparisonOperator();
                            }
                            break;

                        case State.R3:
                            if (s[current_i] == ' ')
                            {
                                status_rel = State.R3;
                                current_i += 1;
                            }
                            else if (Identificator(s, current_i) != -1)
                            {
                                status_rel = State.R5;
                                current_i = Identificator(s, current_i);
                            }
                            else if (IsConst(s, current_i) != -1)
                            {
                                status_rel = State.R6;
                                current_i = IsConst(s, current_i);
                            }
                            else
                            {
                                throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалась константа или идентификатор", current_i);
                            }
                            break;

                        case State.R5:
                        case State.R6:
                            status_rel = State.Fr;
                            break;
                    }
                }
            }
            else if (IsConst(s, current_i) != -1)
            {
                current_i = IsConst(s, current_i);
                status_rel = State.R2;
                while (status_rel != State.Fr)
                {
                    switch (status_rel)
                    {
                        case State.R2:
                            if (s[current_i] == ' ')
                            {
                                status_rel = State.R2;
                                current_i += 1;
                            }
                            else
                            {
                                CheckComparisonOperator();
                            }
                            break;

                        case State.R4:
                            if (s[current_i] == ' ')
                            {
                                status_rel = State.R4;
                                current_i += 1;
                            }
                            else if (Identificator(s, current_i) != -1)
                            {
                                status_rel = State.R7;
                                current_i = Identificator(s, current_i);
                            }
                            else if (IsConst(s, current_i) != -1)
                            {
                                status_rel = State.R8;
                                current_i = IsConst(s, current_i);
                            }
                            else
                            {
                                throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалась константа или идентификатор", current_i);
                            }
                            break;

                        case State.R7:
                        case State.R8:
                            status_rel = State.Fr;
                            ans = current_i;
                            break;
                    }
                }
            }
            else
            {
                throw new ExceptionWithPosition("[!] ОШИБКА: Ожидалась константа или идентификатор", current_i);
            }

            return current_i;
        }
        static int IsOperator(string s, int current_i)
        {
            State status_op = State.start_operator;

            void CheckAssignmentOperator()
            {
                if (s[current_i] == ':' && s[current_i + 1] == '=')
                {
                    current_i += 2;
                    status_op = State.O2;
                }
                else
                {
                    throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался пробел или := или продолжение идентификатора", current_i);
                }
            }

            if (Identificator(s, current_i) != -1)
            {
                status_op = State.O1;
                current_i = Identificator(s, current_i);
                while (status_op != State.finish_operator)
                {
                    switch (status_op)
                    {
                        case State.O1:
                            if (s[current_i] == ' ')
                            {
                                current_i += 1;
                                status_op = State.O1;
                            }
                            else
                            {
                                CheckAssignmentOperator();
                            }
                            break;

                        case State.O2:
                            if (s[current_i] == ' ')
                            {
                                current_i += 1;
                                status_op = State.O2;
                            }
                            else if ((s[current_i] >= '0' && s[current_i] <= '9') || s[current_i] == '-')
                            {
                                if (IsConst(s, current_i) != -1)
                                {
                                    current_i = IsConst(s, current_i);
                                    status_op = State.O3;
                                }
                            }
                            else if (Identificator(s, current_i) != -1)
                            {
                                current_i = Identificator(s, current_i);
                                status_op = State.O4;
                            }
                            else
                            {
                                throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался идентификатор или константа", current_i);
                            }
                            break;

                        case State.O3:
                            if (s[current_i] == ' ')
                            {
                                current_i += 1;
                                status_op = State.O3;
                            }
                            else if (s[current_i] == '=' || s[current_i] == '+' || s[current_i] == '-' || s[current_i] == '*' || s[current_i] == '/')
                            {
                                current_i += 1;
                                status_op = State.O5;
                            }
                            else
                            {
                                status_op = State.finish_operator;
                            }
                            break;

                        case State.O5:
                            if (s[current_i] == ' ')
                            {
                                current_i += 1;
                                status_op = State.O2;
                            }
                            else if (IsConst(s, current_i) != -1)
                            {
                                current_i = IsConst(s, current_i);
                                status_op = State.O8;
                            }
                            else if (Identificator(s, current_i) != -1)
                            {
                                current_i = Identificator(s, current_i);
                                status_op = State.O7;
                            }
                            else
                            {
                                throw new ExceptionWithPosition("[!] ОШИБКА: Ожидался идентификатор или константа", current_i);
                            }
                            break;

                        case State.O7:
                        case State.O8:
                            status_op = State.finish_operator;
                            break;

                        case State.O4:
                            if (s[current_i] == ' ')
                            {
                                status_op = State.O4;
                                current_i++;
                            }
                            else if (s[current_i] == '=' || s[current_i] == '+' || s[current_i] == '-' || s[current_i] == '*' || s[current_i] == '/')
                            {
                                current_i += 1;
                                status_op = State.O5;
                            }
                            else
                            {
                                status_op = State.finish_operator;
                            }
                            break;
                    }
                }
            }
            return current_i;
        }
    }
}


