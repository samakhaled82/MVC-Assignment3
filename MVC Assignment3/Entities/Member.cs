namespace MVC_Assignment2.Entities
{
    public class Member : GymUser
    {
        public string Photo { get; set; } = default!;

        public ICollection<Membership> MemberSubscriptions { get; set; } = default!;

    }
}
