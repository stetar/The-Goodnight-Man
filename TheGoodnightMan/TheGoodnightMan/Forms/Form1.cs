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
        private bool hasPressedEsc;
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
            hasPressedEsc = false;
        }
        
    private void timer1_Tick(object sender, EventArgs e)
        {
            gw.GameLoop();
        
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
