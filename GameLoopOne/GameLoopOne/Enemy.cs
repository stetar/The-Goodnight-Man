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
        public Weapon currentWeapon;
        public int health;
        public Enemy(string imagePath, Vector2D startPos, float scaleFactor, Weapon weapon) : base(imagePath, startPos, scaleFactor)
        {
            this.currentWeapon = weapon;
            health = 10; //TODO fix this, this should be overridden in the enemy types

        }
        public override void Update(float fps)
        {
            fps = 1f/fps;
            if (timer > currentWeapon.AttackSpeed)
            {
                currentWeapon.AttackRanged();
                timer = 0;
            }
            timer += fps;
            if (health <= 0)
            {
                GameWorld.removeList.Add(this);
            }
        }
    }
}
