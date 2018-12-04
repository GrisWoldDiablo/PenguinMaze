using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.PathFinding
{
    public class AStar
    {
        public static List<Node> FindPath(Node startNode, Node goalNode)
        {
            List<Node> path = new List<Node>();
            List<Node> openNodes = new List<Node>();
            List<Node> closedNodes = new List<Node>();

            openNodes.Add(startNode);

            while (openNodes.Count > 0)
            {
                Node currentNode = TakeOutNode(openNodes);
                if (currentNode == goalNode)
                {
                    goalNode.ParentNode = currentNode.ParentNode;
                    break;
                }

                List<Node> neighbors = currentNode.GetNeighbors();
                foreach (Node neighbor in neighbors)
                {
                    int indexInOpen = openNodes.IndexOf(neighbor);
                    if (indexInOpen > 0)
                    {
                        if (openNodes[indexInOpen].CompareTo(currentNode) <= 0)
                        {
                            continue;
                        }
                    }


                    int indexInClosed = openNodes.IndexOf(neighbor);
                    if (indexInClosed > 0)
                    {
                        if (closedNodes[indexInClosed].CompareTo(currentNode) <= 0)
                        {
                            continue;
                        }
                    }

                    if (indexInOpen != -1)
                    {
                        openNodes.RemoveAt(indexInOpen);
                    }
                    if (indexInClosed != -1)
                    {
                        closedNodes.RemoveAt(indexInClosed);
                    }

                    openNodes.Add(neighbor);
                }

                closedNodes.Add(currentNode);

            }

            Node pathNode = goalNode;

            while ((pathNode != null))
            {
                path.Insert(0, pathNode);
                pathNode = pathNode.ParentNode;
            }

            return path;
        }

        private static Node TakeOutNode(List<Node> nodes)
        {
            nodes.Sort();
            //nodes.Reverse();
            Node n = nodes[0];
            nodes.RemoveAt(0);
            return n;
        }
    }
}
