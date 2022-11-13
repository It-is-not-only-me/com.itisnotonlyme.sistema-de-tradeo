using ItIsNotOnlyMe.SistemaDeTradeo;

public class MonedaPrueba : IObjeto
{
    private IValor _valor;

    public MonedaPrueba(IValor valor)
    {
        _valor = valor;
    }

    public IValor Valor() => _valor;
}
