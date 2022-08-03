namespace SudokuPro
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
            this.button3 = new System.Windows.Forms.Button();
            this.btnStage1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnStage2 = new System.Windows.Forms.Button();
            this.btnStage3 = new System.Windows.Forms.Button();
            this.btnStage4 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPerebor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(1342, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 103);
            this.button3.TabIndex = 8;
            this.button3.Text = "заново";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnStage1
            // 
            this.btnStage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage1.BackColor = System.Drawing.SystemColors.Control;
            this.btnStage1.Enabled = false;
            this.btnStage1.Location = new System.Drawing.Point(1342, 179);
            this.btnStage1.Name = "btnStage1";
            this.btnStage1.Size = new System.Drawing.Size(130, 44);
            this.btnStage1.TabIndex = 7;
            this.btnStage1.Text = "метод 1";
            this.btnStage1.UseVisualStyleBackColor = false;
            this.btnStage1.Click += new System.EventHandler(this.btnStage1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1342, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 103);
            this.button1.TabIndex = 6;
            this.button1.Text = "решить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.SystemColors.Control;
            this.textBox.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox.Location = new System.Drawing.Point(1357, 567);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(115, 75);
            this.textBox.TabIndex = 9;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(8, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "пример 1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(8, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "пример 2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(3, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 28);
            this.button6.TabIndex = 12;
            this.button6.Text = "пример 3";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnStage2
            // 
            this.btnStage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage2.BackColor = System.Drawing.SystemColors.Control;
            this.btnStage2.Enabled = false;
            this.btnStage2.Location = new System.Drawing.Point(1342, 229);
            this.btnStage2.Name = "btnStage2";
            this.btnStage2.Size = new System.Drawing.Size(130, 44);
            this.btnStage2.TabIndex = 13;
            this.btnStage2.Text = "метод 2";
            this.btnStage2.UseVisualStyleBackColor = false;
            this.btnStage2.Click += new System.EventHandler(this.btnStage2_Click);
            // 
            // btnStage3
            // 
            this.btnStage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage3.BackColor = System.Drawing.SystemColors.Control;
            this.btnStage3.Enabled = false;
            this.btnStage3.Location = new System.Drawing.Point(1342, 279);
            this.btnStage3.Name = "btnStage3";
            this.btnStage3.Size = new System.Drawing.Size(130, 44);
            this.btnStage3.TabIndex = 14;
            this.btnStage3.Text = "метод 3";
            this.btnStage3.UseVisualStyleBackColor = false;
            this.btnStage3.Click += new System.EventHandler(this.btnStage3_Click);
            // 
            // btnStage4
            // 
            this.btnStage4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStage4.BackColor = System.Drawing.SystemColors.Control;
            this.btnStage4.Enabled = false;
            this.btnStage4.Location = new System.Drawing.Point(1342, 329);
            this.btnStage4.Name = "btnStage4";
            this.btnStage4.Size = new System.Drawing.Size(130, 44);
            this.btnStage4.TabIndex = 15;
            this.btnStage4.Text = "метод 4";
            this.btnStage4.UseVisualStyleBackColor = false;
            this.btnStage4.Click += new System.EventHandler(this.btnStage4_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(1342, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 44);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "начать";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(8, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "пример 4";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPerebor
            // 
            this.btnPerebor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPerebor.BackColor = System.Drawing.SystemColors.Control;
            this.btnPerebor.Enabled = false;
            this.btnPerebor.Location = new System.Drawing.Point(1342, 379);
            this.btnPerebor.Name = "btnPerebor";
            this.btnPerebor.Size = new System.Drawing.Size(130, 44);
            this.btnPerebor.TabIndex = 18;
            this.btnPerebor.Text = "перебором";
            this.btnPerebor.UseVisualStyleBackColor = false;
            this.btnPerebor.Click += new System.EventHandler(this.btnPerebor_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1237, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(86, 127);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BackColor = System.Drawing.SystemColors.Control;
            this.btnGenerate.Location = new System.Drawing.Point(1193, 179);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(130, 44);
            this.btnGenerate.TabIndex = 21;
            this.btnGenerate.Text = "сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "(нет)";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "easy",
            "medium",
            "difficult"});
            this.comboBox1.Location = new System.Drawing.Point(1193, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnPerebor);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStage4);
            this.Controls.Add(this.btnStage3);
            this.Controls.Add(this.btnStage2);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnStage1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = " ";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnStage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnStage2;
        private System.Windows.Forms.Button btnStage3;
        private System.Windows.Forms.Button btnStage4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPerebor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

