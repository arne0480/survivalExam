using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SurvivalExamh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Enemy : Component, IUpdate, ILoad, ICollisionEnter, ICollisionExit
    {

        private IStrategy strategy;
        private Animator animator;
        DIRECTION currentDirection;
        private GameObject player;
        bool isAlive;
        bool threadStart = false;
        private int health;
        Player playerHealth;
        //static Semaphore semaphore = new Semaphore(1, 1);
        //static Mutex m = new Mutex();

        public Enemy(GameObject gameObject) : base(gameObject)
        {

        }
        public int Health
        {
            get
            {
                if (health < 0)
                {
                    health = 0;
                }
                return health;
            }
            set
            {
                if (value <= 100)
                {
                    health = value;
                }
            }
        }
        public void SetHealth(int health)
        {
            this.health = health;
        }

        public void Update()
        {

            if (threadStart == false)
            {
                Thread thread = new Thread(new ThreadStart(CheckForPlayer));
                isAlive = true;
                thread.IsBackground = true;
                thread.Start();
                threadStart = true;
            }
            else
            {
                strategy.Execute(ref currentDirection);
            }
            //   CheckForPlayer();
        }

        public void CheckForPlayer()
        {

            while (isAlive)
            {
                if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 150 && !(strategy is FollowTarget))
                {
                    strategy = new FollowTarget(player.transform, gameObject.transform, animator);
                }
                else if (Vector2.Distance(gameObject.transform.position, player.transform.position) > 150 && !(strategy is Idle))
                {
                    strategy = new Idle(animator);
                }
                if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 80 && !(strategy is Attack))
                {
                    strategy = new Attack(animator);
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            player = GameWorld.Instance.FindGameObjectWithTag("Player");

            animator = (Animator)gameObject.GetComponets("Animator");

            CreatAnimation();

            //animator.PlayAnimations("IdleRight");
            animator.PlayAnimations("IdleLeft");
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
        public void OnCollisionExit(Collider other)
        {
            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.White;
          //  playerHealth.Health -= 10;
        }
        public void OnCollisionEnter(Collider other)
        {

            (other.gameObject.GetComponets("SpriteRenderer") as SpriteRenderer).Color = Color.Red;
           
        }
    }
}