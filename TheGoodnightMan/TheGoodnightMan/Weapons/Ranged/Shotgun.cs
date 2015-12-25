using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class Shotgun : Weapon
    {
        private static string imagePath = "weapons/sprites/WeaponSprite1.png";
        private static int weaponIndex = 15;

        public Shotgun(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 7;
            this.AttackSpeed = 1.2f;
        }
    }
}
