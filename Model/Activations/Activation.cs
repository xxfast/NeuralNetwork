using System;
using System.Collections.Generic;
namespace xf
{
    public abstract class Activation<T>
    {
		public abstract T Activate(T weightedSum, T bias);
    }
}
