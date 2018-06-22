using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Animator : Component, IUpdate
    {
        private SpriteRenderer spriteRenderer;
        private int currentIndex;
        private float timeElapse;
        private float fps;
        private Rectangle[] rectangles;
        string animationName;
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponets("SpriteRenderer");
        }
        public void Update()
        {

            timeElapse += GameWorld.Instance.DeltaTime;
            currentIndex = (int)(timeElapse * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(animationName);
                timeElapse = 0;
                currentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[currentIndex];
        }
        public void CreateAnimation(string name, Animation animation)
        {
            animations.Add(name, animation);
        }
        public void PlayAnimations(string animationName)
        {
            if (this.animationName != animationName)
            {
                this.rectangles = animations[animationName].Rectangles;
                this.spriteRenderer.Rectangle = rectangles[0];
                this.spriteRenderer.Offset = animations[animationName].Offset;

                this.animationName = animationName;
                this.fps = animations[animationName].fps;

                timeElapse = 0;
                currentIndex = 0;

            }
        }
    }
}
