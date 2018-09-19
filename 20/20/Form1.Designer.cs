namespace _20
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.processButton1 = new System.Windows.Forms.Button();
            this.inputFromFileButton = new System.Windows.Forms.Button();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.processbutton2 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.processbutton = new System.Windows.Forms.Button();
            this.inputOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox1.Location = new System.Drawing.Point(6, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(527, 159);
            this.textBox1.TabIndex = 0;
            // 
            // processButton1
            // 
            this.processButton1.Location = new System.Drawing.Point(6, 283);
            this.processButton1.Name = "processButton1";
            this.processButton1.Size = new System.Drawing.Size(163, 23);
            this.processButton1.TabIndex = 10;
            this.processButton1.Text = "Решение1";
            this.processButton1.UseVisualStyleBackColor = true;
            this.processButton1.Click += new System.EventHandler(this.processButton1_Click);
            // 
            // inputFromFileButton
            // 
            this.inputFromFileButton.Location = new System.Drawing.Point(6, 177);
            this.inputFromFileButton.Name = "inputFromFileButton";
            this.inputFromFileButton.Size = new System.Drawing.Size(132, 23);
            this.inputFromFileButton.TabIndex = 9;
            this.inputFromFileButton.Text = "Загрузить из файла";
            this.inputFromFileButton.UseVisualStyleBackColor = true;
            this.inputFromFileButton.Click += new System.EventHandler(this.inputFromFileButton_Click);
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(6, 312);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(259, 66);
            this.TextBox2.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 257);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(163, 20);
            this.textBox6.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(3, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Число от 1 до";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(271, 312);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(262, 66);
            this.textBox3.TabIndex = 16;
            // 
            // processbutton2
            // 
            this.processbutton2.Location = new System.Drawing.Point(271, 283);
            this.processbutton2.Name = "processbutton2";
            this.processbutton2.Size = new System.Drawing.Size(132, 23);
            this.processbutton2.TabIndex = 19;
            this.processbutton2.Text = "Первое";
            this.processbutton2.UseVisualStyleBackColor = true;
            this.processbutton2.Click += new System.EventHandler(this.pervoe_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(97, 233);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(72, 20);
            this.textBox5.TabIndex = 20;
            // 
            // processbutton
            // 
            this.processbutton.Location = new System.Drawing.Point(6, 208);
            this.processbutton.Name = "processbutton";
            this.processbutton.Size = new System.Drawing.Size(132, 23);
            this.processbutton.TabIndex = 21;
            this.processbutton.Text = "Решение";
            this.processbutton.UseVisualStyleBackColor = true;
            this.processbutton.Click += new System.EventHandler(this.processbutton_Click);
            // 
            // inputOpenFileDialog
            // 
            this.inputOpenFileDialog.DefaultExt = "txt";
            this.inputOpenFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(409, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Последнее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.poslednee_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(545, 384);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.processbutton);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.processbutton2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.processButton1);
            this.Controls.Add(this.inputFromFileButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "20";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button processButton1;
        private System.Windows.Forms.Button inputFromFileButton;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button processbutton2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button processbutton;
        private System.Windows.Forms.OpenFileDialog inputOpenFileDialog;
        private System.Windows.Forms.Button button1;
    }
}

