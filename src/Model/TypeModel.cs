using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WebApp.Model
{
    /// <summary>
    /// Type of Object to extratc data from WebAPI
    /// </summary>
    [Serializable]
    [DataContract]
    public class TypeModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }        

        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
       

    }
}