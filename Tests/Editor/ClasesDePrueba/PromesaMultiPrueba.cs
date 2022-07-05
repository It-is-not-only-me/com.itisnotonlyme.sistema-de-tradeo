public class PromesaMultiPrueba : PromesaPrueba
{
    public PromesaMultiPrueba(int interes)
        : base(interes)
    {
    }

    public override int ModificarInteres(int interesPrevio)
    {
        return interesPrevio * _interes;
    }
}
