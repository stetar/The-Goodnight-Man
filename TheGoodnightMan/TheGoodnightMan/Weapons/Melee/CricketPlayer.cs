using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class CricketPlayer : Weapon
    {
        private static string imagePath = "weapons/sprites/CricketPlayer1.png;weapons/sprites/CricketPlayer2.png;weapons/sprites/CricketPlayer3.png;weapons/sprites/CricketPlayer4.png";

        private static int weaponIndex = 1;

        public CricketPlayer(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = 1;
            this.animationSpeed = 30;
            meleeRangeX = 40;
            meleeRangeY = 80;
            moveWeaponUp = -40;
            moveWeaponRight = 10;
        }
    }
}
