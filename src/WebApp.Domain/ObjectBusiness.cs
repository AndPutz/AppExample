using System.Net;
using WebApp.Model;
using WebApp.Repository;

namespace WebApp.Business
{
    public class ObjectBusiness
    {
        static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        #region Singleton
        private static ObjectBusiness _instance;

        public static ObjectBusiness Insance
        {
            get
            {
                if (_instance == null)
                    _instance = new ObjectBusiness();

                return _instance;
            }
        }

        private ObjectBusiness() { }

        #endregion

        public ObjectList GetAllObjects()
        {
            ObjectList list = new ObjectList();

            try
            {
                ObjectListResponse response = ObjectRepository.Instance.GetAllObjects();

                if (response?.StatusCode == (int)HttpStatusCode.OK && response.Item.Count > 0)
                {
                    list = response.Item;
                }

                return list;
            }
            catch(ApiException ex)
            {                
                _logger.Error(ex, $"ObjectBusiness on GetObjectList, error: {ex.Message}");
                throw ex;
            }            
        }

        public ObjectModel GetObject(long Id)
        {
            ObjectModel item = new ObjectModel();

            try
            {
                ObjectResponse response = ObjectRepository.Instance.GetObjectById(Id);

                if (response?.StatusCode == (int)HttpStatusCode.OK && response.Item.ID > 0)
                {
                    item = response.Item;
                }

                return item;
            }
            catch (ApiException ex)
            {
                _logger.Error(ex, $"ObjectBusiness on GetObject, error: {ex.Message}");
                throw ex;
            }
        }
    }
}