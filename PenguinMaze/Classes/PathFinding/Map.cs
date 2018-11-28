﻿using PenguinMaze.Classes.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.PathFinding
{
    class Map
    {

        enum MapSymbol
        {
            Wall   = '#',
            Floor  = '.',
            Player = 'P',
            Enemy  = 'E',
            Food   = 'F',
            Igloo  = 'I'
        }


        //public static string mapFile = "Map.txt";
        //private static AbstractEntity[,] entities = null;
        private static List<AbstractEntity> entities = null;
        private static int[,] mapData = null;
        private static int cellSize = 30;

        //public static AbstractEntity[,] Entities { get => entities; set => entities = value; }
        public static List<AbstractEntity> Entities { get => entities; set => entities = value; }
        public static int[,] MapData { get => mapData; set => mapData = value; }
        public static int CellSize { get => cellSize; set => cellSize = value; }

        public static bool LoadMap(string mapFile, out Player player, out Igloo ending)
        {
            player = null;
            ending = null;
            string[] fileLines = File.ReadAllLines($"../../Resources/{mapFile}");
            int height = fileLines.Length;
            int witdh = fileLines[0].Length;
            mapData = new int[witdh, height];
            entities = new List<AbstractEntity>();

            int y = 0;
            foreach (string line in fileLines)
            {
                char[] characters = line.ToCharArray();
                int x = 0;
                foreach (char character in characters)
                {
                    switch ((MapSymbol)character)
                    {
                        case MapSymbol.Wall:
                            //entities[x, y] = new Wall(new Point(x, y));
                            entities.Add(new Wall(new Point(x, y)));
                            mapData[x, y] = -1;
                            break;
                        case MapSymbol.Floor:
                            //entities[x, y] = new Floor(new Point(x, y));
                            entities.Add(new Floor(new Point(x, y)));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Player:
                            //entities[x, y] = new Floor(new Point(x, y));
                            entities.Add(new Floor(new Point(x, y)));
                            player = new Player(new Point(x, y));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Enemy:
                            //entities[x, y] = new Floor(new Point(x, y));
                            //entities[x, y] = new Enemy(new Point(x, y));
                            entities.Add(new Floor(new Point(x, y)));
                            entities.Add(new Enemy(new Point(x, y)));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Food:
                            //entities[x, y] = new Floor(new Point(x, y));
                            //entities[x, y] = new Food(new Point(x, y));
                            entities.Add(new Floor(new Point(x, y)));
                            entities.Add(new Food(new Point(x, y)));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Igloo:
                            //entities[x, y] = new Floor(new Point(x, y));
                            entities.Add(new Floor(new Point(x, y)));
                            ending = new Igloo(new Point(x, y));
                            entities.Add(ending);
                            mapData[x, y] = 1;
                            break;
                        default:
                            break;
                    }
                    x++;
                }
                y++;
            }
            entities.Add(player);
            return !(player is null);
        }
    }
}
