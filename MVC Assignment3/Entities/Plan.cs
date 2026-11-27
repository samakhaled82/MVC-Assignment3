namespace MVC_Assignment2.Entities
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int DurationDays { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Membership> PlanSubscriptions { get; set; } = default!;


    }
}
