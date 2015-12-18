using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class LMG : Weapon
    {
        private static string imagePath = "";

        public LMG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 10;
            this.AttackSpeed = 0.8f;
        }
    }
}
