using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Taskbook_ASPNETCore.Models{
    public class Response
    {
        public int responseId {get; set;}

        [Required]
        public string content {get; set;}

        //llave externa de Activity
        public int activityId {get; set;}

        //propiedad de navegacion a Activity
        public Activity activity {get; set;}

        //propiedad de navegacion a User indicando que una respuesta esta relacionada a un usuario
        public User user {get; set;}
    }
}