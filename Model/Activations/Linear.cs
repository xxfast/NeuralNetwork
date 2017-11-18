using System;
namespace xf
{
    public class Linear : Activation<float>
    {
        public override float Activate(Neuron toActivate)
        {
            return toActivate.WeightedSum;
        }
    }
}
