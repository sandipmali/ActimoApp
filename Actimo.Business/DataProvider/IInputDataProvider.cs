using Actimo.Business.Services;
using Actimo.Data.Accesor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.DataProvider
{
    public interface IInputDataProvider
    {
        ApiUriService ApiUriService { get; }
        Client Client { get; }
          
    }
}
