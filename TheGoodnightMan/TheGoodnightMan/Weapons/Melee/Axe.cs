using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class Axe : Weapon
    {
        private static string imagePath = "weapons/sprites/AxeSprite1.png;weapons/sprites/AxeSprite2.png;weapons/sprites/AxeSprite3.png;weapons/sprites/AxeSprite4.png";

        private static int weaponIndex = 6;

        public Axe(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 23;
            this.AttackSpeed = 0.6f;
            this.animationSpeed = 30;
            meleeRangeX = 50;
            meleeRangeY = 80;
            moveWeaponUp = -10;
            moveWeaponRight = 20;
        }
    }
}
