namespace RichEnum.Playground.Domain;

public interface IShippingStrategy
{
	decimal CalculateShipping(decimal weight, decimal distance);
}
