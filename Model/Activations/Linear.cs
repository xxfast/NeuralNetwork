using System;
namespace xf
{
    public class Linear : Activation<float>
    {
        public override float Activate(float weightedSum, float bias)
        {
            return weightedSum + bias;
        }
    }
}
