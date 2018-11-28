using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze.Classes.Entity
{
    public class Floor : AbstractEntity
    {
        private static string imageFile = "Floor.png";
        private static Image spriteIMG;

        public Floor(Point location) : base(0, location)
        {
        }


        static Floor()
        {
            spriteIMG = Image.FromFile($"../../Resources/{imageFile}");
        }

        public override void Draw(Graphics g, Image spriteIMG = null)
        {
            base.Draw(g, Floor.spriteIMG);
        }

        public override void Move()
        {
            // Don't Move
        }
    }
}
