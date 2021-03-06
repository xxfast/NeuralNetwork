﻿using NUnit.Framework;
using xf;
using System;

namespace NeuralNetworkTests
{
    [TestFixture()]
    public class TestStep
    {
        private Step step;

        [SetUp()]
        public void init(){
            step = new Step();
            step.Treshhold = 0.5f;
        }

        [Test()]
        public void TestStepActive()
        {
            float expected = 1;
            float actual = step.Activate(1,0);
            Assert.AreEqual(expected,actual);
        }

		[Test()]
		public void TestStepInActive()
		{
			float expected = 0;
			float actual = step.Activate(0,0);
			Assert.AreEqual(expected, actual);
		}
    }
}
