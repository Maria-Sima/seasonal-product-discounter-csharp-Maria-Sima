using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public abstract class IDiscount
{
    public abstract bool Accepts(Product product, DateTime date);
    public virtual string Name { get; }
    public virtual int Rate { get; }
}