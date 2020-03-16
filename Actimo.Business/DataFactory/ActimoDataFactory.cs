using Actimo.Business.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.DataFactory
{
    public class ActimoDataFactory : IActimoDataFactory
    {
        private IEnumerable<IDataEngine> dataEngines;

        public ActimoDataFactory(IContactDataEngine contactDataEngine,
            IContactMangerDataEngine contactMangerDataEngine)
        {
            dataEngines = new List<IDataEngine>
            {
                contactDataEngine,
                contactMangerDataEngine
            };
        }

        public IEnumerable<IDataEngine> GetAllDataEngines()
        {
            return dataEngines;
        }
    }
}
