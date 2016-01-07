using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.EnemyOnly
{
    class EnemyAssaultRifle : Weapon
    {
        private static string imagePath = "Weapons/Sprites/EnemySprites/AssualtRifle1.png";
        private static int weaponIndex;

        public EnemyAssaultRifle(Vector2D startPos, float scalefactor) : base(imagePath, startPos, scalefactor, weaponIndex)
        {
            damage = 15;
            this.AttackSpeed = 1;
        }
    }
}
