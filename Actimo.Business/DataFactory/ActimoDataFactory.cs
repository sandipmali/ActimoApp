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
            IContactMangerDataEngine contactMangerDataEngine,
            IEngagementDataEngine engagementDataEngine)
        {
            dataEngines = new List<IDataEngine>
            {
                contactDataEngine,
                contactMangerDataEngine,
                engagementDataEngine
            };
        }

        public IEnumerable<IDataEngine> GetAllDataEngines()
        {
            return dataEngines;
        }
    }
}
