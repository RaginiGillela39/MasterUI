namespace TQMS_Organization_Application.Validations
{
    public class OrganizationTypeValidation : IOrganizationTypevalidator
    {
        public void ValidateEntity(OrganizationType organizationType)
        {
            Guard.IsNotNull(organizationType, nameof(organizationType));
            Guard.IsNotNullOrWhiteSpace(organizationType.Name, nameof(organizationType.Name));
        }
    }
}
