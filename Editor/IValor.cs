using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IValor
    {
        public bool ValorMayor(IValor valor);

        public bool ValorMayor(List<IValor> valores);
    }
}