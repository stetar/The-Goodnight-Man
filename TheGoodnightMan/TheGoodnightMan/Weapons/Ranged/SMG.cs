using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class SMG : Weapon
    {
        private static string imagePath = "";
        private static int weaponIndex = 11;

        public SMG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 5;
            this.AttackSpeed = .4f;
        }
    }
}
