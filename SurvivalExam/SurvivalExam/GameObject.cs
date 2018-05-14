﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class GameObject : Component, IAnimateable
    {
        public Transform transform;
        public Transform GetTransform
        {
            get { return transform; }
            set { transform = value; }
        }

        List<Component> componets = new List<Component>();

        public GameObject()
        {
            this.transform = new Transform(this, Vector2.Zero);
            AddComponet(transform);
        }
        public void AddComponet(Component component)
        {
            componets.Add(component);
        }
        public void LoadContent(ContentManager content)
        {
            foreach (Component componet in componets)
            {
                if (componet is ILoad)
                {
                    (componet as ILoad).LoadContent(content);
                }
            }
        }
        public Component GetComponets(string componet)
        {
            return componets.Find(x => x.GetType().Name == componet);
        }
        public void Update()
        {
            foreach (Component componet in componets)
            {
                if (componet is IUpdate)
                {
                    (componet as IUpdate).Update();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component componet in componets)
            {
                if (componet is IDraw)
                {
                    (componet as IDraw).Draw(spriteBatch);
                }
            }

        }
        public void OnAnimationDone(string animationName)
        {
            foreach (Component componet in componets)
            {
                if (componet is IAnimateable)
                {
                    (componet as IAnimateable).OnAnimationDone(animationName);
                }
            }
        }
    }
}
