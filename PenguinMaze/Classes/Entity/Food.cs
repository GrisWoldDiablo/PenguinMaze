using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    class Food : AbstractEntity
    {
        private static string[] imageFiles = { "Fish.png", "Crab.png", "Fish.png" };
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


        

        public override void Draw(Graphics g, Image spriteIMG = null)
        {
            base.Draw(g, this.spriteIMG);
        }
    }
}
