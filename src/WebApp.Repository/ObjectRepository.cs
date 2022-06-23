using System.Configuration;
using WebApp.Model;

namespace WebApp.Repository
{
    public class ObjectRepository
    {
        protected NLog.Logger _loggerNLog = NLog.LogManager.GetCurrentClassLogger();
        //private readonly string basePathWebAPI = ConfigurationManager.AppSettings["WebAPIUrl"];
        private readonly string basePathWebAPI = "https://localhost:7133/";
        
        #region Singleton
        private static ObjectRepository _instance;

        public static ObjectRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ObjectRepository();

                return _instance;
            }
        }

        private ObjectRepository() { }
        
        #endregion

        public ObjectListResponse GetAllObjects()
        {
            ObjectApi api = new ObjectApi(basePathWebAPI);
            ObjectListResponse response = api.GetAllObjects();
            return response;
        }

        public ObjectResponse GetObjectById(long Id)
        {
            ObjectApi api = new ObjectApi(basePathWebAPI);
            ObjectResponse response = api.GetObjectById(Id);
            return response;
        }

        public ObjectResponse Update(ObjectModel objectModel)
        {
            ObjectApi api = new ObjectApi(basePathWebAPI);
            ObjectResponse response = api.Update(objectModel);
            return response;
        }
    }
}