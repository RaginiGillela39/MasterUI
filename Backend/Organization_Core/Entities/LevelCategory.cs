namespace TQMS_Admin_Domain.Entities
{
    public class LevelCategory:BaseEntity
    {
        [ForeignKey("Levels")]
        public Guid Level_Id { get; set; }
        public string? Category {  get; set; }
        public string? PriorityNumber {  get; set; }
        public string? Acronym {  get; set; }

    }
}
