using System.Data;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository.Interface
{
    public interface IRelationshipRepository
    {
        Task PushRelationshipAsync(int clientId, int contactId, DataTable relationshipDataTable);
    }
}
