using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class PersonaTest
{
    private IPersona _personaBasica = new PersonaPrueba(1);
    private IPersona _personaExigente = new PersonaPrueba(10);

    private IPromesa _promesaSimple = new PromesaSumaPrueba(1);
    private IPromesa _promesaDoble = new PromesaMultiPrueba(2);

    [Test]
    public void Test01PersonaBasicaSinPromesasNoAcepta()
    {
        List<IPromesa> listaPromesas = new List<IPromesa>();

        Assert.IsFalse(_personaBasica.CriterioEvaluacion(listaPromesas));
    }

    [Test]
    public void Test02PersonaBasicaConPromesasAcepta()
    {
        List<IPromesa> listaPromesas = new List<IPromesa> { _promesaSimple, _promesaSimple };

        Assert.IsTrue(_personaBasica.CriterioEvaluacion(listaPromesas));
    }

    [Test]
    public void Test03PersonaExigenteConPocasPromesasNoAcepta()
    {
        List<IPromesa> listaPromesas = new List<IPromesa> { _promesaSimple, _promesaSimple };

        Assert.IsFalse(_personaExigente.CriterioEvaluacion(listaPromesas));
    }

    [Test]
    public void Test04PersonaExigenteConMuchasPromesasAcepta()
    {
        List<IPromesa> listaPromesas = new List<IPromesa> { _promesaSimple, _promesaDoble, _promesaDoble, _promesaDoble, _promesaDoble };

        Assert.IsTrue(_personaExigente.CriterioEvaluacion(listaPromesas));
    }
}
