namespace MiniPaint
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
            panel1 = new System.Windows.Forms.Panel();
            trackBar1 = new System.Windows.Forms.TrackBar();
            Brush_pb1 = new System.Windows.Forms.PictureBox();
            pictureBox9 = new System.Windows.Forms.PictureBox();
            pictureBox8 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox7 = new System.Windows.Forms.PictureBox();
            pictureBox6 = new System.Windows.Forms.PictureBox();
            pictureBox5 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            Canvas = new System.Windows.Forms.PictureBox();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Brush_pb1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(Brush_pb1);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(943, 59);
            panel1.TabIndex = 0;
            // 
            // trackBar1
            // 
            trackBar1.Location = new System.Drawing.Point(486, 0);
            trackBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new System.Drawing.Size(274, 56);
            trackBar1.TabIndex = 11;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // Brush_pb1
            // 
            Brush_pb1.BackColor = System.Drawing.SystemColors.Info;
            Brush_pb1.Image = Properties.Resources._103456;
            Brush_pb1.Location = new System.Drawing.Point(15, 4);
            Brush_pb1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Brush_pb1.Name = "Brush_pb1";
            Brush_pb1.Size = new System.Drawing.Size(47, 51);
            Brush_pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            Brush_pb1.TabIndex = 10;
            Brush_pb1.TabStop = false;
            Brush_pb1.Click += Brush_pb1_Click;
            // 
            // pictureBox9
            // 
            pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pictureBox9.BackColor = System.Drawing.SystemColors.Info;
            pictureBox9.Image = Properties.Resources._169262;
            pictureBox9.Location = new System.Drawing.Point(775, 4);
            pictureBox9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new System.Drawing.Size(47, 51);
            pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 9;
            pictureBox9.TabStop = false;
            pictureBox9.Click += FileOpening;
            // 
            // pictureBox8
            // 
            pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pictureBox8.BackColor = System.Drawing.SystemColors.Info;
            pictureBox8.Image = Properties.Resources.save_icon_125167;
            pictureBox8.Location = new System.Drawing.Point(829, 4);
            pictureBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new System.Drawing.Size(47, 51);
            pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 8;
            pictureBox8.TabStop = false;
            pictureBox8.Click += SaveFile_button;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pictureBox4.BackColor = System.Drawing.SystemColors.Info;
            pictureBox4.Image = Properties.Resources._25402;
            pictureBox4.Location = new System.Drawing.Point(882, 4);
            pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(47, 51);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            pictureBox4.Click += OpenFile_button;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.SystemColors.Info;
            pictureBox3.Image = Properties.Resources.pngtree_palette_art_illustration_png_image_9122276;
            pictureBox3.Location = new System.Drawing.Point(122, 4);
            pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(47, 51);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += Palette;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = System.Drawing.SystemColors.Info;
            pictureBox7.Image = Properties.Resources._60690;
            pictureBox7.Location = new System.Drawing.Point(230, 4);
            pictureBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new System.Drawing.Size(47, 51);
            pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 6;
            pictureBox7.TabStop = false;
            pictureBox7.Click += RestoreLastAction;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = System.Drawing.SystemColors.Info;
            pictureBox6.Image = Properties.Resources._1485;
            pictureBox6.Location = new System.Drawing.Point(422, 4);
            pictureBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(47, 51);
            pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = System.Drawing.SystemColors.Info;
            pictureBox5.Image = Properties.Resources._32475;
            pictureBox5.Location = new System.Drawing.Point(176, 4);
            pictureBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(47, 51);
            pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            pictureBox5.Click += ChangeFigureButton;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.SystemColors.Info;
            pictureBox2.Image = Properties.Resources._2661173;
            pictureBox2.Location = new System.Drawing.Point(69, 4);
            pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(47, 51);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += Rubber;
            // 
            // Canvas
            // 
            Canvas.Location = new System.Drawing.Point(0, 59);
            Canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Canvas.Name = "Canvas";
            Canvas.Size = new System.Drawing.Size(943, 503);
            Canvas.TabIndex = 1;
            Canvas.TabStop = false;
            Canvas.Paint += Canvas_Paint;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseUp += Canvas_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(943, 561);
            Controls.Add(Canvas);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(959, 598);
            Name = "Form1";
            Text = "Form1";
            FormClosing += ExitMessage;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Brush_pb1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.PictureBox Brush_pb1;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}
