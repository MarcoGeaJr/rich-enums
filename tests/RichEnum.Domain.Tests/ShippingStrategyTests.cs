using RichEnum.Playground.Domain;

namespace RichEnum.Domain.Tests;

public class ShippingStrategyTests
{
	[Theory]
	[InlineData(10, 10, 24.8)]
	public void PostalServiceShipping_CalculateShipping_ShouldReturnExpectedCost(decimal weight, decimal distance, decimal expectedCost)
	{
		IShippingStrategy postalServiceShipping = ShippingService.FromService(EShippingService.PostalService);

		var cost = postalServiceShipping.CalculateShipping(weight, distance);

		Assert.Equal(expectedCost, cost);
	}

	[Theory]
	[InlineData(10, 10, 25.3)]
	public void CourierShipping_CalculateShipping_ShouldReturnExpectedCost(decimal weight, decimal distance, decimal expectedCost)
	{
		IShippingStrategy courierShipping = ShippingService.FromService(EShippingService.Courier);

		var cost = courierShipping.CalculateShipping(weight, distance);

		Assert.Equal(expectedCost, cost);
	}

	[Theory]
	[InlineData(10, 10, 27.3)]
	public void ExpressShipping_CalculateShipping_ShouldReturnExpectedCost(decimal weight, decimal distance, decimal expectedCost)
	{
		IShippingStrategy expressShipping = ShippingService.FromService(EShippingService.Express);

		var cost = expressShipping.CalculateShipping(weight, distance);

		Assert.Equal(expectedCost, cost);
	}
}