namespace RichEnum.Playground.Domain.ShippingStrategies;

public abstract class ShippingStrategy : ShippingService, IShippingStrategy
{
    protected ShippingStrategy(EShippingService service, string name) : base(service, name)
    {
    }

    public abstract decimal CalculateShipping(decimal weight, decimal distance);
}
