namespace RichEnum.Playground.Domain.ShippingStrategies;

public sealed class ExpressShipping(string name)
    : ShippingStrategy(EShippingService.Express, name)
{
    private const decimal W_WEIGHT = .55m;
    private const decimal D_WEIGHT = .88m;
    private const decimal E_CONSTANT = 13m;

    public override decimal CalculateShipping(decimal weight, decimal distance)
    {
        return Math.Round(weight * W_WEIGHT + distance * D_WEIGHT + E_CONSTANT, 2);
    }
}
