using System.Threading.Tasks;
using Refit;
using WebApp.Models.ReqRes;

namespace WebApp.HttpClients
{
    public interface IReqResApi
    {
        [Get("/users/{id}")]
        Task<SingleItemResponse<User>> GetUser(int id);

        [Get("/users")]
        Task<CollectionResponse<User>> GetUsers(int page);
    }
}
