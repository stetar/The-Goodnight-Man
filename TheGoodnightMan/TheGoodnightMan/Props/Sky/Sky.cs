using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Props
{
    class Sky : GameObject
    {
        private int randomSpeed = 0;
        private static string imagePath = "Props/Sky/Sky.png";
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        public Sky(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            Random r = new Random();
            randomSpeed = r.Next(10,20);
            

        }
        /// <summary>
        /// Handles the movement of the sky
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            this.position.X -= 1/fps*(randomSpeed)
            ;
            if (CollisionBox.Right < 0) //Move them over to the otherside
            {
                position.X = + 1024;
            }
            base.Update(fps);
        }
    }
}
