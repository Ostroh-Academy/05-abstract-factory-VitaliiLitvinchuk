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
			Console.WriteLine("Result: Testing result code with the first factory type...");
            FactoryMethod(new Factory1());
            Console.WriteLine();

            Console.WriteLine("Result: Testing the same result code with the second factory type...");
            FactoryMethod(new Factory2());
		}
		
		public void FactoryMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.Function());
            Console.WriteLine(productB.Collaborant(productA));
        }
	}
	
    public class Factory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class Factory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
	
	public interface IAbstractFactory 
	{
	 	IAbstractProductA CreateProductA();

        IAbstractProductB CreateProductB();
	}
	
	public interface IAbstractProductA 
	{
		string Function();
	}
		
	public class ProductA1 : IAbstractProductA
	{
		public string Function()
		{
			return "Hello product a 1";
		}
	}
	
	public class ProductA2 : IAbstractProductA
	{
		public string Function()
		{
			return "Hello product a 2";
		}
	}
	
	public interface IAbstractProductB
	{
		string Function();
		string Collaborant(IAbstractProductA collaborator);		
	}
		
	public class ProductB1 : IAbstractProductB
	{
		public string Function()
		{
			return "Hello product b 1";
		}
		
		public string Collaborant(IAbstractProductA collaborator)
		{
			var result = $"{collaborator.Function()} from {nameof(ProductB1)}";
			
			return result;
		}
	}
	
	public class ProductB2 : IAbstractProductB
	{
		public string Function()
		{
			return "Hello product b 2";
		}
		
		public string Collaborant(IAbstractProductA collaborator)
		{
			var result = $"{collaborator.Function()} from {nameof(ProductB2)}";
			
			return result;
		}
	}
}
