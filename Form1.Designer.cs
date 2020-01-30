namespace wf_testLabs
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
            this.UserID = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.UserSurname = new System.Windows.Forms.TextBox();
            this.UserCountry = new System.Windows.Forms.TextBox();
            this.UserCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(435, 11);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(100, 20);
            this.UserID.TabIndex = 0;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(14, 253);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(29, 13);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Страна";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "Получить информацию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Идентификатор пользователя";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(98, 250);
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Size = new System.Drawing.Size(162, 20);
            this.UserName.TabIndex = 7;
            // 
            // UserSurname
            // 
            this.UserSurname.Location = new System.Drawing.Point(98, 276);
            this.UserSurname.Name = "UserSurname";
            this.UserSurname.ReadOnly = true;
            this.UserSurname.Size = new System.Drawing.Size(162, 20);
            this.UserSurname.TabIndex = 8;
            // 
            // UserCountry
            // 
            this.UserCountry.Location = new System.Drawing.Point(98, 301);
            this.UserCountry.Name = "UserCountry";
            this.UserCountry.ReadOnly = true;
            this.UserCountry.Size = new System.Drawing.Size(162, 20);
            this.UserCountry.TabIndex = 9;
            // 
            // UserCity
            // 
            this.UserCity.Location = new System.Drawing.Point(98, 327);
            this.UserCity.Name = "UserCity";
            this.UserCity.ReadOnly = true;
            this.UserCity.Size = new System.Drawing.Size(162, 20);
            this.UserCity.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Город";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 232);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UserCountry);
            this.Controls.Add(this.UserSurname);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.UserID);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox UserSurname;
        private System.Windows.Forms.TextBox UserCountry;
        private System.Windows.Forms.TextBox UserCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

