using ItIsNotOnlyMe.SistemaDeTradeo;

public class ValorPrueba : IValor
{
    private float _valor;

    public ValorPrueba(float valor)
    {
        _valor = valor;
    }

    public void Disminuir(IValor valor) => Disminuir(valor as ValorPrueba);

    public bool Positivo() => _valor > 0;

    private void Disminuir(ValorPrueba valor)
    {
        _valor -= valor._valor;
    }
}
