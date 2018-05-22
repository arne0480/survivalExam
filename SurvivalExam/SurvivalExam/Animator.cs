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
        private Rectangle[] rectangles = new Rectangle[8];
        string animationsName;
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();

        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponets("SpriteRenderer");
        }
        public void Update()
        {

            timeElapse += GameWorld.Instance.deltaTime;
            currentIndex = (int)(timeElapse * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                gameObject.OnAnimationDone(animationsName);
                timeElapse = 0;
                currentIndex = 0;
            }
            spriteRenderer.Rectangle = rectangles[currentIndex];
        }
        public void CreateAnimation(string name, Animation animation)
        {
            animations.Add(name, animation);
        }
        public void PlayAnimations(string animationsName)
        {
            if (this.animationsName != animationsName)
            {
                this.rectangles = animations[animationsName].Rectangles;
                this.spriteRenderer.Rectangle = rectangles[0];
                this.spriteRenderer.Offset = animations[animationsName].Offset;

                this.animationsName = animationsName;
                this.fps = animations[animationsName].fps;

                timeElapse = 0;
                currentIndex = 0;

            }
        }
    }
}
