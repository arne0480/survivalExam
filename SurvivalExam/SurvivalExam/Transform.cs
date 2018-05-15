using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Transform : Component
    {
        private Vector2 position;


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Transform(GameObject gameObject, Vector2 position)
        {
            this.position = position;
        }

        public void Translate(Vector2 translation)
        {
            position += translation;
        }
    }
}