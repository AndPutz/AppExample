using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApp.Model
{
    /// <summary>
    /// Model of Object Table to extratc data from WebAPI
    /// </summary>
    [Serializable]
    [DataContract]
    public class ObjectModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public long ID { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public TypeModel? Type { get; set; }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}