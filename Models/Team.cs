using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    public class Team
    {
        [Key]
        public int teamId {get; set;}
        [Required]
        public string name {get; set;}
        
        [Required]
        public string description {get; set;}

        //propiedad coleccion a Activity
        public List<Activity> activities {get; set;}

        //propiedad coleccion a TeamUser
        public List<TeamUser> teamUsers {get; set;}
    }
}