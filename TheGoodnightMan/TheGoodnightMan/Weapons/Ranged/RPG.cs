using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    internal class RPG : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath =
            "weapons/sprites/weaponSprite1.png;weapons/sprites/weaponSprite2.png;weapons/sprites/weaponSprite3.png;weapons/sprites/weaponSprite4.png";

        private static int weaponIndex = 12;

        public RPG(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 10;
            this.AttackSpeed = 2;
            this.animationSpeed = 10;
            meleeRange = 4;
        }
    }
}
