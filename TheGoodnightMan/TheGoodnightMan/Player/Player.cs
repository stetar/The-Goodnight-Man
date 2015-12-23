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
    class Player : RigidBodyBox
    {
        //Player Weapon
        public static Weapon currentPlayerWeapon;
        public static Weapon tempWeapon;

        private float weaponTimer = 0;
        private float weaponPickupTimer = 0;

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
        private bool test = false;
        public Player(string imagePath, Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            velocity = new Vector2D(0, 0);
            health = 100;
            isAlive = true;
            
            currentPlayerWeapon = new Knife(new Vector2D(0,0), .3f);
            GameWorld.GameWeapons.Add(currentPlayerWeapon); //add it to objects as it should get drawn
        }

        public override void Update(float fps)
        {

            if (currentPlayerWeapon != null)
            {
                currentPlayerWeapon.Position.X = position.X + currentPlayerWeapon.moveWeaponRight;
                currentPlayerWeapon.Position.Y = position.Y + currentPlayerWeapon.moveWeaponUp;
            }
           
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
            if (Keyboard.IsKeyDown(Keys.Space) && weaponTimer > currentPlayerWeapon.AttackSpeed) 
            {
                currentPlayerWeapon.AttackMelee();
                weaponTimer = 0;
            }
            weaponTimer += deltaTime;
           

            if (Keyboard.IsKeyDown(Keys.B))
            {
                GameWorld.SaveGameState();

            }
            if (Keyboard.IsKeyDown(Keys.S) && weaponPickupTimer > 3)
            {
                //Weapon
                foreach (Weapon wep in GameWorld.GameWeapons.ToList())
                {
                    if (this.IsCollidingWith(wep))//If the player is colliding with a weapon and is pressing s
                    {
                        //tempWeapon = wep;
                        //currentPlayerWeapon = null;
                        ChangeWeapon(currentPlayerWeapon, wep);
                    }
                }
                weaponPickupTimer = 0;
            }
            weaponPickupTimer += deltaTime;
            //if (Keyboard.IsKeyDown(Keys.S) && weaponPickupTimer > 3)
            //{
            //    //Weapon
            //    foreach (Weapon wep in Weapon.gameWeapons.ToList())
            //    {
            //        if (this.IsCollidingWith(wep) && Keyboard.IsKeyDown(Keys.S)/* && currentPlayerWeapon != wep*/)//If the player is colliding with a weapon and is pressing s
            //        {
            //            currentPlayerWeapon.DropWeapon(currentPlayerWeapon);
            //            Weapon.removeWeapons.Add(currentPlayerWeapon);
            //            currentPlayerWeapon = wep;

            //            Weapon.removeWeapons.Add(wep);
            //            GameWorld.removeList.Add(wep);
            //            test = true;
            //        }
            //    }
            //    weaponPickupTimer = 0;
            //}
            //weaponPickupTimer += deltaTime;

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
                //Weapon.GameWeapons.Clear();

                GameWorld.SetupDifferentWorlds();
            }
            else if (position.X < GameWorld.WindowRectangle.Left)
            {
                GameWorld.iLevel--;
                position.X = 900;
                //Weapon.GameWeapons.Clear();

                GameWorld.SetupDifferentWorlds();
            }

            if (Keyboard.IsKeyDown(Keys.I) && !SpeechBubble.insultActive)
            {
                SpeechBubble.insultActive = true;
                GameWorld.objects.Add(new SpeechBubble("Speech_bubble.png", new Vector2D(0, 0), .9f, this));
            }
            base.Update(fps);
        }

        public void ChangeWeapon(Weapon oldWeapon, Weapon newWeapon)
        {
            //GameWorld.removeList.Add(oldWeapon);
            GameWorld.GameWeapons.Add(newWeapon);
            GameWorld.GameWeapons.Remove(oldWeapon);
            currentPlayerWeapon = newWeapon;
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
                health -= Enemy.currentEnemyWeapon.damage; //TODO Fix with different weapons
                //GameWorld.objects.Add(new Impact(new Vector2D(x, y), 1.5f));
                GameWorld.objects.Add(new Impact(new Vector2D(x, y), .5f));
                GameWorld.removeList.Add(other);

            }
            if (other is Weapon)
            {
                if (other != currentPlayerWeapon)
                {
                    
                }
            }
            
        }
    }
}
