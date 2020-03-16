using Actimo.Business.DataProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Managers
{
    public interface IDataFeedManager
    {
        void CreateFeed(IInputDataProvider inputDataProvider);
    }
}
