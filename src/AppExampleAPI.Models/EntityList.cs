using Newtonsoft.Json;

namespace AppExampleAPI.Models
{
    public abstract class EntityList : List<Entity>
    {
        public abstract bool Equals(object obj);

        public abstract bool Equals(Entity other);

        public abstract int GetHashCode();

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static bool operator ==(EntityList left, Entity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityList left, Entity right)
        {
            return !Equals(left, right);
        }
    }
}
