using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
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
