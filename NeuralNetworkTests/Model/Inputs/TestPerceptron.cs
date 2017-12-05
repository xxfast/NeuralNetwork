using NUnit.Framework;
using System;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestPerceptron
	{
        private Perceptron perceptron;

		[SetUp()]
		public void init()
		{
			perceptron = new Perceptron(Input.FromArray(new float[] { 1, 1, 1, 1 }));
			perceptron.Tune(new float[] { 1, 1, 1, 1 });
            IHaveTreshhold activation = perceptron.Activation as IHaveTreshhold;
            activation.Treshhold = 2.0f;
		}

		[Test()]
		public void TestWeightedSum()
		{
			float expect = 4.0f;
			float actual = perceptron.WeightedSum;
			Assert.AreEqual(expect, actual);
		}

        [Test()]
        public void TestActivate()
        {
            perceptron.Feed(Input.FromArray(new float[] { 1, 1, 1, 0 }));
            float expect = 1;
			float actual = perceptron.Activate();
			Assert.AreEqual(expect, actual);
        }

		[Test()]
		public void TestBorderlineActivate()
		{
			perceptron.Feed(Input.FromArray(new float[] { 0, 1, 1, 1 }));
			float expect = 1;
			float actual = perceptron.Activate();
			Assert.AreEqual(expect, actual);
		}


		[Test()]
		public void TestInactivate()
		{
			perceptron.Feed(Input.FromArray(new float[] { 0, 0, 0, 1 }));
			float expect = 0;
			float actual = perceptron.Activate();
			Assert.AreEqual(expect, actual);
		}
    }
}
