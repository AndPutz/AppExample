using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AppExampleAPI.Models
{
    [DataContract] 
    public class ObjectTab : IEquatable<ObjectTab>
    {
        public ObjectTab()
        {
            ID = 0;
            Name = string.Empty;
            Type = new TypeTab();
        }

        /// <summary>
        /// Object Table PK
        /// </summary>
        [DataMember(Name="ObjectID")]
        public long ID { get; set; }

        /// <summary>
        /// Object Name is unique and cant be null
        /// </summary>
        [DataMember(Name = "ObjectName")]
        public string Name { get; set; }

        /// <summary>
        /// Object description
        /// </summary>
        [DataMember(Name = "ObjectDescription")]
        public string? Description { get; set; }

        /// <summary>
        /// Object Type is register previously and cant be null
        /// </summary>
        [DataMember(Name = "ObjectType")]
        public TypeTab Type { get; set; }

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
        public bool Equals(ObjectTab other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ID == other.ID ||
                    ID.Equals(other.ID)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
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
                    hashCode = hashCode * 59 + ID.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObjectTab left, ObjectTab right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObjectTab left, ObjectTab right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators

    }
}
