using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AppExampleAPI.Models
{
    [DataContract] 
    public class ObjectTabResponse : IEquatable<ObjectTabResponse>
    {

        /// <summary>
        /// Status Code returned from API HTTP request
        /// </summary>        
        [DataMember(Name = "StatusCode")]
        public int? StatusCode { get; set; }

        /// <summary>
        /// Enum that represents the StatusCode
        /// </summary>
        /// <value>Status da informações enviadas pela API</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {

            /// <summary>
            /// Enum NoneEnum for None
            /// </summary>
            [EnumMember(Value = "None")]
            NoneEnum = 1,

            /// <summary>
            /// Enum OKEnum for OK
            /// </summary>
            [EnumMember(Value = "OK")]
            OKEnum = 2,

            /// <summary>
            /// Enum ErrorEnum for Error
            /// </summary>
            [EnumMember(Value = "Error")]
            ErrorEnum = 3,

            /// <summary>
            /// Enum InvalidEnum for Invalid
            /// </summary>
            [EnumMember(Value = "Invalid")]
            InvalidEnum = 4
        }

        /// <summary>
        /// Information status sent to API
        /// </summary>        
        [DataMember(Name = "Status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// Return API Message
        /// </summary>        
        [DataMember(Name = "Message")]
        public string? Message { get; set; }

        /// <summary>
        /// Gets or Sets Item
        /// </summary>
        [DataMember(Name = "item")]
        public ObjectTab Item { get; set; }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ObjectTab)obj);
        }

        /// <summary>
        /// Returns true if Carrier instances are equal
        /// </summary>
        /// <param name="other">Instance of Carrier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObjectTabResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    StatusCode == other.StatusCode ||
                    StatusCode != null &&
                    StatusCode.Equals(other.StatusCode)
                ) &&
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                ) &&
                (
                    Message == other.Message ||
                    Message != null &&
                    Message.Equals(other.Message)
                ) &&
                (
                    Item != null &&
                    Item == other.Item &&
                    Item.Equals(other.Item)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)                                    
                if (StatusCode != null)
                    hashCode = hashCode * 59 + StatusCode.GetHashCode();                
                if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                if (Message != null)
                    hashCode = hashCode * 59 + Message.GetHashCode();
                if (Item != null)
                    hashCode = hashCode * 59 + Item.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObjectTabResponse left, ObjectTab right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObjectTabResponse left, ObjectTab right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators

    }
}
