using PenguinMaze.Classes.PathFinding;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinMaze.Classes.Entity
{
    public abstract class AbstractEntity
    {
        protected bool isAlive;                // Is the entity alive or eaten.
        protected int scoreValue;              // Point value of the entity.  
        protected Point location;              // Point location (X,Y) of the entity.
        protected Direction currentDirection;  // The direction this entity is going.

        protected AbstractEntity target;
        protected int healthPoint;
        protected int damagePoint;
        protected bool isFighting;

        // Proterties
        public int Score { get => scoreValue; set => scoreValue = value; }
        public Point Location { get => location; set => location = value; }
        public int HealthPoint { get => healthPoint; set => healthPoint = value; }
        public int DamagePoint { get => damagePoint; set => damagePoint = value; }
        public bool IsFighting { get => isFighting; set => isFighting = value; }
        public AbstractEntity Target { get => target; set => target = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }

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
            this.currentDirection = Direction.NONE;
        }

        public virtual void Draw(Graphics g, Image spriteIMG = null, int size = 0)
        {
            if (spriteIMG is null) return;
            if (size == 0)
            {
                size = Map.CellSize;
                Rectangle spriteBound = new Rectangle(location.X * size, location.Y * size, size, size); // Get the bound of the sprite to draw on the graphic
                g.DrawImage(spriteIMG, spriteBound);
            }
            else
            {
                Rectangle spriteBound = new Rectangle(0, 0, size, size); // Get the bound of the sprite to draw on the graphic
                g.DrawImage(spriteIMG, spriteBound);
            }
        }
        
        public virtual void Eat(AbstractEntity entity)
        {
            if (!entity.isAlive)
            {
                this.scoreValue += entity.scoreValue;
                entity.isAlive = true;
                Map.Entities.Remove(entity);
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
                default: // Direction.NONE
                    return new Point(0, 0);
            }
        }

        public virtual void Move()
        {
            Point velocity = GetVelocity();
            int tX = this.location.X + velocity.X;
            int tY = this.location.Y + velocity.Y;

            if (!(Map.MapData[tX,tY] < 0))
            {
                this.location.X += velocity.X;
                this.location.Y += velocity.Y;
            }   
        }

        public virtual void Fight(AbstractEntity target)
        {
            target.healthPoint -= this.damagePoint;

            if (target.healthPoint <= 0)
            {
                target.isAlive = false;
                target.isFighting = false;
                this.isFighting = false;
            }
        }

    }
}
