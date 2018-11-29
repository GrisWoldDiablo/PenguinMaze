using PenguinMaze.Classes.PathFinding;
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
            this.heading = Direction.NONE;
            this.target = null;
            this.healthPoint = 100;
            this.damagePoint = 10;
            this.isAlive = true;
        }

        public override void Draw(Graphics g, Image spriteIMG = null, int size = 0)
        {
            base.Draw(g, this.spriteIMG, size);
        }

        public override void Move()
        {
            base.Move();
            AbstractEntity other = Map.Entities.Find(x => x.Location == this.location && !(x is Floor || x is Igloo || x is Enemy));

            if (!(other is null))
            {
                if (other is Player)
                {
                    this.target = other;
                    this.isFighting = true;
                }
                else
                {
                    base.Eat(other);
                }
            }
        }
    }
}
