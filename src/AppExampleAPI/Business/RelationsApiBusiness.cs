using AppExampleAPI.Models;
using AppExampleAPI.Interfaces;
using Microsoft.Extensions.Logging;
using AppExampleAPI.Extensions;
using AppExampleAPI.Rules;

namespace AppExampleAPI.Business
{
    public class RelationsApiBusiness : IRelationsApi
    {
        public string ErrorLog { get; private set; }

        #region Singleton
        private static RelationsApiBusiness _instance;

        static RelationsApiBusiness()
        {

        }

        public static RelationsApiBusiness Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RelationsApiBusiness();
                }

                return _instance;
            }
        }
        #endregion

        public async Task<RelationsTabResponse> CreateRelations(IConfiguration config, RelationsTab relationsTab)
        {
            RelationsTabResponse response = new();
            RelationsTab objectCreated = null;

            if (relationsTab.ObjectA.ID.Equals(relationsTab.ObjectB.ID))
            {
                response.StatusCode = 401;
                response.Message = "The objects can not be the same";
            }
            else
            {
                try
                {
                    RelationsBusiness apiBusiness = new();
                    objectCreated = await apiBusiness.CreateRelations(config, relationsTab);
                    response.StatusCode = 200;
                    response.Message = "Object created";
                }
                catch (Exception ex)
                {
                    ErrorLog = "CreateRelations Error: " + ex.Message;
                }
            }

            response.Item = objectCreated;

            return response.PrepareResult();
        }

        public async Task<RelationsTabResponse> DeleteRelations(IConfiguration config, long ID)
        {
            RelationsTabResponse response = new();
            RelationsTab objectDeleted = null;

            try
            {
                RelationsBusiness apiBusiness = new();
                objectDeleted = await apiBusiness.DeleteRelations(config, ID);
                response.StatusCode = 200;
                response.Message = $"Relations ID {ID} Deleted";
            }
            catch (Exception ex)
            {
                ErrorLog = "DeleteRelations Error: " + ex.Message;
            }

            response.Item = objectDeleted;
            
            return response.PrepareResult();
        }
        
        public async Task<RelationsTabResponse> UpdateRelations(IConfiguration config, RelationsTab relationsTab)
        {
            RelationsTabResponse response = new();
            RelationsTab objectUpdated = null;

            if (relationsTab.ObjectA.ID.Equals(relationsTab.ObjectB.ID))
            {
                response.StatusCode = 401;
                response.Message = "The objects can not be the same";
                objectUpdated = relationsTab;
            }
            else
            {                
                try
                {
                    RelationsBusiness apiBusiness = new();
                    objectUpdated = await apiBusiness.UpdateRelations(config, relationsTab);
                    response.StatusCode = 200;
                    response.Message = $"Object Updated";
                }
                catch (Exception ex)
                {
                    ErrorLog = "UpdateRelationst Error: " + ex.Message;
                }
            }

            response.Item = objectUpdated;
            return response.PrepareResult();
        }

        public async Task<RelationsTabListResponse> GetAllRelations(IConfiguration config)
        {
            RelationsTabListResponse response = new();
            RelationsTabList objectList = null;

            try
            {
                RelationsBusiness apiBusiness = new();
                objectList = await apiBusiness.SelectAllRelations(config);
                response.StatusCode = 200;
                response.Message = $"Objects searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "GetAllRelations Error: " + ex.Message;
            }

            response.Item = objectList;
            return response.PrepareResult();
        }

        public async Task<RelationsTabListResponse> GetAllRelationsByName(IConfiguration config, string name)
        {
            RelationsTabListResponse response = new();
            RelationsTabList objectList = null;

            try
            {
                RelationsBusiness apiBusiness = new();
                objectList = await apiBusiness.SelectRelationsByName(config, name);
                response.StatusCode = 200;
                response.Message = $"Relations searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "GetAllRelationsByName Error: " + ex.Message;
            }

            response.Item = objectList;
            return response.PrepareResult();
        }

        public async Task<List<string>> GetRelationsAutoComplete(IConfiguration config, string name)
        {
            List<string> listReturn = new List<string>();

            try
            {
                RelationsBusiness apiBusiness = new();
                listReturn = await apiBusiness.SelectRelationsNameAutoComplete(config, name);                
            }
            catch (Exception ex)
            {
                ErrorLog = "GetRelationsAutoComplete Error: " + ex.Message;
            }


            return listReturn;
        }
    }
}
