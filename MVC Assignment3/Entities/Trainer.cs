using MVC_Assignment2.Entities.Enum;

namespace MVC_Assignment2.Entities
{
    public class Trainer : GymUser
    {
     
        public DateTime HireDate { get; set; }


        public Specialties Specialties { get; set; }

        //1 trainer can have many sessions
        public List<Session> Sessions { get; set; } = default!;

    }


}
