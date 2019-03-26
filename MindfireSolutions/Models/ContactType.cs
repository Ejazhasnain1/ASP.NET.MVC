using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindfireSolutions.Models
{
    public class ContactType
    {
        [Key]
        [Column(Order =0)]
        public int ContactTypeId { get; set; }
        public string ContactTypeValue { get; set; }
    }
}