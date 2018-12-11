using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenguinMaze.Classes.Entity;
using PenguinMaze.Classes.PathFinding;

namespace PenguinMaze.Classes.IStates
{
    class BoostedState : IState
    {
        private static BoostedState myInstance = null;
        private BoostedState() { }

        public static BoostedState GetInstance()
        {
            return myInstance is null ? new BoostedState() : myInstance;
        }

        public List<Node> FindPath(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void GetFood(Player player, AbstractEntity food)
        {
            player.Score += food.Score * 2;
        }

        public void GetBooster(Player player, AbstractEntity booster)
        {
            player.Score += booster.Score * 2;
            booster.IsAlive = false;
        }

        public void MeetEnemy(Player player)
        {
            player.IsFighting = false;
            player.CurrentState = NormalState.GetInstance();
        }
    }
}
