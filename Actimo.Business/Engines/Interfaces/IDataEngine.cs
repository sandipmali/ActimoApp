using Actimo.Business.DataProvider;
using Actimo.Business.Models;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IDataEngine
    {
        DataType dataType { get; }
        void FeedData(IInputDataProvider inputDataProvider);
        //void FeedData(DataTable dataTable);        
    }
}
