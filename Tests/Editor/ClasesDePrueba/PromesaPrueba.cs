using ItIsNotOnlyMe.SistemaDeTradeo;

public abstract class PromesaPrueba : IPromesa
{
    protected int _interes;

    public PromesaPrueba(int interes)
    {
        _interes = interes;
    }

    public abstract int ModificarInteres(int interesPrevio);
}
