using System.Threading.Tasks;
using Refit;
using TestApp.WebApp.Models.ReqRes;

namespace TestApp.WebApp.HttpClients;

public interface IReqResApi
{
    [Get("/users/{id}")]
    Task<SingleItemResponse<User>> GetUser(int id);

    [Get("/users")]
    Task<CollectionResponse<User>> GetUsers(int page);
}
