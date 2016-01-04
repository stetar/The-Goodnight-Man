using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    class AssaultRifle : Weapon
    {
        private static string imagePath = "weapons/sprites/AssaultRifle1.png;weapons/sprites/AssaultRifle2.png;weapons/sprites/AssaultRifle3.png;weapons/sprites/AssaultRifle4.png";
        private static int weaponIndex = 11;
        public static string EnemyWeaponPath = "weapons/sprites/assualtrifle1.png";
        public AssaultRifle(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 10;
            AttackSpeed = 0.7f;
            animationSpeed = 30;
            meleeRangeX = 50f;
            meleeRangeY = 100f;

            moveWeaponRight = 20;
            moveWeaponUp = -30;
            
            
        }
    }
}
