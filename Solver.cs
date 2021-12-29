using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace Rubik_s_Cube
{
    class Solver
    {
        private string solutionString;
        private HashTable cornerPermutations = new HashTable(500);
        private List<Action> solution = new List<Action>();

        public string SolutionString
        {
            get { return solutionString; }
        }

        public List<Action> Solution
        {
            get { return solution; }
        }

        public HashTable CornerPermutations
        {
            get { return cornerPermutations; }
        }

        public Solver(ref RubiksCube cube, int stage)
        {
            Stack<int> moves = new Stack<int>(15);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RotationStore rotations = new RotationStore(ref cube);
            switch (stage)
            {
                case 0:
                case 4:
                    rotations.G1(); rotations.G2(); rotations.G3();
                    break;
                case 2:
                    rotations.G1();
                    break;
            }
            IDDFS(cube, new RubiksCube(), 15, stage, sw, rotations, ref moves);

            while (!moves.isStackEmpty())
            {
                int move = moves.Pop();
                solutionString += rotations.getName(move) + " ";
                solution.Add(rotations.Rotate[move]);
            }
            sw.Stop();
        }

        public Solver(ref RubiksCube cube, HashTable cornerpermutations)
        {
            Stack<int> moves = new Stack<int>(15);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RotationStore rotations = new RotationStore(ref cube);
            cornerPermutations = cornerpermutations;
            rotations.G1(); rotations.G2();
            IDDFS(cube, new RubiksCube(), 15, 3, sw, rotations, ref moves);
            while (!moves.isStackEmpty())
            {
                int move = moves.Pop();
                solutionString += rotations.getName(move) + " ";
                solution.Add(rotations.Rotate[move]);
            }
            sw.Stop();
        }

        public Solver (ref RubiksCube unsolved, RubiksCube customSolution, int depth)
        {
            Stack<int> moves = new Stack<int>(15);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RotationStore rotations = new RotationStore(ref unsolved);
            IDDFS(unsolved, customSolution, depth, 4, sw, rotations, ref moves);
            while (!moves.isStackEmpty())
            {
                int move = moves.Pop();
                solutionString += rotations.getName(move) + " ";
                solution.Add(rotations.Rotate[move]);
            }
            sw.Stop();
        }

        //Pruning method for removing unecessary branches 
        private bool Prune(string current, string last)
        {
            if (current[0] == last[0]) { return true; }
            if (current[0] == 'F' && last[0] == 'B') { return true; }
            if (current[0] == 'L' && last[0] == 'R') { return true; }
            if (current[0] == 'U' && last[0] == 'D') { return true; }
            return false;
        }

        //Found method returns true when the cube has satisfied a particular stage
        private bool Found(RubiksCube cube, RubiksCube solution, int stage)
        {
            switch (stage)
            {
                case 0:
                    return cube.PermutationsGenerated(ref cornerPermutations);
                case 1:
                    return cube.EdgeOrientation();
                case 2:
                    return cube.Stage2();
                case 3:
                    return cube.Stage3(cornerPermutations);
                    //return cube.Stage31();
                case 4:
                    return cube.isEqual(solution);
            }
            return false;
        }

        //This method starts the solution search of a particular cube.
        private bool IDDFS(RubiksCube cube, RubiksCube solution, int maxDepth, int stage, Stopwatch sw, RotationStore rotations, ref Stack<int> moves)
        {
            BigInteger nodeCount = 0;
            //It essentially iteratively deepens by employing depth limited searches at every depth to the maximum
            for (int depth = 0; depth <= maxDepth; depth++)
            {
                //The solution is found once the depth limited search returns true
                if (DLS(cube, solution, depth, " ", stage, rotations, ref nodeCount, ref moves))
                {
                    return true;
                }
                Console.WriteLine("Depth: " + depth + " Nodes: " + nodeCount + " Time: " + sw.Elapsed);
            }
            return false;
        }

        //DLS performs recursive graph traversal over cube states at a certain depth
        private bool DLS(RubiksCube cube, RubiksCube solution, int depth, string last, int stage, RotationStore rotations, ref BigInteger count, ref Stack<int> moves)
        {
            bool solved = false;
            //True is returned once the solution is found.
            if (Found(cube, solution, stage))
            {
                return true;
            }
            //Base case - if the max depth is reached and no solution is found the recursion stops
            if (depth <= 0)
            {
                return false;
            }

            //For each rotation in the store, the cube is rotated and DLS is called.
            for (int x = 0; x < rotations.Count && !solved; x++)
            {
                if (!Prune(rotations.getName(x), last))
                {
                    count++;
                    rotations.Rotate[x]();
                    if (DLS(cube, solution, depth - 1, rotations.getName(x), stage, rotations, ref count, ref moves))
                    {
                        moves.Push(x);
                        solved = true;
                    }
                    else
                    {
                        rotations.Inverse[x]();
                    }
                }
            }
            return solved;
        }
    }
}
