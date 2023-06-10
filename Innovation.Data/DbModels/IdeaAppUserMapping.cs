using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Innovation.Data.DbModels
{
    public class IdeaAppUserMapping
    {
        public int IdeaId { get; set; }
        public int EmployeeId { get; set; }


        public bool IsActive { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
