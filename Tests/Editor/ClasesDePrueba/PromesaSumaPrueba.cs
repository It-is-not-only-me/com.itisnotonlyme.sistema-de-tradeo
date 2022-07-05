public class PromesaSumaPrueba : PromesaPrueba
{
    public PromesaSumaPrueba(int interes)
        : base(interes)
    {
    }

    public override int ModificarInteres(int interesPrevio)
    {
        return interesPrevio + _interes;
    }
}
