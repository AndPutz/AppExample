using System.Net;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Business
{
    public class TypeBusiness
    {
        static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        #region Singleton
        private static TypeBusiness _instance;

        public static TypeBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TypeBusiness();

                return _instance;
            }
        }

        private TypeBusiness() { }

        #endregion

        public TypeList GetAll()
        {
            TypeList list = new TypeList();

            try
            {
                TypeListResponse response = TypeRepository.Instance.GetAll();

                if (response?.StatusCode == (int)HttpStatusCode.OK && response.Item.Count > 0)
                {
                    list = response.Item;
                }

                return list;
            }
            catch(ApiException ex)
            {                
                _logger.Error(ex, $"TypeBusiness on GetAllObjects, error: {ex.Message}");
                throw ex;
            }            
        }
    }
}