using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace LR_7
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        List<IVectorable> vectors = new List<IVectorable>();
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void vectorView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vectorString = textBox1.Text;
            textBox1.Clear();
            string[] vectorInfo = vectorString.Split(' ');
            if (((vectorInfo[0] != "Array") && (vectorInfo[0] != "List") || (Convert.ToInt32(vectorInfo[1]) <= 0) || (vectorInfo.Length - 2 != Convert.ToInt32(vectorInfo[1]))))
            {
                MessageBox.Show("Неправильный ввод. Попробуйте еще раз!\n Ввод в формате: {Тип вектора}{Длина}{Координаты}");
            }
            else
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = vectorInfo[0];
                lvi.SubItems.Add(vectorInfo[1]);
                string coords = "";
                for (int i = 2; i < vectorInfo.Length; i++)
                {
                    coords += vectorInfo[i] + ' ';
                }
                lvi.SubItems.Add(coords);
                vectorView.Items.Add(lvi);
                if (vectorInfo[0] == "Array")
                {
                    IVectorable vector = new ArrayVector(Convert.ToInt32(vectorInfo[1]));
                    for (int i = 2; i < vectorInfo.Length; i++)
                    {
                        vector[i - 2] = Convert.ToInt32(vectorInfo[i]);
                    }
                    vectors.Add(vector);
                }
                else
                {
                    IVectorable vector = new LinkedListVector(Convert.ToInt32(vectorInfo[1]));
                    for (int i = 2; i < vectorInfo.Length; i++)
                    {
                        vector[i - 2] = Convert.ToInt32(vectorInfo[i]);
                    }
                    vectors.Add(vector);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (vectorView.SelectedItems.Count > 0)
            {
                var confirmation = MessageBox.Show("Вы уверены, что хотите удалить выбранные вектора?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    for (int i = vectorView.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        int itmIndex = vectorView.SelectedItems[i].Index;
                        // ListViewItem itm = vectorView.SelectedItems[i];
                        vectorView.Items[itmIndex].Remove();
                        vectors.RemoveAt(itmIndex);
                    }
                }
            }
            else
                MessageBox.Show("Выбрано 0 векторов");
        }

        private void absButton_Click(object sender, EventArgs e)
        {
            if (vectorView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите 1 вектор!");
            }
            else
            {
                int index = vectorView.SelectedItems[0].Index;
                MessageBox.Show(vectors[index].GetNorm().ToString());
            }
        }

        private void cloneButton_Click(object sender, EventArgs e)
        {
            if (vectorView.SelectedItems.Count != 1)
            {
                MessageBox.Show("Выберите 1 вектор!");
            }
            else
            {
                int index = vectorView.SelectedItems[0].Index;
                //ListViewItem lvi = new ListViewItem();
                //lvi.Text = vectorView.SelectedItems[0].Text;
                //lvi.SubItems.Add(vectorView.SelectedItems[0].SubItems[1]);
                //lvi.SubItems.Add(vectorView.SelectedItems[0].SubItems[2]);

                if (vectors[index] is ArrayVector)
                {
                    vectors.Add((IVectorable)((ArrayVector)vectors[index]).Clone());
                    vectorView.Items.Add(VectorToLVI((IVectorable)((ArrayVector)vectors[index]).Clone()));
                }
                else
                {
                    vectors.Add((IVectorable)((LinkedListVector)vectors[index]).Clone());
                    vectorView.Items.Add(VectorToLVI((IVectorable)((LinkedListVector)vectors[index]).Clone()));
                }
            }
        }

        static private ListViewItem VectorToLVI(IVectorable vector)
        {
            ListViewItem lvi = new ListViewItem();
            if (vector is ArrayVector)
            {
                lvi.Text = "Array";
            }
            else
            {
                lvi.Text = "List";
            }
            string coords = "";
            lvi.SubItems.Add(vector.Length.ToString());
            for (int i = 0; i < vector.Length; i++)
            {
                coords += vector[i].ToString() + ' ';
            }
            lvi.SubItems.Add(coords);
            return lvi;
        }

        private void sortByLengthButton_Click(object sender, EventArgs e)
        {
            vectorView.Items.Clear();
            SortByLength(vectors);
            for (int i = 0; i < vectors.Count; i++)
            {
                vectorView.Items.Add(VectorToLVI(vectors[i]));
            }
        }

        static void SortByLength(List<IVectorable> vectors)
        {
            IVectorable temp;
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = 0; j < vectors.Count - 1 - i; j++)
                {
                    if (((IComparable)vectors[j]).CompareTo((IComparable)vectors[j + 1]) > 0)
                    {
                        temp = vectors[j];
                        vectors[j] = vectors[j + 1];
                        vectors[j + 1] = temp;
                    }
                }
            }
        }
        static void SortByNorm(List<IVectorable> vectors)
        {
            IVectorable temp;
            VectorsComparer comparer = new VectorsComparer();
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = 0; j < vectors.Count - 1 - i; j++)
                {
                    if (comparer.Compare(vectors[j], vectors[j + 1]) > 0)
                    {
                        temp = vectors[j];
                        vectors[j] = vectors[j + 1];
                        vectors[j + 1] = temp;
                    }
                }
            }
        }

        private void sortByAbsButton_Click(object sender, EventArgs e)
        {
            vectorView.Items.Clear();
            SortByNorm(vectors);
            for (int i = 0; i < vectors.Count; i++)
            {
                vectorView.Items.Add(VectorToLVI(vectors[i]));
            }
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            string length1 = vectorView.SelectedItems[0].SubItems[1].Text;
            string length2 = vectorView.SelectedItems[1].SubItems[1].Text;
            if ((vectorView.SelectedItems.Count != 2) || (length1 != length2))
            {
                MessageBox.Show("Выберите 2 вектора одинаковым количеством координат!");
            }
            else
            {
                IVectorable vector = Vectors.Sum(vectors[vectorView.SelectedItems[0].Index], vectors[vectorView.SelectedItems[1].Index]);
                vectors.Add(vector);
                vectorView.Items.Add(VectorToLVI(vector));
            }
        }

        private void scalarButton_Click(object sender, EventArgs e)
        {
            string length1 = vectorView.SelectedItems[0].SubItems[1].Text;
            string length2 = vectorView.SelectedItems[1].SubItems[1].Text;
            if ((vectorView.SelectedItems.Count != 2) || (length1 != length2))
            {
                MessageBox.Show("Выберите 2 вектора одинаковым количеством координат!");
            }
            else
            {
                IVectorable vector1 = vectors[vectorView.SelectedItems[0].Index];
                IVectorable vector2 = vectors[vectorView.SelectedItems[1].Index];
                MessageBox.Show(Vectors.Scalar(vector1, vector2).ToString());
            }
        }

        static private void StreamWriter(List<IVectorable> vectors)
        {
            string path1 = @"C:\Users\veron\source\repos\csharp\Console\S2\ЛР07\LR-7\VectorsSymbols.txt";
            if (File.Exists(path1) == true)
            {
                File.Delete(path1);
            }
            using (TextWriter writer = File.AppendText(path1))
            {
                for (int i = 0; i < vectors.Count; i++)
                {
                    Vectors.WriteVector(vectors[i], writer);
                }
                Console.WriteLine("Запись в файл выполнена.");
                writer.Close();
            }
            TextReader reader = File.OpenText(path1);
            List<IVectorable> vectorsRead = new List<IVectorable>();
            for (int i = 0; i < vectors.Count; i++)
            {
                vectorsRead.Add(Vectors.ReadVector(reader));
            }
            reader.Close();
        }

        private void writeInFileButton_Click(object sender, EventArgs e)
        {
            if (vectorView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного вектора.");
            }
            else
            {
                string path1 = @"C:\Users\veron\source\repos\csharp\Console\S2\ЛР07\LR-7\VectorsSymbols.txt"; ;
                List<IVectorable> vectorsTemp = new List<IVectorable>();
                for (int i = 0; i < vectorView.SelectedItems.Count; i++)
                {
                    vectorsTemp.Add(vectors[vectorView.SelectedItems[i].Index]);
                }
                StreamWriter(vectorsTemp);

            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = File.ReadAllText(filename);
            MessageBox.Show(fileText, "Считанные вектора: ");
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var vector = vectors[vectorView.SelectedItems[0].Index];
            Edit edit = new Edit(ref vector, vectorView.SelectedItems[0]);
            edit.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AcceptButton = addButton; // При нажатии ENTER будет нажимать кнопку добавления
        }
    }
}
