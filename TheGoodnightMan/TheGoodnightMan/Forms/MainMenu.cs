﻿using System;
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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            this.BackgroundImage = Image.FromFile("levels/mainmenubackground.png");
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
            label1.Hide();
            if (MessageBox.Show("ALRIGHT YOU PRECIOUS LITTLE MOTHERFUCKERS," + Environment.NewLine + Environment.NewLine + "ARE YOU FUCKTARDS ASSBUTTS READY TO CLINCH FROM INTENSE GAMEPLAY" + Environment.NewLine + Environment.NewLine + "SKULLFUCKINGLY AMAZING SOUND," + Environment.NewLine + Environment.NewLine + "MESMORIZING STORY THAT MAY, OR MAY NOT BE FUCKING RACIST TO SOME, BUT NOT SPECIFICLY TARGETED TERRORISTS! (MUSLIMS)" + Environment.NewLine + Environment.NewLine + "SO BUCKLE THE FUCK UP MEIN HITLER JUGEN, CAUSE OLD PAPA GOODNIGHT MAN IS GONNA SHANK YOU SORRY ASS, SO BAD YOU ARE CHILDREN ARE GONNA HAVING PROBLEMS BREATHING WITHOUT RAW OXYGEN TO THEIR SORRY CRIPPLED LUNGS." + Environment.NewLine + Environment.NewLine + "WARNING: GAME MAY NOT BE FOR HIPSTERS, NIGGAS, DWARFS AND OTHER FREAKS OF NATURE." + Environment.NewLine + Environment.NewLine + "SO IF YOU’RE A FUCKING PLEP, GO BACK TO YOUR CALL OF DUTY (YEP WE JUST FUCKING WENT THERE)" + Environment.NewLine + Environment.NewLine + "CAUSE THIS GAME IS GONNA BLOW YOU MIND UNTIL YOUR GAGGING REFLEX STOPS WORKING!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
            GameWorld.LoadGameState();

            //PlayButton.BackgroundImage = Image.FromFile("mainmenubutton.png");
            //PlayButton.BackColor = Color.Transparent;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Form1 game = new Form1();
            game.Show();
            this.Hide();
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {

        }

        private void GetInsulted_Click(object sender, EventArgs e)
        {
            //Maks
            Random myRandom = new Random();

            //The insults
            string randomInsult = "Fuck you";
            string randomInsult1 = "Screw you";
            string randomInsult2 = "Cunt";
            string randomInsult3 = "Fuck1";
            string randomInsult4 = "fuck2";
            string randomInsult5 = "fuck3";
            string randomInsult6 = "fuck4";
            string randomInsult7 = "fuck5";
            string randomInsult8 = "fuck6";
            string randomInsult9 = "fuck7";
            string randomInsult10 = "fuck8";

            //List needed to get random insult
            List<string> randomInsultList = new List<string>();
            randomInsultList.Add(randomInsult);
            randomInsultList.Add(randomInsult1);
            randomInsultList.Add(randomInsult2);
            randomInsultList.Add(randomInsult3);
            randomInsultList.Add(randomInsult4);
            randomInsultList.Add(randomInsult5);
            randomInsultList.Add(randomInsult6);
            randomInsultList.Add(randomInsult7);
            randomInsultList.Add(randomInsult8);
            randomInsultList.Add(randomInsult9);
            randomInsultList.Add(randomInsult10);

            //Geting the final insult
            int randomInsultSelected = myRandom.Next(randomInsultList.Count);
            string randomInsultFinal = randomInsultList[randomInsultSelected];

            //Instance of label
            Label labelInsult = new Label();
            //Text to label
            labelInsult.Text = " " + randomInsultFinal;
            //Should add the size of label

            label1.Text = randomInsultFinal;
            label1.Show();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}