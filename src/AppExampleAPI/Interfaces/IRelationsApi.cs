using AppExampleAPI.Models;

namespace AppExampleAPI.Interfaces
{
    public interface IRelationsApi
    {
        Task<RelationsTabResponse> CreateRelations(IConfiguration config, RelationsTab objectTab);
        Task<RelationsTabResponse> UpdateRelations(IConfiguration config, RelationsTab objectTab);
        Task<RelationsTabResponse> DeleteRelations(IConfiguration config, long ID);
        Task<RelationsTabListResponse> GetAllRelations(IConfiguration config);

        Task<RelationsTabListResponse> GetAllRelationsByName(IConfiguration config, string name);

        Task<List<string>> GetRelationsAutoComplete(IConfiguration config, string name);

    }
}
