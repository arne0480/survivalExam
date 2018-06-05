using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Walk : IStrategy
    {
        Animator animator;
        Transform transform;
        GameObject gameObject;
        Player player;
        public GameObject other;
        float speed;

        public Walk(Transform transform, Animator animator, GameObject gameObject, float speed)
        {
            this.transform = transform;
            this.animator = animator;
            this.gameObject = gameObject;
            this.speed = speed;
        }

        public void Execute(ref DIRECTION currentDirection)
        {
            Vector2 translation = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();


            if (keyState.IsKeyDown(Keys.W))
            {
                currentDirection = DIRECTION.Up;
                animator.PlayAnimations("WalkUp");
                translation += new Vector2(0, -1);
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                currentDirection = DIRECTION.Down;
                animator.PlayAnimations("WalkDown");
                translation += new Vector2(0, 1);
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                currentDirection = DIRECTION.Left;
                animator.PlayAnimations("WalkLeft");
                translation += new Vector2(-1, 0);
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                currentDirection = DIRECTION.Right;
                animator.PlayAnimations("WalkRight");
                translation += new Vector2(1, 0);
            }

            gameObject.transform.Translate(translation * GameWorld.Instance.deltaTime * speed);
        }
    }
}
