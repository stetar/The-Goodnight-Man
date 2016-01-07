using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne
{
    class Coin : GameObject
    {

        private float timer = 0;
        private float timeOut = 2f; //2 secs
        private bool canPickup;
        private static string imagePath = "Props/Coin/Coin1.png;Props/Coin/Coin2.png;Props/Coin/Coin3.png;Props/Coin/Coin4.png;Props/Coin/Coin5.png;Props/Coin/Coin6.png;Props/Coin/Coin5.png;Props/Coin/Coin4.png;Props/Coin/Coin3.png;Props/Coin/Coin2.png;Props/Coin/Coin1.png";


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        public Coin(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            this.animationSpeed = 10;
            canPickup = false;
        }
        /// <summary>
        /// Handles the collision of the coin
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            if (other is Player && canPickup)
            {
                GameWorld.iIncorrectness += 1;
                GameWorld.removeList.Add(this);
            }
            base.OnCollision(other);
        }
        /// <summary>
        /// Handles the timer so that the player can pick up the coin after the timer runs out.
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            fps = 1f / fps;
            if (timer > timeOut)
            {
                canPickup = true;
                timer = 0;
            }
            timer += fps;
            base.Update(fps);
        }
    }
}
