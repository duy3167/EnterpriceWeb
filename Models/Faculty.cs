using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnterpriceWeb.Models
{
    public class Faculty
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int f_id { get; set; }


        [Required(ErrorMessage = "Faculty name not empty")]
        public string f_name { get; set; }
    }
}
