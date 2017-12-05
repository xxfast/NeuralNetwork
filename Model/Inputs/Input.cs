using System;
using System.Collections.Generic;

namespace xf
{
    public class Input
    {
        private float value;

        public float Value { get => value; set => this.value = value; }

		public Input() { }

        public Input(float val){
            value = val;
        }

        public static List<Input> FromArray(float[] array){
            List<Input> toReturn = new List<Input>();
            foreach (float val in array){
                toReturn.Add(new Input(val));
            }
            return toReturn;
        }
    }
}
