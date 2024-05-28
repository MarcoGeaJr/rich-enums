namespace RichEnum.Playground.Domain.ShippingStrategies;

public sealed class CourierShipping(string name)
    : ShippingStrategy(EShippingService.Courier, name)
{
    private const decimal W_WEIGHT = .35m;
    private const decimal D_WEIGHT = .58m;
    private const decimal E_CONSTANT = 16m;

    public override decimal CalculateShipping(decimal weight, decimal distance)
    {
        return Math.Round(weight * W_WEIGHT + distance * D_WEIGHT + E_CONSTANT, 2);
    }
}
