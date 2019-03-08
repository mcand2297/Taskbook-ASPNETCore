using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    public class TaskUser
    {
        //llave externa a Task
        public int taskId {get; set;}

        //propiedad de navegacion a Task
        public Task task {get; set;}

        //llave externa a User
        public string userId {get; set;}

        //propiedad de navegacion a User
        public User user {get; set;}
    }
}