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

namespace LR_7
{
    public partial class Edit : Form

    {
        IVectorable vector;
        ListViewItem textVector;

        public Edit(ref IVectorable vector, ListViewItem textVector)
        {
            InitializeComponent();
            this.textVector = textVector;
            this.vector = vector;
            numericUpDown1.Maximum = (decimal)vector.Length;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            label2.Text = stringifyVector();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNumber = int.TryParse(textBox1.Text, out int number);

            if (!isNumber)
            {
                MessageBox.Show("Введённое значение некорректно! Введите целое число.");
                return;
            }

            vector[decimal.ToInt32(numericUpDown1.Value) - 1] = int.Parse(textBox1.Text);
            textVector.SubItems[2].Text = stringifyVector();
            label2.Text = stringifyVector();
        }

        private string stringifyVector()
        {
            string result = "";
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i].ToString() + ' ';
            }
            return result;
        }
    }
}
