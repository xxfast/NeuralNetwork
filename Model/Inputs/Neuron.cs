using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace xf
{
    public class Neuron: Input
    {
        private Dictionary<Input, float> inputWeightMap = new Dictionary<Input, float>();
        private float bias = 0;
        private Activation<float> activation = new Sigmoid();
        private Random rnd = new Random();

		public Dictionary<Input, float> Map { get => inputWeightMap; set => inputWeightMap = value; }
       
        public float Bias { get => bias; set => bias = value; }
		public virtual Activation<float> Activation { get => activation; set => activation = value; }
		
        public float[] Weights
		{
			get
			{
				float[] weights = new float[Map.Count];
				Map.Values.CopyTo(weights, 0);
				return weights;
			}
		}
        public Neuron(){ }

        public Neuron(IEnumerable<Input> inputs){
            Feed(inputs);
		}

        public void Feed(IEnumerable<float> inputs)
        {
            Feed(Input.FromArray((float[])inputs));
        }

        public void Feed(IEnumerable<Input> inputs){
            if(inputWeightMap.Count <= 0){
    			foreach (Input i in inputs)
                    inputWeightMap.Add(i, 0);
            }else{
				IEnumerator<Input> i = inputs.GetEnumerator();
                i.MoveNext();
                foreach(Input I in Map.Keys){
                    I.Value = i.Current.Value;
                    i.MoveNext();
                }
            }       
		}

		public void Tune(IEnumerable<float> weights)
		{
            IEnumerator<float> i = weights.GetEnumerator();
            i.MoveNext();
            List<Input> toTune = new List<Input>();
            foreach (Input input in Map.Keys){
                toTune.Add(input);

            }
            foreach(Input tuning in toTune){
				Map[tuning] = i.Current;
                i.MoveNext();
            }
		}

        public float WeightedSum {
            get {
				float val = 0;
                foreach (Input n in Map.Keys){
                    val += n.Value * Map[n];
				}
				return val;
            }
        }

        public virtual float Activate(){
            Value = Activation.Activate(WeightedSum, Bias);
            return Value;
        }

		public virtual float Activate(float[] input)
		{
            Feed(input);
            return Activate();
		}

	}
}
