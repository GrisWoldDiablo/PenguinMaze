namespace PenguinMaze
{
    partial class CombatForm
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
            this.attacker_PB = new System.Windows.Forms.PictureBox();
            this.target_PB = new System.Windows.Forms.PictureBox();
            this.Fight_Btn = new System.Windows.Forms.Button();
            this.attackerHP_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.targetHP_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.attacker_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // attacker_PB
            // 
            this.attacker_PB.BackColor = System.Drawing.Color.Transparent;
            this.attacker_PB.Location = new System.Drawing.Point(12, 12);
            this.attacker_PB.Name = "attacker_PB";
            this.attacker_PB.Size = new System.Drawing.Size(300, 300);
            this.attacker_PB.TabIndex = 0;
            this.attacker_PB.TabStop = false;
            this.attacker_PB.Paint += new System.Windows.Forms.PaintEventHandler(this.Attacker_PB_Paint);
            // 
            // target_PB
            // 
            this.target_PB.BackColor = System.Drawing.Color.Transparent;
            this.target_PB.Location = new System.Drawing.Point(488, 12);
            this.target_PB.Name = "target_PB";
            this.target_PB.Size = new System.Drawing.Size(300, 300);
            this.target_PB.TabIndex = 1;
            this.target_PB.TabStop = false;
            this.target_PB.Paint += new System.Windows.Forms.PaintEventHandler(this.Target_PB_Paint);
            // 
            // Fight_Btn
            // 
            this.Fight_Btn.Location = new System.Drawing.Point(333, 370);
            this.Fight_Btn.Name = "Fight_Btn";
            this.Fight_Btn.Size = new System.Drawing.Size(118, 40);
            this.Fight_Btn.TabIndex = 2;
            this.Fight_Btn.Text = "FIGHT!";
            this.Fight_Btn.UseVisualStyleBackColor = true;
            this.Fight_Btn.Click += new System.EventHandler(this.Fight_Btn_Click);
            // 
            // attackerHP_TB
            // 
            this.attackerHP_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackerHP_TB.Location = new System.Drawing.Point(212, 318);
            this.attackerHP_TB.Name = "attackerHP_TB";
            this.attackerHP_TB.Size = new System.Drawing.Size(100, 29);
            this.attackerHP_TB.TabIndex = 3;
            this.attackerHP_TB.Text = "88888";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "HP :";
            // 
            // targetHP_TB
            // 
            this.targetHP_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetHP_TB.Location = new System.Drawing.Point(688, 318);
            this.targetHP_TB.Name = "targetHP_TB";
            this.targetHP_TB.Size = new System.Drawing.Size(100, 29);
            this.targetHP_TB.TabIndex = 3;
            this.targetHP_TB.Text = "88888";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(632, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "HP :";
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PenguinMaze.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetHP_TB);
            this.Controls.Add(this.attackerHP_TB);
            this.Controls.Add(this.Fight_Btn);
            this.Controls.Add(this.target_PB);
            this.Controls.Add(this.attacker_PB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CombatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CombatForm";
            ((System.ComponentModel.ISupportInitialize)(this.attacker_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.target_PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox attacker_PB;
        private System.Windows.Forms.PictureBox target_PB;
        private System.Windows.Forms.Button Fight_Btn;
        private System.Windows.Forms.TextBox attackerHP_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox targetHP_TB;
        private System.Windows.Forms.Label label2;
    }
}