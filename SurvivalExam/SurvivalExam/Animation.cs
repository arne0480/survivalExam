using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    class Animation
    {
        public float fps;

        public float Fps
        {
            get { return fps; }
            set { fps = value; }
        }
        public Vector2 offset;
        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }

        }
        public Rectangle[] rectangles;
        public Rectangle[] Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }
        public Animation(int frames, int ypos, int xStartFrame, int width, int height, float fps, Vector2 offset)
        {
            this.fps = fps;
            this.offset = offset;
            this.rectangles = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, ypos, width, height);
            }

        }
    }
}
