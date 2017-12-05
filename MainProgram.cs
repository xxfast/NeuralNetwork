using System;
namespace xf
{
	class MainClass
	{
		private static PerceptronTrainer trainer;
		private static Neuron toTrain;

		private static float[][] input = { new float[] { 0, 0 },
									new float[] { 0, 1 },
									new float[] { 1, 0 },
									new float[] { 1, 1 } };
		private static float[] output = { 0, 1, 1, 1 };

        public static void init()
		{
			trainer = new PerceptronTrainer();
            toTrain = new Perceptron(Input.FromArray(input[0]));

		}
		public static void Main(string[] args)
		{
            init();
            int trainCycles = 1000000;

            //Train Cycle 
			for (int n = 0; n < trainCycles;  n++)
            {
                for (int i = 0; i < input.Length;i++){
					trainer.Train(toTrain, input[i], output[i]);
                }
            }

			int testCycles = 100;
            float[] testOutput = {0,0,0,0};

			//Test Cycle 
			for (int n = 0; n < testCycles; n++)
			{
				for (int i = 0; i < output.Length; i++)
				{
					testOutput[i] += toTrain.Activate(input[i]);
				}
			}

			Console.WriteLine("Done!");

			for (int i = 0; i < output.Length; i++)
			{
				Console.WriteLine(toTrain.Activate(input[i]));
			}


		}
	}
}
