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
        private static string imagePath ="weapons/sprites/weaponSprite1.png;weapons/sprites/weaponSprite2.png;weapons/sprites/weaponSprite3.png;weapons/sprites/weaponSprite4.png";

        public Wrench(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {
            damage = 3;
            this.AttackSpeed = 0.7f;
            this.animationSpeed = 30;
            meleeRange = 1;
        }
    }
}