using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GameLoopOne
{
    class Impact : GameObject
    {
        private static string imagePath = "bam.png";
        private float timer = 0;
        private float timeOut = .5f; //5 secs
        public Impact( Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            
        }

        public override void Update(float fps)
        {
            fps = 1f / fps;
            if (timer > timeOut)
            {
               GameWorld.removeList.Add(this);
               timer = 0;
            }
            timer += fps;
            base.Update(fps);
        }
       
    }
}
