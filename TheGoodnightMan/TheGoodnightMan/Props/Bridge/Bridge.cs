using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Props
{
    class Bridge : GameObject
    {

        private static string imagePath = "Props/Bridge/Bridge.png";
        public Bridge(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {

        }
        
    }
}
