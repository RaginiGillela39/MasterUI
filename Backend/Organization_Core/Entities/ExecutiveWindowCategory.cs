namespace TQMS_Admin_Domain.Entities
{
    public class ExecutiveWindowCategory:BaseEntity
    {
        [ForeignKey("LevelCategory")]
        public Guid LevelCategory_Id { get; set; }
        [ForeignKey("ExecutiveWindow")]
        public Guid ExecutiveWindow_Id {  get; set; }

    }
}
