using System;
namespace xf
{
    public class Step : Activation<float>
    {
        public override float Activate(float weightedSum, float bias)
        {
            return (weightedSum > Treshhold)? 1:0;
        }
    }
}
