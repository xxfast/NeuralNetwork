using System;
using System.Collections.Generic;

namespace xf
{
    public class Network<T>
    {
        List<T> nodes = new List<T>();

        public T this [int i]{
            get { return nodes[i]; }
        }

        public T Map(T toMap){
            nodes.Add(toMap);
            return toMap;
        }
    }
}
