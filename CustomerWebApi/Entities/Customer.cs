using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerWebApi.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int Id { get; set; }

        [Column("customer_name")]
        public string Name { get; set; }

        [Column("mobile_no")]
        public string Mobile { get; set; }

        [Column("email")]
        public string Email { get; set; }
    }
}
