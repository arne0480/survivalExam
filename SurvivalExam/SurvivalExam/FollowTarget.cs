using Microsoft.Xna.Framework;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurvivalExam.DIRECTION;

namespace SurvivalExam
{

    class FollowTarget : IStrategy
    {
        private Transform target;
        private Transform transform;
        private float movementSpeed = 40;
        private Animator animator;

        public FollowTarget(Transform target, Transform transform, Animator animator)
        {
            this.target = target;
            this.transform = transform;
            this.animator = animator;
        }

        public void Execute(ref DIRECTION currentDirection)
        {
            Vector2 translation = Vector2.Zero;

            if (target.position.Y >= transform.position.Y) //Op på skærmen
            {
                translation += new Vector2(0, 1);
                currentDirection = Up;
            }
            if (target.position.Y <= transform.position.Y) //Ned op skærmen
            {
                translation += new Vector2(0, -1);
                currentDirection = Down;
            }
            if (target.position.X <= transform.position.X) //Venstre på skærmen
            {
                translation += new Vector2(-1, 0);
                currentDirection = Left;
            }
            if (target.position.X >= transform.position.X) //Højre på skærmen
            {
                translation += new Vector2(1, 0);
                currentDirection = Right;
            }

            transform.Translate(translation * movementSpeed * GameWorld.Instance.DeltaTime);

            animator.PlayAnimations("Walk" + currentDirection);
        }
    }
}
