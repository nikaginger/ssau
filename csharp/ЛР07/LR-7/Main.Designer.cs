namespace LR_7
{
    partial class Main
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
            textBox1 = new TextBox();
            label1 = new Label();
            vectorView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            addButton = new Button();
            editButton = new Button();
            cloneButton = new Button();
            absButton = new Button();
            deleteButton = new Button();
            sortByLengthButton = new Button();
            sortByAbsButton = new Button();
            sumButton = new Button();
            scalarButton = new Button();
            writeInFileButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.MenuBar;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(427, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 32);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Desktop;
            label1.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.LightSteelBlue;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(192, 40);
            label1.TabIndex = 2;
            label1.Text = "Vectors.IO";
            // 
            // vectorView
            // 
            vectorView.BackColor = SystemColors.GradientActiveCaption;
            vectorView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            vectorView.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            vectorView.Location = new Point(21, 68);
            vectorView.Name = "vectorView";
            vectorView.Scrollable = false;
            vectorView.ShowGroups = false;
            vectorView.Size = new Size(389, 456);
            vectorView.TabIndex = 3;
            vectorView.UseCompatibleStateImageBehavior = false;
            vectorView.View = View.Details;
            vectorView.SelectedIndexChanged += vectorView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Тип Вектора";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Длина";
            columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Координаты";
            columnHeader3.Width = 230;
            // 
            // addButton
            // 
            addButton.BackColor = Color.LightSteelBlue;
            addButton.Cursor = Cursors.Hand;
            addButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.Location = new Point(427, 106);
            addButton.Name = "addButton";
            addButton.Size = new Size(343, 56);
            addButton.TabIndex = 4;
            addButton.Text = "Добавить вектор";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += button1_Click;
            // 
            // editButton
            // 
            editButton.BackColor = Color.LightSteelBlue;
            editButton.Cursor = Cursors.Hand;
            editButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            editButton.Location = new Point(427, 189);
            editButton.Name = "editButton";
            editButton.Size = new Size(164, 56);
            editButton.TabIndex = 5;
            editButton.Text = "Редактировать";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // cloneButton
            // 
            cloneButton.BackColor = Color.LightSteelBlue;
            cloneButton.Cursor = Cursors.Hand;
            cloneButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cloneButton.Location = new Point(597, 189);
            cloneButton.Name = "cloneButton";
            cloneButton.Size = new Size(173, 56);
            cloneButton.TabIndex = 6;
            cloneButton.Text = "Клонировать";
            cloneButton.UseVisualStyleBackColor = false;
            cloneButton.Click += cloneButton_Click;
            // 
            // absButton
            // 
            absButton.BackColor = Color.LightSteelBlue;
            absButton.Cursor = Cursors.Hand;
            absButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            absButton.Location = new Point(427, 251);
            absButton.Name = "absButton";
            absButton.Size = new Size(164, 56);
            absButton.TabIndex = 7;
            absButton.Text = "Модуль";
            absButton.UseVisualStyleBackColor = false;
            absButton.Click += absButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.LightSteelBlue;
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteButton.Location = new Point(597, 251);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(173, 56);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // sortByLengthButton
            // 
            sortByLengthButton.BackColor = Color.LightSteelBlue;
            sortByLengthButton.Cursor = Cursors.Hand;
            sortByLengthButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            sortByLengthButton.Location = new Point(427, 338);
            sortByLengthButton.Name = "sortByLengthButton";
            sortByLengthButton.Size = new Size(164, 56);
            sortByLengthButton.TabIndex = 9;
            sortByLengthButton.Text = "Сортировать по длине";
            sortByLengthButton.UseVisualStyleBackColor = false;
            sortByLengthButton.Click += sortByLengthButton_Click;
            // 
            // sortByAbsButton
            // 
            sortByAbsButton.BackColor = Color.LightSteelBlue;
            sortByAbsButton.Cursor = Cursors.Hand;
            sortByAbsButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            sortByAbsButton.Location = new Point(597, 338);
            sortByAbsButton.Name = "sortByAbsButton";
            sortByAbsButton.Size = new Size(173, 56);
            sortByAbsButton.TabIndex = 10;
            sortByAbsButton.Text = "Сортировать по модулю";
            sortByAbsButton.UseVisualStyleBackColor = false;
            sortByAbsButton.Click += sortByAbsButton_Click;
            // 
            // sumButton
            // 
            sumButton.BackColor = Color.LightSteelBlue;
            sumButton.Cursor = Cursors.Hand;
            sumButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            sumButton.Location = new Point(427, 400);
            sumButton.Name = "sumButton";
            sumButton.Size = new Size(164, 56);
            sumButton.TabIndex = 11;
            sumButton.Text = "Сумма векторов";
            sumButton.UseVisualStyleBackColor = false;
            sumButton.Click += sumButton_Click;
            // 
            // scalarButton
            // 
            scalarButton.BackColor = Color.LightSteelBlue;
            scalarButton.Cursor = Cursors.Hand;
            scalarButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scalarButton.Location = new Point(597, 400);
            scalarButton.Name = "scalarButton";
            scalarButton.Size = new Size(173, 56);
            scalarButton.TabIndex = 12;
            scalarButton.Text = "Скалярное произведение";
            scalarButton.UseVisualStyleBackColor = false;
            scalarButton.Click += scalarButton_Click;
            // 
            // writeInFileButton
            // 
            writeInFileButton.BackColor = Color.LightSteelBlue;
            writeInFileButton.Cursor = Cursors.Hand;
            writeInFileButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            writeInFileButton.Location = new Point(427, 468);
            writeInFileButton.Name = "writeInFileButton";
            writeInFileButton.Size = new Size(164, 56);
            writeInFileButton.TabIndex = 13;
            writeInFileButton.Text = "Записать в файл";
            writeInFileButton.UseVisualStyleBackColor = false;
            writeInFileButton.Click += writeInFileButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileButton
            // 
            openFileButton.BackColor = Color.LightSteelBlue;
            openFileButton.Cursor = Cursors.Hand;
            openFileButton.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            openFileButton.Location = new Point(597, 468);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(173, 56);
            openFileButton.TabIndex = 14;
            openFileButton.Text = "Открыть файл";
            openFileButton.UseVisualStyleBackColor = false;
            openFileButton.Click += openFileButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(782, 553);
            Controls.Add(openFileButton);
            Controls.Add(writeInFileButton);
            Controls.Add(scalarButton);
            Controls.Add(sumButton);
            Controls.Add(sortByAbsButton);
            Controls.Add(sortByLengthButton);
            Controls.Add(deleteButton);
            Controls.Add(absButton);
            Controls.Add(cloneButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(vectorView);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "Main";
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Label label1;
        private ListView vectorView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button addButton;
        private Button editButton;
        private Button cloneButton;
        private Button absButton;
        private Button deleteButton;
        private Button sortByLengthButton;
        private Button sortByAbsButton;
        private Button sumButton;
        private Button scalarButton;
        private Button writeInFileButton;
        private OpenFileDialog openFileDialog1;
        private Button openFileButton;
    }
}