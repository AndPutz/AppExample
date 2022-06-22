using AppExampleAPI.Models;

namespace AppExampleAPI.Interfaces
{
    public interface IObjectApi
    {
        Task<ObjectTabResponse> CreateObject(IConfiguration config, ObjectTab objectTab);
        Task<ObjectTabResponse> UpdateObject(IConfiguration config, ObjectTab objectTab);
        Task<ObjectTabResponse> DeleteObject(IConfiguration config, long ID);
        Task<ObjectTabListResponse> GetAllObjects(IConfiguration config);

        Task<ObjectTabListResponse> GetAllObjectsByName(IConfiguration config, string name);

        Task<List<string>> GetObjectsAutoComplete(IConfiguration config, string name);

    }
}
