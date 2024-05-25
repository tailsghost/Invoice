using Invoice.View;

namespace Invoice.Interface;

public interface ICondition
{
    public T ConditionType<T>(string text, List<Product>? products = null);
}