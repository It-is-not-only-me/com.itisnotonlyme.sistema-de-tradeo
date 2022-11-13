using System.Collections.Generic;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class PersonaQueIntentaPagarPrueba : IPersona
{
    private List<IObjeto> _objetos;

    public PersonaQueIntentaPagarPrueba()
        : this(new List<IObjeto>())
    {
    }

    public PersonaQueIntentaPagarPrueba(IObjeto objeto)
        : this(new List<IObjeto> { objeto })
    {
    }

    public PersonaQueIntentaPagarPrueba(List<IObjeto> objetos)
    {
        _objetos = (objetos == null) ? new List<IObjeto>() : objetos;
    }

    public void AgregarObjetos(IObjeto objeto)
    {
        _objetos.Add(objeto);
    }

    public IObjeto Exigir(IObjeto objeto)
    {
        if (!_objetos.Contains(objeto))
            return null;

        _objetos.Remove(objeto);
        return objeto;
    }

    public void SaldarDeuda(IDeuda deuda)
    {
        while (_objetos.Count > 0 && !deuda.EstaSaldada())
        {
            deuda.Saldar(_objetos[0]);
            _objetos.RemoveAt(0);
        }
    }
}
