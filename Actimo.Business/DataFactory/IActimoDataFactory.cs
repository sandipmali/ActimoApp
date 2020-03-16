using Actimo.Business.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.DataFactory
{
    public interface IActimoDataFactory
    {
        IEnumerable<IDataEngine> GetAllDataEngines();
    }
}
