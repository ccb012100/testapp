using System.Threading.Tasks;
using Refit;
using WebApp.Api.Models.ReqRes;

namespace WebApp.Api.HttpClients
{
    public interface IReqResApi
    {
        [Get("/users/{id}")]
        Task<SingleItemResponse<User>> GetUser(int id);

        [Get("/users")]
        Task<CollectionResponse<User>> GetUsers(int page);
    }
}
