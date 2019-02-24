using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    
    public class Task
    {
        public int taskId {get; set;}

        [Required]
        public string description {get; set;}

        public bool isCompleted {get; set;}
        
        //llave externa de Activity
        public int activityId {get; set;}

        //pripiedad de navegacion a Actividad
        public Activity activity {get; set;}

        //propiedad coleccion a TaskUser
        public List<TaskUser> taskUsers {get; set;}
    }
}