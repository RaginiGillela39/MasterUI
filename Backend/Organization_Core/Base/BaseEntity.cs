namespace Organization_Domain.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy{ get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive {  get; set; } 
    }
}
