using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Drawing.Drawing2D;

namespace Rubik_s_Cube
{
    public partial class RubiksCubeUI : Form
    {
        List<Action> rotate = new List<Action>();
        RubiksCube cube = new RubiksCube();
        RubiksCube startConfig = new RubiksCube();
        int rotationPosition = 0;
        bool custom;
        string sequence = "";
        UInt64 cycleColour = 1;
        HashTable cornerPermutationStore = new HashTable(500);
        bool firstTick = true;
        string solutionTime = "";

        public RubiksCubeUI()
        {
            InitializeComponent();
        }

        //As the user interface is loaded, the hash table of corner permutations for stage 3 is generated.
        private void RubiksCubeUI_Load(object sender, EventArgs e)
        {
            Solver HashTableGeneration = new Solver(ref cube, 0);
            cornerPermutationStore = HashTableGeneration.CornerPermutations;
            Console.WriteLine("Generated HashTable");
            cube = new RubiksCube();
            Stopwatch sw = new Stopwatch();
        }

        //This draws the black lines between squares on each face
        private void Lines(ref PaintEventArgs e)
        {
            int size = 90;
            e.Graphics.DrawLine(new Pen(Color.Black, 3), size / 3, 0, size / 3, size);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), (size / 3) * 2, 0, (size / 3) * 2, size);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 0, size / 3, size, size / 3);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), 0, (size / 3) * 2, size, (size / 3) * 2);
        }

        //Each panel on the User interface corrseponding to the sides of the cube is drawn using DrawFace
        private void White_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.White, 1, ref e, false);
        }

        private void Orange_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.DarkOrange, 5, ref e, false);
        }

        private void Yellow_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.Yellow, 6, ref e, false);
        }

        private void Red_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.Red, 3, ref e, true);
        }

        private void Blue_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.Blue, 2, ref e, false);
        }

        private void Green_Paint(object sender, PaintEventArgs e)
        {
            DrawFace(Color.LimeGreen, 4, ref e, false); 
        }

        //Controls how each face of the cube is drawn on the two dimensional representation.
        private void DrawFace(Color colour, int colourNum, ref PaintEventArgs e, bool red)
        {
            const int size = 90;
            int x = (size / 3) / 2;
            int y = 0;
            int count = 0;
            int[] squares = { 0, 1, 2, 7, 0, 3, 6, 5, 4 };
            int[] redSquares = { 2, 1, 0, 3, 0, 7, 4, 5, 6 };
            if (red) { squares = redSquares; }
            for (int a = 0; a < 3; a++)
            {
                e.Graphics.DrawLine(new Pen(Colour(cube, colourNum, squares[count++]), size / 3), x, y, x, y + (size / 3));
                if (a == 1) { e.Graphics.DrawLine(new Pen(colour, size / 3), x + (size / 3), y, (x + size / 3), y + (size / 3)); count++; }
                else { e.Graphics.DrawLine(new Pen(Colour(cube, colourNum, squares[count++]), size / 3), x + (size / 3), y, (x + size / 3), y + (size / 3)); }
                e.Graphics.DrawLine(new Pen(Colour(cube, colourNum, squares[count++]), size / 3), x + ((size / 3) * 2), y, x + ((size / 3) * 2), y + (size / 3));
                y += (size / 3);
            }
            Lines(ref e);
        }

        //This function returns the draw colour of a particular square by extracting it from the cube 
        private Color Colour(RubiksCube cube, int face, int square)
        {
            UInt64 colour;
            UInt64 bitmask = 255;
            for (int y = 0; y < square; y++)
            {
                bitmask <<= 8;
            }
            colour = (cube.Sides[face - 1] & (bitmask)) >> square * 8;
            switch(colour)
            {
                case 1:
                    return Color.White;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Red;
                case 4:
                    return Color.LimeGreen;
                case 5:
                    return Color.DarkOrange;
                case 6:
                    return Color.Yellow;
            }
            return Color.Black;
        }

        //These functions execute rotations of the cube when the corresponding buttons are clicked
        private void R_Click(object sender, EventArgs e)
        {
            cube.R();
            ReDraw();
        }

        private void L_Click(object sender, EventArgs e)
        {
            cube.L();
            ReDraw();
        }

        private void U_Click(object sender, EventArgs e)
        {
            cube.U();
            ReDraw();
        }

        private void D_Click(object sender, EventArgs e)
        {
            cube.D();
            ReDraw();
        }

        private void F_Click(object sender, EventArgs e)
        {
            cube.F();
            ReDraw();
        }

        private void B_Click(object sender, EventArgs e)
        {
            cube.B();
            ReDraw();
        }

        //All panels are invalidated to refresh/redraw the cube so the display is updated
        private void ReDraw()
        {
            White.Invalidate();
            Orange.Invalidate();
            Yellow.Invalidate();
            Red.Invalidate();
            Blue.Invalidate();
            Green.Invalidate();
            Cube3D.Invalidate();
        }
        
        //The cube is reset to the solved state by calling the constructor when the reset button is clicked
        private void Reset_Click(object sender, EventArgs e)
        {
            cube = new RubiksCube();
            ReDraw();
        }

        //Takes the co-ordinates of the cursor and returns the square that was clicked 
        private int GetSquare(int x, int y, int face)
        {
            int[] squares = { 0, 1, 2, 7, 0, 3, 6, 5, 4 };
            int[] redSquares = { 2, 1, 0, 3, 0, 7, 4, 5, 6 };
            const int size = 90;
            int count = 0;
            for (int ysize = (size/3); ysize < size + 1; ysize += (size / 3))
            {
                for (int xsize = (size / 3); xsize < size + 1; xsize += (size / 3))
                {
                    if(x < xsize && x > xsize - (size/3) && y < ysize && y > ysize - (size / 3))
                    {
                        if (count != 4)
                        {
                            if (face == 3) { return redSquares[count]; }
                            else { return squares[count]; }
                        }
                    }
                    count++;
                }
            }
            return 0;
        }

        //The colours chosen by the user when manually inserting are placed into the cube object using this function
        private void ManualInsertion(int face, int square, UInt64 colour)
        {
            UInt64 bitmask = 18446744073709551360;
            for (int x = 0; x < square; x++)
            {
                bitmask = bitmask << 8 | bitmask >> 56;
                colour <<= 8;
            }
            cube.Sides[face] = (cube.Sides[face] & bitmask) + colour;
        }

        //Controls execution of a custom solution when requested on UI
        private void CustomSolve(ref BackgroundWorker worker, ref DoWorkEventArgs e)
        {
            if (cube.isValid())
            {
                rotate.Clear();
                Stopwatch sw = new Stopwatch();
                RubiksCube cubeCopy = new RubiksCube();
                for (int x = 0; x < 6; x++)
                {
                    cubeCopy.Sides[x] = cube.Sides[x];
                }
                for (int x = 0; x < 6; x++)
                {
                    cube.Sides[x] = startConfig.Sides[x];
                }
                sw.Start();
                Solver custom = new Solver(ref cube, cubeCopy, (int)Depth.Value);
                sw.Stop();
                solutionTime = sw.Elapsed.ToString();
                sequence = custom.SolutionString;
                rotate = custom.Solution;
                for (int x = 0; x < 6; x++)
                {
                    cube.Sides[x] = startConfig.Sides[x];
                }
                worker.ReportProgress(100);
                ReDraw();
                e.Result = "";
                if(rotate.Count == 0)
                {
                    e.Result = "Custom solution could not be found within " + Depth.Value + " rotation(s)";
                }
            }
            else { e.Cancel = true; backgroundWorker.CancelAsync(); }
        }

        //Controls execution of traditional solution searching
        private void SolveCube(ref BackgroundWorker worker, ref DoWorkEventArgs e)
        {
            sequence = "";
            if (cube.isValid())
            {
                rotate.Clear();
                for (int x = 0; x < 6; x++)
                {
                    startConfig.Sides[x] = cube.Sides[x];
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for(int stage = 1; stage < 5; stage++)
                {
                    Solver solveStage;
                    if(stage == 3) 
                    { 
                        solveStage = new Solver(ref cube, cornerPermutationStore); 
                    }
                    else 
                    { 
                        solveStage = new Solver(ref cube, stage); 
                    }
                    Console.WriteLine("STAGE" + stage + ": " + sw.Elapsed.ToString());
                    sequence += solveStage.SolutionString;
                    rotate.AddRange(solveStage.Solution);
                    worker.ReportProgress(stage * 25);
                    e.Result = "";
                }
                ReDraw();
                solutionTime = sw.Elapsed.ToString();
                sw.Stop();
            }
            else { e.Cancel = true; backgroundWorker.CancelAsync(); }
        }

        //This paints the sides of the cube for the axonometric projection
        private void PaintSides(ref PaintEventArgs e, int x, RubiksCube cube, int count, int count1, int count2)
        {
            Point[] points = { new Point(120, 186 + x), new Point(120, 236 + x), new Point(168, 285 + x), new Point(168, 235 + x) };
            e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 5, count)), points);
            Point[] points1 = { new Point(172, 239 + x), new Point(172, 289 + x), new Point(220, 338 + x), new Point(220, 288 + x) };
            if (x == 53) { e.Graphics.FillPolygon(new SolidBrush(Color.DarkOrange), points1); }
            else { e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 5, count1)), points1); }
            Point[] points2 = { new Point(224, 292 + x), new Point(224, 342 + x), new Point(274, 391 + x), new Point(274, 341 + x) };
            e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 5, count2)), points2);
            Point[] points3 = { new Point(277, 340 + x), new Point(277, 390 + x), new Point(327, 341 + x), new Point(327, 291 + x) };
            e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 4, count)), points3);
            Point[] points4 = { new Point(332, 335 + x), new Point(332, 285 + x), new Point(382, 236 + x), new Point(382, 286 + x) };
            if (x == 53) { e.Graphics.FillPolygon(new SolidBrush(Color.LimeGreen), points4); }
            else { e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 4, count1)), points4); }
            Point[] points5 = { new Point(387, 282 + x), new Point(387, 232 + x), new Point(433, 186 + x), new Point(433, 235 + x) };
            e.Graphics.FillPolygon(new SolidBrush(Colour(cube, 4, count2)), points5);
        }

        //The cube colour is changed cyclically when clicked through incrementing
        private void ChangeCubeColour(int colour, ref MouseEventArgs e, int face)
        {
            ManualInsertion(colour, GetSquare(e.X, e.Y, face), cycleColour);
            cycleColour = (cycleColour + 1) % 7;
            if (cycleColour == 0) { cycleColour++; }
            ReDraw();
        }

        //These event handlers execute the colour change of the cube when a face is clicked
        private void White_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(0, ref e, 1);
        }

        private void Orange_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(4, ref e, 5);
        }

        private void Yellow_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(5, ref e, 6);
        }

        private void Red_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(2, ref e, 3);
        }

        private void Green_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(3, ref e, 4);
        }

        private void Blue_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCubeColour(1, ref e, 2);
        }

        //When requesting the solution to be solved, this executes the solution movements on the cube
        private void ShowSolution_Click(object sender, EventArgs e)
        {
            if(rotate.Count != 0)
            {
                for (int x = 0; x < 6; x++)
                {
                    cube.Sides[x] = startConfig.Sides[x];
                }
                ReDraw();
                firstTick = true;
                rotateCubeTimer.Enabled = true;
            }
        }

        //Executes a random scramble when the scramble button is clicked.
        private void Scramble_Click(object sender, EventArgs e)
        {
            new RotationStore(ref cube).Scramble();
            ReDraw();
        }

        //Saves the cube that was entered and resets the interface so the solution can be input
        private void CustomB_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 6; x++)
            {
                startConfig.Sides[x] = cube.Sides[x];
            }
            cube = new RubiksCube();
            custom = true;
            ReDraw();
        }

        //Disables all interactable buttons and starts finding a solution when solve is clicked
        private void SolveB_Click(object sender, EventArgs e)
        {
            L.Enabled = false; R.Enabled = false;
            U.Enabled = false; D.Enabled = false;
            F.Enabled = false; B.Enabled = false;
            SolveB.Enabled = false; CustomB.Enabled = false;
            Scramble.Enabled = false; Reset.Enabled = false;
            ShowSolution.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            solutionText.Text = sequence;
        }

        //Draws the 3D representation of the cube on the user interface
        private void Cube3D_Paint(object sender, PaintEventArgs e)
        {
            int startx = 250;
            int starty = 50;
            const int size = 70;
            int count = 0;
            int[] squares = { 0, 1, 2, 7, 3, 6, 5, 4 };
            for(int x = 0; x < 3; x++)
            {
                e.Graphics.DrawLine(new Pen(Colour(cube, 1, squares[count++]), size), startx, starty, startx + 50, starty + 50);
                if(x == 1) { e.Graphics.DrawLine(new Pen(Color.White, size), startx + 53, starty + 53, startx + 103, starty + 103); }
                else { e.Graphics.DrawLine(new Pen(Colour(cube, 1, squares[count++]), size), startx + 53, starty + 53, startx + 103, starty + 103); }
                e.Graphics.DrawLine(new Pen(Colour(cube, 1, squares[count++]), size), startx + 106, starty + 106, startx + 156, starty + 156);
                startx -= 53; starty += 53;
            }
            PaintSides(ref e, 0, cube, 0, 1, 2);
            PaintSides(ref e, 53, cube, 7, 0, 3);
            PaintSides(ref e, 106, cube, 6, 5, 4);
        }

        //Timer that controls the periodic movements of rotations and its speed when the solution is shown
        private void rotateCubeTimer_Tick(object sender, EventArgs e)
        {
            if (!firstTick)
            {
                rotateCubeTimer.Interval = 2000 / Convert.ToInt32(Speed.Value);
                rotate[rotationPosition]();
                solutionRotation.Text = sequence.Split(' ')[rotationPosition];
                ReDraw();
                rotationPosition++;
                if (rotationPosition == rotate.Count)
                {
                    rotateCubeTimer.Enabled = false; rotationPosition = 0;
                }
            }
            firstTick = false;
        }

        //Background worker executes the solution search on a different thread so the UI does not freeze
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (custom)
            {
                CustomSolve(ref worker, ref e);
                custom = false;
            }
            else
            {
                SolveCube(ref worker, ref e);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                solutionText.Text = ""; 
                invalidCube.Text = "The cube entered is not valid";
            }
            else
            {
                invalidCube.Text = e.Result.ToString();
                solutionText.Text = sequence;
                Console.WriteLine(sequence);
                timeTaken.Text = solutionTime;
            }
            L.Enabled = true; R.Enabled = true;
            U.Enabled = true; D.Enabled = true;
            F.Enabled = true; B.Enabled = true;
            SolveB.Enabled = true; CustomB.Enabled = true;
            Scramble.Enabled = true; Reset.Enabled = true;
            ShowSolution.Enabled = true;
        }
    }
}
