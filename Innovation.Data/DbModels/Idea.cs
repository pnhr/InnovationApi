using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovation.Data.DbModels
{
    [Table("tblIdeas")]
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IdeaRef { get; set; }
        public string IdeaName { get; set; }
        public string IdeaDescription { get; set; }

        public bool IsActive { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
