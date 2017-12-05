using NUnit.Framework;
using System;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestLinear
	{
        private Linear linear;
		private float bias = 0;

		[SetUp()]
		public void init()
		{
			linear = new Linear();
		}

		[Test()]
		public void TestLinearMaxActive()
		{
			float expected = 1;
			float actual = linear.Activate(1, bias);
			Assert.AreEqual(expected, actual);
		}

		[Test()]
		public void TestLinearMinInActive()
		{
			float expected = 0;
			float actual = linear.Activate(0, bias);
			Assert.AreEqual(expected, actual);
		}

		[Test()]
		public void TestLinearMiddleActive()
		{
            float expected = 0.5f;
			float actual = linear.Activate(0.5f, bias);
			Assert.AreEqual(expected, actual);
		}
    }
}
