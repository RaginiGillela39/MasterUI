namespace TQMS_Admin_Domain.Entities
{
    public class ExecutiveWindow:BaseEntity
    {
       
        [ForeignKey("Levels")]
        public Guid Level_Id {  get; set; }
        [ForeignKey("StatusType")]
        public Guid StatusType_Id {  get; set; }

    }
}
