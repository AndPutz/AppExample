using AppExampleAPI.Models;

namespace AppExampleAPI.Interfaces
{
    public interface IObjectApi
    {
        Task<ObjectTabResponse> CreateObject(IConfiguration config,  ObjectTab objectTab);
        Task<ObjectTabResponse> UpdateObject(ObjectTab objectTab);
        Task<ObjectTabResponse> GetObjects();
        Task<ObjectTabResponse> GetObjectById(long objectID);
    }
}
