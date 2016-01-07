namespace GameLoopOne.Forms
{
    partial class MainMenuForm
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.HowToPlayButton = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.GetInsulted = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GoToBuyMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlayButton.Location = new System.Drawing.Point(201, 74);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(133, 35);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Get to the action!";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // HowToPlayButton
            // 
            this.HowToPlayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HowToPlayButton.Location = new System.Drawing.Point(201, 130);
            this.HowToPlayButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HowToPlayButton.Name = "HowToPlayButton";
            this.HowToPlayButton.Size = new System.Drawing.Size(133, 35);
            this.HowToPlayButton.TabIndex = 1;
            this.HowToPlayButton.Text = "Instructions?! Hell no!";
            this.HowToPlayButton.UseVisualStyleBackColor = true;
            this.HowToPlayButton.Click += new System.EventHandler(this.HowToPlayButton_Click);
            // 
            // Quit
            // 
            this.Quit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Quit.Location = new System.Drawing.Point(201, 297);
            this.Quit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(133, 35);
            this.Quit.TabIndex = 4;
            this.Quit.Text = "Pussy out";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // GetInsulted
            // 
            this.GetInsulted.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GetInsulted.Location = new System.Drawing.Point(201, 236);
            this.GetInsulted.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GetInsulted.Name = "GetInsulted";
            this.GetInsulted.Size = new System.Drawing.Size(133, 35);
            this.GetInsulted.TabIndex = 3;
            this.GetInsulted.Text = "Get insulted";
            this.GetInsulted.UseVisualStyleBackColor = true;
            this.GetInsulted.Click += new System.EventHandler(this.GetInsulted_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // GoToBuyMenu
            // 
            this.GoToBuyMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GoToBuyMenu.Location = new System.Drawing.Point(201, 183);
            this.GoToBuyMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GoToBuyMenu.Name = "GoToBuyMenu";
            this.GoToBuyMenu.Size = new System.Drawing.Size(133, 35);
            this.GoToBuyMenu.TabIndex = 2;
            this.GoToBuyMenu.Text = "Buy Menu";
            this.GoToBuyMenu.UseVisualStyleBackColor = true;
            this.GoToBuyMenu.Click += new System.EventHandler(this.GoToBuyMenu_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 381);
            this.Controls.Add(this.GoToBuyMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetInsulted);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.HowToPlayButton);
            this.Controls.Add(this.PlayButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button HowToPlayButton;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button GetInsulted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoToBuyMenu;
    }
}