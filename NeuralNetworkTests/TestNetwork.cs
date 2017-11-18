using NUnit.Framework;
using xf;
using System;
namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestNetwork
    {
        private Network<int> network;

		[SetUp()]
		public void init()
		{
			network = new Network<int>();
		}

        [Test()]
        public void TestMap()
		{
			network.Map(1);
            int expected = 1;
            int actual = network[0];
            Assert.AreEqual(expected,actual);
        }
    }
}
