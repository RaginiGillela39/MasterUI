namespace TQMS_Admin_Domain.Entities
{
    public class LevelHierarchy:BaseEntity
    {
        [ForeignKey("Levels")]
        public Guid Level_Id { get; set; }
        public Guid Parent_Id {  get; set; }

    }
}
