using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Katana : Weapon
    {
        private static string imagePath = "weapons/sprites/Katana1.png;weapons/sprites/Katana2.png;weapons/sprites/Katana3.png;weapons/sprites/Katana4.png;weapons/sprites/Katana5.png";

        private static int weaponIndex = 5;

        public Katana(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 5;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRangeX = 40;
            meleeRangeY = 80;
            moveWeaponUp = -40;
            moveWeaponRight = 20;
        }
    }
}
