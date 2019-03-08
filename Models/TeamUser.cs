using System.ComponentModel.DataAnnotations;

namespace Taskbook_ASPNETCore.Models{
    public class TeamUser
    {
        public bool isCreator {get; set;}

        //llave externa de Team
        public int teamId {get; set;}
        
        //propiedad navegacion a Team
        public Team team {get; set;}

        //llave externa de User
        public string userId {get; set;}

        //propiedad navegacion a User
        public User user {get; set;}
    }
}