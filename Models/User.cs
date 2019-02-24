using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    public class User
    {
        [Key]
        public long userId {get; set;}

        [Required]
        public string displayName {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string password {get; set;}

        [DataType(DataType.DateTime)]
        public System.DateTime lastLogin {get; set;}
    }
}