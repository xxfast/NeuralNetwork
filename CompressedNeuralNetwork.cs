using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Distributions;

namespace xann
{
	public class CompressedNeuralNetwork
	{
		private int _nI; // number of inputs
		private int _nH; // number of hidden 
		private int _nO; // number of outputs

		private Matrix<float> _iW; // input weights
		private Matrix<float> _oW; // output weights

		private Matrix<float> _aH; // activity of hidden 
		private Matrix<float> _aO; // activity of Output 

		private Matrix<float> _AH; // activation of hidden 
		private Matrix<float> _AO; // activation of hidden 

		public CompressedNeuralNetwork(int inputs, int hidden, int outputs)
		{
			_nI = inputs;
			_nH = hidden;
			_nO = outputs;
		}

		public CompressedNeuralNetwork() : this(2, 3, 1) 
		{
			_iW = Matrix<float>.Build.Random(_nI, _nH);
			_oW = Matrix<float>.Build.Random(_nH, _nO);
		}

		public Matrix<float> Forward(Matrix<float> input) {
			_aH = input.Multiply(_iW);
			_AH = Sigmoid(_aH);
			_aO = _AH.Multiply(_oW);
			_AO = Sigmoid(_aO);
			return _AO;
		}

		public Matrix<float> Sigmoid(Matrix<float> z)
		{
			float[] outs = new float[z.RowCount * z.ColumnCount];
			int i=0;
			foreach (float x in z.Enumerate())
			{
				outs[i++] = 1 / (1 + (float)Math.Exp(-x));
			}
			return Matrix<float>.Build.Dense(z.RowCount,z.ColumnCount,outs);
		}
	}
}
