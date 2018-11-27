using PenguinMaze.Classes;
using PenguinMaze.Classes.Entity;
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
    public partial class Form1 : Form
    {
        public AbstractEntity theOne;
        public List<AbstractEntity> entities = new List<AbstractEntity>();
        public Form1()
        {
            InitializeComponent();
            theOne = new Player(new Point(0, 0));
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    switch (Rand.Next(3))
                    {
                        case 0:
                            entities.Add(new Floor(new Point(i * 50, j * 50)));
                            entities.Add(new Player(new Point(i * 50, j * 50)));
                            break;
                        case 1:
                            entities.Add(new Floor(new Point(i * 50, j * 50)));
                            entities.Add(new Food(new Point(i * 50, j * 50)));
                            break;
                        case 2:
                            entities.Add(new Floor(new Point(i * 50, j * 50)));
                            entities.Add(new Enemy(new Point(i * 50, j * 50)));
                            break;
                        case 3:
                            entities.Add(new Wall(new Point(i * 50, j * 50)));
                            break;
                        case 4:
                            entities.Add(new Floor(new Point(i * 50, j * 50)));
                            break;

                        default:
                            break;
                    } 
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in entities)
            {
                item.Draw(e.Graphics); 
            }
        }
    }
}
