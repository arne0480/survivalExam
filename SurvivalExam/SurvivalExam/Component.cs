using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    abstract class Component
    {

        public GameObject gameObject { get; private set; }

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
    }
}
