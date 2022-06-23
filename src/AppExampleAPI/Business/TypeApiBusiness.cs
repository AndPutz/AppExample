using AppExampleAPI.Models;
using AppExampleAPI.Interfaces;
using Microsoft.Extensions.Logging;
using AppExampleAPI.Extensions;
using AppExampleAPI.Rules;

namespace AppExampleAPI.Business
{
    public class TypeApiBusiness : ITypeApi
    {
        public string ErrorLog { get; private set; }

        #region Singleton
        private static TypeApiBusiness _instance;

        static TypeApiBusiness()
        {

        }

        public static TypeApiBusiness Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TypeApiBusiness();
                }

                return _instance;
            }
        }
        #endregion

        
        public async Task<TypeTabListResponse> GetAll(IConfiguration config)
        {
            TypeTabListResponse response = new();
            TypeTabList list = null;

            try
            {
                TypeBusiness apiBusiness = new();
                list = await apiBusiness.SelectAll(config);
                response.StatusCode = 200;
                response.Message = $"Types searched";
            }
            catch (Exception ex)
            {
                ErrorLog = "GetAll Error: " + ex.Message;
            }

            response.Item = list;
            return response.PrepareResult();
        }

       

      
    }
}
