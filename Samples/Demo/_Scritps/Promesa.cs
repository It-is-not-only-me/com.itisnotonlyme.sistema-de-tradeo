using ItIsNotOnlyMe.SistemaDeTradeo;

public class Promesa : IPromesa
{
    private IObjeto _objetoPrometido;

    public Promesa(IObjeto objetoPrometido)
    {
        _objetoPrometido = objetoPrometido;
    }

    public IObjeto Exigir()
    {
        return _objetoPrometido;
    }
}


