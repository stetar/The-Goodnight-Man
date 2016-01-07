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
    public partial class ShopMenu : Form
    {
        public ShopMenu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            
            WindowState = FormWindowState.Normal;
            GameWorld.LoadGameState();
            
        }

        private void CheckForWeapons()
        {
        }


        private void BuyAssaultRifle_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 10 && !GameWorld.OwnAssaultRifle)
            {
                GameWorld.iIncorrectness -= 10;
                GameWorld.OwnAssaultRifle = true;
                
            }
            else if(GameWorld.OwnAssaultRifle)
            {
                Player.weaponIndexNumber = 9;
                
            }
            else if (GameWorld.iIncorrectness < 10)
            {
                NotEnoughMoney();
            }
        }
        private void BuyRPG_Click_1(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 30 && !GameWorld.OwnRPG)
            {
                GameWorld.iIncorrectness -= 30;
                GameWorld.OwnRPG = true;
               
            }
            else if (GameWorld.OwnRPG)
            {
                Player.weaponIndexNumber = 10;

            }
            else if(GameWorld.iIncorrectness < 30)
            {
                NotEnoughMoney();
            }
        }
        private void BuyLMG_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 25 && !GameWorld.OwnLMG)
            {
                GameWorld.iIncorrectness -= 25;
                GameWorld.OwnLMG = true;

            }
            else if (GameWorld.OwnLMG)
            {
                Player.weaponIndexNumber = 12;

            }
            else if (GameWorld.iIncorrectness < 25)
            {
                NotEnoughMoney();
            }
        }
        private void BuyCricketPlayer_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 30 && !GameWorld.OwnCricketPlayer)
            {
                GameWorld.iIncorrectness -= 30;
                GameWorld.OwnCricketPlayer = true;

            }
            else if (GameWorld.OwnCricketPlayer)
            {
                Player.weaponIndexNumber = 1;

            }
            else if (GameWorld.iIncorrectness < 30)
            ;
            {
                NotEnoughMoney();
            }
        }
        private void BuyISISFlag_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 100 && !GameWorld.OwnISISFlag)
            {
                GameWorld.iIncorrectness -= 100;
                GameWorld.OwnISISFlag = true;

            }
            else if (GameWorld.OwnISISFlag)
            {
                Player.weaponIndexNumber = 8;

            }
            else if (GameWorld.iIncorrectness < 100)
            {
                NotEnoughMoney();
            }
        }
        private void BuyAxe_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 5 && !GameWorld.OwnAxe)
            {
                GameWorld.iIncorrectness -= 5;
                GameWorld.OwnAxe = true;

            }
            else if (GameWorld.OwnAxe)
            {
                Player.weaponIndexNumber = 6;

            }
            else if (GameWorld.iIncorrectness < 5)
            {
                NotEnoughMoney();
            }
        }

        private void BuyDildoSword_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 15 && !GameWorld.OwnDildoSword)
            {
                GameWorld.iIncorrectness -= 15;
                GameWorld.OwnDildoSword = true;

            }
            else if (GameWorld.OwnDildoSword)
            {
                Player.weaponIndexNumber = 5;

            }
            else if (GameWorld.iIncorrectness < 15)
            {
                NotEnoughMoney();
            }
        }

        private void BuyKatana_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 50 && !GameWorld.OwnDildoSword)
            {
                GameWorld.iIncorrectness -= 50;
                GameWorld.OwnKatana = true;

            }
            else if (GameWorld.OwnKatana)
            {
                Player.weaponIndexNumber = 4;

            }
            else if(GameWorld.iIncorrectness < 50)
            {
                NotEnoughMoney();
            }
        }

        private void BuyKnife_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 5 && !GameWorld.OwnKnife)
            {
                GameWorld.iIncorrectness -= 5;
                GameWorld.OwnKnife = true;

            }
            else if (GameWorld.OwnKnife)
            {
                Player.weaponIndexNumber = 2;

            }
            else if (GameWorld.iIncorrectness < 5)
            {
                NotEnoughMoney();
            }
        }

        private void BuyGuitar_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 15 && !GameWorld.OwnGuitar)
            {
                GameWorld.iIncorrectness -= 15;
                GameWorld.OwnGuitar = true;

            }
            else if (GameWorld.OwnGuitar)
            {
                Player.weaponIndexNumber = 3;

            }
            else if (GameWorld.iIncorrectness < 15)
            {
                NotEnoughMoney();
            }
        }

        private void BuyBeaver_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 15 && !GameWorld.OwnBeaver)
            {
                GameWorld.iIncorrectness -= 15;
                GameWorld.OwnBeaver = true;

            }
            else if (GameWorld.OwnBeaver)
            {
                Player.weaponIndexNumber = 7;

            }
            else if (GameWorld.iIncorrectness < 15)
            {
                NotEnoughMoney();
            }
        }
        private void BuyPistol_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 10 && !GameWorld.OwnPistol)
            {
                GameWorld.iIncorrectness -= 15;
                GameWorld.OwnPistol = true;

            }
            else if (GameWorld.OwnPistol)
            {
                Player.weaponIndexNumber = 13;

            }
            else if (GameWorld.iIncorrectness < 15)
            {
                NotEnoughMoney();
            }
        }

        private void BuyUZI_Click(object sender, EventArgs e)
        {
            if (GameWorld.iIncorrectness >= 10 && !GameWorld.OwnSmg)
            {
                GameWorld.iIncorrectness -= 15;
                GameWorld.OwnPistol = true;

            }
            else if (GameWorld.OwnSmg)
            {
                Player.weaponIndexNumber = 11;

            }
            else if (GameWorld.iIncorrectness < 15)
            {
                NotEnoughMoney();
            }
        }
        private void UseBat_Click(object sender, EventArgs e)
        {
            Player.weaponIndexNumber = 0;

        }
        /// <summary>
        /// Handles the message saying the player is missing money.
        /// </summary>
        private void NotEnoughMoney()
        {
            if (MessageBox.Show("Not enough Incorrectness", "Kill some more people", MessageBoxButtons.OK) == DialogResult.Yes)
            {
                
            }
        }
        
      
        private void ShopMenuTimer_Tick_1(object sender, EventArgs e)
        {
            this.IncorrectnessLabel.Text = ("Your score is " + GameWorld.iIncorrectness);
            // CheckForWeapons();
            BuyAssaultRifle.Image = Image.FromFile(GameWorld.OwnAssaultRifle ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyRPG.Image = Image.FromFile(GameWorld.OwnRPG ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyLMG.Image = Image.FromFile(GameWorld.OwnLMG ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyCricketPlayer.Image = Image.FromFile(GameWorld.OwnCricketPlayer ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyISISFlag.Image = Image.FromFile(GameWorld.OwnISISFlag ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyAxe.Image = Image.FromFile(GameWorld.OwnAxe ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyDildoSword.Image = Image.FromFile(GameWorld.OwnDildoSword ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyKatana.Image = Image.FromFile(GameWorld.OwnKatana ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyKnife.Image = Image.FromFile(GameWorld.OwnKnife ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyGuitar.Image = Image.FromFile(GameWorld.OwnGuitar ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyBeaver.Image = Image.FromFile(GameWorld.OwnBeaver ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyPistol.Image = Image.FromFile(GameWorld.OwnPistol ? "Forms/usebutton.png" : "Forms/buy.png");
            BuyUZI.Image = Image.FromFile(GameWorld.OwnSmg ? "Forms/usebutton.png" : "Forms/buy.png");





        }

        protected override void OnClosing(CancelEventArgs e)
        {
            GameWorld.SaveGameState();
            base.OnClosing(e);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GameWorld.SaveGameState();

            //MainMenuForm mainMenuForm = new MainMenuForm();
            MainMenuForm.showWarning = false;
            ActiveForm.Dispose();

            new MainMenuForm().Show();

            //this.Hide();
        }
    }
}
