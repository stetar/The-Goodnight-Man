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
using GameLoopOne.Forms;

namespace GameLoopOne
{
    public partial class Form1 : Form
    {
        public static Graphics dc;
        GameWorld gw;

        /// <summary>
        /// Initalizes the main game and sets the max and min resolution
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
            MainMenuForm.showWarning = false;
        }
        
    private void timer1_Tick(object sender, EventArgs e)
        {
            gw.GameLoop();
            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                GameWorld.SaveGameState();
                MainMenuForm.showWarning = false;
                timer1.Stop();
                DialogResult dialogResult = MessageBox.Show("What?! Are you pussying out?? Are you fukcing leaving?! Don't you dare be gone for long, you hear me?", "Pause menu (sucker!)", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GameWorld.objects.Clear();
                    GameWorld.GameWeapons.Clear();
                    GameWorld.removeList.Clear();
                    ActiveForm.Dispose();
                    new MainMenuForm().Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MainMenuForm.showWarning = true;
                    timer1.Start();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(dc == null)
                dc = CreateGraphics();

            gw = new GameWorld(CreateGraphics(), this.DisplayRectangle);
            this.Controls.Add(SpeechBubble.insultText);
            SpeechBubble.insultText.Hide();



        }
        /// <summary>
        /// Handles the close function of the form and exits the application on input.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
          
            Application.Exit();
            GameWorld.SaveGameState();
            base.OnFormClosing(e);

        }
    }
}
