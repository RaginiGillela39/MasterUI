namespace TQMS_Admin_Application.Validations
{
    public class StatusTypeValidation : IStatusTypeValidator
    {
        public void ValidateEntity(StatusType statusType)
        {
            Guard.IsNotNull(statusType, nameof(statusType));
            Guard.IsNotNullOrWhiteSpace(statusType.Name, nameof(statusType.Name));
        }
    }
}
