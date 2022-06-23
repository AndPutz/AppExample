using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AppExampleAPI.Models
{
    [DataContract] 
    public class TypeTabList : List<TypeTab>, IEquatable<TypeTabList>
    {
               
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
            return obj.GetType() == GetType() && Equals((ObjectTabList)obj);
        }

        /// <summary>
        /// Returns true if TypeTabList instances are equal
        /// </summary>
        /// <param name="other">Instance of TypeTabList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TypeTabList other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return false;
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
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TypeTabList left, TypeTab right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TypeTabList left, TypeTab right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators

    }
}
