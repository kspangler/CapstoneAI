using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapstoneAI
{
    class Program
    {
        public class Node
        {
            public int space = 0;
            public int weight = 0;
            public BitArray player = new BitArray(25, false);
            public BitArray computer = new BitArray(25, false);
            public List<Node> children = null;
            public Node parent = null;
        }

        public class Tree
        {
            public List<Node> nodes = new List<Node>();
            public Node root = null;
        }

        public class intNode
        {
            public int value;
            public int alpha = Int32.MinValue;
            public int beta = Int32.MaxValue;
            public List<intNode> children = new List<intNode>();
            public bool min = true;
            public bool max = false;
        }

        public class intTree
        {
            public List<intNode> nodes = new List<intNode>();
            public intNode root = new intNode();
        }

        Node makeChild(Node parent, int space)
        {
            //a legal move has been detected and will now be a child
            //space is the space on the board the piece will occupy

            Node child = new Node();
            child = parent;
            child.space = space;
            child.children = null;
            child.parent = parent;
            parent.children.Add(child);
            if(child.)
            if (parent.min)
            {
                child.player[space] = true;
            }
            else
                child.computer[space] = true;

            return child;
        }

        //public Node alphaBeta(Node root, int alpha, int beta, bool max)
        //{
        //    Node bestMove = new Node();
        //    bestMove = root;
        //    if (root.children != null && alpha < beta)
        //    {
        //        if (!max)
        //        {
        //            foreach (Node child in root.children)
        //            {
        //                if (alphaBeta(child, alpha, beta, true).weight < beta)
        //                    bestMove = child;
        //                else
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            foreach (Node child in root.children)
        //            {
        //                if (alphaBeta(child, alpha, beta, false).weight > alpha)
        //                    bestMove = child;
        //                else
        //                    break;
        //            }
        //        }
        //    }
        //    return bestMove;
        //}

        public int evaluate(Node move, bool [,] adjacent)
        {
            if (move.children == null)
            {
                //if there's a mill, +3, make sure that move is selected
                //if (move.adjacent[i][j] && move.adjacent[j][k])
                {
                    move.weight += 3;
                }
                //if 2 in a row with no opponent in that row, +2
                //if (move.adjacent[i][j] && !move.player1[k])
                //weight more if an opponent cannot block (i.e. 2 in a row, and you can get a mill on next move)
                {
                    move.weight += 2;
                }
                //if 2 in a row, +1
                //if (move.adjacent[i][j])
                {
                    move.weight += 1;
                }
                //# of connections +1 each
                if (true)
                { }
            //blocking opponents mill +2, make sure that's done
            //if (opponent has mill && (move.adjacent[i][j] || move.adjacent[j][k]))
                {
                    move.weight += 3;
                }
                //if (opponent gets mill)
                {
                    move.weight = 0;
                }

            }
            else
            {
                foreach (Node child in move.children)
                    evaluate(child, adjacent);
            }
            return move.weight;
        }

        bool mill(Node move, bool[,] adjacent)
        {
            bool isMill = false;

            if(adjacent[move.space])
            return isMill;
        }

        bool legalMove(Node from, Node to, bool[,] adjacent)
        {
            bool legal = false;
            if (adjacent[from.space, to.space])
                legal = true;
            return legal;
        }

        int evaluate(intNode number)
        {
            return number.value;
        }

        public int findMax(intNode root, int alpha, int beta, bool max)
        {
            int bestMove = root.value;
            List<int> minList = new List<int>();
            List<int> maxList = new List<int>();
            if (root.children == null)
                bestMove = root.value;
            else if (alpha < beta)
            {
                if(!max)
                {
                    foreach (intNode child in root.children)
                    {
                        if (findMax(child, alpha, beta, true) < beta)
                            bestMove = child.value;
                        else
                            break;
                    }
                }
                else
                {
                    foreach (intNode child in root.children)
                    {
                        if (findMax(child, alpha, beta, false) > alpha)
                            bestMove = child.value;
                        else
                            break;
                    }
                }
            }
            return bestMove;
        }

        public Node alphaBeta(Node root, int alpha, int beta, bool max)
        {
            Node bestMove = root
            if (root.children == null)
                evaluate(root);
            else if (alpha < beta)
            {
                if (!max)
                {
                    foreach (Node child in root.children)
                    {
                        if (alphaBeta(child, alpha, beta, true).weight < beta)
                            bestMove = child;
                        else
                            break;
                    }
                }
                else
                {
                    foreach (Node child in root.children)
                    {
                        if (alphaBeta(child, alpha, beta, false).weight > alpha)
                            bestMove = child;
                        else
                            break;
                    }
                }
            }
            //else - what happens if alpha >= beta?
            return bestMove;
        }

        static void Main(string[] args)
        {
            //make the tree here
            //the root is the move the player just made, and it is a min
            //the max child needs to be selected

            //Tree tree = new CapstoneAI.Program.Tree();
            //tree.root = playerMove;
            //tree.root.min = true;
            //tree.root.max = false;

            intTree tree = new intTree();

            bool[,] adjacent = new bool[25, 25];

            adjacent[1, 2] = adjacent[2, 1] = true;
            adjacent[2, 3] = adjacent[3, 2] = true;
            adjacent[4, 5] = adjacent[5, 4] = true;
            adjacent[5, 6] = adjacent[6, 5] = true;
            adjacent[7, 8] = adjacent[8, 7] = true;
            adjacent[8, 9] = adjacent[9, 8] = true;
            adjacent[10, 11] = adjacent[11, 10] = true;
            adjacent[11, 12] = adjacent[12, 11] = true;
            adjacent[13, 14] = adjacent[14, 13] = true;
            adjacent[14, 15] = adjacent[15, 14] = true;
            adjacent[16, 17] = adjacent[17, 16] = true;
            adjacent[17, 18] = adjacent[18, 17] = true;
            adjacent[19, 20] = adjacent[20, 19] = true;
            adjacent[20, 21] = adjacent[21, 20] = true;
            adjacent[22, 23] = adjacent[23, 22] = true;
            adjacent[23, 24] = adjacent[24, 23] = true;

            adjacent[1, 10] = adjacent[10, 1] = true;
            adjacent[10, 22] = adjacent[22, 10] = true;
            adjacent[4, 11] = adjacent[11, 4] = true;
            adjacent[11, 19] = adjacent[19, 11] = true;
            adjacent[7, 12] = adjacent[12, 7] = true;
            adjacent[12, 16] = adjacent[16, 12] = true;
            adjacent[2, 5] = adjacent[5, 2] = true;
            adjacent[5, 8] = adjacent[8, 5] = true;
            adjacent[17, 20] = adjacent[20, 17] = true;
            adjacent[20, 23] = adjacent[23, 20] = true;
            adjacent[9, 13] = adjacent[13, 9] = true;
            adjacent[13, 18] = adjacent[18, 13] = true;
            adjacent[6, 14] = adjacent[14, 6] = true;
            adjacent[14, 21] = adjacent[21, 14] = true;
            adjacent[3, 15] = adjacent[15, 3] = true;
            adjacent[15, 24] = adjacent[24, 15] = true;

            //for right now, the search will go 3 layers deep
            int newChildValue;
            newChildValue = Convert.ToInt32(Console.ReadLine());
            tree.root = new intNode();
            tree.root.value = newChildValue;
            int counter = 0;
            newChildValue = Convert.ToInt32(Console.ReadLine());
            intNode curChild = new CapstoneAI.Program.intNode();
            curChild = tree.root;
            List<intNode> nodes = new List<intNode>();
            int position = 0;
            while (newChildValue != 0)
            {
                if (counter == 2)
                {
                    counter = 0;
                    position++;
                    curChild = nodes[position];
                }
                else
                    counter++;

                intNode newChild = new CapstoneAI.Program.intNode();
                if(curChild.min)
                {
                    newChild.max = true;
                    newChild.min = false;
                }
                newChild.value = newChildValue;
                curChild.children.Add(newChild);
                nodes.Add(newChild);

                newChildValue = Convert.ToInt32(Console.ReadLine());
            }
            CapstoneAI.Program program = new CapstoneAI.Program();
            Console.WriteLine(program.findMax(tree.root, Int32.MinValue, Int32.MaxValue, true));

        }
    }
}
