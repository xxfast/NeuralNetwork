using System;
using MathNet.Numerics.LinearAlgebra;

namespace xann
{
	public static class Utilities
	{
		public static Matrix<float> Standerdise(Matrix<float> to)
		{
			float[] outs = new float[to.RowCount * to.ColumnCount];
			int n = 0;
			float[] maxs = new float[to.ColumnCount];
			int i=0;
			foreach (Vector<float> cols in to.EnumerateColumns())
			{
				maxs[i] = cols[0];
				foreach (float val in cols) 
					maxs[i] = Math.Max(maxs[i], val);
				foreach (float val in cols) 
					outs[n++] = val/maxs[i];
				i++;
			}
			return Matrix<float>.Build.Dense(to.RowCount, to.ColumnCount, outs);
		}

		public static Matrix<float> Differentiate(Matrix<float> to, float min, float max) {
			return null;
		}
	}
}
