using System.ComponentModel.DataAnnotations;


namespace ItemList.Client.Requests.Create {
    public class ItemCreateDTO {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public int? CategoryId { get; set; }
    }
}
