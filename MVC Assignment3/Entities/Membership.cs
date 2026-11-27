namespace MVC_Assignment2.Entities
{
    public class Membership: BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //1 member can have many memberships
        public Member Member { get; set; } = default!;
        public int MemberId { get; set; }

        //1 plan can have many memberships
        public Plan Plan { get; set; } = default!;
        public int PlanId { get; set; }

        //[NotMapped]
        public string Status => StartDate > DateTime.Now ? "UpComing" : EndDate > DateTime.Now ? "Active" : "Expaird";

    }
}
