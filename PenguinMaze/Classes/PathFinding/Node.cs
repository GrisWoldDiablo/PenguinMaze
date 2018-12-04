using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes.PathFinding
{
    public class Node : IComparable, IComparer
    {

        private int x;
        private int y;
        private Node goalNode;
        private Node parentNode;
        private int gValue;
        private int gTV;
        private float fV;
        private float hV;

        public Node(int x, int y, Node goalNode, Node parentNode, int gValue = 1)
        {
            this.gValue = gValue;
            this.x = x;
            this.y = y;
            this.goalNode = goalNode;
            this.parentNode = parentNode;
        }

        public Node GoalNode { get => goalNode; set => goalNode = value; }
        public Node ParentNode { get => parentNode; set => parentNode = value; }
        private float GTotalValue { get { return !(this. parentNode is null) ? this.parentNode.GTotalValue + this.gValue : this.gValue; } }
        private float HValue { get { return !(this.goalNode is null) ? (float)Math.Sqrt(Math.Pow((this.x - this.goalNode.x),2) * Math.Pow((this.y - this.goalNode.y),2)) : 0.0f; } }
        public float FValue { get { return this.GTotalValue + this.HValue; } }


        public List<Node> GetNeighbors()
        {
            List<Node> neighbors = new List<Node>();

            if (Map.GetData(this.x, this.y - 1) > 0) // Up
            {
                Node upN = new Node(this.x, this.y - 1, this.goalNode, this);
                if (upN != this.parentNode)
                {
                    neighbors.Add(upN);
                }
            }

            if (Map.GetData(this.x, this.y + 1) > 0) // Down
            {
                Node downN = new Node(this.x, this.y + 1, this.goalNode, this);
                if (downN != this.parentNode)
                {
                    neighbors.Add(downN);
                }
            }

            if (Map.GetData(this.x - 1, this.y) > 0) // Left
            {
                Node leftN = new Node(this.x - 1, this.y, this.goalNode, this);
                if (leftN != this.parentNode)
                {
                    neighbors.Add(leftN);
                }
            }

            if (Map.GetData(this.x + 1, this.y) > 0) // Right
            {
                Node rightN = new Node(this.x + 1, this.y, this.goalNode, this);
                if (rightN != this.parentNode)
                {
                    neighbors.Add(rightN);
                }
            }
            
            return neighbors;
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }
            else
            {
                Node otherNode = obj as Node;
                if (!(otherNode is null))
                {
                    return this.GTotalValue.CompareTo(otherNode.GTotalValue);
                }
                else
                {
                    throw new ArgumentException("Object provided is not a Node");
                }
            }
        }

        public int Compare(object left, object right)
        {
            return (int)(Math.Round(((Node)left).GTotalValue - ((Node)right).GTotalValue));
        }

        public static bool operator ==(Node a, Node b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return (a.x == b.x && a.y == b.y);
        }

        public static bool operator !=(Node a, Node b)
        {
            if (b is null)
            {
                return true;
            }
            return (a.x != b.x || a.y != b.y);
        }


        public virtual void Draw(Graphics g)
        {
            int size = Map.CellSize;
            Brush myBrush = new SolidBrush(Color.Red);
            Rectangle bound = new Rectangle(this.x * size, this.y * size, size, size); // Get the bound of the sprite to draw on the graphic
            g.FillRectangle(myBrush, bound);
        }
    }
}
