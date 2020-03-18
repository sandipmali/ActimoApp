using System.Data;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository.Interface
{
    public interface IEngagementRepository
    {
        Task PushEngagementDataAsync(int clientId, DataTable engagementTable);
    }
}
