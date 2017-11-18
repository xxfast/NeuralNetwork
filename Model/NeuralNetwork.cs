using System;
using System.Collections.Generic;

namespace xf
{
    public class NeuralNetwork: Network<Input>
    {
        private List<Input> inputs = new List<Input>();
        private List<Neuron> hiddens = new List<Neuron>();
        private List<Neuron> outputs = new List<Neuron>();

        public List<Input> Inputs { get => inputs; set => inputs = value; }
        public List<Neuron> Hiddens { get => hiddens; set => hiddens = value; }
        public List<Neuron> Outputs { get => outputs; set => outputs = value; }

        public NeuralNetwork() { Initialise(3,4,2); }
        public NeuralNetwork(int i, int h, int o) { Initialise(i,h,o); }

        private void Initialise(int i, int h, int o)
        {
            for (int _i = 0; _i < i; _i++) inputs.Add(new Input());
			for (int _h = 0; _h < i; _h++) hiddens.Add(new Neuron(inputs));
			for (int _o = 0; _o < i; _o++) outputs.Add(new Neuron(hiddens));
        }

        public List<float> FeedForward(List<float> inputs){
            if (inputs.Count < this.inputs.Count) throw new IndexOutOfRangeException();
            List<float> toReturn = new List<float>();
            for (int i = 0; i < inputs.Count; i++) Inputs[i].Value = inputs[i];
			for (int j = 0; j < hiddens.Count; j++) hiddens[j].Activate();
            for (int k = 0; k < outputs.Count; k++) toReturn.Add(hiddens[k].Activate());
			return toReturn;
        }
    }
}
