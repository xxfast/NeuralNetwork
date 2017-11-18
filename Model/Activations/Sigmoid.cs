using System;
using System.Collections.Generic;
namespace xf
{
    public class Sigmoid : Activation<float>
    {
        public override float Activate(float weightedSum, float bias)
        {
            return 1 / (1 + (float)Math.Exp(-(weightedSum + bias)));
        }
    }
}
