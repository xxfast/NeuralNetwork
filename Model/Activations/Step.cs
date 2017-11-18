using System;
namespace xf
{
    public class Step : Activation<float>
    {
        public override float Activate(Neuron toActivate)
        {
            return (toActivate.WeightedSum > Treshhold)? 1:0;
        }
    }
}
