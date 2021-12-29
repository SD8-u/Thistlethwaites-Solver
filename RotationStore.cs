using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik_s_Cube
{
    class RotationStore
    {
        private List<Action> rotate = new List<Action>();
        private List<Action> inverse = new List<Action>();
        private List<string> rotationType = new List<string>();

        public List<Action> Rotate
        {
            get { return rotate; }
        }

        public List<Action> Inverse
        {
            get { return inverse; }
        }

        public string getName(int index)
        {
            return rotationType[index];
        }

        public int Count
        {
            get { return rotationType.Count; }
        }

        //The RotationStore is constructed by adding all rotations to the list properties
        public RotationStore(ref RubiksCube cube)
        {
            rotate.Add(cube.L); rotate.Add(cube.LP); rotate.Add(cube.L2); rotate.Add(cube.R); rotate.Add(cube.RP); rotate.Add(cube.R2);
            rotate.Add(cube.U); rotate.Add(cube.UP); rotate.Add(cube.U2); rotate.Add(cube.D); rotate.Add(cube.DP); rotate.Add(cube.D2);
            rotate.Add(cube.F); rotate.Add(cube.FP); rotate.Add(cube.F2); rotate.Add(cube.B); rotate.Add(cube.BP); rotate.Add(cube.B2);

            inverse.Add(cube.LP); inverse.Add(cube.L);  inverse.Add(cube.L2); inverse.Add(cube.RP); inverse.Add(cube.R); 
            inverse.Add(cube.R2); inverse.Add(cube.UP); inverse.Add(cube.U);  inverse.Add(cube.U2); inverse.Add(cube.DP); 
            inverse.Add(cube.D);  inverse.Add(cube.D2); inverse.Add(cube.FP); inverse.Add(cube.F);  inverse.Add(cube.F2); 
            inverse.Add(cube.BP); inverse.Add(cube.B);  inverse.Add(cube.B2);

            rotationType.Add("L");  rotationType.Add("L'"); rotationType.Add("L2"); rotationType.Add("R");  rotationType.Add("R'");
            rotationType.Add("R2"); rotationType.Add("U");  rotationType.Add("U'"); rotationType.Add("U2"); rotationType.Add("D");
            rotationType.Add("D'"); rotationType.Add("D2"); rotationType.Add("F");  rotationType.Add("F'"); rotationType.Add("F2");
            rotationType.Add("B");  rotationType.Add("B'"); rotationType.Add("B2"); 
        }

        //Removes rotations to achieve group 1
        public void G1()
        {
            rotate.RemoveAt(6); rotate.RemoveAt(6); rotate.RemoveAt(7); rotate.RemoveAt(7);
            inverse.RemoveAt(6); inverse.RemoveAt(6); inverse.RemoveAt(7); inverse.RemoveAt(7);
            rotationType.RemoveAt(6); rotationType.RemoveAt(6); rotationType.RemoveAt(7); rotationType.RemoveAt(7);
        }

        //Removes rotations to achieve group 2
        public void G2()
        {
            rotate.RemoveAt(8); rotate.RemoveAt(8); rotate.RemoveAt(9); rotate.RemoveAt(9);
            inverse.RemoveAt(8); inverse.RemoveAt(8); inverse.RemoveAt(9); inverse.RemoveAt(9);
            rotationType.RemoveAt(8); rotationType.RemoveAt(8); rotationType.RemoveAt(9); rotationType.RemoveAt(9);
        }

        //Removes rotations to achieve group 3
        public void G3()
        {
            rotate.RemoveAt(0); rotate.RemoveAt(0); rotate.RemoveAt(1); rotate.RemoveAt(1);
            inverse.RemoveAt(0); inverse.RemoveAt(0); inverse.RemoveAt(1); inverse.RemoveAt(1);
            rotationType.RemoveAt(0); rotationType.RemoveAt(0); rotationType.RemoveAt(1); rotationType.RemoveAt(1);
        }

        //Causes a pseudorandom 100-move sequence to be applied to the cube
        public void Scramble()
        {
            string scramble = "";
            Random random = new Random();
            for (int y = 0; y < 100; y++)
            {
                int ran = random.Next(0, 18);
                rotate[ran]();
                scramble += rotationType[ran] + ", ";
            }
            Console.WriteLine(scramble);
        }
    }
}
