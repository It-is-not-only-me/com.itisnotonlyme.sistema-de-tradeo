using System.Collections.Generic;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class PersonaPrueba : IPersona
{
    private static int _interesInicial = 0;
    private int _nivelDeInteresMinimo;

    public PersonaPrueba(int nivelDeInteresMinimo)
    {
        _nivelDeInteresMinimo = nivelDeInteresMinimo;
    }

    public bool CriterioEvaluacion(List<IPromesa> promesas)
    {
        int interesInicial = _interesInicial;
        foreach (IPromesa promesa in promesas)
        {
            PromesaPrueba promesaPrueba = promesa as PromesaPrueba;
            interesInicial = promesaPrueba.ModificarInteres(interesInicial);
        }
        return interesInicial > _nivelDeInteresMinimo;
    }
}
