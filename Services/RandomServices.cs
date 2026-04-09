namespace ApiBackendCsharp.Services;
using ApiBackendCsharp.Services;

public class RandomServices : IRandomServices
{
    private readonly int _value;

    public int Value
    {
        get => _value;
    }
    public RandomServices()
    {
        _value = new Random().Next(1000);
    }

}
