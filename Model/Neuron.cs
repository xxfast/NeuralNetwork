using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace xf
{
    public class Neuron: Input
    {
        private Dictionary<Input, float> weights = new Dictionary<Input, float>();
        private float bias = 0;
        private Activation<float> activation = new Sigmoid();

		public Dictionary<Input, float> Weights { get => weights; set => weights = value; }
        public float Bias { get => bias; set => bias = value; }
		public virtual Activation<float> Activation { get => activation; set => activation = value; }

        public Neuron(){ }

        public Neuron(IEnumerable<Input> inputs){
            Feed(inputs);
		}

        public void Feed(IEnumerable<Input> inputs){

			foreach (Input i in inputs)
				weights.Add(i, 0);
		}

		public void Tune(IEnumerable<float> weights)
		{
            IEnumerator<float> i = weights.GetEnumerator();
            i.MoveNext();
            List<Input> toTune = new List<Input>();
            foreach (Input input in Weights.Keys){
                toTune.Add(input);

            }
            foreach(Input tuning in toTune){
				Weights[tuning] = i.Current;
                i.MoveNext();
            }
		}

        public float WeightedSum {
            get {
				float val = 0;
                foreach (Input n in Weights.Keys){
                    val += n.Value * Weights[n];
				}
				return val;
            }
        }


        public virtual float Activate(){
            Value = Activation.Activate(this);
            return Value;
        }
    }
}
