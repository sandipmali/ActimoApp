using Actimo.Business.Services;
using Actimo.Data.Accesor.Entities;

namespace Actimo.Business.DataProvider
{
    public interface IInputDataProvider
    {
        ApiUriService ApiUriService { get; }
        Client Client { get; set; }
    }
}
