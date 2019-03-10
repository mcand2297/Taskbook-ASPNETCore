using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Taskbook_ASPNETCore.Models{
    public class User: IdentityUser
    {   
        [Required]
        public override string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public System.DateTime lastLogin {get; set;}

        //llave externa de Response
        public int responseId {get; set;}

        //propiedad de navegacion a Response
        public Response response {get; set;}

        //propiedad coleccion a TeamUser
        public List<TeamUser> teamUsers {get; set;}

        //propiedad coleccion a TaskUser
        public List<TaskUser> taskUsers {get; set;}
    }
}