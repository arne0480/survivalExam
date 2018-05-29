using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SurvivalExam
{
    class HealthBar
    {
        private Texture2D container, lifeBar;
        private Vector2 position;
        private int fullHealth;
        private int currentHealth;
        private int rateOfChange = 1;
        private Color barColor;

        public HealthBar(ContentManager content)
        {
            position = new Vector2(100, 100);
            LoadContent(content);
            fullHealth = lifeBar.Width;
            currentHealth = fullHealth;
        }

        private void LoadContent(ContentManager content)
        {
            container = content.Load<Texture2D>("Health bar");
            lifeBar = content.Load<Texture2D>("Health bar farve");
        }

        public void Update()
        {
            HealthColor();
            if (currentHealth >= 0)
                currentHealth -= rateOfChange;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(lifeBar, position, new Rectangle((int)position.X, (int)position.Y, currentHealth, lifeBar.Height), barColor);
            spriteBatch.Draw(container, position, Color.White);
        }

        public void HealthColor()
        {
            if (currentHealth >= lifeBar.Width * 0.75)
                barColor = Color.Green;
            else if (currentHealth >= lifeBar.Width * 0.5)
                barColor = Color.Yellow;
            else
            {
                barColor = Color.Red;
            }
        }
    }
}
