using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Rubik_s_Cube
{
    class RubiksCube
    {
        private UInt64[] sides = new UInt64[6];

        public UInt64[] Sides
        {
            get { return sides; }
        }

        //white = 1 blue = 2 red = 3 green = 4 orange = 5 yellow = 6
        public RubiksCube()
        {
            sides[0] = 72340172838076673;
            sides[1] = 144680345676153346;
            sides[2] = 217020518514230019;
            sides[3] = 289360691352306692;
            sides[4] = 361700864190383365;
            sides[5] = 434041037028460038;
        }

        //Returns true or false depending on whether the cube entered exists
        public bool isValid()
        {
            int[] colours = new int[6];
            for (int x = 0; x < 6; x++)
            {
                UInt64 bitmask = 255;
                UInt64 face = this.sides[x];
                for (int bits = 0; bits < 64; bits+=8)
                {
                    UInt64 colour = (face & bitmask) >> bits;
                    bitmask <<= 8;
                    colours[colour - 1]++;
                }
            }
            for(int x = 0; x < 6; x++)
            {
                if(colours[x] != 8)
                {
                    return false;
                }
            }
            return true;
        }

        public bool PermutationsGenerated(ref HashTable cornerPermutations)
        {
            UInt64 currentPermutation = CornerPermutation();
            if (!cornerPermutations.Contains(currentPermutation))
            {
                cornerPermutations.Add(currentPermutation);
            }
            if (cornerPermutations.Count == 96) { return true; }
            return false;
        }

        //2 = 16711680, 4 = 1095216660480, 6 = 71776119061217280
        public UInt64 CornerPermutation()
        {
            UInt64 permutation = 0;
            UInt64 position = 1;
            for(int face = 0; face != 7; face += 2)
            {
                if (face == 6) { face--; }
                UInt64 bitmask = 255;
                int bits = 0;
                for (int x = 0; x < 4; x++)
                {
                    permutation += ((this.sides[face] & bitmask) >> bits) * position;
                    position *= 10;
                    bitmask <<= 16;
                    bits += 16;
                }
            }
            return permutation;
            /*((this.sides[0] & 255) * 1000000000000000) + (((this.sides[2] & 16711680) >> 16) * 100000000000000) +
            (((this.sides[0] & 16711680) >> 16) * 10000000000000) + ((this.sides[2] & 255) * 1000000000000) +
            (((this.sides[0] & 1095216660480) >> 32) * 100000000000) + (((this.sides[4] & 16711680) >> 16) * 10000000000) +
            (((this.sides[0] & 71776119061217280) >> 48) * 1000000000) + ((this.sides[4] & 255) * 100000000) +
            ((this.sides[5] & 255) * 10000000) + (((this.sides[4] & 71776119061217280) >> 48) * 1000000) +
            (((this.sides[5] & 16711680) >> 16) * 100000) + (((this.sides[4] & 1095216660480) >> 32) * 10000) +
            (((this.sides[5] & 1095216660480) >> 32) * 1000) + (((this.sides[2] & 71776119061217280) >> 48) * 100) +
            (((this.sides[5] & 71776119061217280) >> 48) * 10) + ((this.sides[2] & 1095216660480) >> 32);
            /*((this.sides[0] & 255).ToString() + (this.sides[2] & 16711680).ToString() +
            (this.sides[0] & 16711680).ToString() + (this.sides[2] & 255).ToString() +
            (this.sides[0] & 1095216660480).ToString() + (this.sides[4] & 16711680).ToString() +
            (this.sides[0] & 71776119061217280).ToString() + (this.sides[4] & 255).ToString() +
            (this.sides[5] & 255).ToString() + (this.sides[4] & 71776119061217280).ToString() +
            (this.sides[5] & 16711680).ToString() + (this.sides[4] & 1095216660480).ToString() +
            (this.sides[5] & 1095216660480).ToString() + (this.sides[2] & 71776119061217280).ToString() +
            (this.sides[5] & 71776119061217280).ToString() + (this.sides[2] & 1095216660480).ToString());*/
        }

        //Checks an edge pieces two squares to see whether it is oriented correctly
        private bool Check(UInt64 square, UInt64 adjacentSquare)
        {
            if (square == 5 || square == 3)
            {
                return true;
            }
            else if ((square== 1 || square == 6) && (adjacentSquare == 2 || adjacentSquare == 4))
            {
                return true;
            }
            return false;
        }

        public bool Stage2()
        {
            const int byte1 = 65280;
            const UInt64 byte5 = 280375465082880;
            //First checks whether the corners are correctly oriented by observing their colour on the blue and green faces
            UInt64 bitmask = 255;
            for (int x = 0; x < 4; x++)
            {
                if (((this.sides[3] & bitmask) >> (16 * x) != 4) && ((this.sides[3] & bitmask) >> (16 * x) != 2)) { return false; }
                if (((this.sides[1] & bitmask) >> (16 * x) != 4) && ((this.sides[1] & bitmask) >> (16 * x) != 2)) { return false; }
                bitmask <<= 16;
            }
            //Next all edges within the M slice are checked to see whether they are orange, red or white (in the correct slice)
            for (int face = 0; face < 7; face += 2)
            {
                if (face == 6) { face--; }
                UInt64 colour = (this.sides[face] & byte1) >> 8;
                if (!(colour == 5 || colour == 1 || colour == 6 || colour == 3))
                {
                    return false;
                }
                colour = (this.sides[face] & byte5) >> 40;
                if (!(colour == 5 || colour == 1 || colour == 6 || colour == 3))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Stage31()
        {
            //Iterates through all squares of each face apart from white and yellow
            for(int face = 1; face < 5; face++)
            {
                UInt64 bitmask = 255;
                int bits = 0;
                for(int piece = 0; piece < 8; piece++)
                {
                    UInt64 square = (this.sides[face] & bitmask) >> bits;
                    //Checks whether the square is the opposite or same face colour
                    if(!(square == 5 || square == 4 || square == 3 || square == 2))
                    {
                        return false;
                    }
                    bitmask <<= 8;
                    bits += 8;
                }
            }
            return true;
        }

        public bool Stage3(HashTable cornerPermutations)
        {
            const int byte1 = 65280;
            const UInt64 byte3 = 4278190080;
            const UInt64 byte5 = 280375465082880;
            const UInt64 byte7 = 18374686479671623680;
            //Checks the colour of edges on the top and bottom face - White/Yellow
            for (int face = 1; face < 5; face++)
            {
                UInt64 colour = (this.sides[face] & byte7) >> 56;
                if (!(colour == 5 || colour == 4 || colour == 3 || colour== 2)) { return false; }
                colour = (this.sides[face] & byte3) >> 24;
                if (!(colour == 5 || colour == 4 || colour == 3 || colour == 2)) { return false; }
            }
            //Checks colour of edges on the front, right, left and back face - Orange, Green, Blue, Red
            for (int face = 1; face != 2; face += 2)
            {
                if (face == 7) { face = 0; }
                UInt64 colour = (this.sides[face] & byte1) >> 8;
                if (!(colour == 1 || colour == 2 || colour == 4 || colour == 6)) { return false; }
                colour = (this.sides[face] & byte5) >> 40;
                if (!(colour == 1 || colour == 2 || colour == 4 || colour == 6)) { return false; }
            }
            //Checks whether the corner permutation of the cube is valid
            if (cornerPermutations.Contains(CornerPermutation())) { return true; }
            return false;
        }

        public bool EdgeOrientation()
        {
            const int byte1 = 65280;
            const UInt64 byte3 = 4278190080;
            const UInt64 byte5 = 280375465082880;
            const UInt64 byte7 = 18374686479671623680;
            //Checks each edge on the orange face (Front Face) 
            UInt64 bitmask = 65280;
            if (!Check((this.sides[4] & bitmask) >> 8, (this.sides[0] & byte5) >> 40)) { return false; }
            if (!Check((this.sides[4] & (bitmask <<= 16)) >> 24, (this.sides[3] & byte7) >> 56)) { return false; }
            if (!Check((this.sides[4] & (bitmask <<= 16)) >> 40, (this.sides[5] & byte1) >> 8)) { return false; }
            if (!Check((this.sides[4] & (bitmask <<= 16)) >> 56, (this.sides[1] & byte3) >> 24)) { return false; }
            //Checks each edge on the red face (Back Face)
            bitmask = 65280;
            if (!Check((this.sides[2] & bitmask) >> 8, (this.Sides[0] & bitmask) >> 8)) { return false; }
            if (!Check((this.sides[2] & (bitmask <<= 16)) >> 24, (this.sides[1] & byte7) >> 56)) { return false; }
            if (!Check((this.sides[2] & (bitmask <<= 16)) >> 40, (this.sides[5] & byte5) >> 40)) { return false; }
            if (!Check((this.sides[2] & (bitmask <<= 16)) >> 56, (this.sides[3] & byte3) >> 24)) { return false; }
            //Checks the right and left edges on the white and yellow face (Top and Bottom Face) that have not been checked.
            if (!Check((this.sides[0] & byte3) >> 24, (this.sides[3] & byte1) >> 8)) { return false; }
            if (!Check((this.sides[0] & byte7) >> 56, (this.sides[1] & byte1) >> 8)) { return false; }
            if (!Check((this.sides[5] & byte3) >> 24, (this.sides[3] & byte5) >> 40)) { return false; }
            if (!Check((this.sides[5] & byte7) >> 56, (this.sides[1] & byte5) >> 40)) { return false; }
            return true;
        }

        public bool isEqual(RubiksCube cube)
        {
            if (this.sides[0] != cube.Sides[0]) { return false; }
            if (this.sides[1] != cube.Sides[1]) { return false; }
            if (this.sides[2] != cube.Sides[2]) { return false; }
            if (this.sides[3] != cube.Sides[3]) { return false; }
            if (this.sides[4] != cube.Sides[4]) { return false; }
            if (this.sides[5] != cube.Sides[5]) { return false; }
            return true;
        }

        //Executes a Rubiks cube R movement - Singmaster notation
        public void R()
        {
            UInt64 temp = sides[5] & 1099511562240;
            sides[3] = sides[3] << 16 | sides[3] >> 48;
            UInt64 temp1 = (sides[2] & 18446462598732841215) << 32 | (sides[2] & 18446462598732841215) >> 32;
            sides[5] = temp1 + (sides[5] & 18446742974197989375);
            temp1 = sides[4] & 1099511562240;
            sides[4] = temp + (sides[4] & 18446742974197989375);
            temp = (sides[0] & 1099511562240) >> 32 | (sides[0] & 1099511562240) << 32;
            sides[0] = temp1 + (sides[0] & 18446742974197989375);
            sides[2] = temp + (sides[2] & 140737488355200);
        }
        //L Movement
        public void L()
        {
            UInt64 temp = (sides[5] & 18446462598732841215) << 32 | (sides[5] & 18446462598732841215) >> 32;
            sides[1] = sides[1] << 16 | sides[1] >> 48;
            UInt64 temp1 = sides[4] & 18446462598732841215;
            sides[5] = temp1 + (sides[5] & 281474976710400);
            temp1 = (sides[2] & 1099511562240) >> 32 | (sides[2] & 1099511562240) << 32;
            sides[2] = temp + (sides[2] & 18446742974197989375);
            temp = sides[0] & 18446462598732841215;
            sides[0] = temp1 + (sides[0] & 281474976710400);
            sides[4] = temp + (sides[4] & 281474976710400);
        }
        //U Movement
        public void U()
        {
            UInt64 temp = sides[4] & 16777215;
            sides[0] = sides[0] << 16 | sides[0] >> 48;
            sides[4] = (sides[4] & 9223372036846387200) + (sides[3] & 16777215);
            UInt64 temp1 = sides[1] & 16777215;
            sides[1] = (sides[1] & 9223372036846387200) + temp;
            temp = sides[2] & 16777215;
            sides[2] = (sides[2] & 9223372036846387200) + temp1;
            sides[3] = (sides[3] & 9223372036846387200) + temp;
        }
        //D Movement
        public void D()
        {
            UInt64 temp = sides[4] & 36028792723996672;
            sides[5] = sides[5] << 16 | sides[5] >> 48;
            sides[4] = (sides[4] & 18374686483966590975) + (sides[1] & 36028792723996672);
            UInt64 temp1 = sides[3] & 36028792723996672;
            sides[3] = (sides[3] & 18374686483966590975) + temp;
            temp = sides[2] & 36028792723996672;
            sides[2] = (sides[2] & 18374686483966590975) + temp1;
            sides[1] = (sides[1] & 18374686483966590975) + temp;
        }
        //F Movement
        public void F()
        {
            UInt64 temp = sides[3] & 18446462598732841215;
            sides[4] = sides[4] << 16 | sides[4] >> 48;
            sides[3] = (sides[3] & 281474976710400) + ((sides[0] & 72057589742960640) << 16 | (sides[0] & 72057589742960640) >> 48);
            UInt64 temp1 = (sides[5] & 16777215) << 16 | (sides[5] & 16777215) >> 48;
            sides[5] = (sides[5] & 18446744073692774400) + (temp << 16 | temp >> 48);
            temp = (sides[1] & 1099511562240) << 16 | (sides[1] & 1099511562240) >> 48;
            sides[0] = (sides[0] & 18374686483966590975) + temp;
            sides[1] = (sides[1] & 18446742974197989375) + temp1;
        }
        //B Movement
        public void B()
        {
            UInt64 temp = sides[3] & 1099511562240;
            sides[2] = sides[2] << 16 | sides[2] >> 48;
            sides[3] = (sides[3] & 18446742974197989375) + ((sides[5] & 72057589742960640) >> 16 | (sides[5] & 72057589742960640) << 48);
            UInt64 temp1 = (sides[0] & 16777215) >> 16 | (sides[0] & 16777215) << 48;
            sides[0] = (sides[0] & 18446744073692774400) + (temp >> 16 | temp << 48);
            temp = (sides[1] & 18446462598732841215) >> 16 | (sides[1] & 18446462598732841215) << 48;
            sides[5] = (sides[5] & 18374686483966590975) + temp;
            sides[1] = (sides[1] & 281474976710400) + temp1;
        }
        //R Prime Movement
        public void RP()
        {
            UInt64 temp = sides[0] & 1099511562240;
            sides[3] = sides[3] >> 16 | sides[3] << 48;
            UInt64 temp1 = (sides[2] & 18446462598732841215) << 32 | (sides[2] & 18446462598732841215) >> 32;
            sides[0] = temp1 + (sides[0] & 18446742974197989375);
            temp1 = sides[4] & 1099511562240;
            sides[4] = temp + (sides[4] & 18446742974197989375);
            temp = (sides[5] & 1099511562240) >> 32 | (sides[5] & 1099511562240) << 32;
            sides[5] = temp1 + (sides[5] & 18446742974197989375);
            sides[2] = temp + (sides[2] & 140737488355200);
        }
        //L Prime Movement
        public void LP()
        {
            UInt64 temp = (sides[0] & 18446462598732841215) << 32 | (sides[0] & 18446462598732841215) >> 32;
            sides[1] = sides[1] >> 16 | sides[1] << 48;
            UInt64 temp1 = sides[4] & 18446462598732841215;
            sides[0] = temp1 + (sides[0] & 281474976710400);
            temp1 = (sides[2] & 1099511562240) >> 32 | (sides[2] & 1099511562240) << 32;
            sides[2] = temp + (sides[2] & 18446742974197989375);
            temp = sides[5] & 18446462598732841215;
            sides[5] = temp1 + (sides[5] & 281474976710400);
            sides[4] = temp + (sides[4] & 281474976710400);
        }
        //U Prime Movement
        public void UP()
        {
            UInt64 temp = sides[4] & 16777215;
            sides[0] = sides[0] >> 16 | sides[0] << 48;
            sides[4] = (sides[4] & 9223372036846387200) + (sides[1] & 16777215);
            UInt64 temp1 = sides[3] & 16777215;
            sides[3] = (sides[3] & 9223372036846387200) + temp;
            temp = sides[2] & 16777215;
            sides[2] = (sides[2] & 9223372036846387200) + temp1;
            sides[1] = (sides[1] & 9223372036846387200) + temp;
        }
        //D Prime Movement
        public void DP()
        {
            UInt64 temp = sides[4] & 36028792723996672;
            sides[5] = sides[5] >> 16 | sides[5] << 48;
            sides[4] = (sides[4] & 18374686483966590975) + (sides[3] & 36028792723996672);
            UInt64 temp1 = sides[1] & 36028792723996672;
            sides[1] = (sides[1] & 18374686483966590975) + temp;
            temp = sides[2] & 36028792723996672;
            sides[2] = (sides[2] & 18374686483966590975) + temp1;
            sides[3] = (sides[3] & 18374686483966590975) + temp;
        }
        //F Prime Movement
        public void FP()
        {
            UInt64 temp = sides[1] & 1099511562240;
            sides[4] = sides[4] >> 16 | sides[4] << 48;
            sides[1] = (sides[1] & 18446742974197989375) + ((sides[0] & 72057589742960640) >> 16);
            UInt64 temp1 = (sides[5] & 16777215) >> 16 | (sides[5] & 16777215) << 48;
            sides[5] = (sides[5] & 18446744073692774400) + (temp >> 16);
            temp = (sides[3] & 18446462598732841215) >> 16 | (sides[3] & 18446462598732841215) << 48;
            sides[3] = (sides[3] & 281474976710400) + temp1;
            sides[0] = (sides[0] & 18374686483966590975) + temp;
        }
        //B Prime Movement
        public void BP()
        {
            UInt64 temp = sides[3] & 1099511562240;
            sides[2] = sides[2] >> 16 | sides[2] << 48;
            sides[3] = (sides[3] & 18446742974197989375) + ((sides[0] & 16777215) << 16);
            UInt64 temp1 = (sides[5] & 72057589742960640) << 16 | (sides[5] & 72057589742960640) >> 48;
            sides[5] = (sides[5] & 18374686483966590975) + (temp << 16);
            temp = (sides[1] & 18446462598732841215) << 16 | (sides[1] & 18446462598732841215) >> 48;
            sides[1] = (sides[1] & 281474976710400) + temp1;
            sides[0] = (sides[0] & 18446744073692774400) + temp;
        }

        //Half Rotations for all sides
        public void R2()
        {
            this.R(); this.R();
        }
        public void L2()
        {
            this.L(); this.L();
        }
        public void U2()
        {
            this.U(); this.U();
        }
        public void D2()
        {
            this.D(); this.D();
        }
        public void F2()
        {
            this.F(); this.F();
        }
        public void B2()
        {
            this.B(); this.B();
        }
    }
}
