namespace Organization_Domain.Entities
{
    public class Department:BaseEntity
    {
        [ForeignKey("Organization")]
        public Guid Org_Id { get; set; }
    }
}
