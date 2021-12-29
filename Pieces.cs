using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik_s_Cube
{
    interface IPiece
    {
        int XColour
        {
            get;
            set;
        }
        int YColour
        {
            get;
            set;
        }
        int ZColour
        {
            get;
            set;
        }
        void XTurn(); // (U/U') AND (D/D') Rotations
        void YTurn(); // (R/R') AND (L/L') Rotations
        void ZTurn(); // (F/F') AND (B/B') Rotations
    }

    class Center : IPiece
    {
        private int x;
        private int y;
        private int z;

        public Center(int xColour, int yColour, int zColour)
        {
            x = xColour;
            y = yColour;
            z = zColour;
        }

        public int XColour
        {
            get { return x; }
            set { x = value; }
        }
        public int YColour
        {
            get { return y; }
            set { y = value; }
        }

        public int ZColour
        {
            get { return z; }
            set { z = value; }
        }
        //Colours do not change on the center piece
        public void XTurn() { }
        public void YTurn() { }
        public void ZTurn() { }
    }

    class CornerEdge : IPiece
    {
        private int x;
        private int y;
        private int z;

        public CornerEdge(int xColour, int yColour, int zColour)
        {
            x = xColour;
            y = yColour;
            z = zColour;
        }

        public int XColour
        {
            get { return x; }
            set { x = value; }
        }

        public int YColour
        {
            get { return y; }
            set { y = value; }
        }

        public int ZColour
        {
            get { return z; }
            set { z = value; }
        }

        public void XTurn()
        {
            int temp = y;
            y = x;
            x = temp;
        }

        public void YTurn()
        {
            int temp = y;
            y = z;
            z = temp;
        }

        public void ZTurn()
        {
            int temp = z;
            z = x;
            x = temp;
        }
    }
}
