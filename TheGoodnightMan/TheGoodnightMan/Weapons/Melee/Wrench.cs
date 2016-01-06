using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    internal class Wrench : Weapon
    {
        //public override float AttackSpeed { get; set; }
        private static string imagePath ="weapons/sprites/AxeSprite1.png;weapons/sprites/AxeSprite2.png;weapons/sprites/AxeSprite3.png;weapons/sprites/AxeSprite4.png";
        private static int weaponIndex = 0;

        public Wrench(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 2;
            this.AttackSpeed = 0.5f;
           // this.animationSpeed = 30;
            meleeRangeX = 1;
            meleeRangeY = 1;
            moveWeaponUp = -20;
            moveWeaponRight = 20;
        }
    }
}