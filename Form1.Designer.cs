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
            this.DgvGraph = new System.Windows.Forms.DataGridView();
            this.TbxShortPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvGraph
            // 
            this.DgvGraph.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvGraph.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DgvGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGraph.ColumnHeadersVisible = false;
            this.DgvGraph.Location = new System.Drawing.Point(12, 12);
            this.DgvGraph.Name = "DgvGraph";
            this.DgvGraph.RowHeadersVisible = false;
            this.DgvGraph.Size = new System.Drawing.Size(240, 150);
            this.DgvGraph.TabIndex = 0;
            // 
            // TbxShortPath
            // 
            this.TbxShortPath.Location = new System.Drawing.Point(258, 12);
            this.TbxShortPath.Multiline = true;
            this.TbxShortPath.Name = "TbxShortPath";
            this.TbxShortPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbxShortPath.Size = new System.Drawing.Size(237, 239);
            this.TbxShortPath.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TbxShortPath);
            this.Controls.Add(this.DgvGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DgvGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvGraph;
        private System.Windows.Forms.TextBox TbxShortPath;
    }
}

