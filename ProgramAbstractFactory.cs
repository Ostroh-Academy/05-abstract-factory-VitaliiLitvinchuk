using System;

public class Program
{
	public static void Main()
	{
		new FactoryResults().Results();
	}
	
	public class FactoryResults
	{
		public void Results()
		{
            FactoryMethod(new FactoryDimensional());
            Console.WriteLine();
		}
		
		public void FactoryMethod(IAbstractFactory factory)
        {
            var m2d = factory.CreateMatrix2D();
            var m3d = factory.CreateMatrix3D();

			var result2d = m2d.Function(3, 5);

			Console.WriteLine($"{result2d.GetLength(0)} {result2d[0].GetLength(0)}");
			
			var result3d = m3d.Function(3, 5, 10);

			Console.WriteLine($"{result3d.GetLength(0)} {result3d[0].GetLength(0)} {result3d[0][0].GetLength(0)}");
        }
	}
	
    public class FactoryDimensional : IAbstractFactory
    {
        public IAbstractMatrix2D CreateMatrix2D()
        {
            return new Matrix2D();
        }

		public IAbstractMatrix3D CreateMatrix3D()
        {
            return new Matrix3D();
        }
	}
	
	public interface IAbstractFactory 
	{
	 	IAbstractMatrix2D CreateMatrix2D();

        IAbstractMatrix3D CreateMatrix3D();
	}
	
	public interface IAbstractMatrix2D 
	{
		double[][] Function(int dimension1, int dimension2);
	}
		
	public class Matrix2D : IAbstractMatrix2D
	{
		public double[][] Function(int dimension1, int dimension2)
		{
			double[][] array = new double[dimension1][];
			
			for (int i = 0; i < dimension1; i++)
				array[i] = new double[dimension2];
			
			return array;
		}
	}
	
	public interface IAbstractMatrix3D
	{
		double[][][] Function(int dimension1, int dimension2, int dimension3);
	}
		
	public class Matrix3D : IAbstractMatrix3D
	{
		public double[][][] Function(int dimension1, int dimension2, int dimension3)
		{
			double[][][] array = new double[dimension1][][];
			
			for (int i = 0; i < dimension1; i++)
			{
				array[i] = new double[dimension2][];
				
				for (int b = 0; b < dimension2; b++)
					array[i][b] = new double[dimension3];
			}
			
			return array;
		}
	}
}
