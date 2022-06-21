namespace AppExampleAPI.Models
{
    public class TypeTab
    {
        public TypeTab()
        {
            Id = 0;
            Description = String.Empty;
        }

        public int Id { get; set; }

        /// <summary>
        /// Type description can not be null
        /// </summary>
        public string Description { get; set; }    
    }
}
