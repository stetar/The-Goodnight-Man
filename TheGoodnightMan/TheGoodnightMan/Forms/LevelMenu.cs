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
        public LevelMenu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
            Level1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            Label label1 = new Label();
            Level1.BackColor = Color.Transparent;
            Level1.TabStop = false; //removes focus;
            //Level2.TabStop = false; //removes focus;
            //Level3.TabStop = false; //removes focus;
            Level1.FlatAppearance.BorderSize = 0;
            Level1.FlatAppearance.BorderSize = 0;
            Level2.FlatAppearance.BorderSize = 0;
            Level3.FlatAppearance.BorderSize = 0;
            Level4.FlatAppearance.BorderSize = 0;



        }

        

        private void Level2_Click(object sender, EventArgs e)
        {
            GameWorld.LoadGameState();

            Form1 game = new Form1();
            game.Show();
            this.Hide();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            Application.Exit();
            base.OnFormClosing(e);

        }
    }
}
