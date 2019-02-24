using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    public class Activity
    {
        public int activityId {get; set;}

        [Required]
        public string title {get; set;}

        [Required]
        public string description {get; set;}

        //llave externa
        public int teamId {get; set;}
        
        //propiedad de navegacion a Team
        public Team team {get; set;}

        //pripiedad coleccion a Response
        public List<Response> responses {get; set;}

        //propiedad coleccion a Task
        public List<Task> tasks {get; set;}
    }
}