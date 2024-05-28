namespace RichEnum.Playground.Domain.ShippingStrategies;

public sealed class PostalServiceShipping(string name)
    : ShippingStrategy(EShippingService.PostalService, name)
{
    private const decimal W_WEIGHT = .25m;
    private const decimal D_WEIGHT = .68m;
    private const decimal E_CONSTANT = 15.5m;

    public override decimal CalculateShipping(decimal weight, decimal distance)
    {
        return Math.Round(weight * W_WEIGHT + distance * D_WEIGHT + E_CONSTANT, 2);
    }
}
