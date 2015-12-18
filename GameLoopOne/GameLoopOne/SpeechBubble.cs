using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLoopOne.Props;
using GameLoopOne.Weapons;

namespace GameLoopOne
{
    class SpeechBubble : GameObject
    {
        private Player player;
        private float timer = 0;
        private float timeOut = 3; //3 secs
        public static bool insultActive;
        public static Label insultText = new Label();
        public static string insult;
        public static int insultLength;


        public SpeechBubble(string imagePath, Vector2D startPos, float scaleFactor, Player player)
            : base(imagePath, startPos, scaleFactor)
        {
            this.player = player;

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
                "Fucking wanke'!"
            };
            Random myRandom = new Random();

            //List needed to get random insult
            List<string> randomInsultList = new List<string>(27);
            randomInsultList.AddRange(insults);

            //Getting the final insult
            int randomInsultSelected = myRandom.Next(0, randomInsultList.Count + 1);
            insult = randomInsultList[randomInsultSelected];

            insultText.Text = insult;
            insultText.AutoSize = true;
            insultText.Hide();
        }

        public override void Update(float fps)
        {
            this.Position.X = player.Position.X + 30;
            this.Position.Y = player.Position.Y - 100;

            if (insultActive)
            {
                insultText.Show();
                fps = 1f / fps;
                if (timer > timeOut)
                {
                    GameWorld.removeList.Add(this);
                    timer = 0;
                    insultActive = false;
                    insultText.Hide();
                }
                timer += fps;
            }
            insultText.Location = new Point(Convert.ToInt32(player.Position.X + 52), Convert.ToInt32(player.Position.Y - 65));
        }
    }
}
