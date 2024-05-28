using RichEnum.Enum;
using RichEnum.Playground.Domain.ShippingStrategies;

namespace RichEnum.Playground.Domain;

public class ShippingService : Enumeration
{
	public static readonly IShippingStrategy PostalService
		= new PostalServiceShipping(nameof(PostalService));

	public static readonly IShippingStrategy Courier
		= new CourierShipping(nameof(Courier));

	public static readonly IShippingStrategy Express
		= new ExpressShipping(nameof(Express));

	public ShippingService() { }

	protected ShippingService(
		EShippingService service,
		string name)
		: base(((int)service), name) { }

	public static IShippingStrategy FromService(EShippingService service)
	{
		return FromValue<ShippingService>((int)service) as IShippingStrategy;
	}
}
