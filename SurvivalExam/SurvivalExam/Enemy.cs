using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Enemy : Component, IUpdate, ILoad, ICollisionEnter, ICollisionExit
    {
        // private float speed = 100;
        private IStrategy strategy;
        //  bool canEnemyMove = true;
        private Animator animator;
        DIRECTION currentDirection;
        private GameObject player;

        public Enemy(GameObject gameObject) : base(gameObject)
        {
            gameObject.Tag = "Enemy";
        }
        public void Update()
        {
            if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 150 && !(strategy is FollowTarget))
            {
                strategy = new FollowTarget(player.transform, gameObject.transform, animator);
            }
            else if (Vector2.Distance(gameObject.transform.position, player.transform.position) > 150 && !(strategy is Idle))
            {
                strategy = new Idle(animator);
            }

            strategy.Execute(ref currentDirection);
        }
        public void CreatAnimation()
        {
            animator.CreateAnimation("IdleLeft", new Animation(6, 320, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("IdleRight", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("WalkLeft", new Animation(8, 240, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("WalkRight", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("WalkUp", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("WalkDown", new Animation(8, 0, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("IdleUp", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("IdleDown", new Animation(6, 80, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("AttackRight", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("AttackLeft", new Animation(7, 400, 0, 80, 80, 7, new Vector2(0, 0)));

            animator.CreateAnimation("AttackUp", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));
            animator.CreateAnimation("AttackDown", new Animation(7, 160, 0, 80, 80, 7, new Vector2(0, 0)));

            //animator.CreateAnimation("DieLeft", new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero));
            //animator.CreateAnimation("DieRight", new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero));

        }
        public void LoadContent(ContentManager content)
        {
            player = GameWorld.Instance.FindGameObjectWithTag("Player");

            animator = (Animator)gameObject.GetComponets("Animator");

            CreatAnimation();

            animator.PlayAnimations("IdleRight");
        }

        public void OnCollisionExit(Collider other)
        {
            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.White;

        }

        public void OnCollisionEnter(Collider other)
        {

            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.Red;
        }
    }
}