namespace AppExampleAPI.Models
{
    public class RelationsTab
    {
        public RelationsTab()
        {
            ID = 0;
            ObjectA = new ObjectTab();
            ObjectB = new ObjectTab();
        }

        /// <summary>
        /// Relations Table PK
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// Relantion between to objects and this case we call Object A
        /// </summary>
        public ObjectTab ObjectA { get; set; }

        /// <summary>
        /// Relantion between to objects and this case we call Object B
        /// </summary>
        public ObjectTab ObjectB { get; set; }

        
    }
}
