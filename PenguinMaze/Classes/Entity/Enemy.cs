using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    public class Enemy : AbstractEntity
    {
        private static string[] imageFiles = {"Orca.png", "Shark.png"};
        private static List<Image> spriteImages = new List<Image>();
        private Image spriteIMG;
        private Direction heading;

        static Enemy()
        {
            foreach (var item in imageFiles)
            {
                spriteImages.Add(Image.FromFile($"../../Resources/{item}"));
            }
        }

        public Enemy(Point location) : base(200, location)
        {
            this.spriteIMG = Enemy.spriteImages[Rand.Next(spriteImages.Count)];
        }

        public override void Draw(Graphics g, Image spriteIMG = null)
        {
            base.Draw(g, this.spriteIMG);
        }
    }
}
