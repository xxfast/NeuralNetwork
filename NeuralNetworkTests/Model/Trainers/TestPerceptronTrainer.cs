using NUnit.Framework;
using System;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestPerceptronTrainer
    {

		private PerceptronTrainer trainer;
        private Perceptron toTrain;

        private float[][] input = { new float[] { 0, 0 },
                                    new float[] { 0, 1 }, 
                                    new float[] { 1, 0 },
                                    new float[] { 1, 1 } };
		private float[] output = { 0, 1, 1, 1 };

		[SetUp()]
		public void init()
		{
			trainer = new PerceptronTrainer();
            trainer.LearningRate = 0.05f;
            toTrain = new Perceptron(Input.FromArray(input[0]));
            toTrain.Tune(new float[] { 0, 0 });
		}

		[Test()]
        public void TestTrainInactiveInputs()
        {
            float[] expectedWeights = {0, 0};

			trainer.Train(toTrain,input[0],output[0]);

            float[] actual = toTrain.Weights;

			for (int i = 0; i < expectedWeights.Length;i++){
                Assert.AreEqual(expectedWeights[i],actual[i]);
            }
		}

		[Test()]
		public void TestTrainMixInputs1()
		{
			float preoutput = toTrain.Activate();
			float error = (output[1] - preoutput);

			float[] expectedWeights = { 0 , 0.05f };

			trainer.Train(toTrain, input[1], output[1]);

			float[] actualWeights = toTrain.Weights;

			for (int i = 0; i < expectedWeights.Length; i++)
			{
				Assert.AreEqual(expectedWeights[i], actualWeights[i]);
			}

		}

		[Test()]
		public void TestTrainMixInputs2()
		{
			float preoutput = toTrain.Activate();
			float error = (output[2] - preoutput);

			float[] expectedWeights = { 0.05f , 0};

			trainer.Train(toTrain, input[2], output[2]);

			float[] actualWeights = toTrain.Weights;

			for (int i = 0; i < expectedWeights.Length; i++)
			{
				Assert.AreEqual(expectedWeights[i], actualWeights[i]);
			}

		}

		[Test()]
		public void TestTrainAllActiveInputs()
		{
            float preoutput = toTrain.Activate();
            float error = (output[3] - preoutput);

			float[] expectedWeights = { 0.05f, 0.05f };

			trainer.Train(toTrain, input[3], output[3]);

            float[] actualWeights = toTrain.Weights;

			for (int i = 0; i < expectedWeights.Length; i++)
			{
				Assert.AreEqual(expectedWeights[i], actualWeights[i]);
			}

		}
    }
}
