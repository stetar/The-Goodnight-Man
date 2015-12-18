using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class Pistol : Weapon
    {
        private static string imagePath = "";

        public Pistol(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 5;
            this.AttackSpeed = 1;
        }
    }
}
