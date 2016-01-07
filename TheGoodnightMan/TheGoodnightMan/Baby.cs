using GameLoopOne.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne
{
    internal class Baby : GameObject
    {
        /// <summary>
        /// Constructor, plays a sound on init
        /// </summary>
        /// <param name="imagepath"></param>
        /// <param name="startPos"></param>
        /// <param name="scalefactor"></param>
        public Baby(string imagepath, Vector2D startPos, float scalefactor) : base(imagepath, startPos, scalefactor)
        {
            GameWorld.eng.Play2D("BabyCrying.wav", true);
        }
    }
}