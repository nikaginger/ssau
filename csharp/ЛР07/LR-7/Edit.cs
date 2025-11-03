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
        public Edit(IVectorable vector)
        {
            InitializeComponent();
            this.vector = vector;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                label2.Text += vector[i].ToString() + ' ';
            }
        }
    }
}
