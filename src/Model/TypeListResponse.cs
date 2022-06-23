using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApp.Model
{
    [Serializable]
    [DataContract]
    public class TypeListResponse 
    {
        /// <summary>
        /// Status Code returned by WebAPI
        /// </summary>        
        [DataMember(Name = "StatusCode", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "StatusCode")]
        public int? StatusCode { get; set; }

        /// <summary>
        /// Status returned by WebAPI
        /// </summary>        
        [DataMember(Name = "Status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// Mensage returned by WebAPI
        /// </summary>        
        [DataMember(Name = "Message", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Item
        /// </summary>
        [DataMember(Name = "Item", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Item")]
        public TypeList Item { get; set; }

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
