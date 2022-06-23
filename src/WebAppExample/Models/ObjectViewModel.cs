namespace WebAppExample.Models
{
    public class ObjectViewModel
    {
        public List<ObjectItemViewModel> ListObjectsView { get; set; }

        public ObjectItemViewModel ObjectView { get; set; }

        public List<TypeViewModel> ListTypeView { get; set; } 

        public ObjectViewModel()
        {
            ListObjectsView = new List<ObjectItemViewModel>();
            ObjectView = new ObjectItemViewModel();
            ListTypeView = new List<TypeViewModel>();
        }
    }
}
