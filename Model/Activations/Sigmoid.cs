using System;
using System.Collections.Generic;
namespace xf
{
    public class Sigmoid : Activation<float>
    {
        public override float Activate(Neuron toActivate)
        {
            return 1 / (1 + (float)Math.Exp(-(toActivate.WeightedSum + toActivate.Bias)));
        }
    }
}
