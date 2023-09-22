using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpeedrunsaver.Models
{
    public class Rule
    {
        public int Id { get; set; }
        public string RuleDescription { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
