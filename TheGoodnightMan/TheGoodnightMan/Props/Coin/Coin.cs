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
        private static string imagePath = "Props/Coin/Coin1.png;Props/Coin/Coin2.png;Props/Coin/Coin3.png;Props/Coin/Coin4.png;Props/Coin/Coin3.png;Props/Coin/Coin2.png;Props/Coin/Coin1.png";

        

        public Coin(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            
        }
    }
}
