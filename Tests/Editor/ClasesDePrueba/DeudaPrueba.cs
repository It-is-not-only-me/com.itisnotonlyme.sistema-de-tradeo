using ItIsNotOnlyMe.SistemaDeTradeo;

public class DeudaPrueba : IDeuda
{
    private IValor _valorASaldar;

    public DeudaPrueba(IValor valorASaldar)
    {
        _valorASaldar = valorASaldar;
    }

    public bool EstaSaldada()
    {
        return !_valorASaldar.Positivo();
    }

    public void Saldar(IObjeto objeto)
    {
        _valorASaldar.Disminuir(objeto.Valor());
    }
}
