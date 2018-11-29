using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.Entity
{
    public static class EntityFactory
    {
        public static Enemy GetEnemy(int x, int y)
        {
            return new Enemy(new Point(x, y));
        }

        public static Floor GetFloor(int x, int y)
        {
            return new Floor(new Point(x, y));
        }

        public static Wall GetWall(int x, int y)
        {
            return new Wall(new Point(x, y));
        }

        public static Food GetFood(int x, int y)
        {
            return new Food(new Point(x, y));
        }

        public static Igloo GetIgloo(int x, int y)
        {
            return new Igloo(new Point(x, y));
        }

        public static Player GetPlayer(int x, int y)
        {
            return new Player(new Point(x, y));
        }
    }
}
