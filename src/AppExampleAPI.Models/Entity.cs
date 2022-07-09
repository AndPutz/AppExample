using Newtonsoft.Json;

namespace AppExampleAPI.Models
{
    public class Entity
    {
        public Entity()
        {
            Id = 0;
        }

        public virtual long Id { get; set; }

        /// <summary>
        /// Returns the JSON string presentation of the entity
        /// </summary>        
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }



    }
}