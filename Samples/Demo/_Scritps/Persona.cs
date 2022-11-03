using System.Collections.Generic;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class Persona : IPersona
{
    private List<IObjeto> _objetos;
    private List<IPromesa> _promesas;

    public Persona(List<IObjeto> objetos = null)
    {
        _objetos = (objetos != null) ? objetos : new List<IObjeto>();
        _promesas = new List<IPromesa>();
    }

    public IObjeto Exigir(IPromesa promesa)
    {
        IObjeto objetoPrometido = promesa.Exigir();
        if (!_objetos.Contains(objetoPrometido))
            return null;
        return objetoPrometido;
    }

    public void Recibir(IObjeto objeto)
    {
        _objetos.Add(objeto);
    }

    public void Recibir(IPromesa promesa)
    {
        _promesas.Add(promesa);
    }
}
