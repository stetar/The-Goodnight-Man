using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using GameLoopOne.Props;

namespace GameLoopOne
{
    abstract class GameObject
    {
        protected Vector2D position;
        public Image sprite;
        
        protected List<Image> animationFrames;
        protected float currentFrameIndex;
        protected float scaleFactor;
        public float animationSpeed = 10;

        //Collision
        public RectangleF CollisionBox
        {
            get
            {
                return new RectangleF(
                    position.X, 
                    position.Y, 
                    sprite.Width * scaleFactor, 
                    sprite.Height * scaleFactor
                );
            }
        }
        //Vector 2D
        public Vector2D Position
        {
            get
            {
                return position;
            }
            set { position = value; }
        }   

        public GameObject(string imagePath, Vector2D startPos, float scaleFactor)
        {
            
            position = startPos;
            this.scaleFactor = scaleFactor;
            string[] imagePaths = imagePath.Split(';');
            animationFrames = new List<Image>();
            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }

            this.sprite = animationFrames[0];
        }


        public virtual void Draw(Graphics dc) //virtual because we want to override
        {
           dc.DrawImage(sprite, position.X, position.Y, sprite.Width * scaleFactor, sprite.Height * scaleFactor);
        #if DEBUG
            dc.DrawRectangle(new Pen(Brushes.Red), CollisionBox.X, CollisionBox.Y, CollisionBox.Width, CollisionBox.Height);
        #endif
        }

        public virtual void Update(float fps) //virtual because we want to override
        {
            CheckCollision();
        }

        public virtual void UpdateAnimation(float fps)
        {
            float factor = 1/fps;
            currentFrameIndex += factor*animationSpeed;
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }
            sprite = animationFrames[(int) currentFrameIndex];
        }

        /// <summary>
        /// Checks collision for all GameObjects
        /// </summary>
        protected void CheckCollision()
        {
            for (int i = 0; i < GameWorld.objects.Count; i++)
            {
                GameObject obj = GameWorld.objects[i];

                if (obj != this)
                {
                    if (IsCollidingWith(obj))
                    {
                        //Collision
                        OnCollision(obj);
                    }
                }
            }
        }
        public bool IsCollidingWith(GameObject other)
        {
            return CollisionBox.IntersectsWith(other.CollisionBox);
        }
        public virtual void OnCollision(GameObject other)
        {
            
        }

    }
}
