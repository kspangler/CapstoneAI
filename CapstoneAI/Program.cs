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

        Node makeChild(Node parent, int space, bool max)
        {
            //a legal move has been detected and will now be a child
            //space is the space on the board the piece will occupy

            Node child = new Node();
            child = parent;
            child.space = space;
            child.children = null;
            child.parent = parent;
            parent.children.Add(child);
            if (max)
            {
                child.computer[space] = true;
            }
            else
                child.player[space] = true;

            return child;
        }

        public int evaluate(Node move, bool [,] adjacent)
        {
            int weight = 0;
                if(mill(move))
                //if (move.adjacent[i][j] && move.adjacent[j][k])
                {
                weight += 3;
                }
                //if 2 in a row with no opponent in that row, +2
                //if (move.adjacent[i][j] && !move.player1[k])
                //weight more if an opponent cannot block (i.e. 2 in a row, and you can get a mill on next move)
                {
                weight += 2;
                }
                //if 2 in a row, +1
                //if (move.adjacent[i][j])
                {
                weight += 1;
                }
                //# of connections +1 each
                if (true)
                { }
            if(blockedMill)
            //if (opponent has mill && (move.adjacent[i][j] || move.adjacent[j][k]))
                {
                weight += 3;
                }
                if (mill) //pass in opponents bitset instead of CPU's
                {
                weight = 0;
                }
            move.weight = weight;
            return move.weight;
        }

        bool mill(Node move, bool[,] adjacent)
        {
            //use adjacency to figure out if there is a mill in the move
            bool isMill = false;
            foreach (bool bit in move.computer)
            {
                //make arrays for the different mills - there are 16 possible, so you know you will have 16 arrays of 3 ints
                if(bit && millbit[0] && millbit[1] && millbit[2])
                    //its a mill
                    //i.e. 1 is the poential space, so is mill1[0], mill1[1], mill2[2]?
            }
            return isMill;
        }

        bool blockedMill(Node move)
        {
            bool isBlocked = false;
            if (//opponent has two spaces adjacent && CPU can place a piece in that row)
                isBlocked = true;
            return isBlocked;
        }

        bool legalMove(Node from, Node to, bool[,] adjacent)
        {
            bool legal = false;
            if (adjacent[from.space, to.space])
                legal = true;
            return legal;
        }
 
        public int alphaBeta(Node root, int alpha, int beta, bool max)
        {
            //check time constraint of 6 seconds
            //if so, return immediately
            int bestValue = root.weight;
            if (root.children == null)
                bestValue = root.weight;
            if (max)
            {
                foreach (Node child in root.children)
                {
                    int result = alphaBeta(child, alpha, beta, false);
                    if (result > alpha)
                    {
                        alpha = result;
                        bestValue = child.weight;
                    }
                    if (alpha >= beta)
                        break;
                }
            }

            else
            {
                foreach (Node child in root.children)
                {
                    int result = alphaBeta(child, alpha, beta, true);
                    if (result < beta)
                    {
                        beta = result;
                        bestValue = child.weight;
                    }
                    if (alpha >= beta)
                        break;
                }
            }

            return bestValue;
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
                if (!max)
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

        static void Main(string[] args)
        {
            //make the tree here
            //the root is the move the player just made, and it is a min
            //the max child needs to be selected

            //Tree tree = new CapstoneAI.Program.Tree();
            //tree.root = playerMove;
            //tree.root.min = true;
            //tree.root.max = false;

            Tree tree = new Tree();

            //bool[,] adjacent = new bool[25, 25];

            int[] adjacent1 = new int[4] { 2, 10, 0, 0 };
            int[] adjacent2 = new int[4] { 1, 3, 5, 0 };
            int[] adjacent3 = new int[4] { 2, 15, 0, 0 };
            int[] adjacent4 = new int[4] { 5, 11, 0, 0 };
            int[] adjacent5 = new int[4] { 2, 4, 6, 8 };
            int[] adjacent6 = new int[4] { 5, 14, 0, 0 };
            int[] adjacent7 = new int[4] { 8, 12, 0, 0 };
            int[] adjacent8 = new int[4] { 5, 7, 9, 0 };
            int[] adjacent9 = new int[4] { 8, 13, 0, 0 };
            int[] adjacent10 = new int[4] { 1, 11, 22, 0 };
            int[] adjacent11 = new int[4] { 4, 10, 12, 19 };
            int[] adjacent12 = new int[4] { 7, 11, 16, 0 };
            int[] adjacent13 = new int[4] { 9, 14, 18, 0 };
            int[] adjacent14 = new int[4] { 6, 13, 15, 21 };
            int[] adjacent15 = new int[4] { 3, 14, 24, 0 };
            int[] adjacent16 = new int[4] { 12, 17, 0, 0 };
            int[] adjacent17 = new int[4] { 16, 18, 20, 0 };
            int[] adjacent18 = new int[4] { 13, 17, 0, 0 };
            int[] adjacent19 = new int[4] { 11, 20, 0, 0 };
            int[] adjacent20 = new int[4] { 17, 19, 21, 23 };
            int[] adjacent21 = new int[4] { 14, 20, 0, 0 };
            int[] adjacent22 = new int[4] { 10, 23, 0, 0 };
            int[] adjacent23 = new int[4] { 20, 22, 24, 0 };
            int[] adjacent24 = new int[4] { 15, 23, 0, 0 };
            
            //adjacent[1, 2] = adjacent[2, 1] = true;
            //adjacent[2, 3] = adjacent[3, 2] = true;
            //adjacent[4, 5] = adjacent[5, 4] = true;
            //adjacent[5, 6] = adjacent[6, 5] = true;
            //adjacent[7, 8] = adjacent[8, 7] = true;
            //adjacent[8, 9] = adjacent[9, 8] = true;
            //adjacent[10, 11] = adjacent[11, 10] = true;
            //adjacent[11, 12] = adjacent[12, 11] = true;
            //adjacent[13, 14] = adjacent[14, 13] = true;
            //adjacent[14, 15] = adjacent[15, 14] = true;
            //adjacent[16, 17] = adjacent[17, 16] = true;
            //adjacent[17, 18] = adjacent[18, 17] = true;
            //adjacent[19, 20] = adjacent[20, 19] = true;
            //adjacent[20, 21] = adjacent[21, 20] = true;
            //adjacent[22, 23] = adjacent[23, 22] = true;
            //adjacent[23, 24] = adjacent[24, 23] = true;

            //adjacent[1, 10] = adjacent[10, 1] = true;
            //adjacent[10, 22] = adjacent[22, 10] = true;
            //adjacent[4, 11] = adjacent[11, 4] = true;
            //adjacent[11, 19] = adjacent[19, 11] = true;
            //adjacent[7, 12] = adjacent[12, 7] = true;
            //adjacent[12, 16] = adjacent[16, 12] = true;
            //adjacent[2, 5] = adjacent[5, 2] = true;
            //adjacent[5, 8] = adjacent[8, 5] = true;
            //adjacent[17, 20] = adjacent[20, 17] = true;
            //adjacent[20, 23] = adjacent[23, 20] = true;
            //adjacent[9, 13] = adjacent[13, 9] = true;
            //adjacent[13, 18] = adjacent[18, 13] = true;
            //adjacent[6, 14] = adjacent[14, 6] = true;
            //adjacent[14, 21] = adjacent[21, 14] = true;
            //adjacent[3, 15] = adjacent[15, 3] = true;
            //adjacent[15, 24] = adjacent[24, 15] = true;

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
