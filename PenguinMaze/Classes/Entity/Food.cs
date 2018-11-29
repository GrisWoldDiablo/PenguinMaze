using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze.Classes.Entity
{
    public class Food : AbstractEntity
    {
        private static string[] imageFiles = { "Fish.png", "Crab.png", "Lobster.png" };
        private static List<Image> spriteImages = new List<Image>();
        private Image spriteIMG;

        static Food()
        {
            foreach (var item in imageFiles)
            {
                spriteImages.Add(Image.FromFile($"../../Resources/{item}"));
            }
        }

        public Food(Point location) : base(100, location)
        {
            this.spriteIMG = Food.spriteImages[Rand.Next(spriteImages.Count)];
        }

        public override void Draw(Graphics g, Image spriteIMG = null, int size = 0)
        {
            base.Draw(g, this.spriteIMG);
        }

        public override void Move()
        {
            // Don't Move
        }
    }
}
