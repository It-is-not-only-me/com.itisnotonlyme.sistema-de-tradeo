using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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

public class MonedaPrueba : IObjeto
{
    private IValor _valor;

    public MonedaPrueba(IValor valor)
    {
        _valor = valor;
    }

    public IValor Valor() => _valor;
}

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

public class TradeoTest
{
    [Test]
    public void Test01PersonaSinObjetosNoPuedeSaldarDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IPersona persona = new PersonaQueIntentaPagarPrueba();

        persona.SaldarDeuda(deuda);

        Assert.IsFalse(deuda.EstaSaldada());
    }

    [Test]
    public void Test02PersonaConValorEquivalenteSaldaLaDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(valor);
        IPersona persona = new PersonaQueIntentaPagarPrueba(monedas);

        persona.SaldarDeuda(deuda);

        Assert.IsTrue(deuda.EstaSaldada());
    }

    [Test]
    public void Test03PersonaConMenosQueLaDeudaNoPuedeSaldarDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(new ValorPrueba(10));
        IPersona persona = new PersonaQueIntentaPagarPrueba(monedas);

        persona.SaldarDeuda(deuda);

        Assert.IsFalse(deuda.EstaSaldada());
    }

    [Test]
    public void Test04SePuedeUsarLaPromesaDeUnObjetoParaSaldarUnaDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(valor);
        IPersona deudor = new PersonaQueIntentaPagarPrueba(monedas);
        IPromesa promesa = new PromesaPrueba(monedas, deudor);

        IPersona persona = new PersonaQueIntentaPagarPrueba(promesa);

        persona.SaldarDeuda(deuda);

        Assert.IsTrue(deuda.EstaSaldada());
    }

    [Test]
    public void Test05AUnaPersonaSeLeExigeLoPrometido()
    {
        IValor valor = new ValorPrueba(25);
        IObjeto monedas = new MonedaPrueba(valor);
        IPersona deudor = new PersonaQueIntentaPagarPrueba(monedas);

        IPromesa promesa = new PromesaPrueba(monedas, deudor);

        Assert.AreEqual(monedas, promesa.Exigir());
    }
}
