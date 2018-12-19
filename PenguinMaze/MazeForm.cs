using PenguinMaze.Classes;
using PenguinMaze.Classes.Entity;
using PenguinMaze.Classes.PathFinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze
{
    public partial class MazeForm : Form
    {
        public List<AbstractEntity> entities = new List<AbstractEntity>();
        public CombatForm combatForm = new CombatForm();

        public MazeForm()
        {
            InitializeComponent();
            GameManager.StartGame(this,combatForm);
        }

        private void MazeArea_PB_Paint(object sender, PaintEventArgs e)
        {
           
            GameManager.DrawGame(e.Graphics);
            int width  = (Map.MapData.GetUpperBound(0) + 1) * Map.CellSize;
            int height = (Map.MapData.GetUpperBound(1) + 1) * Map.CellSize;
            MazeArea_PB.Size = new Size(width, height);
        }

        private void Hint_Btn_Click(object sender, EventArgs e)
        {
            GameManager.ShowPath();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            GameManager.UpdateEntities(keyData);
            GameManager.UpdateStatus();
            Refresh();
            return true;
        }

        private void Player_PB_Paint(object sender, PaintEventArgs e)
        {
            GameManager.Player.Draw(e.Graphics, null, Player_PB.Width);
        }

        public void UpdatePlayerInfo(object sender)
        {
            if (sender is Player)
            {
                Player player = (Player)sender;
                PlayerLife_Lb.Text = "Life : " + player.Lifes;
                PlayerHP_Lb.Text = "HP : " + player.HealthPoint;
                PlayerWD_Lb.Text = "Wall Destroyer : " + player.WallDestroyer;
                PlayerScore_Lb.Text = "Score : " + player.Score;
            }
        }
    }
}
