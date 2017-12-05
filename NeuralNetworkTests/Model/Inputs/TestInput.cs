using NUnit.Framework;
using System;
using System.Collections.Generic;
using xf;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestInput
	{
        private Input input;

		[SetUp()]
		public void init()
		{
			input = new Input();
		}

        [Test()]
        public void TestFromArray(){
            List<Input> actual = Input.FromArray(new float[] { 1, 0.75f, 0.5f, 0 });
            float[] expected = new float[] { 1, 0.75f, 0.5f, 0 };
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i].Value);
            }
        }
    }
}
