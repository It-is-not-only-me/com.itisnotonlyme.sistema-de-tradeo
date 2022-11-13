using ItIsNotOnlyMe.SistemaDeTradeo;
using System.Collections.Generic;

public class ValorPrueba : IValor
{
    private float _valor;

    public ValorPrueba(float valor)
    {
        _valor = valor;
    }

    public bool ValorMayor(IValor valor) => ValorMayor(new List<IValor> { valor });

    public bool ValorMayor(List<IValor> valores)
    {
        float valorTotal = 0;
        foreach (IValor valor in valores)
            valorTotal += (valor as ValorPrueba)._valor;
        return _valor > valorTotal;
    }
}
