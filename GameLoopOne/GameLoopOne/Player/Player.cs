using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GameLoopOne.Props;
using GameLoopOne.Weapons;
using GameLoopOne.Weapons.Melee;


namespace GameLoopOne
{
    class Player : RigidBodyBox
    {
        //Player Weapon
        public static Weapon currentWeapon;
        private float weaponTimer = 0;
        //Player health
        public int health;
        //Player animations
        private bool movingLeft;
        private bool movingRight;
        private int speed = 100;
        //Gravity
        private int gravity = 290;//the force the player is taken down with.
        private int jumpVelocity = -300;
        public static Vector2D velocity;
        public static bool isGrounded;

        public bool isAlive;


        public Player(string imagePath, Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            velocity = new Vector2D(0, 0);
            health = 100;
            isAlive = true;
            currentWeapon = new Wrench(position, 1);
            GameWorld.objects.Add(currentWeapon); //add it to objects as it should get drawn
        }



        public override void Update(float fps)
        {


            //Player animation & Movement
            movingLeft = false;
            movingRight = false;

            if (Keyboard.IsKeyDown(Keys.A))
            {
                position.X -= 1 / fps * speed;
                movingLeft = true;
            }

            if (Keyboard.IsKeyDown(Keys.D))
            {
                position.X += 1 / fps * speed;
                movingRight = true;
            }
            float deltaTime = 1f / fps;
            if (Keyboard.IsKeyDown(Keys.Space) && weaponTimer > currentWeapon.AttackSpeed)
            {
                currentWeapon.AttackMelee();
                weaponTimer = 0;
                //TODO fix damage
                //foreach (GameObject go in GameWorld.objects)
                //{
                //    if (go is Enemy)
                //    {

                //        Enemy e1 = go as Enemy;;
                //        if (this.CollisionBox.IntersectsWith(go.CollisionBox))
                //        {
                //            e1.health -= 1;

                //        }
                //    }
                //}


            }
            weaponTimer += deltaTime;

            //Jump
            if (Keyboard.IsKeyDown(Keys.W))
            {
                if (isGrounded)
                {
                    velocity.Y = jumpVelocity;
                    isGrounded = false;

                }

            }

            // Bottom collision

            if (position.Y > GameWorld.WindowRectangle.Bottom - (GameWorld.WindowRectangle.Bottom / 5)) //align it with the backgroundline
            {
                isGrounded = true;

                if (velocity.Y > 0)
                {
                    velocity.Y = 0;
                }
            }
            else
            {
                isGrounded = false;
            }

            // if the player is not grounded, add gravity
            if (!isGrounded)
            {
                velocity.Y += gravity * 1 / fps;
            }
            position.Y += velocity.Y * 1 / fps;

            //position and next level
            if (position.X > GameWorld.WindowRectangle.Right)
            {
                GameWorld.iLevel++;
                position.X = 0;
                GameWorld.SetupDifferentWorlds();

            }

            if (Keyboard.IsKeyDown(Keys.I) && !SpeechBubble.insultActive)
            {
                SpeechBubble.insultActive = true;
                GameWorld.objects.Add(new SpeechBubble("Speech_bubble.png", new Vector2D(0, 0), .9f, this));

            }
            base.Update(fps);
        }
        public override void UpdateAnimation(float fps)
        {
            float factor = 1 / fps;

            if (movingLeft)
            {
                // Calculate current frame index
                currentFrameIndex -= factor * animationSpeed * 2;
            }
            else if (movingRight)
            {
                currentFrameIndex += factor * animationSpeed * 2;
            }
            else
            {
                currentFrameIndex = 0;
            }

            // Start animation over if needed
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }
            else if (currentFrameIndex < 0)
            {
                currentFrameIndex = animationFrames.Count - 1;
            }

            sprite = animationFrames[(int)currentFrameIndex];

        }
        /// <summary>
        /// Checks the player's collision each tick, only called on actual collision.
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                float x = (position.X - sprite.Width / 2) - 75;
                float y = position.Y - sprite.Height / 2;
                //float x = position.X - 90;
                //float y = position.Y - 80;
                health -= 10; //TODO Fix with different weapons
                //GameWorld.objects.Add(new Impact(new Vector2D(x, y), 1.5f));
                GameWorld.objects.Add(new Impact(new Vector2D(x, y), .5f));
                GameWorld.removeList.Add(other);

            }

        }
    }
}
