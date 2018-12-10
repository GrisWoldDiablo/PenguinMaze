using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze.Classes.Entity
{
    public class Wall : AbstractEntity
    {
        private static string imageFile = "Wall.png";
        private static Image spriteIMG;

        public Wall(Point location) : base(0, location)
        {
        }

        static Wall()
        {
            spriteIMG = Image.FromFile($"../../Resources/{imageFile}");
        }

        public override void Draw(Graphics g, Image spriteIMG = null, int size = 0)
        {
            base.Draw(g, Wall.spriteIMG);
        }

        public override void Move()
        {
            // Don't Move
        }
    }
}
