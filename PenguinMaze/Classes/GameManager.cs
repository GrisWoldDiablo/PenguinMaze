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
        private static Point playerOGLocation;
        private static int playerOGHP;
        private static Igloo ending;
        private static int currentLevel = 0;
        private static MazeForm mazeForm;
        private static CombatForm combatForm;
        private static string[] levels = { "level0.txt", "Level1.txt" };

        private static List<Node> path = new List<Node>();

        public static Player Player { get => player; set => player = value; }
        public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        private static Task t = null;
        public static Task T { get => t; set => t = value; }
        public static MazeForm MazeForm { get => mazeForm; set => mazeForm = value; }

        public static void StartGame(MazeForm theMazeForm, CombatForm theCombatForm)
        {
            mazeForm = theMazeForm;
            combatForm = theCombatForm;
            combatForm.Show();
            combatForm.Hide();
            ResetGame();
        }

        private static void ResetGame()
        {
            InitLevel();
            currentLevel = 0;
            player.Lifes = 1;
        }

        private static void InitLevel()
        {
            LoadLevel(levels[currentLevel]);
        }

        private static void NextLevel()
        {
            currentLevel++;
            if (currentLevel >= levels.Length)
            {
                currentLevel = 0;
            }
            InitLevel();
        }

        private static void LoadLevel(string mapFileName)
        {
            if (!Map.LoadMap(mapFileName, out player, out ending))
            {
                MessageBox.Show($"File name {mapFileName} missing");
            }
            playerOGLocation = Map.Entities.Find(x => x is Player).Location;
            playerOGHP = Map.Entities.Find(x => x is Player).HealthPoint;
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
            if (player.Location == ending.Location)
            {
                NextLevel();
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
        }

        public static async void ShowPath()
        {   
            Node endingNode = new Node(ending.Location.X, ending.Location.Y, null, null);
            Node playerNode = new Node(player.Location.X, player.Location.Y, endingNode, null);
            //new Task(() => path = AStar.FindPath(playerNode, endingNode)).Start();
            t = Task.Run(() => path = AStar.FindPath(playerNode, endingNode));
            mazeForm.Task_Lb1.Text = t.Status != TaskStatus.RanToCompletion?"Thinking...":t.Status.ToString();
            await t;
            if (path.Count > 0)
            {
                mazeForm.Task_Lb1.Text = "Found path."; 
            }
            else
            {
                mazeForm.Task_Lb1.Text = "No path found.";
            }
            mazeForm.Refresh();
            path = new List<Node>();
        }

        public static void CombatUpdate()
        {
            if (player.IsFighting)
            {
                player.FightUpdate();
                //player.Fight(player.Target); 
            }
            foreach (var item in Map.Entities)
            {
                if (item.IsFighting && !(item is Player))
                {
                    if (item.Fight(item.Target))
                    {
                        break;
                    }
                    
                }
            }
            if (!player.IsAlive)
            {
                //Map.Entities.Remove(player.Target);
                //player.Target = null;
                player.Location = playerOGLocation;
                player.HealthPoint = playerOGHP;
                Map.Entities.Add(player);
                player.Lifes--;
                UpdateStatus();
            }
            if (!player.IsFighting)
            {
                mazeForm.Enabled = true;
                combatForm.Hide();
            }
        }
    }
}
