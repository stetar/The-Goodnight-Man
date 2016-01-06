namespace GameLoopOne.Forms
{
    partial class LevelMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelMenu));
            this.Level1 = new System.Windows.Forms.Button();
            this.Level2 = new System.Windows.Forms.Button();
            this.Level3 = new System.Windows.Forms.Button();
            this.Level4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Level1
            // 
            this.Level1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Level1.BackColor = System.Drawing.SystemColors.Desktop;
            this.Level1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Level1.BackgroundImage")));
            this.Level1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Level1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level1.Font = new System.Drawing.Font("Impact", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1.Location = new System.Drawing.Point(136, 149);
            this.Level1.Margin = new System.Windows.Forms.Padding(0);
            this.Level1.Name = "Level1";
            this.Level1.Size = new System.Drawing.Size(164, 154);
            this.Level1.TabIndex = 1;
            this.Level1.TabStop = false;
            this.Level1.Text = " Level 1";
            this.Level1.UseVisualStyleBackColor = false;
            this.Level1.Click += new System.EventHandler(this.Level2_Click);
            // 
            // Level2
            // 
            this.Level2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Level2.BackColor = System.Drawing.SystemColors.Desktop;
            this.Level2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Level2.BackgroundImage")));
            this.Level2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Level2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level2.Font = new System.Drawing.Font("Impact", 8.142858F);
            this.Level2.Location = new System.Drawing.Point(337, 149);
            this.Level2.Margin = new System.Windows.Forms.Padding(0);
            this.Level2.Name = "Level2";
            this.Level2.Size = new System.Drawing.Size(164, 154);
            this.Level2.TabIndex = 2;
            this.Level2.TabStop = false;
            this.Level2.Text = " Level 1";
            this.Level2.UseVisualStyleBackColor = false;
            // 
            // Level3
            // 
            this.Level3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Level3.BackColor = System.Drawing.SystemColors.Desktop;
            this.Level3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Level3.BackgroundImage")));
            this.Level3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Level3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level3.Font = new System.Drawing.Font("Impact", 8.142858F);
            this.Level3.Location = new System.Drawing.Point(545, 149);
            this.Level3.Margin = new System.Windows.Forms.Padding(0);
            this.Level3.Name = "Level3";
            this.Level3.Size = new System.Drawing.Size(164, 154);
            this.Level3.TabIndex = 3;
            this.Level3.TabStop = false;
            this.Level3.Text = " Level 1";
            this.Level3.UseVisualStyleBackColor = false;
            // 
            // Level4
            // 
            this.Level4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Level4.BackColor = System.Drawing.SystemColors.Desktop;
            this.Level4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Level4.BackgroundImage")));
            this.Level4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Level4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Level4.Font = new System.Drawing.Font("Impact", 8.142858F);
            this.Level4.Location = new System.Drawing.Point(735, 149);
            this.Level4.Margin = new System.Windows.Forms.Padding(0);
            this.Level4.Name = "Level4";
            this.Level4.Size = new System.Drawing.Size(164, 154);
            this.Level4.TabIndex = 4;
            this.Level4.TabStop = false;
            this.Level4.Text = " Level 1";
            this.Level4.UseVisualStyleBackColor = false;
            // 
            // LevelMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1000, 704);
            this.Controls.Add(this.Level4);
            this.Controls.Add(this.Level3);
            this.Controls.Add(this.Level2);
            this.Controls.Add(this.Level1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "LevelMenu";
            this.Text = "LevelMenu";
            this.ResumeLayout(false);

        }

        #endregion

      
        private System.Windows.Forms.Button Level1;
        private System.Windows.Forms.Button Level2;
        private System.Windows.Forms.Button Level3;
        private System.Windows.Forms.Button Level4;
    }
}