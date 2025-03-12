namespace TQMS_Admin_Domain.Entities
{
    public class Levels:BaseEntity
    {
        public string? Acronym {  get; set; }
        [ForeignKey("Organization")]
        public Guid Organization_Id { get; set; }
        [ForeignKey("Department")]
        public Guid Department_Id {  get; set; }
        [ForeignKey("Branch")]
        public Guid Branch_Id { get; set; }
        public string? LatestTokenNumber {  get; set; }
    }
}
