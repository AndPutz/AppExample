using System.Configuration;
using WebApp.Model;

namespace WebApp.Repository
{
    public class TypeRepository
    {
        protected NLog.Logger _loggerNLog = NLog.LogManager.GetCurrentClassLogger();
        //private readonly string basePathWebAPI = ConfigurationManager.AppSettings["WebAPIUrl"];
        private readonly string basePathWebAPI = "https://localhost:7133/";
        
        #region Singleton
        private static TypeRepository _instance;

        public static TypeRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TypeRepository();

                return _instance;
            }
        }

        private TypeRepository() { }
        
        #endregion

        public TypeListResponse GetAll()
        {
            TypeApi api = new TypeApi(basePathWebAPI);
            TypeListResponse response = api.GetAll();
            return response;
        }

    }
}