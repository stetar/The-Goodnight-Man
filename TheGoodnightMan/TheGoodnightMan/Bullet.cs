using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLoopOne.Props;
using GameLoopOne.Weapons;
using GameLoopOne.Weapons.EnemyOnly;
using GameLoopOne.Weapons.Ranged;
using GameLoopOne.Weapons.Sprites;

namespace GameLoopOne
{
    class Bullet : GameObject
    {
        private GameObject player;
        private float speed;
        private Vector2D targetPosition;
        private bool hasAttacked;

        private Vector2D velocity; //for storing the value
        /// <summary>
        /// Constructor for the bullet.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="speed">Bullet speed</param>
        /// <param name="player">Player to follow</param>
        public Bullet(string imagePath, Vector2D startPos, float scaleFactor, float speed, GameObject player) : base(imagePath, startPos, scaleFactor)
        {
            this.player = player;
            this.speed = speed;
        }

        /// <summary>
        /// Handles the movement for the bullet
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            //Calculate distance between player and enemy

            if (!hasAttacked)
            {
                velocity = position.Subtract(player.Position); //only do this once
                velocity.Normalize();
                hasAttacked = true;
            }

            position.X += 1 / fps * (velocity.X * speed);
            position.Y += 1 / fps * (velocity.Y * speed);
            if (CollisionBox.Right < 0 || CollisionBox.Left < 0 || CollisionBox.Top < 0) //optimaahzation
            {
                GameWorld.removeList.Add(this);
            }

            base.Update(fps);

        }
        /// <summary>
        /// Handles the collision for the bullet
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Crate || other is Bridge)
            {
                GameWorld.removeList.Add(this);
            }

            if (Enemy.currentEnemyWeapon is EnemyRPG)
            {
                if (hasAttacked)
                {
                    if (!(other is Enemy || other is Weapon || other is Sky))
                    {
                        GameWorld.removeList.Add(this);
                        GameWorld.objects.Add(new Explosion(new Vector2D(this.position.X - (sprite.Width / 2), this.position.Y - (sprite.Height / 2)), 1));
                        hasAttacked = false;
                    }
                }
            }
           
        }
    }
}
