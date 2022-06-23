using AppExampleAPI.Models;

namespace AppExampleAPI.Interfaces
{
    public interface ITypeApi
    {
        Task<TypeTabListResponse> GetAll(IConfiguration config);

       

    }
}
