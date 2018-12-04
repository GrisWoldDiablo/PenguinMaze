using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenguinMaze.Classes;
using PenguinMaze.Classes.Entity;
using PenguinMaze.Classes.PathFinding;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace PenguinMaze.Classes
{
    public class GameManager
    {
        private static bool isGameOver = false;
        private static Player player;
        private static Igloo ending;
        private static int currentLevel = 0;
        private static MazeForm mazeForm;
        private static CombatForm combatForm;
        private static string[] levels = { "Level0.txt" };

        private static List<Node> path = new List<Node>();

        public static Player Player { get => player; set => player = value; }
        public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        private static Task t = null;
        public static Task T { get => t; set => t = value; }

        public static void StartGame(MazeForm theMazeForm, CombatForm theCombatForm)
        {
            mazeForm = theMazeForm;
            combatForm = theCombatForm;

            ResetGame();

        }

        private static void ResetGame()
        {
            InitLevel();
            currentLevel = 0;
            player.Lifes = 3;
        }

        private static void InitLevel()
        {
            LoadLevel(levels[currentLevel]);
        }

        private static void NextLevel()
        {
            currentLevel++;
            InitLevel();
        }

        private static void LoadLevel(string mapFileName)
        {
            if (!Map.LoadMap(mapFileName, out player, out ending))
            {
                MessageBox.Show($"File name {mapFileName} missing");
            }
        }

        public static void DrawGame(Graphics g)
        {
            foreach (var item in path)
            {
                item.Draw(g);
            }
            foreach (AbstractEntity entity in Map.Entities)
            {
                entity.Draw(g);
            }
            
        }

        public static void UpdateStatus()
        {
            if (player.Lifes <= 0)
            {
                ResetGame();
            }
        }

        public static void UpdateEntities(Keys key)
        {
            
            player.UpdateDirection(key);
            player.Move();
            if (player.IsFighting)
            {
                mazeForm.Enabled = false;
                combatForm.StartCombat(player, player.Target);
            }
            foreach (AbstractEntity entity in Map.Entities)
            {
                if (entity is Enemy)
                {
                    entity.Move();
                }
            }

            if (/*key == Keys.Space*/true)
            {
                Node endingNode = new Node(ending.Location.X, ending.Location.Y, null, null);
                Node playerNode = new Node(player.Location.X, player.Location.Y, endingNode, null);
                //new Task(() => path = AStar.FindPath(playerNode, endingNode)).Start();
                t = Task.Run(() => path = AStar.FindPath(playerNode, endingNode));
            }
        }

        public static void CombatUpdate()
        {
            foreach (var item in Map.Entities)
            {
                if (item.IsFighting)
                {
                    item.Fight(item.Target);
                }
            }
            if (!player.Target.IsAlive)
            {
                Map.Entities.Remove(player.Target);
                player.Target = null;
            }
            if (!player.IsFighting)
            {
                mazeForm.Enabled = true;
                combatForm.Hide();
            }
        }
        
    }
}
