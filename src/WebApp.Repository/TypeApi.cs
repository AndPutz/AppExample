using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Repository
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITypeApi
    {
        /// <summary>
        /// List all types in database
        /// </summary>        
        /// <returns>ObjectListResponse</returns>
        TypeListResponse GetAll();
    }

    public class TypeApi : ITypeApi
    {
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }
        
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TypeApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TypeApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        public TypeListResponse GetAll()
        {
            var path = "/SelectAllTypes";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();            
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { "api_key" };

            // make the HTTP request
            RestResponse response = (RestResponse)ApiClient.CallApi(path, Method.Get, queryParams, postBody, headerParams, formParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling SelectAllTypes: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling SelectAllTypes: " + response.ErrorMessage, response.ErrorMessage);

            return (TypeListResponse)ApiClient.Deserialize(response.Content, typeof(TypeListResponse), response.Headers);
        }       
    }
}
