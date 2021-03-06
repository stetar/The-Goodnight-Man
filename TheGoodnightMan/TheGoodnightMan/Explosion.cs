﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopOne.Weapons.Sprites
{
    class Explosion : GameObject
    {
        private static string imagePath = "weapons/sprites/Explosion1.png;weapons/sprites/Explosion2.png;weapons/sprites/Explosion3.png;weapons/sprites/Explosion4.png;weapons/sprites/Explosion5.png;weapons/sprites/Explosion6.png;weapons/sprites/Explosion7.png;weapons/sprites/Explosion8.png;weapons/sprites/Explosion9.png;weapons/sprites/Explosion10.png;weapons/sprites/Explosion11.png;weapons/sprites/Explosion12.png";
        public static bool damageTaken = false;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="scaleFactor"></param>
        public Explosion(Vector2D startPos, float scaleFactor) : base(imagePath, startPos, scaleFactor)
        {

        }
        /// <summary>
        /// Handles the animation for the explosion
        /// </summary>
        /// <param name="fps"></param>
        public override void UpdateAnimation(float fps)
        {
            float factor = 1 / fps;

            currentFrameIndex += factor * animationSpeed;
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
                damageTaken = false;
                GameWorld.removeList.Add(this);
            }
            sprite = animationFrames[(int)currentFrameIndex];
        }
    }
}
