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
        public AbstractEntity theOne;
        public List<AbstractEntity> entities = new List<AbstractEntity>();
        public CombatForm combatForm = new CombatForm();

        public MazeForm()
        {
            InitializeComponent();
            theOne = new Player(new Point(0, 0));

            GameManager.StartGame(this,combatForm);
            //combatForm.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameManager.UpdateEntities(e.KeyCode);
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!(GameManager.T is null))
            {
                Task_Lb.Text = GameManager.T.Status.ToString(); 
            }
            GameManager.DrawGame(e.Graphics);
            int width  = (Map.MapData.GetUpperBound(0) + 1) * Map.CellSize;
            int height = (Map.MapData.GetUpperBound(1) + 1) * Map.CellSize;
            pictureBox1.Size = new Size(width, height);
        }
    }
}
