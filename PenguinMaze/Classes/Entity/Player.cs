using PenguinMaze.Classes.IStates;
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
    public delegate void PlayerUpdate();
    public delegate void UpdateInfo(object sender);

    public class Player : AbstractEntity
    {
        private event UpdateInfo playerUpdateEvent;
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
        private static string fightingImageFile = "PenguinFight.png";
        private static Image fightingSprite;
        private Image spriteIMG;
        private int lifes;
        private int wallDestroyer;
        private IState currentState;
        private event PlayerUpdate PlayerMoved;
        
        
        public int Lifes { get => lifes; set => lifes = value; }
        public int WallDestroyer { get => wallDestroyer; set => wallDestroyer = value; }
        public IState CurrentState { get => currentState; set => currentState = value; }

        static Player()
        {
            foreach (var item in imageFiles)
            {
                spriteImages.Add(Image.FromFile($"../../Resources/{item}"));
            }
            fightingSprite = Image.FromFile($"../../Resources/{fightingImageFile}");
        }

        public Player(Point location) : base(0, location)
        {
            this.playerUpdateEvent = GameManager.MazeForm.UpdatePlayerInfo;
            this.currentDirection = Direction.NONE;
            this.lifes = 3;
            this.target = null;
            this.healthPoint = 100;
            this.damagePoint = 30;
            this.isAlive = true;
            this.wallDestroyer = 3;
            this.currentState = NormalState.GetInstance();
            this.playerUpdateEvent(this);
        }


        public override void Draw(Graphics g, Image spriteIMG = null, int size = 0)
        {
            if (this.isFighting)
            {
                this.spriteIMG = fightingSprite;
            }
            else
            {
                this.spriteIMG = Player.spriteImages[(int)this.currentDirection];
            }
            base.Draw(g, this.spriteIMG, size);
        }
        
        public void UpdateDirection(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.W:
                    this.currentDirection = Direction.UP;
                    break;
                case Keys.Down:
                case Keys.S:
                    this.currentDirection = Direction.DOWN;
                    break;
                case Keys.Left:
                case Keys.A:
                    this.currentDirection = Direction.LEFT;
                    break;
                case Keys.Right:
                case Keys.D:
                    this.currentDirection = Direction.RIGHT;
                    break;
                default:
                    this.currentDirection = Direction.NONE;
                    break;
            }
        }

        public override void Move()
        {
            Point currentLocation = new Point(this.location.X,this.location.Y);
            base.Move();
            if (currentLocation == this.location && this.wallDestroyer > 0)
            {
                Point velocity = GetVelocity();
                int tX = this.location.X + velocity.X;
                int tY = this.location.Y + velocity.Y;

                try
                {
                    if ((Map.MapData[tX, tY] < 0))
                    {
                        Point tempPoint = new Point(tX, tY);
                        int index = Map.Entities.IndexOf(Map.Entities.Find(x => x.Location == tempPoint && x is Wall));
                        Map.Entities[index] = EntityFactory.GetFloor(tX, tY);
                        Map.MapData[tX, tY] = 1;
                        this.wallDestroyer--;
                        this.playerUpdateEvent(this);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            AbstractEntity other = Map.Entities.Find(x => x.Location == this.location && !(x is Floor || x is Igloo || x is Player) );

            if (!(other is null))
            {
                if (other is Enemy)
                {
                    this.currentState.MeetEnemy(this, other);
                }
                else if (other is Food)
                {
                    this.currentState.GetFood(this, other);
                }
                this.playerUpdateEvent(this);
            }

        }

        public override void Eat(AbstractEntity entity)
        {
            if (entity is Food)
            {
                this.healthPoint += entity.Score;
            }
            base.Eat(entity);
        }

        public void SubscribeEvents(Enemy enemy)
        {
            this.PlayerMoved += enemy.UpdatePath;
        }

        public bool FightUpdate()
        {
            if (this.IsFighting)
            {
                this.IsFighting = !base.Fight(this.Target);
            }
            this.playerUpdateEvent(this);
            return this.IsFighting;
        }
    }
}
