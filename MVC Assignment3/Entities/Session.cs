using System.Security.Principal;

namespace MVC_Assignment2.Entities
{
    public class Session : BaseEntity
    {
        public string Descraption { get; set; } = default!;

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        //1 trainer can have many sessions
        public Trainer Trainer { get; set; } = default!;

        public int TrainerId { get; set; }

    }
}
