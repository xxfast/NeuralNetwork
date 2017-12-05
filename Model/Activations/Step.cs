using System;
namespace xf
{
    public class Step : Activation<float> , IHaveTreshhold
	{
        private float treshhold = 0.5f;
		public float Treshhold { get => treshhold; set => treshhold = value; }

        public override float Activate(float weightedSum, float bias)
        {
            return (weightedSum > Treshhold)? 1:0;
        }
    }
}
