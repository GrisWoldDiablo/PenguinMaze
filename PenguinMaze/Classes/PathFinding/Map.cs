using PenguinMaze.Classes.Entity;
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

        private static List<AbstractEntity> entities = null;
        private static int[,] mapData = null;
        private static int cellSize = 25;
        
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
                            entities.Add(EntityFactory.GetWall(x,y));
                            mapData[x, y] = -1;
                            break;
                        case MapSymbol.Floor:
                            entities.Add(EntityFactory.GetFloor(x, y));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Player:
                            entities.Add(EntityFactory.GetFloor(x, y));
                            player = EntityFactory.GetPlayer(x, y);
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Enemy:
                            entities.Add(EntityFactory.GetFloor(x, y));
                            entities.Add(EntityFactory.GetEnemy(x, y));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Food:
                            entities.Add(EntityFactory.GetFloor(x, y));
                            entities.Add(EntityFactory.GetFood(x, y));
                            mapData[x, y] = 1;
                            break;
                        case MapSymbol.Igloo:
                            entities.Add(EntityFactory.GetFloor(x, y));
                            ending = EntityFactory.GetIgloo(x, y);
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
            entities.Add(ending);
            return !(player is null);
        }

        public static int GetData(int x, int y)
        {
            int maxX = mapData.GetUpperBound(0);
            int maxY = mapData.GetUpperBound(1);
            if (x < 0 || x > maxX)
            {
                return -1;
            }
            else if (x < 0 || x > maxX)
            {
                return -1;
            }
            else
            {
                return mapData[x, y];
            }
        }
    }
}
