using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    public class Player : AbstractEntity
    {
        
        private static string[] imageFiles = { "PenguinNone.png", "PenguinUp.png", "PenguinDown.png", "PenguinLeft.png", "PenguinRight.png", };
        /// <summary>
        /// Image for needed based on players <see cref="Direction"/> Indexes:
        /// <para/>0 : <see cref="Direction.NONE"/> , PenguinNone.png 
        /// <para/>1 : <see cref="Direction.UP"/>   , PenguinUp.png   
        /// <para/>2 : <see cref="Direction.DOWN"/> , PenguinDown.png 
        /// <para/>3 : <see cref="Direction.LEFT"/> , PenguinLeft.png 
        /// <para/>4 : <see cref="Direction.RIGHT"/>, PenguinRight.png
        /// </summary>
        private static List<Image> spriteImages = new List<Image>();
        private Image spriteIMG;
        private Direction heading;

        static Player()
        {
            foreach (var item in imageFiles)
            {
                spriteImages.Add(Image.FromFile($"../../Resources/{item}"));
            }
        }

        public Player(Point location) : base(200, location)
        {
            this.heading = Direction.NONE;
            this.spriteIMG = Player.spriteImages[(int)this.heading];
        }

        public override void Draw(Graphics g, Image spriteIMG = null)
        {
            this.spriteIMG = Player.spriteImages[(int)this.heading];
            base.Draw(g, this.spriteIMG);
        }
    }
}
