using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalExam
{
    interface ICollisionStay
    {
        void OnCollisionStay(Collider other);
    }
}
