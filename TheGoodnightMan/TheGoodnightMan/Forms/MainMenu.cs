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
    public partial class MainMenuForm : Form
    {
        public static bool showWarning = true;

        public MainMenuForm()
        {
            this.BackgroundImage = Image.FromFile("levels/mainmenubackground.png");
            InitializeComponent();
            this.MinimumSize = new Size(1024, 768);
            this.MaximumSize = new Size(1024, 768);
            this.CenterToScreen();
            WindowState = FormWindowState.Normal;
            label1.Hide();
            GameWorld.eng.Play2D("Drawing.wav", true);
            if (showWarning)
            {
                Random random = new Random();

                if (random.Next(0, 101) <= 90)
                {
                    if (MessageBox.Show("Warning! The game you are about to play contains an overall disturbing and offensive style, which includes, but is not limited to, langauge, imagery, sound and humor." + Environment.NewLine + Environment.NewLine + "Player discretion and parental guidance is advised. The game is intended for at mature audience." + Environment.NewLine + Environment.NewLine + "The opinions expressed in the game do not necessarily reflect the views of the game developers, the developing company or any other individuals connected to the development and publishing of this game." + Environment.NewLine + Environment.NewLine + "All characters and events in this game are completely fictional and have no intentions of representing any real life characters or groups." + Environment.NewLine + Environment.NewLine + "We, the developer team, hope you can tell, that this is a piece of fiction created for entertainment purpose and therefor will enjoy it as such." + Environment.NewLine + "In advance thank you.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                }
                if (random.Next(0, 101) > 90)
                {
                    if (MessageBox.Show("ALRIGHT YOU PRECIOUS LITTLE MOTHERFUCKERS," + Environment.NewLine + Environment.NewLine + "ARE YOU FUCKTARDS ASSBUTTS READY TO CLINCH FROM INTENSE GAMEPLAY, SKULLFUCKINGLY AMAZING SOUND," + Environment.NewLine + Environment.NewLine + "MESMORIZING STORY THAT MAY, OR MAY NOT BE FUCKING RACIST TO SOME, BUT NOT SPECIFICLY TARGETED TERRORISTS! (MUSLIMS)" + Environment.NewLine + Environment.NewLine + "SO BUCKLE THE FUCK UP MEIN HITLERJUGEND, CAUSE OLD PAPA GOODNIGHT MAN IS GONNA SHANK YOUR SORRY ASS, SO BAD YOUR CHILDREN ARE GONNA HAVING PROBLEMS BREATHING WITHOUT RAW OXYGEN TO THEIR SORRY, CRIPPLED LUNGS." + Environment.NewLine + Environment.NewLine + "WARNING: THIS GAME MAY NOT BE FOR HIPSTERS, NIGGAS, DWARFS AND OTHER FREAKS OF NATURE." + Environment.NewLine + Environment.NewLine + "SO IF YOU’RE A FUCKING FAGGOT, GO BACK TO YOUR CALL OF DUTY (YEP, WE JUST FUCKING WENT THERE)" + Environment.NewLine + Environment.NewLine + "CAUSE THIS GAME IS GONNA BLOW YOUR MIND UNTIL YOUR GAGGING REFLEX STOPS WORKING!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
                }
                
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
            GameWorld.eng.StopAllSounds();
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
        }

        private void GetInsulted_Click(object sender, EventArgs e)
        {
            //Maks
            Random myRandom = new Random();

            //The insults
            string[] insults =
            {
                "Fuck you!",
                "Screw you!",
                "Cunt!",
                "You cunt!",
                "Bitch!",
                "You fuck!",
                "You piece of shit!",
                "Motherfucker!",
                "Terrorist!",
                "Midget!",
                "You ugly!",
                "You are a bitch!",
                "Eat a dick!",
                "You suck!",
                "Jewish scum!",
                "Damn son, you bad!",
                "You fat fuck!",
                "You play like a girl!",
                "Nazi bitch!",
                "Transvestite fuck!",
                "ISIS loving shit!",
                "Fucking hippie!",
                "You retard!",
                "You soulless ginger\n piece of crap!",
                "Fucking muggle!",
                "You homeless\n greenlander!",
                "You alchoholic\n muslim!",
                "Fucking wanker!",
                "You faggot!",
                "You stinkin' cripple!"
            };

            //List needed to get random insult
            List<string> randomInsultList = new List<string>();
            randomInsultList.AddRange(insults);

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
            GameWorld.eng.StopAllSounds();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
        }
    }
}