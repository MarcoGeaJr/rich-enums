# Rich Enumerations

This repository implements a base [Enumeration](https://github.com/MarcoGeaJr/rich-enums/blob/master/src/RichEnum.Enum/Enumeration.cs) class.

The Enumeration enriches the default System.Enum or enums. It makes it possible to transform simple enums into rich domain objects.

The basic usage of the enumeration can be seen below:
```csharp
public class EmployeeType : Enumeration
{
	public static readonly EmployeeType Manager = new(0, "Manager");
	public static readonly EmployeeType Servant = new(1, "Servant");
	public static readonly EmployeeType Assistant = new(2, "Assistant");

	private EmployeeType() { }
	private EmployeeType(int value, string displayName) : base(value, displayName) { }
}
```

This small example is already able to get around switch cases that are boring and sometimes unreadable.

But this can be even more powerful when combined with some type of behavior.

In the repository, you will also find an implementation, as shown in the example below, of a strategy pattern, for calculating the cost of shipping, which uses the enumeration base class.

Declares an enum with the types of shipping services and an interface for the strategy:
```csharp
public enum EShippingService
{
	PostalService,
	Courier,
	Express
}

public interface IShippingStrategy
{
	decimal CalculateShipping(decimal weight, decimal distance);
}
```

Implements an Enumeration class with all types of shipping services:
```csharp
public class ShippingService : Enumeration
{
	public static readonly IShippingStrategy PostalService
		= new PostalServiceShipping(nameof(PostalService));

	public static readonly IShippingStrategy Courier
		= new CourierShipping(nameof(Courier));

	public static readonly IShippingStrategy Express
		= new ExpressShipping(nameof(Express));

	...
}
```

Finally, it creates concrete implementations of shipping strategies:
```csharp
public abstract class ShippingStrategy : ShippingService, IShippingStrategy
{
  public abstract decimal CalculateShipping(decimal weight, decimal distance);
}

public sealed class PostalServiceShipping(string name)
    : ShippingStrategy(EShippingService.PostalService, name)
{
  public override decimal CalculateShipping(decimal weight, decimal distance)

  ...
}

public sealed class ExpressShipping(string name)
    : ShippingStrategy(EShippingService.Express, name)
{
  public override decimal CalculateShipping(decimal weight, decimal distance)

  ...
}

public sealed class CourierShipping(string name)
    : ShippingStrategy(EShippingService.Courier, name)
{
  public override decimal CalculateShipping(decimal weight, decimal distance)

  ...
}
```

This repository was inspired by the following sources:
[LosTechies](https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/)
[Microsoft](https://learn.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types)
[Ardalis](https://ardalis.com/enum-alternatives-in-c/)
