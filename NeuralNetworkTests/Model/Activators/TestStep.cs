using NUnit.Framework;
using System;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestStep
    {
        private Step step;
        private float bias = 0;

        [SetUp()]
        public void init(){
            step = new Step();
            step.Treshhold = 0.5f;
        }

        [Test()]
        public void TestStepActive()
        {
            float expected = 1;
            float actual = step.Activate(1,bias);
            Assert.AreEqual(expected,actual);
        }

		[Test()]
		public void TestStepInActive()
		{
			float expected = 0;
			float actual = step.Activate(0,bias);
			Assert.AreEqual(expected, actual);
		}
    }
}
