namespace HopeForPravilnost
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 73);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(356, 39);
            textBox1.TabIndex = 0;
            textBox1.Text = "Государство";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(912, 89);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(594, 501);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(325, 164);
            button1.Name = "button1";
            button1.Size = new Size(132, 60);
            button1.TabIndex = 2;
            button1.Text = "Найти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(35, 185);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(240, 39);
            numericUpDown1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 38);
            label1.Name = "label1";
            label1.Size = new Size(304, 32);
            label1.TabIndex = 4;
            label1.Text = "Категория(класс) субъекта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(912, 54);
            label2.Name = "label2";
            label2.Size = new Size(286, 32);
            label2.TabIndex = 5;
            label2.Text = "Информация о субъекте";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 150);
            label3.Name = "label3";
            label3.Size = new Size(142, 32);
            label3.TabIndex = 6;
            label3.Text = "ID субъекта";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(325, 445);
            label4.Name = "label4";
            label4.Size = new Size(225, 32);
            label4.TabIndex = 8;
            label4.Text = "Название субъекта";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(325, 480);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(356, 39);
            textBox2.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 445);
            label5.Name = "label5";
            label5.Size = new Size(142, 32);
            label5.TabIndex = 10;
            label5.Text = "ID субъекта";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(35, 480);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(240, 39);
            numericUpDown2.TabIndex = 9;
            // 
            // button2
            // 
            button2.Location = new Point(236, 553);
            button2.Name = "button2";
            button2.Size = new Size(132, 60);
            button2.TabIndex = 11;
            button2.Text = "Создать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1552, 653);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private NumericUpDown numericUpDown2;
        private Button button2;
    }
}
