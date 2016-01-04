﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Melee
{
    class BaseballBat : Weapon
    {
        private static string imagePath = "weapons/sprites/Baseballbat1.png;weapons/sprites/Baseballbat2.png;weapons/sprites/Baseballbat3.png;weapons/sprites/Baseballbat4.png";

        private static int weaponIndex = 6;

        public BaseballBat(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor, weaponIndex)
        {
            damage = 2;
            this.AttackSpeed = 0.5f;
            this.animationSpeed = 30;
            meleeRangeX = 40;
            meleeRangeY = 40;
            moveWeaponUp = -40;
            moveWeaponRight = 20;
        }
    }
}
