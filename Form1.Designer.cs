namespace Rubik_s_Cube
{
    partial class RubiksCubeUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.White = new System.Windows.Forms.Panel();
            this.Orange = new System.Windows.Forms.Panel();
            this.Yellow = new System.Windows.Forms.Panel();
            this.Red = new System.Windows.Forms.Panel();
            this.Green = new System.Windows.Forms.Panel();
            this.Blue = new System.Windows.Forms.Panel();
            this.R = new System.Windows.Forms.Button();
            this.L = new System.Windows.Forms.Button();
            this.U = new System.Windows.Forms.Button();
            this.D = new System.Windows.Forms.Button();
            this.F = new System.Windows.Forms.Button();
            this.B = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.solutionText = new System.Windows.Forms.Label();
            this.SolveB = new System.Windows.Forms.Button();
            this.timeTaken = new System.Windows.Forms.Label();
            this.invalidCube = new System.Windows.Forms.Label();
            this.CustomB = new System.Windows.Forms.Button();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.ShowSolution = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.rotateCubeTimer = new System.Windows.Forms.Timer(this.components);
            this.Cube3D = new System.Windows.Forms.Panel();
            this.Scramble = new System.Windows.Forms.Button();
            this.solutionRotation = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.Depth = new System.Windows.Forms.NumericUpDown();
            this.depthLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth)).BeginInit();
            this.SuspendLayout();
            // 
            // White
            // 
            this.White.Location = new System.Drawing.Point(106, 193);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(90, 90);
            this.White.TabIndex = 0;
            this.White.Paint += new System.Windows.Forms.PaintEventHandler(this.White_Paint);
            this.White.MouseClick += new System.Windows.Forms.MouseEventHandler(this.White_MouseClick);
            // 
            // Orange
            // 
            this.Orange.Location = new System.Drawing.Point(106, 289);
            this.Orange.Name = "Orange";
            this.Orange.Size = new System.Drawing.Size(90, 90);
            this.Orange.TabIndex = 1;
            this.Orange.Paint += new System.Windows.Forms.PaintEventHandler(this.Orange_Paint);
            this.Orange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Orange_MouseClick);
            // 
            // Yellow
            // 
            this.Yellow.Location = new System.Drawing.Point(106, 385);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(90, 90);
            this.Yellow.TabIndex = 2;
            this.Yellow.Paint += new System.Windows.Forms.PaintEventHandler(this.Yellow_Paint);
            this.Yellow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Yellow_MouseClick);
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(106, 481);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(90, 90);
            this.Red.TabIndex = 3;
            this.Red.Paint += new System.Windows.Forms.PaintEventHandler(this.Red_Paint);
            this.Red.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Red_MouseClick);
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(202, 289);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(90, 90);
            this.Green.TabIndex = 4;
            this.Green.Paint += new System.Windows.Forms.PaintEventHandler(this.Green_Paint);
            this.Green.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Green_MouseClick);
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(10, 289);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(90, 90);
            this.Blue.TabIndex = 5;
            this.Blue.Paint += new System.Windows.Forms.PaintEventHandler(this.Blue_Paint);
            this.Blue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Blue_MouseClick);
            // 
            // R
            // 
            this.R.BackColor = System.Drawing.Color.White;
            this.R.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.R.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.R.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.R.Location = new System.Drawing.Point(573, 4);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(75, 23);
            this.R.TabIndex = 7;
            this.R.Text = "R";
            this.R.UseVisualStyleBackColor = false;
            this.R.Click += new System.EventHandler(this.R_Click);
            // 
            // L
            // 
            this.L.BackColor = System.Drawing.Color.White;
            this.L.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.L.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L.ForeColor = System.Drawing.SystemColors.ControlText;
            this.L.Location = new System.Drawing.Point(487, 4);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(75, 23);
            this.L.TabIndex = 8;
            this.L.Text = "L";
            this.L.UseVisualStyleBackColor = false;
            this.L.Click += new System.EventHandler(this.L_Click);
            // 
            // U
            // 
            this.U.BackColor = System.Drawing.Color.White;
            this.U.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.U.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U.Location = new System.Drawing.Point(487, 33);
            this.U.Name = "U";
            this.U.Size = new System.Drawing.Size(75, 23);
            this.U.TabIndex = 9;
            this.U.Text = "U";
            this.U.UseVisualStyleBackColor = false;
            this.U.Click += new System.EventHandler(this.U_Click);
            // 
            // D
            // 
            this.D.BackColor = System.Drawing.Color.White;
            this.D.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.D.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(573, 33);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(75, 23);
            this.D.TabIndex = 10;
            this.D.Text = "D";
            this.D.UseVisualStyleBackColor = false;
            this.D.Click += new System.EventHandler(this.D_Click);
            // 
            // F
            // 
            this.F.BackColor = System.Drawing.Color.White;
            this.F.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.F.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.F.Location = new System.Drawing.Point(487, 62);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(75, 23);
            this.F.TabIndex = 11;
            this.F.Text = "F";
            this.F.UseVisualStyleBackColor = false;
            this.F.Click += new System.EventHandler(this.F_Click);
            // 
            // B
            // 
            this.B.BackColor = System.Drawing.Color.White;
            this.B.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B.Location = new System.Drawing.Point(573, 62);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(75, 23);
            this.B.TabIndex = 12;
            this.B.Text = "B";
            this.B.UseVisualStyleBackColor = false;
            this.B.Click += new System.EventHandler(this.B_Click);
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.Color.White;
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reset.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Location = new System.Drawing.Point(733, 81);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 13;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // solutionText
            // 
            this.solutionText.AutoSize = true;
            this.solutionText.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionText.ForeColor = System.Drawing.SystemColors.Control;
            this.solutionText.Location = new System.Drawing.Point(8, 8);
            this.solutionText.Name = "solutionText";
            this.solutionText.Size = new System.Drawing.Size(0, 13);
            this.solutionText.TabIndex = 14;
            // 
            // SolveB
            // 
            this.SolveB.BackColor = System.Drawing.Color.White;
            this.SolveB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SolveB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolveB.Location = new System.Drawing.Point(652, 23);
            this.SolveB.Name = "SolveB";
            this.SolveB.Size = new System.Drawing.Size(75, 23);
            this.SolveB.TabIndex = 15;
            this.SolveB.Text = "Solve";
            this.SolveB.UseVisualStyleBackColor = false;
            this.SolveB.Click += new System.EventHandler(this.SolveB_Click);
            // 
            // timeTaken
            // 
            this.timeTaken.AutoSize = true;
            this.timeTaken.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTaken.ForeColor = System.Drawing.SystemColors.Control;
            this.timeTaken.Location = new System.Drawing.Point(8, 23);
            this.timeTaken.Name = "timeTaken";
            this.timeTaken.Size = new System.Drawing.Size(0, 13);
            this.timeTaken.TabIndex = 16;
            // 
            // invalidCube
            // 
            this.invalidCube.AutoSize = true;
            this.invalidCube.BackColor = System.Drawing.Color.Transparent;
            this.invalidCube.Font = new System.Drawing.Font("Bahnschrift SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidCube.ForeColor = System.Drawing.SystemColors.Control;
            this.invalidCube.Location = new System.Drawing.Point(8, 9);
            this.invalidCube.Name = "invalidCube";
            this.invalidCube.Size = new System.Drawing.Size(0, 13);
            this.invalidCube.TabIndex = 17;
            // 
            // CustomB
            // 
            this.CustomB.BackColor = System.Drawing.Color.White;
            this.CustomB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomB.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomB.Location = new System.Drawing.Point(733, 23);
            this.CustomB.Name = "CustomB";
            this.CustomB.Size = new System.Drawing.Size(75, 23);
            this.CustomB.TabIndex = 18;
            this.CustomB.Text = "Custom";
            this.CustomB.UseVisualStyleBackColor = false;
            this.CustomB.Click += new System.EventHandler(this.CustomB_Click);
            // 
            // Speed
            // 
            this.Speed.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speed.Location = new System.Drawing.Point(614, 88);
            this.Speed.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(34, 20);
            this.Speed.TabIndex = 19;
            this.Speed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShowSolution
            // 
            this.ShowSolution.BackColor = System.Drawing.Color.White;
            this.ShowSolution.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowSolution.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowSolution.Location = new System.Drawing.Point(652, 52);
            this.ShowSolution.Name = "ShowSolution";
            this.ShowSolution.Size = new System.Drawing.Size(156, 23);
            this.ShowSolution.TabIndex = 20;
            this.ShowSolution.Text = "Show Solution";
            this.ShowSolution.UseVisualStyleBackColor = false;
            this.ShowSolution.Click += new System.EventHandler(this.ShowSolution_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.speedLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedLabel.Location = new System.Drawing.Point(568, 91);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(45, 14);
            this.speedLabel.TabIndex = 21;
            this.speedLabel.Text = "Speed:";
            // 
            // rotateCubeTimer
            // 
            this.rotateCubeTimer.Interval = 125;
            this.rotateCubeTimer.Tick += new System.EventHandler(this.rotateCubeTimer_Tick);
            // 
            // Cube3D
            // 
            this.Cube3D.BackColor = System.Drawing.Color.Black;
            this.Cube3D.Location = new System.Drawing.Point(317, 118);
            this.Cube3D.Name = "Cube3D";
            this.Cube3D.Size = new System.Drawing.Size(491, 519);
            this.Cube3D.TabIndex = 22;
            this.Cube3D.Paint += new System.Windows.Forms.PaintEventHandler(this.Cube3D_Paint);
            // 
            // Scramble
            // 
            this.Scramble.BackColor = System.Drawing.Color.White;
            this.Scramble.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Scramble.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scramble.Location = new System.Drawing.Point(652, 81);
            this.Scramble.Name = "Scramble";
            this.Scramble.Size = new System.Drawing.Size(75, 23);
            this.Scramble.TabIndex = 23;
            this.Scramble.Text = "Scramble";
            this.Scramble.UseVisualStyleBackColor = false;
            this.Scramble.Click += new System.EventHandler(this.Scramble_Click);
            // 
            // solutionRotation
            // 
            this.solutionRotation.AutoSize = true;
            this.solutionRotation.BackColor = System.Drawing.Color.Transparent;
            this.solutionRotation.Font = new System.Drawing.Font("Bahnschrift SemiBold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solutionRotation.ForeColor = System.Drawing.SystemColors.Control;
            this.solutionRotation.Location = new System.Drawing.Point(3, 36);
            this.solutionRotation.Name = "solutionRotation";
            this.solutionRotation.Size = new System.Drawing.Size(0, 45);
            this.solutionRotation.TabIndex = 24;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.progressBar.Location = new System.Drawing.Point(652, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(156, 10);
            this.progressBar.Step = 25;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 26;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Depth
            // 
            this.Depth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Depth.Location = new System.Drawing.Point(531, 88);
            this.Depth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Depth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Depth.Name = "Depth";
            this.Depth.Size = new System.Drawing.Size(34, 20);
            this.Depth.TabIndex = 27;
            this.Depth.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.depthLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depthLabel.Location = new System.Drawing.Point(488, 91);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(42, 14);
            this.depthLabel.TabIndex = 28;
            this.depthLabel.Text = "Depth:";
            // 
            // RubiksCubeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(820, 635);
            this.Controls.Add(this.depthLabel);
            this.Controls.Add(this.Depth);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.solutionRotation);
            this.Controls.Add(this.Scramble);
            this.Controls.Add(this.Cube3D);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.ShowSolution);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.CustomB);
            this.Controls.Add(this.invalidCube);
            this.Controls.Add(this.timeTaken);
            this.Controls.Add(this.SolveB);
            this.Controls.Add(this.solutionText);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.B);
            this.Controls.Add(this.F);
            this.Controls.Add(this.D);
            this.Controls.Add(this.U);
            this.Controls.Add(this.L);
            this.Controls.Add(this.R);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Orange);
            this.Controls.Add(this.White);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "RubiksCubeUI";
            this.Text = "Rubiks Cube";
            this.Load += new System.EventHandler(this.RubiksCubeUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Depth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel White;
        private System.Windows.Forms.Panel Orange;
        private System.Windows.Forms.Panel Yellow;
        private System.Windows.Forms.Panel Red;
        private System.Windows.Forms.Panel Green;
        private System.Windows.Forms.Panel Blue;
        private System.Windows.Forms.Button R;
        private System.Windows.Forms.Button L;
        private System.Windows.Forms.Button U;
        private System.Windows.Forms.Button D;
        private System.Windows.Forms.Button F;
        private System.Windows.Forms.Button B;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label solutionText;
        private System.Windows.Forms.Button SolveB;
        private System.Windows.Forms.Label timeTaken;
        private System.Windows.Forms.Label invalidCube;
        private System.Windows.Forms.Button CustomB;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Button ShowSolution;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Timer rotateCubeTimer;
        private System.Windows.Forms.Panel Cube3D;
        private System.Windows.Forms.Button Scramble;
        private System.Windows.Forms.Label solutionRotation;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.NumericUpDown Depth;
        private System.Windows.Forms.Label depthLabel;
    }
}

