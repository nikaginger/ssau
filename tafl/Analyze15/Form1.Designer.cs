namespace Analyze15
{
    partial class Form1
    {
      
        private System.ComponentModel.IContainer components = null;

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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            text = new TextBox();
            analyzeButton = new Button();
            errorMessage = new Label();
            label1 = new Label();
            label2 = new Label();
            idBox = new Label();
            constBox = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // text
            // 
            text.AcceptsTab = true;
            text.BackColor = Color.FromArgb(192, 255, 255);
            text.BorderStyle = BorderStyle.FixedSingle;
            text.CharacterCasing = CharacterCasing.Upper;
            text.Font = new Font("Cascadia Mono", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            text.Location = new Point(112, 38);
            text.Name = "text";
            text.Size = new Size(1021, 39);
            text.TabIndex = 0;
            text.TextChanged += text_TextChanged;
            // 
            // analyzeButton
            // 
            analyzeButton.BackColor = Color.FromArgb(192, 255, 192);
            analyzeButton.FlatStyle = FlatStyle.Flat;
            analyzeButton.Font = new Font("Cascadia Mono", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            analyzeButton.Location = new Point(534, 111);
            analyzeButton.Name = "analyzeButton";
            analyzeButton.Size = new Size(234, 40);
            analyzeButton.TabIndex = 1;
            analyzeButton.Text = "Анализировать";
            analyzeButton.UseVisualStyleBackColor = false;
            analyzeButton.Click += analyzeButton_Click;
            // 
            // errorMessage
            // 
            errorMessage.AutoSize = true;
            errorMessage.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            errorMessage.ForeColor = Color.White;
            errorMessage.Location = new Point(112, 80);
            errorMessage.Name = "errorMessage";
            errorMessage.Size = new Size(0, 29);
            errorMessage.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(192, 255, 255);
            label1.Location = new Point(112, 202);
            label1.Name = "label1";
            label1.Size = new Size(527, 40);
            label1.TabIndex = 3;
            label1.Text = "Идентификаторы";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(192, 255, 255);
            label2.Location = new Point(658, 202);
            label2.Name = "label2";
            label2.Size = new Size(475, 40);
            label2.TabIndex = 4;
            label2.Text = "Константы";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // idBox
            // 
            idBox.BackColor = SystemColors.Control;
            idBox.Font = new Font("Cascadia Mono", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            idBox.Location = new Point(112, 257);
            idBox.Name = "idBox";
            idBox.Size = new Size(527, 249);
            idBox.TabIndex = 5;
            // 
            // constBox
            // 
            constBox.BackColor = SystemColors.Control;
            constBox.Font = new Font("Cascadia Mono", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            constBox.Location = new Point(658, 257);
            constBox.Name = "constBox";
            constBox.Size = new Size(475, 249);
            constBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
            label3.Location = new Point(112, 9);
            label3.Name = "label3";
            label3.Size = new Size(1021, 26);
            label3.TabIndex = 7;
            label3.Text = "Вариант 15. Выполнила Бренева Вероника 6201-020302D";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1382, 553);
            Controls.Add(label3);
            Controls.Add(constBox);
            Controls.Add(idBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(errorMessage);
            Controls.Add(analyzeButton);
            Controls.Add(text);
            Font = new Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "Form1";
            Text = "Анализатор строки DO WHILE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text;
        private Button analyzeButton;
        private Label errorMessage;
        private Label label1;
        private Label label2;
        private Label idBox;
        private Label constBox;
        private Label label3;
    }
}
