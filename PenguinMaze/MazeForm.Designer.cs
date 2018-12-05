using System.Windows.Forms;

namespace PenguinMaze
{
    partial class MazeForm
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
            this.Task_Lb = new System.Windows.Forms.Label();
            this.Hint_Btn = new System.Windows.Forms.Button();
            this.MazeArea_PB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MazeArea_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Task_Lb
            // 
            this.Task_Lb.AutoSize = true;
            this.Task_Lb.Location = new System.Drawing.Point(108, 24);
            this.Task_Lb.Name = "Task_Lb";
            this.Task_Lb.Size = new System.Drawing.Size(38, 13);
            this.Task_Lb.TabIndex = 1;
            this.Task_Lb.Text = "Ready";
            // 
            // Hint_Btn
            // 
            this.Hint_Btn.BackgroundImage = global::PenguinMaze.Properties.Resources.button_hint;
            this.Hint_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Hint_Btn.Location = new System.Drawing.Point(12, 12);
            this.Hint_Btn.Name = "Hint_Btn";
            this.Hint_Btn.Size = new System.Drawing.Size(90, 37);
            this.Hint_Btn.TabIndex = 2;
            this.Hint_Btn.UseVisualStyleBackColor = true;
            this.Hint_Btn.Click += new System.EventHandler(this.Hint_Btn_Click);
            this.Hint_Btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // MazeArea_PB
            // 
            this.MazeArea_PB.BackColor = System.Drawing.Color.White;
            this.MazeArea_PB.InitialImage = null;
            this.MazeArea_PB.Location = new System.Drawing.Point(12, 55);
            this.MazeArea_PB.Name = "MazeArea_PB";
            this.MazeArea_PB.Padding = new System.Windows.Forms.Padding(10);
            this.MazeArea_PB.Size = new System.Drawing.Size(100, 50);
            this.MazeArea_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MazeArea_PB.TabIndex = 0;
            this.MazeArea_PB.TabStop = false;
            this.MazeArea_PB.Paint += new System.Windows.Forms.PaintEventHandler(this.MazeArea_PB_Paint);
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1507, 702);
            this.Controls.Add(this.Hint_Btn);
            this.Controls.Add(this.Task_Lb);
            this.Controls.Add(this.MazeArea_PB);
            this.DoubleBuffered = true;
            this.Name = "MazeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penguin Maze";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MazeArea_PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MazeArea_PB;
        private System.Windows.Forms.Label Task_Lb;
        private System.Windows.Forms.Button Hint_Btn;

        public Label Task_Lb1 { get => Task_Lb; set => Task_Lb = value; }
    }
}

