namespace BouncingGame
{
    partial class BouncingBallsForm
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
            this.exitGameButton = new System.Windows.Forms.Button();
            this.addBallButton = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // exitGameButton
            // 
            this.exitGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.exitGameButton.Location = new System.Drawing.Point(654, 406);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(118, 43);
            this.exitGameButton.TabIndex = 0;
            this.exitGameButton.Text = "Exit Game";
            this.exitGameButton.UseVisualStyleBackColor = true;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // addBallButton
            // 
            this.addBallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addBallButton.Location = new System.Drawing.Point(12, 406);
            this.addBallButton.Name = "addBallButton";
            this.addBallButton.Size = new System.Drawing.Size(116, 43);
            this.addBallButton.TabIndex = 1;
            this.addBallButton.Text = "Add a Ball !";
            this.addBallButton.UseVisualStyleBackColor = true;
            this.addBallButton.Click += new System.EventHandler(this.addBallButton_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            // 
            // BouncingBallsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.addBallButton);
            this.Controls.Add(this.exitGameButton);
            this.Name = "BouncingBallsForm";
            this.Text = "BouncingBallsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitGameButton;
        private System.Windows.Forms.Button addBallButton;
        private System.ComponentModel.BackgroundWorker worker;
    }
}