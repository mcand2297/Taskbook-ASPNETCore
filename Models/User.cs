using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Taskbook_ASPNETCore.Models{
    public class User
    {
        [Key]
        public int userId {get; set;}

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

        //llave externa de Response
        public int responseId {get; set;}

        //propiedad coleccion a TeamUser
        public List<TeamUser> teamUsers {get; set;}

        //propiedad coleccion a TaskUser
        public List<TaskUser> taskUsers {get; set;}
    }
}