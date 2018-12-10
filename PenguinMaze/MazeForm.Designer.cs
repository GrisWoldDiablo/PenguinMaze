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
            this.PlayerHP_Lb = new System.Windows.Forms.Label();
            this.Player_PB = new System.Windows.Forms.PictureBox();
            this.PlayerLife_Lb = new System.Windows.Forms.Label();
            this.PlayerWD_Lb = new System.Windows.Forms.Label();
            this.PlayerScore_Lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MazeArea_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Task_Lb
            // 
            this.Task_Lb.AutoSize = true;
            this.Task_Lb.Location = new System.Drawing.Point(12, 52);
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
            // 
            // MazeArea_PB
            // 
            this.MazeArea_PB.BackColor = System.Drawing.Color.Transparent;
            this.MazeArea_PB.InitialImage = null;
            this.MazeArea_PB.Location = new System.Drawing.Point(12, 68);
            this.MazeArea_PB.Name = "MazeArea_PB";
            this.MazeArea_PB.Padding = new System.Windows.Forms.Padding(10);
            this.MazeArea_PB.Size = new System.Drawing.Size(100, 50);
            this.MazeArea_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.MazeArea_PB.TabIndex = 0;
            this.MazeArea_PB.TabStop = false;
            this.MazeArea_PB.Paint += new System.Windows.Forms.PaintEventHandler(this.MazeArea_PB_Paint);
            // 
            // PlayerHP_Lb
            // 
            this.PlayerHP_Lb.AutoSize = true;
            this.PlayerHP_Lb.Location = new System.Drawing.Point(195, 29);
            this.PlayerHP_Lb.Name = "PlayerHP_Lb";
            this.PlayerHP_Lb.Size = new System.Drawing.Size(55, 13);
            this.PlayerHP_Lb.TabIndex = 3;
            this.PlayerHP_Lb.Text = "HP : 0000";
            // 
            // Player_PB
            // 
            this.Player_PB.BackColor = System.Drawing.Color.Transparent;
            this.Player_PB.InitialImage = null;
            this.Player_PB.Location = new System.Drawing.Point(129, 5);
            this.Player_PB.Name = "Player_PB";
            this.Player_PB.Padding = new System.Windows.Forms.Padding(10);
            this.Player_PB.Size = new System.Drawing.Size(60, 60);
            this.Player_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Player_PB.TabIndex = 0;
            this.Player_PB.TabStop = false;
            this.Player_PB.Paint += new System.Windows.Forms.PaintEventHandler(this.Player_PB_Paint);
            // 
            // PlayerLife_Lb
            // 
            this.PlayerLife_Lb.AutoSize = true;
            this.PlayerLife_Lb.Location = new System.Drawing.Point(195, 5);
            this.PlayerLife_Lb.Name = "PlayerLife_Lb";
            this.PlayerLife_Lb.Size = new System.Drawing.Size(39, 13);
            this.PlayerLife_Lb.TabIndex = 3;
            this.PlayerLife_Lb.Text = "Life : 0";
            // 
            // PlayerWD_Lb
            // 
            this.PlayerWD_Lb.AutoSize = true;
            this.PlayerWD_Lb.Location = new System.Drawing.Point(195, 52);
            this.PlayerWD_Lb.Name = "PlayerWD_Lb";
            this.PlayerWD_Lb.Size = new System.Drawing.Size(94, 13);
            this.PlayerWD_Lb.TabIndex = 3;
            this.PlayerWD_Lb.Text = "Wall Destroyer: 00";
            // 
            // PlayerScore_Lb
            // 
            this.PlayerScore_Lb.AutoSize = true;
            this.PlayerScore_Lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerScore_Lb.Location = new System.Drawing.Point(302, 5);
            this.PlayerScore_Lb.Name = "PlayerScore_Lb";
            this.PlayerScore_Lb.Size = new System.Drawing.Size(197, 31);
            this.PlayerScore_Lb.TabIndex = 3;
            this.PlayerScore_Lb.Text = "Score : 000000";
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PenguinMaze.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1507, 702);
            this.Controls.Add(this.PlayerLife_Lb);
            this.Controls.Add(this.PlayerScore_Lb);
            this.Controls.Add(this.PlayerWD_Lb);
            this.Controls.Add(this.PlayerHP_Lb);
            this.Controls.Add(this.Hint_Btn);
            this.Controls.Add(this.Task_Lb);
            this.Controls.Add(this.Player_PB);
            this.Controls.Add(this.MazeArea_PB);
            this.DoubleBuffered = true;
            this.Name = "MazeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penguin Maze";
            ((System.ComponentModel.ISupportInitialize)(this.MazeArea_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MazeArea_PB;
        private System.Windows.Forms.Label Task_Lb;
        private System.Windows.Forms.Button Hint_Btn;
        private Label PlayerHP_Lb;
        private PictureBox Player_PB;
        private Label PlayerLife_Lb;
        private Label PlayerWD_Lb;
        private Label PlayerScore_Lb;

        public Label Task_Lb1 { get => Task_Lb; set => Task_Lb = value; }
    }
}

