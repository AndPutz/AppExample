namespace AppExampleAPI.Models
{
    public class TypeTab : Entity
    {
        public TypeTab()
        {
            Description = String.Empty;
        }

        /// <summary>
        /// Type description can not be null
        /// </summary>
        public string Description { get; set; }

    }
}
