namespace MiniPaint
{
    partial class FigurePicker
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
            Figures = new System.Windows.Forms.ListBox();
            buttonOK = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // Figures
            // 
            Figures.FormattingEnabled = true;
            Figures.ItemHeight = 20;
            Figures.Items.AddRange(new object[] { "Прямая", "Круг", "Прямоугольник" });
            Figures.Location = new System.Drawing.Point(12, 16);
            Figures.Name = "Figures";
            Figures.Size = new System.Drawing.Size(299, 104);
            Figures.TabIndex = 0;
            // 
            // buttonOK
            // 
            buttonOK.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonOK.Location = new System.Drawing.Point(12, 141);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(299, 68);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "Подтвердить выбор";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // FigurePicker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(323, 221);
            Controls.Add(buttonOK);
            Controls.Add(Figures);
            Name = "FigurePicker";
            Text = "FigurePicker";
            Load += FigurePicker_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox Figures;
        private System.Windows.Forms.Button buttonOK;
    }
}