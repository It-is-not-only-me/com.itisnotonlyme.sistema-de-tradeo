using System.Collections.Generic;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class PersonaPrueba : IPersona
{
    private static int _interesInicial = 0;
    private int _nivelDeInteresMinimo;
    private int _interesAcumulado;

    public PersonaPrueba(int nivelDeInteresMinimo)
    {
        _nivelDeInteresMinimo = nivelDeInteresMinimo;
        _interesAcumulado = _interesInicial;
    }

    public bool CriterioEvaluacion(List<IPromesa> promesas)
    {
        int interesTotal = InteresAcumulado(promesas);
        return interesTotal > _nivelDeInteresMinimo;
    }

    public void Recibir(List<IPromesa> promesas)
    {
        _interesAcumulado = InteresAcumulado(promesas);
    }

    public int InteresAcumulado()
    {
        return _interesAcumulado;
    }

    private int InteresAcumulado(List<IPromesa> promesas)
    {
        int interesInicial = _interesInicial;
        foreach (IPromesa promesa in promesas)
        {
            PromesaPrueba promesaPrueba = promesa as PromesaPrueba;
            interesInicial = promesaPrueba.ModificarInteres(interesInicial);
        }
        return interesInicial;
    }
}
