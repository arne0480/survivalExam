using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    abstract class Component
    {
        public GameObject gameObject { get; set; }
        public Component()
        {

        }
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
