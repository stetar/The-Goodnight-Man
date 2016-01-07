using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Ranged
{
    internal class Pistol : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath ="weapons/sprites/weaponSprite1.png;weapons/sprites/weaponSprite2.png;weapons/sprites/weaponSprite3.png;weapons/sprites/weaponSprite4.png";
        private static int weaponIndex = 13;

        public Pistol(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 3;
            this.AttackSpeed = 1;
            this.animationSpeed = 10;
            meleeRangeX = 10;
        }
    }
}