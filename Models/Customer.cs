using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }

        public DateTime CustomerAdded { get; set; }



    }

}
