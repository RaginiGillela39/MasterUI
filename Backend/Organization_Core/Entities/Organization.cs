namespace Organization_Domain.Entities
{
    public class Organization:BaseEntity    {            
        public string? Description { get; set; }
        [ForeignKey("OrganizationType")]
        public Guid Type {  get; set; }

    }
}
