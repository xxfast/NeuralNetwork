using NUnit.Framework;
using System;
using System.Collections.Generic;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestNeuron
    {
		private Neuron neuron;

		[SetUp()]
		public void init()
		{
			neuron = new Neuron();
		}

		[Test()]
		public void TestInitialise()
		{
			int expect = 0;
			int actual = neuron.Map.Count;
			Assert.AreEqual(expect, actual);
		}

		[Test()]
        public void TestInitialiseWithInputs()
        {
			neuron = new Neuron(Input.FromArray(new float[] { 0, 0, 0, 0 }));
            int expect = 4;
            int actual = neuron.Map.Count;
            Assert.AreEqual(expect,actual);
        }

		[Test()]
		public void TestFeed()
		{
            List<Input> values = Input.FromArray(new float[] { 1, 1, 1, 1 });
            neuron.Feed(values);

			int i = 0;
            foreach (Input actual in neuron.Map.Keys)
			{
                Input expect = values[i++];
                Assert.AreEqual(expect.Value, actual.Value);
			}

		}


		[Test()]
		public void TestTune()
		{
            float[] values = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };
            neuron.Tune(values);

            int i = 0;
            foreach(float actual in neuron.Map.Values){
				float expect = values[i++];
				Assert.AreEqual(expect, actual);
            }
		}

		[Test()]
		public void TestWeightedSum()
		{
			neuron.Feed(Input.FromArray(new float[] { 1, 1, 1, 1 }));

			float[] values = new float[] { 0.5f, 0.5f, 0.5f, 0.5f };
			neuron.Tune(values);

            float expect = 2.0f;
            float actual = neuron.WeightedSum;
			Assert.AreEqual(expect, actual);
		}
    }
}
