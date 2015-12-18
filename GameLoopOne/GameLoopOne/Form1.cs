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

namespace GameLoopOne
{
    public partial class Form1 : Form
    {
        Graphics dc;
        GameWorld gw;
        
        /// <summary>
        /// Initalizes the main game and sets the max and min resolution
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            //this.WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            //this.AutoSize = true;

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





        }
        /// <summary>
        /// Handles the close function of the form and exits the application on input.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           // if (!GameWorld.endGame)
           // {
                Application.Exit();
            //}
            base.OnFormClosing(e);

        }
    }
}
