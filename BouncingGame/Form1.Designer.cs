namespace BouncingGame
{
    partial class Form1
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
            System.Windows.Forms.PictureBox ballPicture;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.ballsButton = new System.Windows.Forms.Button();
            this.beetlesButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ballPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(ballPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ballPicture
            // 
            ballPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ballPicture.BackgroundImage")));
            ballPicture.Image = global::BouncingGame.Properties.Resources.Ball_PNG;
            ballPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("ballPicture.InitialImage")));
            ballPicture.Location = new System.Drawing.Point(126, 129);
            ballPicture.Name = "ballPicture";
            ballPicture.Size = new System.Drawing.Size(50, 50);
            ballPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ballPicture.TabIndex = 3;
            ballPicture.TabStop = false;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Monotype Hadassah", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.welcomeLabel.Location = new System.Drawing.Point(30, 35);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(440, 37);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to the Bouncing Game!";
            // 
            // ballsButton
            // 
            this.ballsButton.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ballsButton.Location = new System.Drawing.Point(192, 129);
            this.ballsButton.Name = "ballsButton";
            this.ballsButton.Size = new System.Drawing.Size(143, 52);
            this.ballsButton.TabIndex = 1;
            this.ballsButton.Text = "Bouncing Balls";
            this.ballsButton.UseVisualStyleBackColor = true;
            this.ballsButton.Click += new System.EventHandler(this.ballsButton_Click);
            // 
            // beetlesButton
            // 
            this.beetlesButton.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beetlesButton.Location = new System.Drawing.Point(175, 194);
            this.beetlesButton.Name = "beetlesButton";
            this.beetlesButton.Size = new System.Drawing.Size(176, 52);
            this.beetlesButton.TabIndex = 2;
            this.beetlesButton.Text = "Bouncing Beetles";
            this.beetlesButton.UseVisualStyleBackColor = true;
            this.beetlesButton.Click += new System.EventHandler(this.beetlesButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BouncingGame.Properties.Resources.Beetle_PNG;
            this.pictureBox1.Location = new System.Drawing.Point(100, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 321);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(ballPicture);
            this.Controls.Add(this.beetlesButton);
            this.Controls.Add(this.ballsButton);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(ballPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button ballsButton;
        private System.Windows.Forms.Button beetlesButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

