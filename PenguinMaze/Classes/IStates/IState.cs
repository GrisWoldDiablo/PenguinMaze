using PenguinMaze.Classes.Entity;
using PenguinMaze.Classes.PathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.IStates
{
    public interface IState
    {
        List<Node> FindPath(Enemy enemy);
        void GetFood(Player player, AbstractEntity food);
        void GetBooster(Player player, AbstractEntity booster);
        void MeetEnemy(Player player);
    }
}
