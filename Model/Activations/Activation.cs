using System;
using System.Collections.Generic;
namespace xf
{
    public abstract class Activation<T>
    {
		private T treshhold;
		public T Treshhold { get => treshhold; set => treshhold = value; }
		public abstract T Activate(Neuron toActivate);
    }
}
