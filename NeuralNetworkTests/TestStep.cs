using NUnit.Framework;
using xf;
using System;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestStep
    {
        private Step step;
        private Neuron neuron;

        [SetUp()]
        public void init(){
            step = new Step();
            neuron = new Neuron();
        }

        [Test()]
        public void TestStepActive()
        {
            float expected = 1;
            float actual = step.Activate(neuron);
            Assert.AreEqual(expected,actual);
        }
    }
}
