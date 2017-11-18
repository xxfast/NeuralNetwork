using System;
using System.Collections.Generic;
namespace xf
{
    public class Perceptron : Neuron
    {
        private Activation<float> activation = new Step();
        public override Activation<float> Activation { get => activation; set => activation = value; }

		public Perceptron() { }

		public Perceptron(IEnumerable<Input> inputs)
		{
			Feed(inputs);
		}

    }
}
