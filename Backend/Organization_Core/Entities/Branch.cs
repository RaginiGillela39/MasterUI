namespace Organization_Domain.Entities
{
    public class Branch:BaseEntity
    {
        [ForeignKey("Organization")]
        public Guid Org_Id { get; set; }
    }
}
