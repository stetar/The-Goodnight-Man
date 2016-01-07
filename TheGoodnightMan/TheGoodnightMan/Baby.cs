using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne
{
    internal class Baby : GameObject
    {
        public Baby(string imagepath, Vector2D startPos, float scalefactor) : base(imagepath, startPos, scalefactor)
        {
            GameWorld.eng.Play2D("BabyCrying.wav", true);
        }
    }
}