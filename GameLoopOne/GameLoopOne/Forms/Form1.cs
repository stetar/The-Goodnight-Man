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
            if (Keyboard.IsKeyDown(Keys.Escape) && !hasPressedEsc)
            {
                hasPressedEsc = true;
                if (MessageBox.Show("Do you want to return to the menu", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GameWorld.endGame = true;
                    MainMenuForm menu = new MainMenuForm();
                    menu.Show();
                    hasPressedEsc = false;

                }
                else
                {
                    hasPressedEsc = false;
                }

            }


            if (GameWorld.endGame)
            {
                this.Close();

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
           // if (!GameWorld.endGame)
           // {
                Application.Exit();
            //}
            base.OnFormClosing(e);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
