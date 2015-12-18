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
        
        public static System.Timers.Timer impactTimer;
        //private static string imagePath = "pow.png";
        private static string imagePath = "bam.png";

        public Impact( Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            SetTimer();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            impactTimer = new System.Timers.Timer(500); //.5 seconds
            // Hook up the Elapsed event for the timer. 
            impactTimer.Elapsed += OnTimedEvent;
            impactTimer.AutoReset = true;
            impactTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GameWorld.removeList.Add(this);
            

        }

        //public override void OnCollision(GameObject other)
        //{
            
        //}
    }
}
