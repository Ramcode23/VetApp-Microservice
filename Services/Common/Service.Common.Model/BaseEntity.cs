using System.ComponentModel.DataAnnotations;

namespace Service.Common.Model;

    public class BaseEntity
    {
        //TODO:Modify model
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeleteteAt { get; set; }

        public bool IsDeleted { get; set; } = false;

    }