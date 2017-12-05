using NUnit.Framework;
using System;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestSigmoid
    {
        private Sigmoid sigmoid;
		private float bias = 0;

		[SetUp()]
		public void init()
		{
			sigmoid = new Sigmoid();
		}

		[Test()]
		public void TestSigmoidMax()
		{
            float expected = 0.75f;
			float actual = sigmoid.Activate(1, bias);
			Assert.AreEqual(expected, actual,0.025);
		}

		[Test()]
		public void TestSigmoidMin()
		{
			float expected = 0.5f;
			float actual = sigmoid.Activate(0, bias);
			Assert.AreEqual(expected, actual, 0.025);
		}
    }
}
