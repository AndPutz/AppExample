using AppExampleAPI.Models;
using AppExampleAPI.Interfaces;
using Microsoft.Extensions.Logging;
using AppExampleAPI.Extensions;
using AppExampleAPI.Rules;

namespace AppExampleAPI.Business
{
    public class ObjectApiBusiness : IObjectApi
    {
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
            ObjectTab objectCreated = null;

            try
            {
                ObjectBusiness apiBusiness = new ();
                objectCreated = await apiBusiness.CreateObject(config, objectTab);
            }
            catch(Exception ex)
            {

            }

            response.Item = objectCreated;
            return response.PrepareResult();
        }

        public Task<ObjectTabResponse> GetObjectById(long objectID)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectTabResponse> GetObjects()
        {
            throw new NotImplementedException();
        }

        public Task<ObjectTabResponse> UpdateObject(ObjectTab objectTab)
        {
            throw new NotImplementedException();
        }
        

    }
}
