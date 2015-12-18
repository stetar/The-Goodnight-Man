using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Props
{
    class Crate : GameObject
    {
        
        private static string imagePath = "Props/Crate/Crate.png";
        public Crate(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            
        }
        //public override void OnCollision(GameObject other)
        //{
            
        //}
    }
}
