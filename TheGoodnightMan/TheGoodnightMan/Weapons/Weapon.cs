using GameLoopOne.Forms;
using IrrKlang;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne.Weapons
{
    internal abstract class Weapon : GameObject
    {
        public int damage = 1;
        protected string imagePath;
        public float AttackSpeed = 0;
        private GameObject targetPlayer;
        public static bool didAttack = false;
        public float meleeRangeY = 1;
        public float meleeRangeX = 1;
        private static ISound FlagSound;

        public float moveWeaponUp = 0;
        public float moveWeaponRight = 0;
        public int weaponIndex;
        private Graphics attackRange;

        public Weapon(string imagePath, Vector2D startPos, float scaleFactor, int weaponIndex) : base(imagePath, startPos, scaleFactor)
        {
            didAttack = false;
            this.weaponIndex = weaponIndex;
        }

        public RectangleF attackRangeBox
        {
            get
            {
                return new RectangleF(position.X, position.Y, meleeRangeX, meleeRangeY);
            }
        }

        public override void Draw(Graphics dc)
        {
            base.Draw(dc);
#if DEBUG
            dc.DrawRectangle(new Pen(Brushes.Red), position.X, position.Y, attackRangeBox.Width, attackRangeBox.Height);//don't draw the actual range in release
#endif
        }

        public virtual void AttackMelee()
        {
            didAttack = true;

            foreach (GameObject go in GameWorld.objects.ToList()) //ToList so we can modify it
            {
                if (go is Enemy)
                {
                    Enemy e1 = go as Enemy;
                    if (attackRangeBox.IntersectsWith(go.CollisionBox))
                    {
                        e1.health -= damage;
                    }
                }
                if (go is Baby)
                {
                    Baby b1 = go as Baby;
                    if (attackRangeBox.IntersectsWith(go.CollisionBox))
                    {
                        GameWorld.eng.StopAllSounds();
                        GameWorld.iIncorrectness += 5;
                        GameWorld.SaveGameState();
                        Form1.timer1.Stop();
                        if (MessageBox.Show("Well done, shithead! No more screaming babies! Enjoy the silence while it lasts...", "Level complete", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            new LevelMenu().Show();
                        }
                    }
                }

                switch (Player.weaponIndexNumber)
                {
                    case 0:
                        GameWorld.eng.Play2D("Weapons/Sounds/BaseballBat.mp3");
                        break;

                    case 1:
                        GameWorld.eng.Play2D("Weapons/Sounds/CricketPlayer.wav");
                        break;

                    case 2:
                        GameWorld.eng.Play2D("Weapons/Sounds/Knife.wav");
                        break;

                    case 3:
                        GameWorld.eng.Play2D("Weapons/Sounds/Guitar slag.wav");
                        break;

                    case 4:
                        GameWorld.eng.Play2D("Weapons/Sounds/Knife.wav");
                        break;

                    case 5:
                        GameWorld.eng.Play2D("Weapons/Sounds/BaseballBat.mp3");
                        break;

                    case 6:
                        GameWorld.eng.Play2D("Weapons/Sounds/BaseballBat.mp3");
                        break;

                    case 7:
                        GameWorld.eng.Play2D("Weapons/Sounds/BaseballBat.mp3");
                        break;

                    case 8:
                        if (FlagSound == null || FlagSound.Finished)
                        {
                            FlagSound = GameWorld.eng.Play2D("Weapons/Sounds/ISISFlag.mp3", false);
                        }
                        break;
                }
            }
        }

        public virtual void AttackRanged()
        {
            foreach (GameObject player in GameWorld.objects)
            {
                if (player is Player)
                {
                    targetPlayer = player;
                }
            }

            //Switch used to select the correct sound
            switch (Player.weaponIndexNumber)
            {
                case 9:
                    GameWorld.eng.Play2D("Machinegun.wav");
                    break;

                case 10:
                    GameWorld.eng.Play2D("RPG.flac");
                    break;

                case 11:
                    GameWorld.eng.Play2D("Submachinegun.wav");
                    break;

                case 12:
                    GameWorld.eng.Play2D("LMG.wav");
                    break;

                case 13:
                    GameWorld.eng.Play2D("GunshotPistol.wav");
                    break;
            }
            float x = position.X + 30;
            float y = position.Y - 20;
            Vector2D bulletStartPos = new Vector2D(x, y);
            GameWorld.objects.Add(new Bullet("bullet.png", bulletStartPos, 1, 150, targetPlayer));
        }

        /// <summary>
        /// override of UpdateAnimation, as the weapon should not loop it's animation
        /// </summary>
        /// <param name="fps"></param>
        public override void UpdateAnimation(float fps)
        {
            float factor = 1 / fps;

            if (didAttack)
            {
                currentFrameIndex += factor * animationSpeed;
                if (currentFrameIndex >= animationFrames.Count)
                {
                    currentFrameIndex = 0;
                    didAttack = false;
                }

                sprite = animationFrames[(int)currentFrameIndex];
            }
        }

        public static implicit operator Weapon(string v)
        {
            throw new NotImplementedException();
        }
    }
}