namespace LR_7
{
    partial class Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            editBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Desktop;
            label1.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.LightSteelBlue;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 40);
            label1.TabIndex = 3;
            label1.Text = "Vectors.IO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(21, 61);
            label2.Name = "label2";
            label2.Size = new Size(138, 23);
            label2.TabIndex = 4;
            label2.Text = "Ваш вектор: ";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown1.BackColor = SystemColors.Desktop;
            numericUpDown1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numericUpDown1.ForeColor = SystemColors.ButtonHighlight;
            numericUpDown1.Location = new Point(267, 108);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(101, 26);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(21, 107);
            label3.Name = "label3";
            label3.Size = new Size(230, 23);
            label3.TabIndex = 6;
            label3.Text = "Изменяемый индекс: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(21, 144);
            label4.Name = "label4";
            label4.Size = new Size(182, 23);
            label4.TabIndex = 7;
            label4.Text = "Новое значение: ";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(267, 141);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "10";
            textBox1.Size = new Size(100, 26);
            textBox1.TabIndex = 8;
            // 
            // editBtn
            // 
            editBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            editBtn.BackColor = Color.LightSteelBlue;
            editBtn.FlatStyle = FlatStyle.Flat;
            editBtn.Location = new Point(267, 183);
            editBtn.Margin = new Padding(3, 4, 3, 4);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(101, 36);
            editBtn.TabIndex = 9;
            editBtn.Text = "Изменить";
            editBtn.UseVisualStyleBackColor = false;
            editBtn.Click += button1_Click;
            // 
            // Edit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(384, 253);
            Controls.Add(editBtn);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(2283, 300);
            MinimumSize = new Size(400, 278);
            Name = "Edit";
            Text = "Edit";
            Load += Edit_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Button editBtn;
    }
}