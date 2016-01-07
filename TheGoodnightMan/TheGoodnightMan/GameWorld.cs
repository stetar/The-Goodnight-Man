using GameLoopOne.Props;
using GameLoopOne.Weapons;
using GameLoopOne.Weapons.EnemyOnly;
using GameLoopOne.Weapons.Melee;
using GameLoopOne.Weapons.Ranged;
using GameLoopOne.Weapons.Sprites;
using IrrKlang;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLoopOne
{
    internal class GameWorld
    {
        private Graphics dc;
        public static List<GameObject> objects;
        public static List<GameObject> removeList;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        private static Image level0Image = Image.FromFile("Levels/level0.png");
        private static Image level1Image = Image.FromFile("Levels/level0.png");
        private static Rectangle displayRectangle;
        public static int iLevel = 0;
        public static int iIncorrectness = 0;
        public static List<Weapon> GameWeapons = new List<Weapon>();
        private static float timer1 = 0;
        private static float timeOut1 = 10f; //5 secs
        private static bool playSound;
        private static ISound levelChangeSound;
        public static ISoundEngine eng = new ISoundEngine();

        public static bool OwnAssaultRifle = false;
        public static bool OwnRPG;
        public static bool OwnLMG;
        public static bool OwnCricketPlayer;
        public static bool OwnISISFlag;
        public static bool OwnAxe;
        public static bool OwnDildoSword;
        public static bool OwnKatana;
        public static bool OwnKnife;
        public static bool OwnGuitar;
        public static bool OwnBeaver;
        public static bool OwnPistol;
        public static bool OwnSmg;

        public static Rectangle WindowRectangle
        {
            get
            {
                return displayRectangle;
            }
            set
            {
                displayRectangle = value;
            }
        }

        public GameWorld(Graphics dc, Rectangle displayRectangle)
        {
            WindowRectangle = displayRectangle;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, displayRectangle);
            this.dc = backBuffer.Graphics;
            objects = new List<GameObject>();
            removeList = new List<GameObject>();
            SetupDifferentWorlds();
            SetupWorld();
        }

        public static List<GameObject> GameObjects
        {
            get { return objects; }
            set { objects = value; }
        }

        public void SetupWorld()
        {
            endTime = DateTime.Now;
            //Random rand = new Random();
            //string imageString = "weapons/sprites/weaponSprite1.png;weapons/sprites/weaponSprite2.png;weapons/sprites/weaponSprite3.png;weapons/sprites/weaponSprite4.png";

            string imageString = "Player/Sprites/Playersprite1.png;Player/Sprites/Playersprite2.png;Player/Sprites/Playersprite3.png;Player/Sprites/Playersprite4.png;Player/Sprites/Playersprite5.png;Player/Sprites/Playersprite6.png;Player/Sprites/Playersprite7.png;Player/Sprites/Playersprite8.png";
            objects.Add(new Player(imageString, new Vector2D(100, 550), .75f));
            objects.Add(new Sky(new Vector2D(10, 100), 1));
            objects.Add(new Sky(new Vector2D(850, 50), 1));
            objects.Add(new Sky(new Vector2D(440, 75), 1));
            string text = File.ReadAllText("test.txt");

            //string[] lines = System.IO.File.ReadAllLines("test.txt");
            ////if (lines[0] != null)
            ////{
            ////    //GameWorld.iIncorrectness = Convert.ToInt32(lines[0]);
            ////}
            ////for (int i = 0; i < GameWorld.objects.Count; i++)
            ////{
            ////    lines[0] = Player.currentPlayerWeapon.ToString(); // the current player weapon.
            ////    //lines[1] = GameWorld.iIncorrectness.ToString();
            ////    //lines[2] = GameWorld.iLevel.ToString();
            ////}
            //string[] savedLines = new string[] { };

            //for (int i = 0; i < lines.Count(); i++)
            //{
            //    savedLines[lines.Count()];
            //}

            //foreach (string line in lines)
            //{
            //    //lines[0] = Player.currentPlayerWeapon.ToString(); // the current player weapon.
            //    //lines[1] = GameWorld.iIncorrectness.ToString();
            //    //lines[2] = GameWorld.iLevel.ToString();
            //    lines[0] = "Hej";
            //    lines[1] = "line2";
            //    lines[2] = "line 43";
            //    File.WriteAllLines("test.txt", lines);
            //}

            //text = text.Replace("weapon", "new value");
            //string penis = Player.currentPlayerWeapon.ToString();
            //File.WriteAllText("test.txt", penis);
        }

        private void UpdateAnimations(float fps)
        {
            foreach (GameObject go in objects)
            {
                go.UpdateAnimation(fps);
            }
            foreach (Weapon wep in GameWeapons)
            {
                wep.UpdateAnimation(fps);
            }
        }

        public void GameLoop()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan deltaTime = startTime - endTime;
            int milliSeconds = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;
            currentFps = 1000f / milliSeconds;
            endTime = DateTime.Now;
            Update(currentFps);
            Draw();
        }

        private void Update(float fps)
        {
            if (timer1 > timeOut1)
            {
                if (playSound)
                {
                    if (levelChangeSound == null || levelChangeSound.Finished)
                    {
                        levelChangeSound = eng.Play2D("Drawing.wav", false);
                        timer1 = 10;
                    }
                }
            }
            playSound = false;

            timer1 += fps;
            foreach (Weapon wep in GameWeapons.ToList()) //To list as you can't modify it in runtime elsewise.
            {
                wep.UpdateAnimation(fps);
            }
            foreach (GameObject go in objects.ToList()) //To list as you can't modify it in runtime elsewise.
            {
                if (!(go is Weapon))
                {
                    go.Update(fps);
                    go.UpdateAnimation(fps);
                }
            }

            ResolveRigidbodyCollisions();

            //remove list
            foreach (GameObject go in removeList.ToList())
            {
                if (objects.Contains(go))
                {
                    if (go is Enemy)
                    {
                        //Add score
                    }
                    objects.Remove(go);
                }
            }

            // Clear toremove
            removeList.Clear();
        }

        private void ResolveRigidbodyCollisions()
        {
            foreach (var a in objects)
            {
                if (a is RigidBodyBox)
                {
                    foreach (var b in objects.ToList())
                    {
                        if (a != b)
                        {
                            if (!(b is Bullet || b is Impact || b is Enemy || b is Sky || b is Weapon || b is SpeechBubble || b is Explosion)) //Don't calculate solid collisions for these classes
                            {
                                this.ResolveAABBCollision(a, b);
                            }
                            else
                            {
                                //Dont do anything
                            }
                        }
                    }
                }
            }
        }

        private void ResolveAABBCollision(GameObject rigidbody, GameObject b)
        {
            RectangleF result = RectangleF.Intersect(rigidbody.CollisionBox, b.CollisionBox);
            if (result.Width > 0 || result.Height > 0)
            {
                Vector2D rigidbodyCenter = new Vector2D(
                    rigidbody.CollisionBox.Left + rigidbody.CollisionBox.Width * 0.5f,
                    rigidbody.CollisionBox.Top + rigidbody.CollisionBox.Height * 0.5f
                );
                if (result.Height > result.Width)
                //resolve horisontally
                {
                    float distanceFromRight = Math.Abs(rigidbodyCenter.X - b.CollisionBox.Right);
                    float distanceFromLeft = Math.Abs(rigidbodyCenter.X - b.CollisionBox.Left);
                    if (distanceFromRight > distanceFromLeft)
                    {
                        // Go left
                        rigidbody.Position.X -= result.Width;
                    }
                    else
                    {
                        // Go right
                        rigidbody.Position.X += result.Width;
                    }
                }
                else
                {
                    float distanceFromTop = Math.Abs(rigidbodyCenter.Y - b.CollisionBox.Top);
                    float distanceFromBottom = Math.Abs(rigidbodyCenter.Y - b.CollisionBox.Bottom);
                    if (distanceFromTop < distanceFromBottom)
                    {
                        // Go up
                        rigidbody.Position.Y -= result.Height;
                        Player.isGrounded = true;
                        if (Player.velocity.Y > 0) // Don't pull player down
                        {
                            Player.velocity.Y = 0;
                        }
                    }
                    else
                    {
                        // Go down
                        //Player.isGrounded = false;
                        //Don't make the position go down as we go below the map
                        rigidbody.Position.Y += result.Height;
                    }
                }
            }
        }

        private void Draw()
        {
            // Top background image

            switch (iLevel)
            {
                default:
                    dc.DrawImage(level0Image, 0, 0, level0Image.Width, level0Image.Height);
                    break;

                case 1:
                    dc.DrawImage(level1Image, 0, 0, level1Image.Width, level1Image.Height);
                    break;

                case 2:
                    dc.DrawImage(level1Image, 0, 0, level1Image.Width, level1Image.Height);
                    break;
            }
            foreach (Weapon wep in GameWorld.GameWeapons.ToList())
            {
                wep.Draw(dc);
            }
            foreach (GameObject go in objects.ToList())
            {
                go.Draw(dc);
            }

            Font f = new Font("IMPACT", 16);

#if DEBUG
            dc.DrawString(string.Format("FPS: {0}", currentFps), f, Brushes.Black, 0, 0);
#endif

            //Incorrectness meter
            //dc.DrawString(string.Format("INCORRECTNESS:{0}", iIncorrectness), f1, Brushes.Black, displayRectangle.Width / 2, 0);
            dc.DrawString(string.Format("INCORRECTNESS: {0}", iIncorrectness), f, Brushes.DarkRed, 0, 30);
            dc.DrawString(string.Format("LEVEL: {0}", iLevel), f, Brushes.Black, 0, 60);
            dc.DrawString(string.Format("HEALTH: {0}", Player.health), f, Brushes.Black, 0, 90);

            backBuffer.Render();
        }

        public static void SetupDifferentWorlds()
        {
            playSound = true;
            foreach (GameObject go in objects.ToList())
            {
                if (!(go is Player || go is Sky))//dont remove the player or the sky
                {
                    removeList.Add(go);
                }
            }
            foreach (GameObject go in GameWeapons.ToList())
            {
                removeList.Add(go);
            }

            switch (iLevel)
            {
                case 0:
                    objects.Add(new Crate(new Vector2D(400, 590), .5f));
                    objects.Add(new Crate(new Vector2D(540, 590), .5f));
                    objects.Add(new Crate(new Vector2D(470, 508), .5f));
                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(470, 425), .75f, (new EnemyAssaultRifle(new Vector2D(470, 425), .3f))));
                    break;

                case 1:

                    objects.Add(new Crate(new Vector2D(540, 590), .5f));

                    objects.Add(new Bridge(new Vector2D(770, 500), .75f));
                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(770, 417), .75f, (new EnemyAssaultRifle(new Vector2D(770, 417), .3f))));

                    break;

                case 2:

                    objects.Add(new Crate(new Vector2D(570, 590), .5f));
                    objects.Add(new Crate(new Vector2D(670, 590), .5f));
                    objects.Add(new Bridge(new Vector2D(590, 435), .75f));
                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(590, 518), .75f, (new EnemyAssaultRifle(new Vector2D(590, 518), .3f))));
                    break;

                case 3:
                    objects.Add(new Crate(new Vector2D(250, 590), .5f));
                    objects.Add(new Bridge(new Vector2D(450, 490), .5f));
                    objects.Add(new Crate(new Vector2D(450, 590), .5f));
                    objects.Add(new Crate(new Vector2D(0, 300), .5f));
                    objects.Add(new Crate(new Vector2D(0, 382), .5f));
                    objects.Add(new Crate(new Vector2D(0, 464), .5f));
                    objects.Add(new Crate(new Vector2D(950, 590), .5f));
                    objects.Add(new Crate(new Vector2D(950, 508), .5f));
                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(75, 217), .75f, (new EnemyRPG(new Vector2D(75, 217), .3f))));

                    break;

                case 4:
                    objects.Add(new Crate(new Vector2D(100, 590), .5f));
                    objects.Add(new Crate(new Vector2D(950, 590), .5f));
                    objects.Add(new Crate(new Vector2D(950, 508), .5f));
                    objects.Add(new Crate(new Vector2D(950, 426), .5f));
                    objects.Add(new Crate(new Vector2D(950, 344), .5f));
                    objects.Add(new Crate(new Vector2D(950, 262), .5f));
                    objects.Add(new Crate(new Vector2D(950, 180), .5f));
                    objects.Add(new Crate(new Vector2D(850, 180), .5f));
                    objects.Add(new Crate(new Vector2D(200, 450), .5f));
                    objects.Add(new Crate(new Vector2D(200, 150), .5f));
                    objects.Add(new Crate(new Vector2D(300, 590), .5f));
                    objects.Add(new Crate(new Vector2D(50, 300), .5f));
                    objects.Add(new Crate(new Vector2D(700, 150), .5f));
                    objects.Add(new Crate(new Vector2D(400, 200), .5f));
                    objects.Add(new Crate(new Vector2D(600, 450), .5f));
                    objects.Add(new Enemy("player/sprites/playersprite1.png", new Vector2D(700, 67), .75f, (new EnemyAssaultRifle(new Vector2D(700, 67), .3f))));

                    break;

                case 5:
                    objects.Add(new Crate(new Vector2D(950, 590), .5f));
                    objects.Add(new Crate(new Vector2D(950, 508), .5f));
                    objects.Add(new Crate(new Vector2D(950, 426), .5f));
                    objects.Add(new Crate(new Vector2D(950, 344), .5f));
                    objects.Add(new Crate(new Vector2D(950, 262), .5f));
                    objects.Add(new Crate(new Vector2D(950, 180), .5f));
                    objects.Add(new Crate(new Vector2D(950, 98), .5f));
                    objects.Add(new Crate(new Vector2D(950, 16), .5f));
                    objects.Add(new Crate(new Vector2D(950, -16), .5f));
                    objects.Add(new Crate(new Vector2D(900, 0), .5f));
                    objects.Add(new Baby("Babycar.png", new Vector2D(500, 570), .5f));

                    break;
            }
        }

        public static void SaveGameState()
        {
            List<string> lineList = new List<string>();
            lineList.Clear();
            lineList.Add(GameWorld.iIncorrectness.ToString());
            lineList.Add(GameWorld.iLevel.ToString());
            lineList.Add(Player.weaponIndexNumber.ToString());
            lineList.Add(OwnAssaultRifle.ToString());
            lineList.Add(OwnRPG.ToString());
            lineList.Add(OwnLMG.ToString());
            lineList.Add(OwnCricketPlayer.ToString());
            lineList.Add(OwnISISFlag.ToString());
            lineList.Add(OwnAxe.ToString());
            lineList.Add(OwnDildoSword.ToString());
            lineList.Add(OwnKatana.ToString());
            lineList.Add(OwnKnife.ToString());
            lineList.Add(OwnGuitar.ToString());
            lineList.Add(OwnBeaver.ToString());
            lineList.Add(OwnSmg.ToString());
            lineList.Add(OwnPistol.ToString());

            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.
            System.IO.File.WriteAllLines("test.txt", lineList);
        }

        public static void LoadGameState()
        {
            string[] lines = File.ReadAllLines("test.txt");
            GameWorld.iIncorrectness = Convert.ToInt32(lines[0]);
            GameWorld.iLevel = Convert.ToInt32(lines[1]);
            Player.weaponIndexNumber = Convert.ToInt32(lines[2]);
            OwnAssaultRifle = Convert.ToBoolean(lines[3]);
            OwnRPG = Convert.ToBoolean(lines[4]);
            OwnLMG = Convert.ToBoolean(lines[5]);
            OwnCricketPlayer = Convert.ToBoolean(lines[6]);
            OwnISISFlag = Convert.ToBoolean(lines[7]);
            OwnAxe = Convert.ToBoolean(lines[8]);
            OwnDildoSword = Convert.ToBoolean(lines[9]);
            OwnKatana = Convert.ToBoolean(lines[10]);
            OwnKnife = Convert.ToBoolean(lines[11]);
            OwnGuitar = Convert.ToBoolean(lines[12]);
            OwnBeaver = Convert.ToBoolean(lines[13]);
            OwnSmg = Convert.ToBoolean(lines[14]);
            OwnPistol = Convert.ToBoolean(lines[15]);
        }
    }
}