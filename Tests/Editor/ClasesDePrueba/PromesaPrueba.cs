using ItIsNotOnlyMe.SistemaDeTradeo;

public class PromesaPrueba : IPromesa
{
    private IPersona _deudor;
    private IObjeto _objetoPrometido;

    public PromesaPrueba(IObjeto objeto, IPersona deudor)
    {
        _objetoPrometido = objeto;
        _deudor = deudor;
    }

    public IValor Valor() => _objetoPrometido.Valor();

    public IPersona Deudor() => _deudor;

    public IObjeto Exigir()
    {
        return Deudor().Exigir(_objetoPrometido);
    }
}
