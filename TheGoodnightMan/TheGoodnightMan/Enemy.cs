using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GameLoopOne.Weapons;

namespace GameLoopOne
{
    class Enemy : GameObject
    {
        private float timer = 0;
        public static Weapon currentEnemyWeapon;
        public int health;
        private bool isAlive = true;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        /// <param name="enemyWeapon">Which weapon the enemy should use</param>
        public Enemy(string imagePath, Vector2D startPos, float scaleFactor, Weapon enemyWeapon) : base(imagePath, startPos, scaleFactor)
        {
            currentEnemyWeapon = enemyWeapon;
            GameWorld.objects.Add(currentEnemyWeapon);//Weapon should also be added to the list of objects
            Random hp = new Random();
            health = hp.Next(60, 101);
        }

        
        /// <summary>
        /// Handles the basic AI code and removes enemy on death
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            fps = 1f/fps;
            if ((timer > currentEnemyWeapon.AttackSpeed) && isAlive)
            {
                currentEnemyWeapon.AttackRanged();
                timer = 0;
            }
            timer += fps;
            if (health <= 0)
            {
                isAlive = false;
                //GameWorld.GameWeapons.Add(currentEnemyWeapon);//Weapon should also be added
                float x = (position.X - sprite.Width / 2) - 75;
                float x1 = position.X + 10;
                float y = position.Y - sprite.Height / 2;
                float y1 = position.Y + 10;
                GameWorld.objects.Add(new Coin(new Vector2D(x1, y1), .5f));

                GameWorld.objects.Add(new Impact(new Vector2D(x,y), .5f));

                GameWorld.removeList.Add(currentEnemyWeapon);
                GameWorld.removeList.Add(this);
            }
        }
    }
}
