using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenguinMaze.Classes.Entity;
using PenguinMaze.Classes.PathFinding;

namespace PenguinMaze.Classes.IStates
{
    class NormalState : IState
    {
        private static NormalState myInstance = null;
        private NormalState() { }
        
        public static NormalState GetInstance()
        {
            return myInstance is null ? new NormalState() : myInstance;
        }

        public List<Node> FindPath(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void GetFood(Player player, AbstractEntity food)
        {
            player.Score += food.Score;
        }

        public void GetBooster(Player player, AbstractEntity booster)
        {
            player.Score += booster.Score;
            booster.IsAlive = false;
            player.CurrentState = BoostedState.GetInstance();
        }

        public void MeetEnemy(Player player)
        {
            player.IsFighting = true;
        }
    }
}
