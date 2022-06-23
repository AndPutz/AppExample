using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApp.Model
{
    [Serializable]
    [DataContract]
    public class ObjectList : List<ObjectModel>
    {
        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
