using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    abstract class AbstractEntity
    {
        protected bool isEaten;                // Is the entity eaten.
        protected int scoreValue;              // Point value of the entity.  
        protected Point location;              // Point location (X,Y) of the entity.
        protected Direction currentDirection;  // The direction this entity is going.
        
        // Proterties
        public int Score { get => scoreValue; set => scoreValue = value; }
        public Point Location { get => location; set => location = value; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="scoreValue">Point/score value</param>
        /// <param name="location">Point location (X,Y)</param>
        /// <param name="spriteIMG">Image to be drawn</param>
        public AbstractEntity(int score, Point location)
        {
            this.scoreValue = score;
            this.location = location;
            this.isEaten = false;
            this.currentDirection = Direction.NONE;
        }

        public virtual void Draw(Graphics g, Image spriteIMG = null)
        {
            if (spriteIMG is null) return;
            int size = 0; // Map cell size TOCOMPLETE
            Rectangle spriteBound = new Rectangle(location.X, location.Y, size, size); // Get the bound of the sprite to draw on the graphic
            g.DrawImage(spriteIMG, spriteBound);
        }
        
        public virtual void Eat(AbstractEntity entity)
        {
            if (!entity.isEaten)
            {
                this.scoreValue += entity.scoreValue;
                entity.isEaten = true;
            }
        }

        public virtual Point GetVelocity()
        {
            switch (this.currentDirection)
            {
                case Direction.UP:
                    return new Point(0, -1);
                case Direction.DOWN:
                    return new Point(0, 1);
                case Direction.LEFT:
                    return new Point(-1, 0);
                case Direction.RIGHT:
                    return new Point(1, 0);
                default:
                    return new Point(0, 0);
            }
        }
    }
}
