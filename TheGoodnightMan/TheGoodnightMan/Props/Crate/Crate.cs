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
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        public Crate(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            
        }
 
    }
}
