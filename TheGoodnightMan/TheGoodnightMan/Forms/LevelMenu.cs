using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne.Forms
{
    public partial class LevelMenu : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LevelMenu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
            Level1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            Level1.TabStop = false; //removes focus;


        }


        /// <summary>
        /// Loads a level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Level2_Click(object sender, EventArgs e)
        {
            GameWorld.LoadGameState();
            GameWorld.eng.StopAllSounds();
            Form1 game = new Form1();
            game.Show();
            this.Hide();
        }
        /// <summary>
        /// Exits the game
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            Application.Exit();
            base.OnFormClosing(e);

        }
        /// <summary>
        /// Goes back to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenuForm.showWarning = false;
            ActiveForm.Dispose();
            new MainMenuForm().Show();
        }
    }
}
