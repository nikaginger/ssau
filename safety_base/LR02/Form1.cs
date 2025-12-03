using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LR02
{
    public partial class Form1 : Form
    {
        RichTextBox rtbText;
        GroupBox gbFile, gbEncrypt, gbFreq, gbMapping, gbView;
        Button btnLoad, btnSave, btnEncrypt, btnFreqShow, btnFreqAuto, btnAdd, btnDelete, btnSavePartial;
        TextBox tbCipher, tbReplace;
        ListBox lbMap;
        NumericUpDown nudShift;
        CheckBox cbOnlyReplaced;
        Label lblShift, lblCipher, lblReplace;

        Dictionary<char, char> map = new Dictionary<char, char>();
        string currentText = "";
        bool showOnly = false;

        readonly char[] rusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        readonly char[] rusFreqOrder = "оеаинтсрвлкмдпуяьыгзбчйхжшюцщэ".ToCharArray();

        public Form1()
        {
            Text = "6301 Бренева Вероника Лабораторная №2";
            Size = new Size(1120, 720);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10);
            BackColor = Color.FromArgb(240, 247, 255);

            InitUI();
            currentText = "Загрузите текст...";
            UpdateDisplay();
        }

        void InitUI()
        {
            rtbText = new RichTextBox
            {
                Location = new Point(25, 25),
                Size = new Size(700, 630),
                Font = new Font("Consolas", 12),
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            Controls.Add(rtbText);

            int x = 750, y = 25, w = 330;
            Color accent = Color.FromArgb(80, 150, 240);

            // Файл
            gbFile = new GroupBox
            {
                Text = "Файл",
                Location = new Point(x, y),
                Size = new Size(w, 100),
                ForeColor = accent
            };
            btnLoad = MakeButton("📂 Открыть текст", new Point(20, 30));
            btnSave = MakeButton("💾 Сохранить исходный", new Point(170, 30));
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            gbFile.Controls.AddRange(new Control[] { btnLoad, btnSave });
            Controls.Add(gbFile);

            // Частотный анализ
            y += 110;
            gbFreq = new GroupBox
            {
                Text = "Частотный анализ",
                Location = new Point(x, y),
                Size = new Size(w, 100),
                ForeColor = accent
            };
            btnFreqShow = MakeButton("📊 Показать частоты", new Point(20, 30));
            btnFreqAuto = MakeButton("⚙ Автозамена по частотам", new Point(170, 30));
            btnFreqShow.Click += BtnFreqShow_Click;
            btnFreqAuto.Click += BtnFreqAuto_Click;
            gbFreq.Controls.AddRange(new Control[] { btnFreqShow, btnFreqAuto });
            Controls.Add(gbFreq);

            // Шифр Цезаря
            y += 110;
            gbEncrypt = new GroupBox
            {
                Text = "Шифрование (Цезарь)",
                Location = new Point(x, y),
                Size = new Size(w, 100),
                ForeColor = accent
            };
            lblShift = new Label { Text = "Сдвиг:", Location = new Point(20, 35), Width = 50 };
            nudShift = new NumericUpDown
            {
                Location = new Point(75, 33),
                Minimum = -32,
                Maximum = 32,
                Value = 5,
                Width = 60
            };
            btnEncrypt = MakeButton("🔐 Применить шифр", new Point(150, 30));
            btnEncrypt.Click += BtnEncrypt_Click;
            gbEncrypt.Controls.AddRange(new Control[] { lblShift, nudShift, btnEncrypt });
            Controls.Add(gbEncrypt);

            // Таблица замен
            y += 110;
            gbMapping = new GroupBox
            {
                Text = "Таблица замен",
                Location = new Point(x, y),
                Size = new Size(w, 230),
                ForeColor = accent
            };
            lblCipher = new Label { Text = "Буква шифра:", Location = new Point(20, 35) };
            tbCipher = new TextBox { Location = new Point(125, 32), Width = 30, TextAlign = HorizontalAlignment.Center };
            lblReplace = new Label { Text = "→ заменить на:", Location = new Point(165, 35) };
            tbReplace = new TextBox { Location = new Point(275, 32), Width = 30, TextAlign = HorizontalAlignment.Center };
            btnAdd = MakeButton("Добавить", new Point(20, 70));
            btnDelete = MakeButton("Удалить", new Point(160, 70));
            lbMap = new ListBox
            {
                Location = new Point(20, 110),
                Size = new Size(290, 100),
                Font = new Font("Consolas", 11),
                BorderStyle = BorderStyle.FixedSingle
            };
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            gbMapping.Controls.AddRange(new Control[] { lblCipher, tbCipher, lblReplace, tbReplace, btnAdd, btnDelete, lbMap });
            Controls.Add(gbMapping);

            // Просмотр и сохранение
            y += 240;
            gbView = new GroupBox
            {
                Text = "Просмотр и сохранение",
                Location = new Point(x, y),
                Size = new Size(w, 110),
                ForeColor = accent
            };
            cbOnlyReplaced = new CheckBox
            {
                Text = "Показать только заменённые (# для неизвестных)",
                Location = new Point(20, 30),
                Width = 300
            };
            cbOnlyReplaced.CheckedChanged += (s, e) => { showOnly = cbOnlyReplaced.Checked; UpdateDisplay(); };
            btnSavePartial = MakeButton("💾 Сохранить частично расшифрованный", new Point(20, 60), 280);
            btnSavePartial.Click += BtnSavePartial_Click;
            gbView.Controls.AddRange(new Control[] { cbOnlyReplaced, btnSavePartial });
            Controls.Add(gbView);
        }

        Button MakeButton(string text, Point p, int width = 130)
        {
            return new Button
            {
                Text = text,
                Location = p,
                Size = new Size(width, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 150, 240),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9),
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(60, 130, 220) }
            };
        }

        private void BtnLoad_Click(object s, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "Текстовые файлы|*.txt|Все файлы|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentText = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                map.Clear();
                lbMap.Items.Clear();
                UpdateDisplay();
            }
        }

        private void BtnSave_Click(object s, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "Текстовые файлы|*.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, currentText, Encoding.UTF8);
        }

        private void BtnEncrypt_Click(object s, EventArgs e)
        {
            int shift = (int)nudShift.Value;
            currentText = Caesar(currentText, shift);
            map.Clear();
            lbMap.Items.Clear();
            UpdateDisplay();
            MessageBox.Show($"Текст зашифрован со сдвигом {shift}.");
        }

        private void BtnFreqShow_Click(object s, EventArgs e)
        {
            var freq = GetFreq(currentText);
            var top = freq.OrderByDescending(p => p.Value).Take(10);
            var sb = new StringBuilder();
            sb.AppendLine("10 наиболее частых букв:");
            foreach (var p in top)
                sb.AppendLine($"{p.Key} : {p.Value:F2}%");
            sb.AppendLine("\nТипичный порядок частот русского языка:");
            sb.AppendLine(new string(rusFreqOrder));
            MessageBox.Show(sb.ToString(), "Частоты букв");
        }

        private void BtnFreqAuto_Click(object s, EventArgs e)
        {
            var freq = GetFreq(currentText);
            var top = freq.OrderByDescending(p => p.Value).Select(p => p.Key).ToList();
            int n = Math.Min(top.Count, rusFreqOrder.Length);
            for (int i = 0; i < n; i++) map[top[i]] = rusFreqOrder[i];
            RefreshMap();
            UpdateDisplay();
        }

        private void BtnAdd_Click(object s, EventArgs e)
        {
            if (tbCipher.TextLength != 1 || tbReplace.TextLength != 1)
            {
                MessageBox.Show("Введите по одной букве.");
                return;
            }
            char c1 = char.ToLower(tbCipher.Text[0]);
            char c2 = char.ToLower(tbReplace.Text[0]);
            map[c1] = c2;
            RefreshMap();
            UpdateDisplay();
        }

        private void BtnDelete_Click(object s, EventArgs e)
        {
            if (lbMap.SelectedItem == null) return;
            char c = lbMap.SelectedItem.ToString()[0];
            map.Remove(c);
            RefreshMap();
            UpdateDisplay();
        }

        private void BtnSavePartial_Click(object s, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "Текстовые файлы|*.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, BuildMapped(showOnly), Encoding.UTF8);
                MessageBox.Show("Файл сохранён.");
            }
        }

        void RefreshMap()
        {
            lbMap.Items.Clear();
            foreach (var kv in map.OrderBy(k => k.Key))
                lbMap.Items.Add($"{kv.Key} → {kv.Value}");
        }

        Dictionary<char, double> GetFreq(string text)
        {
            var counts = new Dictionary<char, int>();
            int total = 0;
            foreach (char ch in text)
            {
                char l = char.ToLower(ch);
                if (rusAlphabet.Contains(l))
                {
                    if (!counts.ContainsKey(l)) counts[l] = 0;
                    counts[l]++;
                    total++;
                }
            }
            return counts.ToDictionary(kv => kv.Key, kv => kv.Value * 100.0 / Math.Max(1, total));
        }

        string Caesar(string text, int shift)
        {
            var sb = new StringBuilder();
            int n = rusAlphabet.Length;
            foreach (char ch in text)
            {
                char l = char.ToLower(ch);
                if (rusAlphabet.Contains(l))
                {
                    int i = Array.IndexOf(rusAlphabet, l);
                    int j = (i + shift + n) % n;
                    char res = rusAlphabet[j];
                    if (char.IsUpper(ch)) res = char.ToUpper(res);
                    sb.Append(res);
                }
                else sb.Append(ch);
            }
            return sb.ToString();
        }

        string BuildMapped(bool only)
        {
            var sb = new StringBuilder();
            foreach (char ch in currentText)
            {
                char l = char.ToLower(ch);
                if (rusAlphabet.Contains(l))
                {
                    if (map.ContainsKey(l))
                    {
                        char m = map[l];
                        if (char.IsUpper(ch)) m = char.ToUpper(m);
                        sb.Append(m);
                    }
                    else sb.Append(only ? '#' : ch);
                }
                else sb.Append(ch);
            }
            return sb.ToString();
        }

        void UpdateDisplay()
        {
            rtbText.Clear();
            foreach (char ch in currentText)
            {
                char l = char.ToLower(ch);
                if (rusAlphabet.Contains(l))
                {
                    if (map.ContainsKey(l))
                    {
                        char m = map[l];
                        if (char.IsUpper(ch)) m = char.ToUpper(m);
                        rtbText.SelectionColor = Color.Black;
                        rtbText.AppendText(m.ToString());
                    }
                    else
                    {
                        rtbText.SelectionColor = Color.DarkRed;
                        rtbText.AppendText(showOnly ? "#" : ch.ToString());
                    }
                }
                else
                {
                    rtbText.SelectionColor = Color.Black;
                    rtbText.AppendText(ch.ToString());
                }
            }

            if (rusAlphabet.All(c => map.ContainsKey(c)))
                MessageBox.Show("Текст полностью расшифрован!", "Готово");
        }
    }
}