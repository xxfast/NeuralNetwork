using NUnit.Framework;
using System;
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
    }
}
