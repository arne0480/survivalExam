using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    abstract class Component
    {

        public GameObject gameObject;

        public GameObject GameObject

        {
            get { return gameObject; }
            set { gameObject = value; }
        }
        public Component()
        {

        }
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
