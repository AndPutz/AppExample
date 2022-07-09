using AppExampleAPI.Models;
using AppExampleAPI.Interfaces;
using Microsoft.Extensions.Logging;
using AppExampleAPI.Extensions;
using AppExampleAPI.Rules;

namespace AppExampleAPI.Business
{
    public class ObjectApiBusiness : IObjectApi
    {
        public string ErrorLog { get; private set; }

        #region Singleton
        private static ObjectApiBusiness _instance;

        static ObjectApiBusiness()
        {

        }

        public static ObjectApiBusiness Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ObjectApiBusiness();
                }

                return _instance;
            }
        }
        #endregion

        public async Task<ObjectTabResponse> CreateObject(IConfiguration config, ObjectTab objectTab)
        {
            ObjectTabResponse response = new();
            Entity objectCreated = null;

            try
            {
                ObjectBusiness apiBusiness = new ();
                objectCreated = await apiBusiness.CreateObject(config, objectTab);
                response.StatusCode = 200;
                response.Message = "Object created";
            }
            catch(Exception ex)
            {
                ErrorLog = "CreateObject Error: " + ex.Message;
            }

            response.Item = objectCreated;

            return response.PrepareResult();
        }

        public async Task<ObjectTabResponse> DeleteObject(IConfiguration config, long ID)
        {
            ObjectTabResponse response = new();
            ObjectTab objectDeleted = null;

            try
            {
                ObjectBusiness apiBusiness = new();
                objectDeleted = await apiBusiness.DeleteObject(config, ID);
                response.StatusCode = 200;
                response.Message = $"Object ID {ID} Deleted";
            }
            catch (Exception ex)
            {
                ErrorLog = "DeleteObject Error: " + ex.Message;
            }

            response.Item = objectDeleted;
            
            return response.PrepareResult();
        }
        
        public async Task<ObjectTabResponse> UpdateObject(IConfiguration config, ObjectTab objectTab)
        {
            ObjectTabResponse response = new();
            Entity objectUpdated = new();
            
            TabList types = await new TypeBusiness().SelectAll(config);
            if (types.FirstOrDefault(x => x.Id.Equals(objectTab.Type.Id)) == null)
            {
                response.StatusCode = 404;
                response.Message = $"Type not exists";
            }
            else
            {
                try
                {
                    ObjectBusiness apiBusiness = new();
                    objectUpdated = await apiBusiness.UpdateObject(config, objectTab);
                    response.StatusCode = 200;
                    response.Message = $"Object Updated";
                }
                catch (Exception ex)
                {
                    ErrorLog = "UpdateObject Error: " + ex.Message;
                }
            }

            response.Item = objectUpdated;
            return response.PrepareResult();
        }

        public async Task<ObjectTabListResponse> GetAllObjects(IConfiguration config)
        {
            ObjectTabListResponse response = new();
            ObjectTabList objectList = null;

            try
            {
                ObjectBusiness apiBusiness = new();
                objectList = await apiBusiness.SelectAllObjects(config);
                response.StatusCode = 200;
                response.Message = $"Objects searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "UpdateObject Error: " + ex.Message;
            }

            response.Item = objectList;
            return response.PrepareResult();
        }

        public async Task<ObjectTabListResponse> GetAllObjectsByName(IConfiguration config, string name)
        {
            ObjectTabListResponse response = new();
            ObjectTabList objectList = null;

            try
            {
                ObjectBusiness apiBusiness = new();
                objectList = await apiBusiness.SelectObjectsByName(config, name);
                response.StatusCode = 200;
                response.Message = $"Objects searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "GetAllObjectsByName Error: " + ex.Message;
            }

            response.Item = objectList;
            return response.PrepareResult();
        }

        public async Task<ObjectTabResponse> GetObjectById(IConfiguration config, long ID)
        {
            ObjectTabResponse response = new();
            ObjectTab objectItem = null;

            try
            {
                ObjectBusiness apiBusiness = new();
                objectItem = await apiBusiness.SelectObjectsById(config, ID);
                response.StatusCode = 200;
                response.Message = $"Objects searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "GetAllObjectsByName Error: " + ex.Message;
            }

            response.Item = objectItem;
            return response.PrepareResult();
        }

        public async Task<List<string>> GetObjectsAutoComplete(IConfiguration config, string name)
        {
            List<string> listReturn = new List<string>();

            try
            {
                ObjectBusiness apiBusiness = new();
                listReturn = await apiBusiness.SelectObjectsNameAutoComplete(config, name);                
            }
            catch (Exception ex)
            {
                ErrorLog = "GetObjectsAutoComplete Error: " + ex.Message;
            }


            return listReturn;
        }
    }
}
