using System;

namespace xf
{
    public abstract class Trainer
    {
        public abstract void Train(Neuron toTrain, float[] givenInputs, float expectedOutput);
    }
}
