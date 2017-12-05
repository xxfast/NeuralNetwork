using System;
using System.Collections.Generic;

namespace xf
{
    public class PerceptronTrainer : Trainer
    {
        private float learningRate = 0.05f;

        public float LearningRate { get => learningRate; set => learningRate = value; }

        public override void Train(Neuron toTrain, float[] givenInputs, float expectedOutput)
        {
			List<float> newWeights = new List<float>();
            toTrain.Feed(Input.FromArray(givenInputs));
            float actualOutput = toTrain.Activate();
            float error = (expectedOutput - actualOutput);
            float learningAmount = LearningRate * error;
            foreach(KeyValuePair<Input, float> input in toTrain.Map){
                newWeights.Add( input.Value + (learningAmount * input.Key.Value));
            }
            toTrain.Tune(newWeights);
        }
    }
}
